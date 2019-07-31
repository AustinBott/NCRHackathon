<template>
    <!--<div class = "card">
        <div class = "table">
            <div class = "row header">--> 
               <md-input class = "item" v-model="handler.name" />
            <!--</div>
        </div>
    </div>-->
</template>

<script>
export default {
    props:{
        handler:{
            name: String
        }
    }
}
</script>