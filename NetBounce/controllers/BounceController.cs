using System;
using Earlz.LucidMVC;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Earlz.LucidMVC.ViewEngine;
using System.Threading;
using System.Text;
using Newtonsoft.Json;

namespace Earlz.NetBounce
{
	public class BounceController : HttpController 
	{
		public class RequestData
		{
			public List<string> Data;
			public DateTime LastPosted;
			public bool Received=false;
		}
		const int DataTimeout=60*1000;
		static ConcurrentDictionary<string, RequestData> State;
		static BounceController()
		{
			State=new ConcurrentDictionary<string, RequestData>();
			var t=new Thread(() => 
			{
				while(true)
				{
					CheckState();
					Thread.Sleep(30*1000);
				}
			});
			t.Start();
		}
		static void CheckState()
		{
			foreach(var key in State.Keys)
			{
				RequestData data=null;
				if(State.TryGetValue(key, out data))
				{
					lock(data)
					{
						if((DateTime.Now - data.LastPosted).TotalMilliseconds > DataTimeout)
						{
							State.TryRemove(key, out data);
						}
					}
				}
			}

		}
		public BounceController(RequestContext c) : base(c)
		{
		}
		public ILucidView Post(string key)
		{
			RequestData data;
			bool result;
			lock(State)
			{
				result=State.TryGetValue(key, out data);
				if(result==false)
				{
					data=new RequestData();
					data.Data=new List<string>();
					data.LastPosted=DateTime.Now;
					if(!State.TryAdd(key, data))
					{
						throw new ApplicationException("concurrency error. This shouldn't have happened :( ");
					}
				}
			}
			lock(data)
			{
				data.LastPosted=DateTime.Now;
				data.Data.Add(Context.BarePost);
			}
			return new WrapperView("received");
		}
		public ILucidView Dequeue(string key)
		{
			RequestData data;
			if(!State.TryGetValue(key, out data))
			{
				return new WrapperView("[]");
			}
			List<string> requests;
			lock(data)
			{
				if(data.Data.Count==0)
				{
					return new WrapperView("[]");
				}
				requests=data.Data;
				data.Data=new List<string>();
			}
			string json=JsonConvert.SerializeObject(requests);
			return new WrapperView(json);
		}
		public ILucidView View()
		{
			return null;
		}
	}
}

