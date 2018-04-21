<template>
    <div>
      <p>Hello</p>
      <p> {{ ShowUsername }} </p>
      <p> {{ GetToken }} </p>
      <p> {{ GetViewClaims }} </p>
    </div>
</template>

<script>
export default {
  computed: {
    ShowUsername: function () {
      return this.$store.getters.getusername
    },
    // remove get token function just for testing
    GetToken: function () {
      return this.$store.getters.gettoken
    },
    GetViewClaims: function () {
      return this.$store.getters.getviewclaims
    }
  }
}
</script>

<style>

</style>
