<template>
    <div>
        <h4>Available Checks</h4>
        <div v-if="agentId > 0">
            <p> Agent {{agentId}} selected </p>
        </div>
        <div v-else>
            <p> No agent selected </p>
        </div>
        <div id="checks">
            <div v-for="check in checks" v-bind:key="check.name">
                <div v-on:click="SelectCheck(check.name)">
                <check
                v-bind:check="check" class="card" v-bind:isSelected="check.name == selected"
                />
                </div>
            </div>
        </div>
        <div id="buttonControl">
             <md-button class="md-primary" v-on:click="NewCheck()">Add</md-button>
             <md-button class="md-accent" v-on:click="RemoveCheck()" :disabled="!selected">Remove</md-button>
        </div>
    </div>
</template>
<script>

import check from './component-items/check'

export default {
    props:{
        agentId: String,
    },
    components:{
        check
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
            }
            )
        },
        RemoveCheck(){
        var checks = this.checks;
        
        this.checks = Object.keys(checks)
        .map(key => checks[key]) // turn an array of keys into array of items.
        .filter(check => check.name !== this.selected);
        this.selected = undefined;
        },
        SelectCheck: function(checkName){
            if(this.selected != checkName){
                this.selected = checkName;
            }
            else{
                this.selected = undefined;
            }
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
