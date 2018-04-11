<template>
<div>
  <p>{{pageTitle}}}</p>
</div>
</template>
<script>
import axios from 'axios'

export default {
  name: 'PasswordReset',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'Password Reset',
      hasErrored: false,
      container: '',
      containerHeight: ''
    }
  },
  methods: {
  }
}
</script>

<style scoped>

</style>
