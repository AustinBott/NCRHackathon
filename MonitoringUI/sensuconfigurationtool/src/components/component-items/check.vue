<template>
    <div class = "card" :class="{selected:isSelected}">
        <div class = "table">
            <div class = "row header"> 
               <div class = "item"> Check: {{check.name}}</div>
            </div>
            <div class = "row">
                <div class = "item">{{check.metaData.namespace}}</div>
                <div class = "item">{{check.metaData.name}}</div>
            </div>
            <div class="row">
                <div class = "item">{{check.subscriptions}}</div>
            </div>
            <div class = "row header"> 
               <div class = "item"> Hooks: </div>
            </div>
           <div class="row">
                <div class = "item"
                v-for="hook in check.hooks" v-bind:key="hook.name">
                    <hook
                    v-bind:hook="hook"/>
                </div>
            </div>
            <div class = "row header"> 
               <div class = "item"> Handlers: </div>
            </div>
            <div class="row">
                <div class = "item"
                v-for="handler in check.handlers" v-bind:key="handler.name">
                    <handler
                    v-bind:handler="handler"/>
                </div>  
            </div>
        </div>
        <input v-model="check.name" lazy>
    </div>
</template>


<script>
import hook from './hook'
import handler from './handler'
export default {
    props:{
        isSelected: Boolean,
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
    },
    components:{
        hook,
        handler
    },
}
</script>

<style scoped>
    .card{
        width: 100%;
        display: flex;
        border: 1px blue solid;
        flex-direction: column;
    }
    .card.selected{
        border: 4px red solid;
        background: yellow;
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
    .header{
        justify-content: left;
    }
</style>