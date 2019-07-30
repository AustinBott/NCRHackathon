<template>
  <div id="dashboard">
    <div id="header">
    </div>
    <div id="body">
      <template v-if="$route.matched.length">
          <router-view></router-view>
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
  </div>
</template>

<script>
  import auth from '../auth'
  export default {
    data () {
      return {
        loggedIn: auth.loggedIn()
      }
    },
    created () {
      auth.onChange = loggedIn => {
        this.loggedIn = loggedIn
      }
    }
  }
</script>
