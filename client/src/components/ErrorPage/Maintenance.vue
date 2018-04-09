<template>
<div>
  <p> Maintenance Page</p>
</div>
</template>
<script>
export default {
  name: 'Maintenance',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'Maintenance',
      hasErrored: true,
      container: '',
      containerHeight: ''
    }
  },
  methods: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
