formatters = [];
formatters.push({name: 'None', func: function(data, unescaped){return data;}});
formatters.push({name: 'XML formatter', func: xmlFormatter});

function xmlFormatter(data, unescaped){
	src=vkbeautify.xml(unescaped).escape();
	var expr = new RegExp("\n","g")
    data=src.replace(expr,'<br />');
	return '<pre onload="prettyPrint()" class="prettyprint" id="xml">'+data+'</pre>';
}
function jsonFormatter(data){
	return '<pre onload="prettyPrint()" class="prettyprint" id="json">'+data+'</pre>';
}
