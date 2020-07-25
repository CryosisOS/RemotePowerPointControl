function startSlideShow(){
    $.post("http://pi.phouse.local/internal/startslideshow");
}

function endSlideShow(){
    $.post("http://pi.phouse.local/internal/endslideshow");
}

function nextSlide(){
    $.post("http://pi.phouse.local/internal/nextslide");
}

function previousSlide(){
    $.post("http://pi.phouse.local/internal/previousslide");
}