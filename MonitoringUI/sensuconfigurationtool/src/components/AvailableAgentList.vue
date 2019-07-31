<template>
  <div id="availableAgentList">
    <div id="body" class = "container">
        <h4> Available Agents </h4>
        <div class ="flex-container">
        <div class= "card-list" v-for="agent in agents" v-bind:key="agent.metadata.name" v-on:click="navigateToDashboard(agent.metadata.name)">
            <agentCard
            v-bind:agent="agent" class="card"
            />
          </div>
        </div>
    </div>
  </div>
</template>

<script>
import auth from '../auth'
import agentCard from './component-items/agentCard'
import {getEntities} from '../api/entitiesAPI';

  export default {
    data () {
      return {
          agents: []
      }
    },
    created() {
      //reset agent ID
      this.$emit('agentChanged', '');

      getEntities().then((data) => {
        this.agents = data;
      });
      console.log(this.agents);
    },
    methods: {
      navigateToDashboard: function (agentName) {
        this.$router.push(`/agent/dashboard/${agentName}`);
        
        this.$emit('agentChanged', agentName)
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