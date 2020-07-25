function startSlideShow(){
    let xhr = new XMLHttpRequest();
    xhr.open('POST', "http://pi.phouse.local/internal/startslideshow", true);
    xhr.send();
    xhr.addEventListener("readystatechange", processResponse, false);

    function processResponse(e){
        if(xhr.readyState == 4){
            console.log(xhr.status);
        }
    }
}

function endSlideShow(){
    let xhr = new XMLHttpRequest();
    xhr.open('POST', "http://pi.phouse.local/internal/endslideshow", true);
    xhr.send();
    xhr.addEventListener("readystatechange", processResponse, false);

    function processResponse(e){
        if(xhr.readyState == 4){
            console.log(xhr.status);
        }
    }
}

function nextSlide(){
    let xhr = new XMLHttpRequest();
    xhr.open('POST', "http://pi.phouse.local/internal/nextslide", true);
    xhr.send();
    xhr.addEventListener("readystatechange", processResponse, false);

    function processResponse(e){
        if(xhr.readyState == 4){
            console.log(xhr.status);
        }
    }
}

function previousSlide(){
    let xhr = new XMLHttpRequest();
    xhr.open('POST', "http://pi.phouse.local/internal/previousslide", true);
    xhr.send();
    xhr.addEventListener("readystatechange", processResponse, false);

    function processResponse(e){
        if(xhr.readyState == 4){
            console.log(xhr.status);
        }
    }
}