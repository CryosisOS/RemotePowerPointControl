var express = require('express');

module.exports = function define_end_points(app, observers){
    app.post('/event/startslideshow', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "event":"START_SLIDE_SHOW"
            });
        });
    });

    app.post('/event/endslideshow', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "event":"END_SLIDE_SHOW"
            });
        });
    });

    app.post('/event/nextslide', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "event":"NEXT_SLIDE"
            });
        });
    });


    app.post('/event/previousslide', (req, res) => {
        observers.forEach(observer => {
            observer.notify({
                "event":"PREVIOUS_SLIDE"
            });
        });
    });
}