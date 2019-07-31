<template>
  <div>
    <md-tabs md-sync-route>
      <md-tab id="tab-home" md-label="Agents" to="/availableAgentList/" exact></md-tab>
      <md-tab id="tab-checks" md-label="Checks" :to="'/checkslist/' + selectedAgentName"></md-tab>
      <!--<md-tab id="tab-favorites" md-label="Favorites" to="/components/tabs/favorites"></md-tab>-->
      <md-tab id="tab-disabled" md-label="Disabled" md-disabled></md-tab>
        <router-link to="/logout">Log out</router-link>
    </md-tabs>

  </div>
</template>

<script>
  export default {
    props: ['selectedAgentName'],
    name: 'TabRouter'
  }
</script>