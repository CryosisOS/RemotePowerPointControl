var express = require('express');
var app = express();
var http = require('http').Server(app);
var io = require('socket.io')(http);

/// Declaring static assets
const path = require('path');
app.use("/js/", express.static(path.join(__dirname, '/public/js/')));


observers = [];
observers.push(new (require('./event_observer'))());


/// REGISTER API's
require('./observer_api')(app, observers);
require('./internal_api')(app);

/// REGISTER ROUTES
app.get('/', (req, res) => { //TODO: Login feature
    res.sendFile(__dirname + '/public/index.html');
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