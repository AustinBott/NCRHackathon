<template>
    <div class = "card">
        <div class = "table">
            <div class = "row header"> 
               <div class = "item"> Hook: {{hook.name}}</div>
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