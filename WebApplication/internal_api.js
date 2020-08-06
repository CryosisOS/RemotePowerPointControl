var express = require('express');
var API = require('./powerpoint_api');

module.exports = function define_end_points(app){
    app.post('/internal/startslideshow', (req, res) => {
        API.startSlideShow();
    });

    app.post('/internal/endslideshow', (req, res) => {
        API.endSlideShow();
    });

    app.post('/internal/nextslide', (req, res) => {
        API.nextSlide();
    });

    app.post('/internal/previousslide', (req, res) => {
        API.previousSlide();
    });

    app.post('/internal/blackout', (req, res) => {
        API.blackOut();
    });
}