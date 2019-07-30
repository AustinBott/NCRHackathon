<template>
  <Main />
</template>

<script>
import auth from '../auth'
import Main from './Main'

export default {
  data () {
    return {
      loggedIn: auth.loggedIn()
    }
  },
  components: {
    Main
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