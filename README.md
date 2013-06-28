# NetBounce

This is a utility so that you can easily test HTTP POST requests without having to run a server or use something like Fiddler. 

# Live Version

You can see a live version of this in action at http://netbounce.earlz.net ... assuming it doesn't choke my server out too much

# Plans

Get it working!

Eventually, there will be formatters and I'll gladly take push requests for additional formatters

# How it works

Basically, the server holds an in-memory queue tied to the ID (or `key`) of your choosing. You can push to this queue by using `/bounce/put/foobar`} where `foobar` is your key. 

# Limitations

Currently, it only accepts POST requests and can only reveal the POST data sent to it. No headers or extra information
