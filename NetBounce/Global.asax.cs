using Earlz.LucidMVC;

namespace Earlz.NetBounce
{
	using System;
	using System.Collections;
	using System.ComponentModel;
	using System.Web;
	using System.Web.SessionState;

	public class Global : System.Web.HttpApplication
	{
		Router router;
		protected void Application_Start(Object sender, EventArgs e)
		{
			router=new Router();

			var landing=router.Controller((c) => new LandingController(c));
			landing.Handles("/").With(x=>x.Landing());
			var bounce=router.Controller(c => new BounceController(c));
			bounce.Handles("/bounce/post/{key}").With(x=>x.Post(x.RouteParams["key"])).Allows("POST");
			bounce.Handles("/bounce/dequeue/{key}").With(x=>x.Dequeue(x.RouteParams["key"]));
			bounce.Handles("/bounce/view/{key}").With(x=>x.View(x.RouteParams["key"]));
		}

		protected void Session_Start(Object sender, EventArgs e)
		{
		}

		protected void Application_BeginRequest(Object sender, EventArgs e)
		{
			if(router.Execute(new AspNetServerContext()))
			{
				CompleteRequest();
			}
		}

		protected void Application_EndRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_AuthenticateRequest(Object sender, EventArgs e)
		{
		}

		protected void Application_Error(Object sender, EventArgs e)
		{
		}

		protected void Session_End(Object sender, EventArgs e)
		{
		}

		protected void Application_End(Object sender, EventArgs e)
		{
		}
	}
}

