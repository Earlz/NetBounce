# NetBounce

This is a utility so that you can easily test HTTP POST requests without having to run a server or use something like Fiddler. 

It supports viewing the headers and HTTP method of the request as well as any data sent with it, such as for POST requests. 

# Live Version

You can see a live version of this in action at http://netbounce.earlz.net

You can also use the SSL live version of this at https://netbounce.earlz.net

The SSL live version has a valid SSL certificate and is especially useful for testing of secure clients which can't handle SSL errors

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
