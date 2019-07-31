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
            <div v-for="(check, index) in checks" v-bind:key="index">
                <div v-on:click="SelectCheck(index)">
                <check
                v-bind:check="check" class="card" v-bind:isSelected="index == selected"
                />
                </div>
            </div>
        </div>
        <div id="buttonControl">
             <md-button class="md-primary" v-on:click="NewCheck()">Add</md-button>
             <md-button class="md-accent" v-on:click="RemoveCheck()" :disabled="(selected === undefined)">Remove</md-button>
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
        },
        RemoveCheck(){
        var checks = this.checks;
        this.checks.splice(this.selected, 1);
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
                console.log(this.selected);
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
