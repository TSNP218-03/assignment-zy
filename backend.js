// init
var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);
// redis init
var redis = require('redis');
var client = redis.createClient();
// error handling
client.on("error", function(err) {
	console.log("Err: " + err);
});

// server listening
var port = 55555;
http.listen(port, function() {
	console.log("listening at *:" + port);
});

// first time generate and store in Redis
var seed = Math.random() * 99;
client.set('seed', seed);
console.log("<seed>:" + seed);

// while connected to client,
io.on('connection', function(socket) {
	
  //send the seed  to user 
	socket.emit('res-seed', seed);
  
	// exit signal call
	process.on('SIGINT', function() {
		console.log("seed program exits!");
		process.exit();
	});

});//closing of io.on ('connection')
