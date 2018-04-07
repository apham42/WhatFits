<template>
<div>
   <h1>{{pageTitle}}</h1>
   <p> An Error Occured</p>
</div>
</template>

<script>
export default {
  name: 'ErrorPage',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'Error Page',
      hasErrored: false
    }
  },
  methods: {
  }
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
button:hover {
    cursor: pointer;
}
</style>
