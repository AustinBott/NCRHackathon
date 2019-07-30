<template>
    <div id="main">

      <div id="header" v-if="loggedIn">
        <Navigation/>
      </div>

      <div id="routingContainer">
        <template v-if="$route.matched.length">
          <router-view></router-view>
        </template>
        <template v-else>
          <div>
            <Dashboard :loggedIn="loggedIn" v-if="loggedIn" />
            <Login v-if="!loggedIn" />
          </div>
        </template>
      </div>

      <div id="footer" v-if="loggedIn">
      </div>    
    </div>
</template>

<script>
import Dashboard from './Dashboard'
import Login from './Login'
import Navigation from "./Navigation"

export default {
  props: ['loggedIn'],
  components: {
      Dashboard,
      Login,
      Navigation
  },
}
</script>

<style>

</style>
