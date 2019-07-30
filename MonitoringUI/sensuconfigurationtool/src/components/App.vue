<template>
  <Main :loggedIn="loggedIn" />
</template>

<script>
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
      this.loggedIn = loggedIn;
      console.log('changing login status', loggedIn);

    }
  }
}
</script>

<style>

</style>