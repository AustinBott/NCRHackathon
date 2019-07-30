<template>
    <div id="main">
        <template v-if="this.loggedIn">
            <Dashboard />
        </template>
        <template v-else>
            <Login />
        </template>
    </div>
</template>

<script>
import auth from '../auth'
import Dashboard from './Dashboard'
import Login from './Login'

export default {
  data () {
    return {
      loggedIn: auth.loggedIn()
    }
  },
  components: {
      Dashboard,
      Login
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
