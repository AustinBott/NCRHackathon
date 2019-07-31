<template>
    <div>
        <h4>Available Checks</h4>
        <div v-if="selectedAgentId > 0">
            <p> Agent {{selectedAgentId}} selected </p>
        </div>
        <div v-else>
            <p> No agent selected </p>
        </div>
    </div>
</template>

<script>
export default {
    props:{
        selectedAgentId: ['selectedAgentId'],
        check:{
            name: String,
            metaData:{
            name: String,
            nameSpace: String
            },
            subscriptions:[],
            hooks:[],
            handlers:[],
        }
    }
}
</script>

<style scoped>
    
</style>