<template>
    <div>
        <div class="header">
            <h4>Available Checks</h4>
            <md-button class="md-primary" v-on:click="NewCheck()">Add</md-button>
        </div>

        <div id="checks">
            <div v-for="(check, index) in checks" v-bind:key="index">
            <md-card md-with-hover>
                <md-card-header>
                    <div class="md-title">{{check.metadata.name}}</div>
                </md-card-header>
                <div id="buttonControl">
                <md-button class="md-primary" v-on:click.stop="EditCheck(check)">Edit</md-button>
                <md-button class="md-accent" v-on:click.stop="RemoveCheck(check.metadata.name)">Remove</md-button>
            </div>
            </md-card>
                    <!-- <div class="check" :class="{selected: selected === index}" v-on:click="SelectCheck(index)">
                    <div class="rows">
                        <div class="row">
                            <p>{{check.name}}</p>
                            <p>{{check.metadata.namespace}}</p>
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
                    </div> -->
                </div>
            </div>
        </div>
    </div>
</template>
<script>

import check from './component-items/check'
import EditCheck from './EditCheck'
import { getChecks, createCheck, deleteCheck } from '../api/checkAPI';


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
            if (!this.checks){
                this.checks = [];
            }

            let check = {"command":"check_cpu --warning 90 --critical 95","handlers":["slack","elasticsearch_event_logging"],"high_flap_threshold":60,"interval":60,"low_flap_threshold":20,"publish":false,"runtime_assets":["nagios-foundation-windows"],"subscriptions":["windows"],"proxy_entity_name":"","check_hooks":null,"stdin":false,"subdue":null,"ttl":0,"timeout":0,"round_robin":false,"output_metric_format":"nagios_perfdata","output_metric_handlers":["elasticsearch"],"env_vars":null,"metadata":{"name":'newCheck' + this.checks.length,"namespace":"cso2_development"}};
            createCheck(check);

            this.selected = undefined;
            this.GetChecks();
        },
        RemoveCheck: function(name){
            deleteCheck(name);
            this.selected = undefined;
            this.GetChecks();
        },
        SelectCheck: function(checkIndex){
            if(this.selected != checkIndex){
                this.selected = checkIndex;
            }
            else{
                this.selected = undefined;
            }
        },
        EditCheck: function(check){
            const newCheck = JSON.stringify(check);
            this.$router.push({path: `/checkslist/editcheck/${newCheck}`});
        },
        GetChecks(){
            getChecks().then((data) => {
            this.checks = data;
            });

        }
    },
    created() {
        this.GetChecks();
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
