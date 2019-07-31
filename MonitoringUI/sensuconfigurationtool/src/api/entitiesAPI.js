import axios from 'axios';
import AuthenticationHandler from './authenticationAPI.js'

function getAuthenticationToken() {
    var authenticationHandler = new AuthenticationHandler();

    return authenticationHandler.authToken;
}

export function getEntities() {
    let entitiesUrl ="https://localhost:5001/api/sensuentities"
    let entitiesList = [];

    return axios({
        method: 'get',
        url: entitiesUrl,
    })
    .then(function (response) {
        return response.data;
    })
    .catch(function (error) {
        console.log(error); //later change to UI error message
    });
}