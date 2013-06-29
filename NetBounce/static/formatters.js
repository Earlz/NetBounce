formatters = [];
formatters.push({name: 'None', func: function(data, unescaped){return data;}});
formatters.push({name: 'XML formatter', func: xmlFormatter});
formatters.push({name: 'JSON formatter', func: jsonFormatter});

function xmlFormatter(data, unescaped){
	src=vkbeautify.xml(unescaped).escape();
	var expr = new RegExp("\n","g")
    data=src.replace(expr,'<br />');
	return '<pre onload="prettyPrint()" class="prettyprint">'+data+'</pre>';
}
function jsonFormatter(data, unescaped){
	src=vkbeautify.json(unescaped).escape();
	var expr = new RegExp("\n","g")
    data=src.replace(expr,'<br />');
	return '<pre onload="prettyPrint()" class="prettyprint">'+data+'</pre>';
}
