import axios from 'axios';
import AuthenticationHandler from './authenticationAPI.js'

function getAuthenticationToken() {
    var authenticationHandler = new AuthenticationHandler();

    return authenticationHandler.authToken;
}

export function getChecks(checkName) {
    var checkUrl = "https://localhost:5001/api/sensuchecks";
    if (checkName)
        checkUrl += "/" + checkName;

    return axios({
        method: 'get',
        url: checkUrl,
    })
    .then(function (response) {
        return response.data;
    })
    .catch(function (error) {
        console.log(error); //later change to UI error message
    });
}


export function createCheck(command, subscriptions, interval, publish, handlers, metadata) {
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
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
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

export function editCheck(command, subscriptions, interval, publish, handlers, metadata) {
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
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
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


export function deleteCheck(name) {
    axios({
        method: 'delete',
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
        url: URL + "/checks/" + name,
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}