import axios from 'axios';
import AuthenticationHandler from './authenticationAPI.js'

function getAuthenticationToken() {
    var authenticationHandler = new AuthenticationHandler();

    return authenticationHandler.authToken;
}

//if a check name is not provided, this endpoint will retrieve the full checks list.
export function getCheck(checkName) {
    let checkUrl = URL + "/checks"
    if (checkName)
        checkUrl += "/" + checkName;

    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
        url: checkUrl,
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}//getCheckList()


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