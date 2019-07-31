<template>
    <div class = "card">
        <div class = "table">
            <div class = "row">
                <div class = "item">{{agent.metadata.name}}</div>
                <div class = "item">{{agent.metadata.namespace}}</div>
            </div>
            <div class="row">
                <div class = "item">{{agent.lastseen}}</div>
                <div class = "item" >{{agent.user}}</div>
            </div>
        </div>
    </div>
</template>

<script>

export default {
    props:{
        agent: Object
    },
    created() {
        console.log("created", this.agent);
    }
}
</script>

<style scoped>
    .card{
        width: 100%;
        display: flex;
        border: 1px blue solid;
    }
    .table{
        width: 100%;
        border: 1px green solid;
        display: flex;
        justify-content: space-evenly;
        flex-direction: column;
        overflow: hidden;
    }
    .row{
        border: 1px red solid;
        display: flex;
        flex-direction: row;
        margin: 2px;
        overflow: hidden;
        justify-content: space-evenly;
    }
    .item{
        margin: 5px;
        padding: 5px;
        font: 2px;
        overflow: hidden;
    }
    </style>
