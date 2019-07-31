<template>
    <div>
        <p>{{checkName}}</p>
        <check
        v-bind:check="check"
        />
    </div>
</template>

<script>

import check from './component-items/check'

export default {
    components:{
        check
    },
    props:{
        checkName:String,
        check:String
    }
}
</script>