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
            <Dashboard v-if="loggedIn" />
            <Login v-if="!loggedIn" />
          </div>
        </template>
      </div>

      <div id="footer" v-if="loggedIn">
      </div>    
    </div>
</template>

<script>
import auth from '../auth'
import Dashboard from './Dashboard'
import Login from './Login'
import Navigation from "./Navigation"

export default {
  data () {
    return {
      loggedIn: auth.loggedIn()
    }
  },
  components: {
      Dashboard,
      Login,
      Navigation
  },
  created () {
    auth.onChange = loggedIn => {
      this.loggedIn = loggedIn
    }
  }
}
</script>

<style>

</style>
