<template>
    <div>
        <div class="header">
            <h4>Available Checks</h4>
            <md-button class="md-primary" v-on:click="NewCheck()">Add</md-button>
        </div>
        <div v-if="agentId > 0">
            <p> Agent {{agentId}} selected </p>
        </div>
        <div v-else>
            <p> No agent selected </p>
        </div>
        <div id="checks">
            <div v-for="(check, index) in checks" v-bind:key="index">
                <div class="check" :class="{selected: selected === index}" v-on:click="SelectCheck(index)">
                    <div class="rows">
                        <div class="row">
                            <p>{{check.name}}</p>
                            <p>{{check.metaData.namespace}}</p>
                        </div>
                        <div class="row">
                            <div v-for="(subscription, index) in check.subscriptions" v-bind:key="index">
                                <p>{{subscription.name}}</p>
                            </div>
                        </div>
                    </div>
                    <div id="buttonControl">
                        <md-button class="md-primary" v-on:click.stop="EditCheck(check)">Edit</md-button>
                        <md-button class="md-accent" v-on:click.stop="RemoveCheck(index)">Remove</md-button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>
<script>

import check from './component-items/check'
import EditCheck from './EditCheck'
import { getChecks } from '../api/checkAPI';


export default {
    props:{
        agentId: String,
    },
    components:{
        check,
        EditCheck
    },
    methods:{
        NewCheck(){
            this.checks = this.checks.concat(
                {
                name: 'newCheck' + this.newCheckCount++,
                metaData:{
                    name: 'newCheck',
                    namespace: 'newChecknameSpace'
                },
                subscriptions:[{
                        name: 'sub1'
                    },
                    {
                        name: 'sub2'
                    }
                ],
                hooks:[{
                        name: 'hook2'
                    },
                    {
                        name: 'hook3'
                    },
                    {
                        name: 'hook4'
                    },
                    {
                        name: 'hook5'
                    }],
                handlers:[{
                        name: 'handler5'
                    },
                    {
                        name: 'handler8'
                    }],
            }
            )
            this.selected = undefined;
        },
        RemoveCheck(){
            var checks = this.checks;
            this.checks.splice(this.selected, 1);
            this.selected = undefined;
        },
        SelectCheck: function(checkIndex){
            if(this.selected != checkIndex){
                this.selected = checkIndex;
                console.log(this.selected);
            }
            else{
                this.selected = undefined;
            }
        },
        EditCheck: function(check){
            const newCheck = JSON.stringify(check);
            this.$router.push({path: `/checkslist/editcheck/${newCheck}`});
        }
    },
    created() {
        getChecks().then((data) => {
            this.checks = data;
            console.log(data);
        });
        console.log(this.checks);
    },
    data () {
        return {
             newCheckCount: 1,
             selected: undefined,
             checks: []
        }
    },
}
</script>

<style scope>
    .header{
        display: flex;
        flex-direction: row;
        justify-content:space-between;
    }
    .check{
        display: flex;
        flex-direction: row;
        border: 2px black solid;
        justify-content:space-between;
    }
    .check.selected{
        background: lightblue;
    }
    .rows{
        display:flex;
        flex-direction: column;
    }
    .row{
        display:flex;
        flex-direction: row;
    }
    .md-ripple {
        z-index: 0;
    }
</style>
