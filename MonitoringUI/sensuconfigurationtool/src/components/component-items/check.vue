<template>
    <div id="check" class = "card" :class="{selected:isSelected}">
        <div class = "table">
            <div class = "row"> 
               <div class="item title">Check:</div>
                <input class = "item">
            </div>
            <div class = "row">
                <div class="item title">Metadata:</div>
                <input class = "item" v-model="check.metadata.namespace">
                <input class = "item" v-model="check.metadata.name">
            </div>
            <div class="row">
                <div class="item title">Subscrptions:</div>
                <div class="item" v-for="(subscription, index) in check.subscriptions" v-bind:key="index">
                    <input v-model="subscription.name">
                </div>
            </div>
            <div class = "row"> 
               <div class = "item"> Hooks: </div>
            </div>
           <div class="row">
                <div class = "item"
                v-for="(hook, index) in check.hooks" v-bind:key="index">
                    <hook
                    v-bind:hook="hook"/>
                </div>
            </div>
            <div class = "row"> 
               <div class = "item"> Handlers: </div>
            </div>
            <div class="row">
                <div class = "item"
                v-for="(handler,index) in check.handlers" v-bind:key="index">
                    <handler
                    v-bind:handler="handler"/>
                </div>  
            </div>
        </div>
    </div>
</template>


<script>
import hook from './hook'
import handler from './handler'
export default {
    props:{
        isSelected: Boolean,
        selectedAgentId: ['selectedAgentId'],
        check: Object
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
        padding: 0px 5px;
        flex-wrap: wrap;
        justify-content: left;
    }
    .item{
        margin: 5px;
        padding: 5px;
        font: 2px;
        overflow: hidden;
    }
</style>