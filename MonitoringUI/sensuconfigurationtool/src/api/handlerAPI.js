import axios from 'axios';
import AuthenticationHandler from './authenticationAPI.js'

function getAuthenticationToken() {
    var authenticationHandler = new AuthenticationHandler();

    return authenticationHandler.authToken;
}


export function getHandler(handlerName) {

    let handlerUrl = URL + "/handlers"
    if (handlerName)
        handlerUrl += "/" + handlerName;


    axios({
        method: 'get',
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
        url: handlerUrl,
    })
        .then(function (response) {
            console.log(response.data);
        })
        .catch(function (error) {
            console.log(error); //later change to UI error message
        });
}//getCheckList()





export function createHandler(command, handlers, metadata) {
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
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
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

export function editHandler(command, handlers, metadata) {
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
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
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


export function deleteHandler(name) {
    axios({
        method: 'delete',
        headers: { "Authorization": "Bearer " + getAuthenticationToken(), "content-type": "application/json" },
        url: URL + "/handlers/" + name,
    })
        .then(function (error) {
            console.log(error);
        })
        .then(function (body) {
            console.log(body);
        });
}