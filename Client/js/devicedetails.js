$('#deviceDetailsPage').live('pageshow', function(event) {
	var viewId = getUrlVars()["viewid"];
	var deviceId = getUrlVars()["deviceid"];
	$.getJSON(serviceURL + '/' +viewId+ '/' +deviceId, displayDetails);
});

function displayDetails(data) {
	$('#deviceData li').remove();
	$.each(data, function(index, device){
		getList(device,$('#deviceData'));	
	});	
	$('#deviceData').listview('refresh');
	
}


function getList(item, $list) {
    if (item) {
        if (item.name) {
            $list.append('<li>' +item.name);
        }
        if (item.children && item.children.length) {
            var $sublist = $('<ul/>');
            $.each(item.children, function (key, value) {	
                getList(value, $sublist);
            });
            $list.append($sublist);
        }
    }
}


function displayDeviceDetails(data) {
	$('#deviceData li').remove();
	$.each(data, function(index, device) {
		$('#deviceData').append('<li><a>' +
				'<img src="icons/object.png"/>' + '<h4>' + device.name + '</h4></a>');
		if( device.children.length != 0 )
			recursivedisplay(device);
		$('#deviceData').append('</li>');
	});
	$('#deviceData').listview('refresh');
}

function recursivedisplay(device)
{
	$('#deviceData').append('<ul data-role="listview">');
	$.each(device, function(index, devobject){ 
	$('#deviceData').append('<li><a>' +
			'<img src="icons/object.png"/>' + '<h4>' + devobject.name + '</h4></a>');
	if( devobject.children.length != 0 )
		recursivedisplay( devobject.children);
	$('#deviceData').append('/<li>');	
	});
	$('#deviceData').append('/<ul>');
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
