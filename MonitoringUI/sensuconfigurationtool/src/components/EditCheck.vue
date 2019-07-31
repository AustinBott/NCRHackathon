<template>
    <div>
        <div class="header">
            <h4>Editing Check</h4>
            <md-button class="md-primary" v-on:click="SaveCheck()">Save</md-button>
        </div>
        <check
        v-bind:check="check"
        />
    </div>
</template>

<script>

import check from './component-items/check'
import {editCheck} from '../api/checkAPI'

export default {
    data(){
        return{
            check
        }
    },
    created(){
        this.check = JSON.parse(this.checkName);
    },
    methods:{
        SaveCheck(){
            editCheck();
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