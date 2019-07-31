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
                <div v-on:click="selected = check.name">
                <check
                v-bind:check="check" class="card" v-bind:isSelected="check.name == selected"
                />
                </div>
            </div>
        </div>
        <div id="buttonControl">
             <md-button class="md-primary">Add</md-button>
             <md-button class="md-accent">Remove</md-button>
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
     data () {
         return {
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
     }
}
</script>


<style scoped>
    .check.highlight{
        background: yellow;
    }
</style>
