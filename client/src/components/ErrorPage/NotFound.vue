<template>
<div class="container">
  <div class="centerBox">
    <span id="notFoundTitle">{{pageTitle}}</span>
    <div>
      <span id="secondTitle">There's been a glitch</span>
      <br>
      <span id="descriptionDetails">Don't know what happend or how you got here. This will take you <router-link to="/">home</router-link>.</span>
    </div>

  </div>
</div>

</template>
<script>
export default {
  name: 'NotFound',
  computed: {
  },
  data () {
    return {
      pageTitle: 'Error 404 - Page Not Found'
    }
  },
  methods: {
  }
}
</script>
<style scoped>
.centerBox{
  padding-top:20%;
}
#notFoundTitle{
font-size: 5em;
}
#secondTitle{
font-size: 2em;
}
#descriptionDetails{
font-size:1.3em;
}
</style>
