<template>
    <div>
      <p>Hello</p>
      <p> {{ ShowUsername }} </p>
      <p> {{ GetToken }} </p>
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
    }
  }
}
</script>

<style>

</style>
