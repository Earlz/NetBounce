formatters = [];
formatters.push({name: 'None', hash: "none", func: rawFormatter});
formatters.push({name: 'XML formatter', hash: "xml", func: xmlFormatter});
formatters.push({name: 'JSON formatter', hash: "json", func: jsonFormatter});


function rawFormatter(req){
	var expr = new RegExp("\n","g")
    data=req.data.replace(expr,'<br />');
    m='<div>Method: '+req.method.escape()+'</div>';
    h='<pre id="headers">'+req.headers.escape()+'</pre>';
    
    return m+h+'<p>'+data.escape()+'</p>';
}

function xmlFormatter(req){
	src=vkbeautify.xml(req.data).escape();
	var expr = new RegExp("\n","g")
    data=src.replace(expr,'<br />');
    m='<div>Method: '+req.method.escape()+'</div>';
    h='<pre id="headers">'+req.headers.escape()+'</pre>';
	return m+h+'<pre onload="prettyPrint()" class="prettyprint">'+data+'</pre>';
}
function jsonFormatter(req){
	src=vkbeautify.json(req.data).escape();
	var expr = new RegExp("\n","g")
    data=src.replace(expr,'<br />');
    m='<div>Method: '+req.method.escape()+'</div>';
    h='<pre id="headers">'+req.headers.escape()+'</pre>';
	return m+h+'<pre onload="prettyPrint()" class="prettyprint">'+data+'</pre>';
}
