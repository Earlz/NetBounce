﻿


/*Generated by the BSD Licensed LucidMVC ViewGenerator T4 file*/
using System.Text;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System;
using Earlz.LucidMVC.ViewEngine;
using Earlz.LucidMVC;

        //custom using statements for your views go here:
        
    
/*File: BounceView */
namespace Earlz.NetBounce.Views{
        ///<summary>
        ///
        ///</summary>
    public class BounceView: Earlz.LucidMVC.ViewEngine.LucidViewBase
    {
                ///<summary>
        ///
        ///</summary>
            public string key{
        get;
        set;
        }

                ///<summary>
        ///This is the layout of the given view (master page)
        ///</summary>
            public LayoutView Layout{
        get;
        set;
        }

                ///<summary>
        ///The "Flash" notification text(passes through to the layout
        ///</summary>
            public override string Flash{
        get{return Layout.Flash;}
        set{Layout.Flash=value;}
        }

         void BuildOutput()
        {
__Write(@"");
__Write(@"");
__Write(@"
");
__Write(@"
");
__Write(@"
");
__Write(@"
");
__Write(@"
");
__Write(@"
<div>
<h1>Bounce of '");
{
                object __v;
                

                    __v=HttpUtility.HtmlEncode(key);
                
__OutputVariable(__v);
}
__Write(@"'</h1>
<p>
 You're viewing a bounce! Data here will refresh every 15 seconds. If you're sending a particular kind of data, you can use a Formatter to view the data more easily. 
</p>
<p>
To post data to this bounce, use <a href=""/bounce/post/");
{
                object __v;
                

                    __v=HttpUtility.UrlEncode(key);
                
__OutputVariable(__v);
}
__Write(@""">This URL</a>.
</p>

</div>
<div>formatter: 
<span id=""formatter_container"">
</span>
</div>
<p>data will show up below</p>
<div id=""output""></div>
<script type=""text/javascript"">
var currentFormatter=0;
setTimeout(function(){
	var s = $('<select id=""formatselect""/>');

	for(var i=0;i<formatters.length;i++) {
		item=formatters[i];
	    $('<option />', {value: i, text: item.name}).appendTo(s);
	}
	s.appendTo('#formatter_container'); // or wherever it should be
	$(""#formatselect"").change(function(){
	    currentFormatter=parseInt($(this).children("":selected"").val());
	    return true;
	});
},0);
String.prototype.escape = function() {
    var tagsToReplace = {
        '&': '&amp;',
        '<': '&lt;',
        '>': '&gt;'
    };
    return this.replace(/[&<>]/g, function(tag) {
        return tagsToReplace[tag] || tag;
    });
};

var refresh=function(){
	$.getJSON('/bounce/dequeue/");
{
                object __v;
                

                    __v=key;
                
__OutputVariable(__v);
}
__Write(@"', function(data) {
	  for(var i=0;i<data.length;i++)
	  {
	    $('#output').append('<div class=""data"">' + formatters[currentFormatter].func(data[i]) + '</div>');
	  }
	 
	  setTimeout(refresh, 15*1000);
	});
};
refresh();
</script>
");

        }
         void __Init()
        {
Layout=new LayoutView(); Layout.Content=this;
        }
        public  BounceView()
        {
__Init();
        }
        protected virtual void __Write(string s)
        {
if(__Writer!=null){ __Writer.Write(s); }
        }
        protected virtual void __Write(ILucidView v)
        {
v.RenderView(__Writer);
        }
        public override void RenderView(System.IO.TextWriter outputStream)
        {
Layout.Title="Viewing bounce of '"+HttpUtility.HtmlEncode(key)+"'"; Layout.ExtraScripts=@"<script src=""https://google-code-prettify.googlecode.com/svn/loader/run_prettify.js""></script>"; Layout.ExtraScripts+=@"<script src=""/static/formatters.js""></script>"; Layout.ExtraScripts+=@"<script src=""/static/vkbeautify.js""></script>"; 
	__Writer=outputStream;
	if(Layout==null){
        BuildOutput();
		return;
	}
	if(__InLayout){
        //If we get here, then the layout is currently trying to render itself(and we are being rendered as a partial/sub view)
        __InLayout=false;
        BuildOutput();
	}else{
        //otherwise, we are here and someone called RenderView on us(and we have a layout to render first)
        __InLayout=true;
        Layout.RenderView(__Writer); 
	}
//This should recurse no more than 2 times
//Basically, this will go to hell if there is ever more than 1 partial view with a Layout set.
        }
        protected void __OutputVariable(object v)
        {

            {
                if(v!=null)
                {
                    var e=v as System.Collections.IEnumerable;
                    if (e!=null)
                    {
                        foreach(var item in e){ 
                            var view=item as Earlz.LucidMVC.ViewEngine.ILucidView;
                            if(view!=null){
                                __Write(view);
                            }else{
                                __Write(item.ToString());
                            }
                        }
                    }else{
                        var view=v as Earlz.LucidMVC.ViewEngine.ILucidView;
                        if(view!=null){
                            __Write(view);
                        }else{
                            __Write(v.ToString());
                        }
                    }
                }        
            }
        }
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __InLayout=false;
                ///<summary>
        ///For internal use only!
        ///</summary>
         TextWriter __Writer;
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __RenderDirectly=true;

    }
}

/*File: Landing */
namespace Earlz.NetBounce.Views{
        ///<summary>
        ///
        ///</summary>
    public class Landing: Earlz.LucidMVC.ViewEngine.LucidViewBase
    {
                ///<summary>
        ///
        ///</summary>
            public string key{
        get;
        set;
        }

                ///<summary>
        ///This is the layout of the given view (master page)
        ///</summary>
            public LayoutView Layout{
        get;
        set;
        }

                ///<summary>
        ///The "Flash" notification text(passes through to the layout
        ///</summary>
            public override string Flash{
        get{return Layout.Flash;}
        set{Layout.Flash=value;}
        }

         void BuildOutput()
        {
__Write(@"");
__Write(@"");
__Write(@"
");
__Write(@"
");
__Write(@"
	<div id=""landing-content"">
		<h1> NetBounce</h1>
		<p>
			This is a web service which allows you to bounce HTTP requests from a local (or remote) service to your browser for easy inspection
		</p>
		<p>
			Your randomly generated key is <a href=""/bounce/view/");
{
                object __v;
                

                    __v=key;
                
__OutputVariable(__v);
}
__Write(@""">");
{
                object __v;
                

                    __v=key;
                
__OutputVariable(__v);
}
__Write(@"</a>
		</p>
		<p>
			To bounce data into your view page, make a request to <a href=""/bounce/post/");
{
                object __v;
                

                    __v=key;
                
__OutputVariable(__v);
}
__Write(@""">/bounce/post/");
{
                object __v;
                

                    __v=key;
                
__OutputVariable(__v);
}
__Write(@"</a>
		</p>
		<p>
			This can accept POST, PUT, GET, and DELETE methods. It will display the HTTP headers, HTTP method, and any data sent with the request.
		</p>
		
		<p>
			You can also use your own custom key by just going to <a href=""/bounce/view/foobar"">/bounce/view/foobar</a> (replace foobar in the URL with your desired key). 
		</p>
		<p>
			The view page will refresh itself every 15 seconds and pull down any data for your key on my server. 
		</p>
		<p>
			This web service is available via <a href=""https://netbounce.earlz.net"">HTTPS</a>. (not a self-signed certificate)
			This can be handy for testing of clients which do not permit invalid certificates when sending to an HTTPS server.
		</p>
		<h1>Warnings</h1>
		<p>
			<b>Do not send any secret data here</b>. I can't guarantee that no one else is listening in. Although I don't make the list of currently active keys public,
			If someone were to guess your key, they would be able to get all data you send. I can not guarantee any privacy on the data you send.
		</p>
		<p>
			This isn't Dropbox. Your data will expire after 1 minute on the server. It may expire sooner depending on how much data you are sending. The View page checks for new data every 15 seconds
		</p>
		<p>
			Do not send requests larger than 128Kb. I will discard them.
		</p>
		<p>
			Yes, I know the HTTP error codes are quite incorrect right now. The MVC framework behind this, <a href=""https://bitbucket.org/earlz/lucidmvc"">LucidMVC</a>, is still pretty much pre-alpha. I'm surprised it works at all sometimes(although it is fast!)
		</p>
		<p>
			Please don't ruin the party by abusing this service. I have huge bandwidth limits and this puts very little load on my server. 
			If you make it to where I have to worry about the load, then I'll just take it offline. It would not be difficult to DDoS this service, but please don't
		</p>
		<h1>Source Code</h1>
		<p>
			The source code for this is freely available under permissive 2-clause BSD license at <a href=""https://github.com/Earlz/NetBounce"">Github</a>. 
			If you have an idea for a new or better request formatter, feel free to send a push request :) 
		</p>
	</div>
");

        }
         void __Init()
        {
Layout=new LayoutView(); Layout.Content=this;
        }
        public  Landing()
        {
__Init();
        }
        protected virtual void __Write(string s)
        {
if(__Writer!=null){ __Writer.Write(s); }
        }
        protected virtual void __Write(ILucidView v)
        {
v.RenderView(__Writer);
        }
        public override void RenderView(System.IO.TextWriter outputStream)
        {
Layout.Title="NetBounce -- Like Moon Bouncing, but with HTTP requests"; 
	__Writer=outputStream;
	if(Layout==null){
        BuildOutput();
		return;
	}
	if(__InLayout){
        //If we get here, then the layout is currently trying to render itself(and we are being rendered as a partial/sub view)
        __InLayout=false;
        BuildOutput();
	}else{
        //otherwise, we are here and someone called RenderView on us(and we have a layout to render first)
        __InLayout=true;
        Layout.RenderView(__Writer); 
	}
//This should recurse no more than 2 times
//Basically, this will go to hell if there is ever more than 1 partial view with a Layout set.
        }
        protected void __OutputVariable(object v)
        {

            {
                if(v!=null)
                {
                    var e=v as System.Collections.IEnumerable;
                    if (e!=null)
                    {
                        foreach(var item in e){ 
                            var view=item as Earlz.LucidMVC.ViewEngine.ILucidView;
                            if(view!=null){
                                __Write(view);
                            }else{
                                __Write(item.ToString());
                            }
                        }
                    }else{
                        var view=v as Earlz.LucidMVC.ViewEngine.ILucidView;
                        if(view!=null){
                            __Write(view);
                        }else{
                            __Write(v.ToString());
                        }
                    }
                }        
            }
        }
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __InLayout=false;
                ///<summary>
        ///For internal use only!
        ///</summary>
         TextWriter __Writer;
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __RenderDirectly=true;

    }
}

/*File: LayoutView */
namespace Earlz.NetBounce.Views{
        ///<summary>
        ///
        ///</summary>
    public class LayoutView: Earlz.LucidMVC.ViewEngine.LucidViewBase
    {
                ///<summary>
        ///
        ///</summary>
            public string Title{
        get;
        set;
        }

                ///<summary>
        ///
        ///</summary>
            public ILucidView Content{
        get;
        set;
        }

                ///<summary>
        ///
        ///</summary>
            public string ExtraScripts{
        get;
        set;
        }

                ///<summary>
        ///This is the layout of the given view (master page)
        ///</summary>
            public ILucidView Layout{
        get;
        set;
        }

                ///<summary>
        ///The "Flash" notification text(passes through to the layout
        ///</summary>
            public override string Flash{
        get{return Layout.Flash;}
        set{Layout.Flash=value;}
        }

         void BuildOutput()
        {
__Write(@"<!DOCTYPE HTML5>
");
__Write(@"
<html>
	<head>
		<title>");
{
                object __v;
                

                    __v=Title;
                
__OutputVariable(__v);
}
__Write(@"</title>
		<link rel=""stylesheet"" type=""text/css"" media=""all"" href=""/static/style.css"" />
		<script src=""//ajax.googleapis.com/ajax/libs/jquery/1.10.1/jquery.min.js""></script>
		");
{
                object __v;
                

                    __v=ExtraScripts;
                
__OutputVariable(__v);
}
__Write(@"
		</head>
	<body>
<script>
  (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
  (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
  m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
  })(window,document,'script','//www.google-analytics.com/analytics.js','ga');

  ga('create', 'UA-41190820-2', 'netbounce.earlz.net');
  ga('send', 'pageview');

</script>
	<div id=""content"">
		");
{
                object __v;
                

                    __v=Content;
                
__OutputVariable(__v);
}
__Write(@"
	</div>
	</body>
</html>");

        }
         void __Init()
        {

        }
        public  LayoutView()
        {
__Init();
        }
        protected virtual void __Write(string s)
        {
if(__Writer!=null){ __Writer.Write(s); }
        }
        protected virtual void __Write(ILucidView v)
        {
v.RenderView(__Writer);
        }
        public override void RenderView(System.IO.TextWriter outputStream)
        {

	__Writer=outputStream;
	if(Layout==null){
        BuildOutput();
		return;
	}
	if(__InLayout){
        //If we get here, then the layout is currently trying to render itself(and we are being rendered as a partial/sub view)
        __InLayout=false;
        BuildOutput();
	}else{
        //otherwise, we are here and someone called RenderView on us(and we have a layout to render first)
        __InLayout=true;
        Layout.RenderView(__Writer); 
	}
//This should recurse no more than 2 times
//Basically, this will go to hell if there is ever more than 1 partial view with a Layout set.
        }
        protected void __OutputVariable(object v)
        {

            {
                if(v!=null)
                {
                    var e=v as System.Collections.IEnumerable;
                    if (e!=null)
                    {
                        foreach(var item in e){ 
                            var view=item as Earlz.LucidMVC.ViewEngine.ILucidView;
                            if(view!=null){
                                __Write(view);
                            }else{
                                __Write(item.ToString());
                            }
                        }
                    }else{
                        var view=v as Earlz.LucidMVC.ViewEngine.ILucidView;
                        if(view!=null){
                            __Write(view);
                        }else{
                            __Write(v.ToString());
                        }
                    }
                }        
            }
        }
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __InLayout=false;
                ///<summary>
        ///For internal use only!
        ///</summary>
         TextWriter __Writer;
                ///<summary>
        ///For internal use only!
        ///</summary>
         bool __RenderDirectly=true;

    }
}


//