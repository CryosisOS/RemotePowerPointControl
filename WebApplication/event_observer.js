module.exports = class EventObserver {
    constructor(){}

    notify(event) {
        console.log("Notified");
        console.log(event);
    }
}