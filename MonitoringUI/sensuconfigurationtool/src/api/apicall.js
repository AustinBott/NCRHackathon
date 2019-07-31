var axios = require('axios');

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
        //createCheck("123", ["windows"], 43, false, null, metadata);
        //editCheck("12345", ["windows"], 10, false, null, metadata);
        //deleteCheck("testcheck2");

        //createHandler("1234", null, metadata);
        //editHandler("12345", null, metadata);
        //deleteHandler("testhandler1");

        //getEntity("CSO2_Lab_Kiosk_0");
        getEvent("CSO2_Lab_Kiosk_0", "windows_check_cpu");



    } else if (waitingTime < 5000) {
        waitingTime += 100;
        setTimeout(waitForAuth, 100);
    } else {
        console.error("Timeout on authenticating Sensu");
    }//if-elseif-else
}//waitForAuth()












function getCheck(checkName) {
    let checkUrl = URL + "/checks"
    if (checkName)
        checkUrl += "/" + checkName;


    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: checkUrl,
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}//getCheckList()

options = {
    "command": "check-cpu",



}
createCheck(options)

function createCheck(command, subscriptions, interval, publish, handlers, metadata) {
    let check = {
        "command": command,
        "subscriptions": subscriptions,
        "interval": interval,
        "publish": publish,
        "handlers": handlers,
        "metadata": metadata
    };

    axios({
        method: 'post',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/checks",
        data: check
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}

function editCheck(command, subscriptions, interval, publish, handlers, metadata) {
    let check = {
        "command": command,
        "subscriptions": subscriptions,
        "interval": interval,
        "publish": publish,
        "handlers": handlers,
        "metadata": metadata
    };

    axios({
        method: 'put',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/checks/" + metadata.name,
        data: check
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}

function deleteCheck(name) {
    axios({
        method: 'delete',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/checks/" + name,
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}

function executeCheck(name) {
    axios({
        method: 'post',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/checks/" + name + "/execute",
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}







function getHandler(handlerName) {

    let handlerUrl = URL + "/handlers"
    if (handlerName)
        handlerUrl += "/" + handlerName;


    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: handlerUrl,
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}//getCheckList()

function createHandler(command, handlers, metadata) {
    let handler = {
        "command": command,
        "handlers": handlers,
        "metadata": metadata,
        "filters": [
            "is_incident",
            "not_silenced"
        ],
        "type": "pipe"
    };

    axios({
        method: 'post',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/handlers",
        data: handler
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}

function editHandler(command, handlers, metadata) {
    let handler = {
        "command": command,
        "handlers": handlers,
        "metadata": metadata,
        "filters": [
            "is_incident",
            "not_silenced"
        ],
        "type": "pipe"
    };

    axios({
        method: 'put',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/handlers/" + metadata.name,
        data: handler
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}

function deleteHandler(name) {
    axios({
        method: 'delete',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: URL + "/handlers/" + name,
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}





function getEntity(entityName) {
    let entityUrl = URL + "/entities"
    if (entityName)
        entityUrl += "/" + entityName;


    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: entityUrl,
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}






function getEvent(entityName, checkName) {
    let eventUrl = URL + "/events"
    if (entityName) {
        eventUrl += "/" + entityName;
        if (checkName)
            eventUrl += "/" + checkName;
    }


    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + authToken, "content-type": "application/json" },
        url: eventUrl,
    })
        .then(function (response) {
            
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}






function updateAgentSubs(subscriptions) {
    let metadata = {
        "name": "update_subscriptions",
        "namespace": "cso2_development"
    };
    createCheck("powershell.exe -ExecutionPolicy unrestricted -Command \"Edit-Agent -subscriptions \'" + subscriptions + "\'\"",
    ["updateCheck"],
    10000,
    false,
    null,
    metadata);

    executeCheck(metadata.name);
    deleteCheck(metadata.name);
}