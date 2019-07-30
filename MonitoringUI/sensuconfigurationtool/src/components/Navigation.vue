<template>
  <div>
    <md-tabs md-sync-route>
      <md-tab id="tab-home" md-label="Home" to="/components/tabs" exact></md-tab>
      <md-tab id="tab-checks" md-label="Checks" to="/components/ChecksList"></md-tab>
      <md-tab id="tab-favorites" md-label="Favorites" to="/components/tabs/favorites"></md-tab>
      <md-tab id="tab-disabled" md-label="Disabled" md-disabled></md-tab>
    </md-tabs>
  </div>
</template>

<script>
  export default {
    name: 'TabRouter'
  }
</script>