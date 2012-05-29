$('#deviceListPage').live('pageshow', function(event) {
	var id = getUrlVars()["id"];
	$.getJSON(serviceURL + '/' +id, displayDevices);
});

function displayDevices(data) {
	$('#deviceList li').remove();
	var id = getUrlVars()["id"];
	$.each(data, function(index, device) {
		$('#deviceList').append('<li><a href="DeviceDetails.html?viewid=' + id + '&deviceid=' + device.ID + '">' +
				'<img src="icons/Server.png"/>' + '<h4>' + device.name + '</h4></a></li>');
	});
	$('#deviceList').listview('refresh');
}
	function getUrlVars() {
	    var vars = [], hash;
	    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
	    for(var i = 0; i < hashes.length; i++)
	    {
	        hash = hashes[i].split('=');
	        vars.push(hash[0]);
	        vars[hash[0]] = hash[1];
	    }
	    return vars;
	}
