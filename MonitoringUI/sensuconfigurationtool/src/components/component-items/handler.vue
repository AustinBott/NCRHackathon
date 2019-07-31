<template>
    <div class = "card">
        <div class = "table">
            <div class = "row header"> 
               <div class = "item"> Handler: {{handler.name}}</div>
            </div>
        </div>
    </div>
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