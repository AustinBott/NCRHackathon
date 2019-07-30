<template>
  <div>
    <h1> Available Agents </h1>
    <ul id="example-1">
      <li v-for="item in items">
        {{ item.message }}
      </li>
    </ul>
  </div>
</template>

<script>

export default {
  computed: {
    items:function () {
      return {'a': any, 'b': any, 'c':any , 'd':any }
  },
}
</script>
