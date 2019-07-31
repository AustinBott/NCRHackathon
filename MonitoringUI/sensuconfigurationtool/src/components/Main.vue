<template>
    <div id="main">

      <div id="header" v-if="loggedIn">
        <Navigation :selectedAgentId="selectedAgentId" />
      </div>

      <div id="routingContainer" class="container">
        <template v-if="$route.matched.length">
            <router-view @agentChanged="onAgentChanged" :loggedIn="loggedIn"></router-view> 
        </template>
        <template v-else>
          <div>
            <p>404 Error</p>
          </div>
        </template>
      </div>

      <div id="footer" v-if="loggedIn" class="footer">
        <router-link to="/logout">Log out</router-link>
      </div>    
    </div>
</template>

<script>
import AvailableAgentList from './AvailableAgentList'
import Login from './Login'
import Navigation from "./Navigation"

export default {
  props: ['loggedIn'],
  data: function() {
    return {
      selectedAgentId: 0
    };
  },
  created() {
    selectedAgentId: 0
  },
  mounted: function() {
    selectedAgentId: 0
  },
  components: {
      AvailableAgentList,
      Login,
      Navigation
  },
  methods: {
    onAgentChanged(selectedAgentId) { 
      this.selectedAgentId = selectedAgentId;
      console.log(selectedAgentId);
    }
  }
    
}
</script>

<style>
  .container{
    margin: 30px;
  }
  .footer{
    margin-left:30px;
  }
</style>
