var map;
var latlng;
var geocoder;

$(document).ready(function () {
    $('#<%= btnSearch.ClientID %>').click(function (e) {
        map = new google.maps.Map(document.getElementById('map'), {
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            zoom: 6
        });

        var latlng = new google.maps.LatLng(38.5, -78.9);
        map.setCenter(latlng);
    });

    //var geocoder = new google.maps.Geocoder();
    //for (var i = 0; i < cities.length; i++) {
    //    var address = cities[i] + "," + stateProvince;
    //    geocoder.geocode({ 'address': address }, onGeocodeResponse);
    //}
});

function onGeocodeResponse(response, status) {
    // the Geocode service has sent its response. We can now use it for the map
    if (status === google.maps.GeocoderStatus.OK) {
        // center the map at the location returned from the geocoding service
        map.setCenter(response[0].geometry.location);

        // set up the store names for the city to display in marker tool tip
        var storesInCity = "\n";
        for (var i = 0; i < dataTable3.getNumberOfRows(); i++) {
            if (response[0].address_components[0].long_name === dataTable3.getValue(i, 1))
                storesInCity += "\n" + dataTable3.getValue(i, 0);
        }

        // put a marker at the specified location
        var marker = new google.maps.Marker({
            map: map,
            icon: {
                path: google.maps.SymbolPath.CIRCLE,
                scale: 8.5,
                fillColor: "#F00",
                fillOpacity: 0.4,
                strokeWeight: 0.4
            },
            position: response[0].geometry.location,
        });
    }
    // else alert("error in geocoding: " + status);// typically this will mean exceed query limit
}







