<template>
  <div id="availableAgentList">
    <div id="header">
    </div>
    <div id="body" class = "container">
      This is the point where the user should have selected a store/agent.
        <h4> Available Agents </h4>
        <div class ="flex-container">
        <div class= "card-list" v-for="item in items" v-bind:key="item.name" v-on:click="navigateToDashboard(item.name)">
            <agentCard
            v-bind:agent="item" class="card"
            />
          </div>
        </div>
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
          },
                    {
            name : 4,
            namespace : 'namespace3',
            lastUpdate : '17:1sdfafda5:20',
            label : 'eventdasfdasdfta'
          },
                    {
            name : 5,
            namespace : 'namespace3',
            lastUpdate : '17:1sdfafda5:20',
            label : 'eventdasfdasdfta'
          },
                    {
            name : 6,
            namespace : 'namespace3',
            lastUpdate : '17:1sdfafda5:20',
            label : 'eventdasfdasdfta'
          }
          ]
      }
    },
    methods: {
      navigateToDashboard: function (agentId) {
        this.$router.push(`/agent/dashboard/${agentId}`);
        
        this.$emit('agentChanged', agentId)
      }
    },
    components:{
      agentCard
    },
  }
</script>

<style scoped>

  .card{
    width: 15em;
  }

  .card-list{
    margin: 10px 15px 10px 0px;
  }

  .flex-container{
    display: flex;
    max-width: 100%;
    margin: 10px 0px;
    flex-wrap: wrap;
    justify-content: left;
  }

  .container{
    max-width: 100%;
    margin: auto;
  }
</style>