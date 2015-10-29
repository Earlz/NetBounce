# NetBounce

This is a utility so that you can easily test HTTP POST requests without having to run a server or use something like Fiddler. 

It supports viewing the headers and HTTP method of the request as well as any data sent with it, such as for POST requests. 

# Live Version

You can see a live version of this in action at http://netbounce.earlz.net

# Formatters

You can add a new formatter by changing `formatters.js`. I currently have Raw, JSON, and XML implemented. If you want to implement a new one all you have to do is add on to formatters.js. 

Here is an example:

	formatters.push({name: 'My Formatter', func: myFormatter}); /*fill out your formatter name and the function */

	function myFormatter(req){
		return '<pre> I'm magical! '+req.data.escape()+'</pre>';
	}

The `req` parameter has three properties at the moment.

* `headers` a string with all of the HTTP headers in it (separated by new line). 
* `method` a string with the HTTP method used, such as GET
* `data` the data sent with the request, such as the FORM data with POST requests

# How it works

Basically, the server holds an in-memory queue tied to the ID (or `key`) of your choosing. You can push to this queue by using `/bounce/put/foobar`} where `foobar` is your key. 

# Compiling

There is a prebuild event to automatically regenerate the T4 view templates. If using Visual Studio, you can remove this
Just make sure to run the T4 template `ViewGenerator.tt` when changing the HTML views. Under Linux, I expect for there to
be the file `/usr/local/bin/mono-t4`. You must add this in yourself. The contents for most Linux distros is this:

    #!/bin/sh
    mono /usr/lib/monodevelop/AddIns/MonoDevelop.TextTemplating/TextTransform.exe -o $1 $2
    
Make sure to make it executable. 
 
