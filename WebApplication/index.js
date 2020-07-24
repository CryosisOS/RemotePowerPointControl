var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);


observers = [];
observers.push(new (require('./event_observer'))());

require('./observer_api')(app, observers);

app.get('/', (req, res) => { //TODO: Login feature
    res.sendFile(__dirname + '/index.html');
});

io.on('connection', (socket) => {
    console.log("User Connected");
    clients.push(socket);
    
    

    socket.on('disconnect', () => {
        console.log("User Disconnected")
        var index = clients.indexOf(socket);
        if (index > -1) clients.splice(index, 1);
    });
});

clients = [];
PORT = 80

http.listen(PORT, () => {
    console.log(`Listening on *:${PORT}`);
});