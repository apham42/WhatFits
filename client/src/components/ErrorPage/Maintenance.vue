<template>
<div class="container">
  <div class="centerBox">
    <span id="notFoundTitle">{{pageTitle}}</span>
    <div>
      <span id="secondTitle">Just us doing some cleanup and patching stuff up</span>
      <br>
      <span id="descriptionDetails">This will take you <router-link to="/">home</router-link>.</span>
    </div>

  </div>
</div>

</template>
<script>
export default {
  name: 'Maintenance',
  computed: {
  },
  data () {
    return {
      pageTitle: 'Down for Maintainence'
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
