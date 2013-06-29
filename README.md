# NetBounce

This is a utility so that you can easily test HTTP POST requests without having to run a server or use something like Fiddler. 

# Live Version

You can see a live version of this in action at http://netbounce.earlz.net

# SSL Live Version

You can also use the SSL live version of this at https://netbounce.earlz.net

# Formatters

You can add a new formatter by changing `formatters.js`. I currently have Raw, JSON, and XML implemented. If you want to implement a new one all you have to do is add on to formatters.js. 

Here is an example:

	formatters.push({name: 'My Formatter', func: myFormatter}); /*fill out your formatter name and the function */

	function myFormatter(data, unescaped){
		return '<pre> I'm magical! '+data+'</pre>';
	}

`data` is the escaped and safe version, `unescaped` is the unsafe unescaped data. `unescaped` is particularly useful when dealing with XML formats. 

# How it works

Basically, the server holds an in-memory queue tied to the ID (or `key`) of your choosing. You can push to this queue by using `/bounce/put/foobar`} where `foobar` is your key. 

# Limitations

Currently, it only accepts POST requests and can only reveal the POST data sent to it. No headers or extra information
