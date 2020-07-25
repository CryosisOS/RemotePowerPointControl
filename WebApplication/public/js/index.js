function startSlideShow(){
    let xhr = new XMLHttpRequest();
    xhr,open('POST', "http://pi.phouse.local/internal/startslideshow", true);
    xhr.send();
}

function endSlideShow(){
    let xhr = new XMLHttpRequest();
    xhr,open('POST', "http://pi.phouse.local/internal/endslideshow", true);
    xhr.send();
}

function nextSlide(){
    let xhr = new XMLHttpRequest();
    xhr,open('POST', "http://pi.phouse.local/internal/nextslide", true);
    xhr.send();
}

function previousSlide(){
    let xhr = new XMLHttpRequest();
    xhr,open('POST', "http://pi.phouse.local/internal/previousslide", true);
    xhr.send();
}