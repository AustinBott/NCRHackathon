<template>
    <div>
        <h4>Available Checks</h4>
        <div v-if="agentId > 0">
            <p> Agent {{agentId}} selected </p>
        </div>
        <div v-else>
            <p> No agent selected </p>
        </div>
    </div>
</template>
<script>

export default {
    props:{
        agentId: Number,
    }
}
</script>
