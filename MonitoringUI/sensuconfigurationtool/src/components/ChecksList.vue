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
        RemoveCheck: function(index){
            this.checks.splice(index, 1);
            this.selected = undefined;
            /*this.checks = Object.keys(checks)
            .map(key => checks[key]) // turn an array of keys into array of items.
            .filter(check => check.name !== this.selected);
            this.selected = undefined;*/
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
     data () {
         return {
             newCheckCount: 1,
             selected: undefined,
             checks: [
            {
                name: 'check1',
                metaData:{
                    name: 'check1',
                    namespace: 'namespace1'
                },
                subscriptions:[{
                        name: 'sub1'
                    },
                    {
                        name: 'sub2'
                    }
                ],
                hooks:[{
                        name: 'hook1'
                    },
                    {
                        name: 'hook3'
                    }],
                handlers:[{
                        name: 'handler5'
                    },
                    {
                        name: 'handler8'
                    }],
            },
            {
                name: 'check2',
                metaData:{
                    name: 'check2',
                    namespace: 'namespace2'
                },
                subscriptions:[{
                        name: 'sub3'
                    },
                    {
                        name: 'sub4'
                    }
                ],
                hooks:[{
                        name: 'hook2'
                    },
                    {
                        name: 'hook3'
                    }],
                handlers:[{
                        name: 'handler1'
                    },
                    {
                        name: 'handler5'
                    }],
            }
          ],
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
</style>
