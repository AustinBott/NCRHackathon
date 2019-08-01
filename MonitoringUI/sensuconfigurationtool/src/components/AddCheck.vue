<template>
    <div>
        <div class="header">
            <md-card-header>
                <div class="md-title">New Check</div>
            </md-card-header>
            <md-button class="md-primary" v-on:click="SaveCheck()">Save</md-button>
        </div>
        <check
        v-bind:check="check"
        v-bind:newCheck= true
        />
    </div>
</template>

<script>

import check from './component-items/check'
import {createCheck} from '../api/checkAPI'

export default {
    data(){
        return{
            check
        }
    },
    created(){
        this.check = {"command":"check_cpu --warning 90 --critical 95","handlers":["slack","elasticsearch_event_logging"],"high_flap_threshold":60,"interval":60,"low_flap_threshold":20,"publish":false,"runtime_assets":["nagios-foundation-windows"],"subscriptions":["windows"],"proxy_entity_name":"","check_hooks":null,"stdin":false,"subdue":null,"ttl":0,"timeout":0,"round_robin":false,"output_metric_format":"nagios_perfdata","output_metric_handlers":["elasticsearch"],"env_vars":null,"metadata":{"name":'New_Check',"namespace":"cso2_development"}};
    },
    methods:{
        SaveCheck(){
            console.log("Add", this.check);
            createCheck(this.check);
            this.$router.go(-1);
        }
    },
    components:{
        check
    },
    props:{
        checkName:String,
    },
}
</script>