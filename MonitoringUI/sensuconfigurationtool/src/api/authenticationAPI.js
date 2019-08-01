import axios from 'axios';
import {getHandler} from './handlerAPI'

export default class AuthenticationHandler {
    constructor() {
        const URL = "https://sensuservice.preprod.ncrsaas.com/api/core/v2/namespaces/cso2_development";

        this.authToken = "";
        this.waitingTime = 0;

        this.getAuthToken();
        this.waitForAuth();  
    }

    getAuthToken() {
        axios({
            auth: {
                username: "pn185074",
                password: "q9IkeOUn2yeit8J/"
            },
            method: 'get',
            url: "http://sensuservice.preprod.ncrsaas.com/auth",
        })
        .then(function (response) {
            this.authToken = response.data.access_token;
        })
        .catch(function (error) {
            console.log(error); 
        });
    }

    waitForAuth() {
        if (this.authToken) {
    
            let metadata = {
                "name": "testhandler1",
                "namespace": "cso2_development"
            };
    
            // --------------- DO STUFF HERE ----------------
            getHandler();
    
    
        } else if (this.waitingTime < 5000) {
            this.waitingTime += 100;
            setTimeout(this.waitForAuth(), 100);
        } else {
            console.error("Timeout on authenticating Sensu");
        }
    }
}





 