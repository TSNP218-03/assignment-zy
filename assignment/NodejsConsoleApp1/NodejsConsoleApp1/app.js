
//Changelog:
//#Issue4 : Migrate to socket.io
//npm install express
//npm install socket.io


//var net = require("net");

//var server = net.createServer();

var app = require('express')();
var http = require('http').Server(app);
var io = require('socket.io')(http);

//server.on("connection", function (socket) {

   // var remoteAddress = socket.remoteAddress + ":" + socket.remotePort;
    //console.log("new client connection is made %s", remoteAddress);
    //var oriName=null


var port = 55555;
http.listen(port, function () {
    console.log("listening at *:" + port);
});

io.on('connection', function (socket) {
    
   
    //receive data
    socket.on("data", function (d) {
        //if the buffer is number
        //if (parseInt(d) == 37 || parseInt(d) == 38 || parseInt(d) == 39 || parseInt(d) == 40) {

        //    console.log("Temperature is: %s", d);

        //}

        //else {
        //    //if the buffer is name
        //    var newName = d.toString()

        //    //check when the name is diffeent print one more time 
        //    if (oriName != newName) {
        //        console.log("Name is :%s", newName)
        //    }
            
        //    oriName=newName
        //}

        console.log(d)
           
    });


    socket.on("disconnect", function () {
        console.log("connection from %s closed", socket.id);
        //remoteAddress=null
    });

    socket.on("error", function (err) {
        console.log("connection %s error: %s", socket.id,err.message);
    });

});

//server.listen(55555, function () {
//    console.log("server listening to %j", server.address());
//});