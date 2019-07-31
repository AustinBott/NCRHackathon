<template>
    <div v-bind:id="'agentDashboard' + agentId">
        {{ agentId }}
    </div>
</template>

<script>
export default {
    props: ['agentId']
}
</script>
