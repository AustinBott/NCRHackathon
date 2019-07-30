import axios from 'axios';
import {getCheck, createCheck, editCheck, deleteCheck} from './checkAPI.js'
import {getHandler, createHandler, editHandler, deleteHandler} from './checkAPI.js'

let waitingTime = 0;
var authToken;
const URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development";




getAuthToken();
waitForAuth();






function getAuthToken() {
    axios({
        auth: {
            username: "pn185074",
            password: "q9IkeOUn2yeit8J/"
        },
        method: 'get',
        url: "https://sensuservice.preprod.ncrsaas.com/auth",
    })
        .then(function (response) {
            authToken = response.data.access_token;
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}//getAuthToken()

function waitForAuth() {
    if (authToken) {

        let metadata = {
            "name": "testhandler1",
            "namespace": "cso2_development"
        };

        // --------------- DO STUFF HERE ----------------
        getHandler();


    } else if (waitingTime < 5000) {
        waitingTime += 100;
        setTimeout(waitForAuth, 100);
    } else {
        console.error("Timeout on authenticating Sensu");
    }//if-elseif-else
}//waitForAuth()