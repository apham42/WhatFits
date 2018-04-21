<template>
<div>
  <span class="control backButton">
    <a class="button is-link " @click="goBack" >Back</a>
  </span>
</div>

</template>
<script>

export default {
  name: 'BackButton',
  data () {
    return {

    }
  },
  methods: {
    goBack: function () {
      this.$router.go(-1)
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
.backButton {
      padding-left: 50%;
  }
</style>
