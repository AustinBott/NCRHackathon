<template>
  <div id="dashboard">
    <div id="header">
      <Navigation />
    </div>
    <div id="body">
      <template v-if="$route.matched.length">
          <h1> Available Agents </h1>
          <ul id="example-1">
            <li v-for="item in items" v-bind:key="item.id">
              <agentCard agent="item" />
            </li>
          </ul>
      </template>
      <template v-else>
        <div>
          This is the dashboard homepage.
          <router-link v-if="loggedIn" to="/logout">Log out</router-link>

        </div>
      </template>
    </div>
    <div id="footer">
    </div>
    This is the point where the user should have selected a store/agent.
  </div>
</template>

<script>

import auth from '../auth'
import agentCard from './component-items/agentCard'
import Navigation from './Navigation'

  export default {
    data () {
      return {
        loggedIn: auth.loggedIn(),
        items: [
          {
            name : 1,
            namespace : '',
            lastUpdate : '17:15:20',
            label : 'eventdata'
          },
          {
            name : 2,
            namespace : '',
            lastUpdate : '17:15:20',
            label : 'eventdata'
          },
          {
            name : 3,
            namespace : '',
            lastUpdate : '17:15:20',
            label : 'eventdata'
          }
          ]
      }
    },
    created () {
      auth.onChange = loggedIn => {
        this.loggedIn = loggedIn
      }
    },
    components:{
      Navigation,
      agentCard
    }
  }
</script>
