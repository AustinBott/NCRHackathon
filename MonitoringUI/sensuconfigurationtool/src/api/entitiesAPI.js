import axios from 'axios';
import AuthenticationHandler from './authenticationAPI.js'

function getAuthenticationToken() {
    var authenticationHandler = new AuthenticationHandler();

    return authenticationHandler.authToken;
}

export function getEntities() {
    let entitiesUrl = URL + "/entities";
    let entitiesList = [];

    axios({
        method: 'get',
        headers: { 
            "Authorization": "Bearer " + getAuthenticationToken(), 
            "content-type": "application/json",
            "Origin": "*"},
        url: entitiesUrl,
    })
    .then(function (response) {
        entitiesList = response;
        console.log(response.data);
    })
    .catch(function (error) {
        console.log(error); //later change to UI error message
    });

    return entitiesList;
}