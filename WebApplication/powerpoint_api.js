var axios = require('axios');
const BASE_URL = "http://desk.phouse.local/powerpointcontrol" 

export function startSlideShow(){
    url = `${BASE_URL}/EndPoints/StartSlideShow`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

export function endSlideShow(){
    url = `${BASE_URL}/EndPoints/EndSlideShow`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

export function nextSlide(){
    url = `${BASE_URL}/EndPoints/NextSlide`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}

export function previousSlide(){
    url = `${BASE_URL}/EndPoints/PreviousSlide`;
    axios.post(url)
    .then((response)=>{
        console.log(response.status);
        console.log(response.statusText);
    }, (error) =>{
        console.log(error);
    });
}