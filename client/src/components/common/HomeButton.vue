<template>
<div>
  <span class="control homeButton">
    <a class="button is-link " @click="goHome" >Go Home</a>
  </span>
</div>

</template>
<script>

export default {
  name: 'HomeButton',
  data () {
    return {

    }
  },
  methods: {
    goHome: function () {
      this.$router.push('/home')
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
</style>
