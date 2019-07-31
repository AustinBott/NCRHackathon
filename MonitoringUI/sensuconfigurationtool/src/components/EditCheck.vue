<template>
    <div>
        <check
        v-bind:check="check"
        />
    </div>
</template>

<script>

import check from './component-items/check'

export default {
    created(){
        this.check = JSON.parse(this.checkName);
    },
    components:{
        check
    },
    props:{
        checkName:String,
        check:Object
    },
}
</script>