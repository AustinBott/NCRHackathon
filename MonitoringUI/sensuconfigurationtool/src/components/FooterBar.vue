<template>
  <div>
    <div class="phone-viewport">
      <md-bottom-bar md-sync-route>
            <md-bottom-bar-item to="/logout" exact md-label="Logout"></md-bottom-bar-item>
      </md-bottom-bar>
    </div>
  </div>
</template>

<script>
  export default {
    name: 'BarRouter'
  }
</script>

<style>
    .phone-viewport {
        width: 100%;
        height: 100px;
        bottom: 0;
        left: 0;
        display: inline-flex;
        align-items: flex-end;
        position: fixed;
        overflow: hidden;
        border: 1px solid rgba(#000, .26);
        background: rgba(#000, .06);
    }

    .phone-viewport i {
        display: none;
    }

    .phone-viewport span {
        color: #448aff;
        font-weight: 500;
    text-transform: uppercase;
    font-size: 15px;
    font-family: inherit;
        letter-spacing: .01em;
    }

    .md-bottom-bar-label {
        color: grey;
    }

</style>