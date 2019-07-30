<template>
    <div>
        <table border="4">
            <tr>
                <td>{{agent.name}}</td>
                <td>{{agent.namespace}}</td>
            </tr>
            <tr>
                <td>{{agent.lastUpdate}}</td>
                <td>{{agent.label}}</td>
            </tr>
        </table>
    </div>
</template>

<script>

export default {
    props:{
        agent:{
            name : String,
            namespace : String,
            lastUpdate : String,
            label : String
        }
    }
}
</script>

<style>

</style>
