formatters = [];
formatters.push({name: 'None', func: function(data){return data;}});
formatters.push({name: 'XML formatter', func: xmlFormatter});

function xmlFormatter(data){
	return 'xml!' + data;
}
