using System;
using Earlz.LucidMVC;
using Earlz.LucidMVC.MyViews;

namespace Earlz.NetBounce
{
	public class LandingController : HttpController 
	{
		public LandingController(RequestContext c) : base(c)
		{
		}
		public Landing Landing()
		{
			return new Landing();
		}

	}
}

