<template>
    <div class = "card">
        <div class = "table">
            <div class = "row header"> 
               <input class = "item" v-model="hook.name">
            </div>
        </div>
    </div>
</template>

<script>
export default {
    props:{
        hook:{
            name: String
        }
    }
}
</script>