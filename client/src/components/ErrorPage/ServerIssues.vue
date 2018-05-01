<template>
<div class="container">
  <div class="centerBox">
    <span id="notFoundTitle">{{pageTitle}}</span>
    <div>
      <span id="secondTitle">Oh...</span>
      <br>
      <span id="descriptionDetails">Yeah...thats not suppose to happen. Something bad happend on our side. This should take you <router-link to="/">home</router-link>.</span>
    </div>

  </div>
</div>

</template>
<script>
export default {
  name: 'ServerIssues',
  computed: {
  },
  data () {
    return {
      pageTitle: 'Error 5XX - Server Error'
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
