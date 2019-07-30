import axios from 'axios';
import authToken from './authenticationAPI.js'


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