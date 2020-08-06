var axios = require('axios');
const BASE_URL = "http://10.0.0.128/powerpointcontrol"

module.exports = class EventObserver {
    constructor(){

        url = `${BASE_URL}/Broadcast/LocalEvent_Subscribed`;
        axios.post(url)
        .then((response)=>{
            console.log(`Request - Subscribed: ${response.status}`);
        }, (error) =>{
            console.log(error);
        });
    }

    notify(event) {
        console.log("Notified");
        console.log(event);
    }
}