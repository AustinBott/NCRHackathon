<template>
  <div id="dashboard">
    This is the point where the user should have selected a store/agent.
  </div>
</template>

<script>
  import auth from '../auth'
  import Navigation from './Navigation'
  export default {
    data () {
      return {
        loggedIn: auth.loggedIn()
      }
    },
    components: {
      Navigation
    },
    created () {
      auth.onChange = loggedIn => {
        this.loggedIn = loggedIn
      }
    }
  }
</script>
