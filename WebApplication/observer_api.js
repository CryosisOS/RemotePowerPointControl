var express = require('express');

module.exports = function define_end_points(app, observers){
    app.post('/event/startslideshow', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "name":"START_SLIDE_SHOW"
            });
        });
    });

    app.post('/event/endslideshow', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "name":"END_SLIDE_SHOW"
            });
        });
    });

    app.post('/event/slidechange', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "name":"SLIDE_CHANGE"
            });
        });
    });
}