<template>
  <div>
    <md-card md-with-hover>
        <md-card-header>
          <div class="md-title">{{agent.metadata.name}}</div>
        </md-card-header>

        <md-card-content>
          <div class = "md-content">Namespace: {{agent.metadata.namespace}}</div>
          <div class = "md-content">User: {{agent.user}}</div>
        </md-card-content>
    </md-card>
  </div>
</template>

<style scoped>
  .md-card {
    width: 320px;
    margin: 4px;
    display: inline-block;
    vertical-align: top;
  }
</style>

<script>
export default {
  name: 'RegularCards',
  props: {
      agent: Object
  }
}
</script>