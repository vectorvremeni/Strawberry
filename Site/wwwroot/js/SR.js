"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/SR").build();

var ReconnectTimeout = 1;
var ReconnectTimeoutIncrement = 1;
var MaxReconnectInterval = 600;

connection.onclose(function () {
	start();
});

connection.on("UpdateCode", function ()
{
	window.location.reload();
});

function start() {
	connection.start().then(function () {
		ReconnectTimeout = 1;
		setcounter();
	}).catch(function (err) {
		var timeout = ReconnectTimeout * 1000;
		setTimeout(start, timeout);
		if (ReconnectTimeout < MaxReconnectInterval) {
			ReconnectTimeout += ReconnectTimeoutIncrement;
		}
		setcounter();

		//return console.error(err.toString());
	});
}

start();

function setcounter() {
	//document.getElementById("cntr").innerHTML = ReconnectTimeout;
}