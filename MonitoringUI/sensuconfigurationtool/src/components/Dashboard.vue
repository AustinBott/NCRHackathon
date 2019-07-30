<template>
  <div id="dashboard">
    <div id="header">
    </div>
    <div id="body">
      This is the point where the user should have selected a store/agent.
        <h4> Available Agents </h4>
        <ul id="example-1">
          <li v-for="item in items" v-bind:key="item.id">
            <agentCard
            v-bind:agent="item"
            />
          </li>
        </ul>
        <router-link to="/logout">Log out</router-link>
    </div>
    <div id="footer">
    </div>
  </div>
</template>

<script>
import auth from '../auth'
import agentCard from './component-items/agentCard'

  export default {
    props: ['loggedIn'],
    data () {
      return {
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
    components:{
      agentCard
    },
  }
</script>
