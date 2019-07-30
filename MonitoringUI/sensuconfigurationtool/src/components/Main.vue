<template>
    <div id="main">

      <div id="header" v-if="loggedIn && selectedAgentId">
        <Navigation/>
      </div>

      <div id="routingContainer">
        <template v-if="$route.matched.length">
          <router-view></router-view>
        </template>
        <template v-else>
          <div>
            <AvailableAgentList @agentChanged="onAgentChanged" :loggedIn="loggedIn" v-if="loggedIn" />
            <Login v-if="!loggedIn" />
          </div>
        </template>
      </div>

      <div id="footer" v-if="loggedIn">
      </div>    
    </div>
</template>

<script>
import AvailableAgentList from './AvailableAgentList'
import Login from './Login'
import Navigation from "./Navigation"

export default {
  props: ['loggedIn'],
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

</style>
