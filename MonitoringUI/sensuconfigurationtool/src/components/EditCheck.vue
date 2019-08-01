<template>
    <div>
        <div class="header">
            <md-card-header>
                <div class="md-title">Edit Check</div>
            </md-card-header>
            <md-button class="md-primary" v-on:click="SaveCheck()">Save</md-button>
        </div>
        <check
        v-bind:check="check"
        v-bind:newCheck='false'
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
            console.log("EDIT", this.check);
            editCheck(this.check);
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