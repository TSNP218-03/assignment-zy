//Changelog: 27 June 2020
// [] Issue#7, redis, express route
// [] Added redis for DB
// [] npm install redis
// [] Express route for API
// [] Route '/' for homepage, include index.html
// [] Route '/data' for sending JSON to dashboard


//Changelog: 25 June 2020 11PM
//#Issue2 : Using JSON 
//Removed some unused code (previously commmented in branch issue#4)

//Changelog:
//#Issue4 : Migrate to socket.io
//npm install express
//npm install socket.io



// init
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
var redis = require('redis');			// redis init
var client = redis.createClient();
const path = require('path'); //require path module for express route

// error handling
client.on("error", function (err) {
	console.log("Err: " + err);
});

//server listening
var port = 55555;
http.listen(port, function () {
	console.log("listening at *:" + port);
});

//Global var
var n2;
var n3;

//Home Route
app.get('/', (request, response) => {
	//response.send("this is home location");
	response.sendFile(path.join(__dirname + '/index.html'));
});

//while connected to client,
io.on('connection', function (socket) {
	console.log('debug: Connected! ID: ' + socket.id);

	//get data from sensorNode (.vb)
	socket.on('data', function (n) {
		

		n2 = JSON.stringify(n)			//Convert the object into a string
		
		client.set('redis', n2);		//Save JSON in Redis for cache purpose  

		client.get('redis', function (err, reply) {		//get the JSON from Redis	
			console.log("<redis reply>:" + reply);
			n3 = reply

			
		});
	});



	//A Simple API Route, send JSON to realtime dashboard (.html)
	app.get('/data', (request, response) => {
		response.send(n3);		//send JSON from Redis over API route
		
	});

	//client disconnection 
	socket.on('disconnect', function () {
		console.log("debug: Disconnected! ID: " + socket.id);
	});

	// exit signal call
	process.on('SIGINT', function () {
		console.log("seed program exits!");
		process.exit();
	});

});//closing of io.on ('connection')