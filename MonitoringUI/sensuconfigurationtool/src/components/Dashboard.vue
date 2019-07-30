<template>
  <div id="dashboard">
    <div id="header">
    </div>
    <div id="body">
      <template v-if="$route.matched.length">
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
          <h4> Available Agents </h4>
          <ul id="example-1">
            <li v-for="item in items" v-bind:key="item.id">
              <agentCard
               v-bind:agent="item"
              />
            </li>
          </ul>
    <router-link v-if="loggedIn" to="/logout">Log out</router-link>
  </div>
</template>

<script>
import auth from '../auth'
import agentCard from './component-items/agentCard'

  export default {
    data () {
      return {
        loggedIn: auth.loggedIn(),
        items: [
          {
            name : 1,
            namespace : 'namespace1',
            lastUpdate : '17:15:20',
            label : 'eventdata'
          },
          {
            name : 2,
            namespace : 'namespace2',
            lastUpdate : '17:dsfsaf',
            label : 'eventdsfasdfata'
          },
          {
            name : 3,
            namespace : 'namespace3',
            lastUpdate : '17:1sdfafda5:20',
            label : 'eventdasfdasdfta'
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
      agentCard
    },
    props: ['loggedIn']
  }
</script>
