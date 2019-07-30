<template>
  <div id="dashboard">
    This is the point where the user should have selected a store/agent.
    <router-link v-if="loggedIn" to="/logout">Log out</router-link>

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
    components: {
    },
    created () {
      auth.onChange = loggedIn => {
        this.loggedIn = loggedIn
      }
    }
  }
</script>
