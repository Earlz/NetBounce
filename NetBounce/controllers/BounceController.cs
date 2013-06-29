using System;
using Earlz.LucidMVC;
using System.Collections.Concurrent;
using System.Collections.Generic;
using Earlz.LucidMVC.ViewEngine;
using System.Threading;
using System.Text;
using Newtonsoft.Json;
using Earlz.NetBounce.Views;
using System.Web;

namespace Earlz.NetBounce
{
	public class BounceController : HttpController 
	{
		public class Request
		{
			[JsonProperty("data")]
			public string Data;
			[JsonProperty("method")]
			public string Method;
			[JsonProperty("headers")]
			public string Headers;
		}
		public class RequestData
		{
			public List<Request> Requests;
			public DateTime LastPosted;
			public bool Received=false;
			public int Size=0;
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
							RequestData trash;
							State.TryRemove(key, out trash);
						}
					}
				}
			}

		}
		public BounceController(RequestContext c) : base(c)
		{
		}
		const int SizeLimit=1024*128;
		const int DataLimit=1024*512;
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
					data.Requests=new List<Request>();
					data.LastPosted=DateTime.Now;
					if(!State.TryAdd(key, data))
					{
						throw new ApplicationException("concurrency error. This shouldn't have happened :( ");
					}
				}
			}
			lock(data)
			{
				if(data.Size>DataLimit)
				{
					throw new ApplicationException("you've exceeded your data limit");
				}
				data.LastPosted=DateTime.Now;
				string d=Context.BarePost;
				if(d.Length>SizeLimit)
				{
					throw new ApplicationException("Please try to restrain your content to 128K or less");
				}
				var req=new Request();
				req.Data=d;
				StringBuilder sb=new StringBuilder();
				foreach(var name in HttpContext.Current.Request.Headers.AllKeys) //LucidMVC doesn't expose this(probably because it's never needed)
				{
					foreach(var val in HttpContext.Current.Request.Headers.GetValues(name))
					{
						sb.Append(name);
						sb.Append(": ");
						sb.AppendLine(val);
					}
				}
				req.Headers=sb.ToString();
				req.Method=Context.HttpMethod;
				data.Requests.Add(req);
				data.Size+=d.Length+sb.Length;
			}
			return new WrapperView("received");
		}
		public ILucidView Dequeue(string key)
		{
			Context.ContentType="application/json";
			RequestData data;
			if(!State.TryGetValue(key, out data))
			{
				return new WrapperView("[]");
			}
			List<Request> requests;
			lock(data)
			{
				if(data.Requests.Count==0)
				{
					return new WrapperView("[]");
				}
				requests=data.Requests;
				data.Requests=new List<Request>();
				data.Size=0;
			}
			string json=JsonConvert.SerializeObject(requests);
			return new WrapperView(json);
		}
		public ILucidView View(string key)
		{
			return new BounceView{key=key};
		}
	}
}

