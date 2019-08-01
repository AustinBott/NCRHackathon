<template>
    <div id="main">

      <div id="header" v-if="loggedIn">
        <Navigation :selectedAgentName="selectedAgentName" />
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
        <FooterBar />
      </div>    
    </div>
</template>

<script>
import AvailableAgentList from './AvailableAgentList'
import Login from './Login'
import Navigation from "./Navigation"
import FooterBar from "./FooterBar"

export default {
  props: ['loggedIn'],
  data: function() {
    return {
      selectedAgentName: ""
    };
  },
  created() {
    selectedAgentName: ""
  },
  mounted: function() {
    selectedAgentName: ""
  },
  components: {
      AvailableAgentList,
      Login,
      Navigation,
      FooterBar
  },
  methods: {
    onAgentChanged(selectedAgentName) { 
      this.selectedAgentName = selectedAgentName;
      console.log(selectedAgentName);
    }
  }
    
}
</script>

<style>
  .container{
    margin: 30px;
    margin-bottom: 60px;
  }
  .footer{
    margin-left:30px;
  }
</style>
