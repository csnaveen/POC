var serviceURL = "http://localhost:6464/MobileDataService/Service1.svc/Views";

$('#viewListPage').bind('pageinit', function(event) {
	getViewList();
});

$.ajaxError( function(event, XMLHttpRequest, ajaxOptions, thrownError){
	alert( thrownError );
	 });

function getViewList() {
	$.getJSON(serviceURL, function(data) {
		$('#viewList li').remove();
		$.each(data, function(index, view) {
			$('#viewList').append('<li><a href="DeviceList.html?id=' + view.ID + '">' +
					'<img src="icons/View.png"/>' + '<h4>' + view.name + '</h4></a></li>');
		});
		$('#viewList').listview('refresh');
	    });	
}