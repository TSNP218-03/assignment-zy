var net = require("net");

var server = net.createServer();

server.on("connection", function (socket) {

    var remoteAddress = socket.remoteAddress + ":" + socket.remotePort;
    console.log("new client connection is made %s", remoteAddress);
    var oriName=null
   
    //receive data
    socket.on("data", function (d) {
        //if the buffer is number
        if (parseInt(d) == 37 || parseInt(d) == 38 || parseInt(d) == 39 || parseInt(d) == 40) {

            console.log("Temperature is: %s", d);

        }

        else {
            //if the buffer is name
            var newName = d.toString()

            //check when the name is diffeent print one more time 
            if (oriName != newName) {
                console.log("Name is :%s", newName)
            }
            
            oriName=newName
        }
           
    });


    socket.once("close", function () {
        console.log("connection from %s closed", remoteAddress);
        remoteAddress=null
    });

    socket.on("error", function (err) {
        console.log("connection %s error: %s", remoteAddress,err.message);

    });

});

server.listen(9000, function () {
    console.log("server listening to %j", server.address());
});