var axios = require('axios');
const BASE_URL = "http://desk.phouse.local:80/powerpointcontrol" 

exports.startSlideShow = function(){
    url = `${BASE_URL}/EndPoints/StartSlideShow`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

exports.endSlideShow = function(){
    url = `${BASE_URL}/EndPoints/EndSlideShow`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

exports.nextSlide = function(){
    url = `${BASE_URL}/EndPoints/NextSlide`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

exports.previousSlide = function(){
    url = `${BASE_URL}/EndPoints/PreviousSlide`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}