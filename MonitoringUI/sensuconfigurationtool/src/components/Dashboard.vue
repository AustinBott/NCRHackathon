<template>
  <div id="dashboard">
    This is the point where the user should have selected a store/agent.
    <router-link v-if="loggedIn" to="/logout">Log out</router-link>
  </div>
</template>

<script>
  export default {
    props: ['loggedIn']
  }
</script>
