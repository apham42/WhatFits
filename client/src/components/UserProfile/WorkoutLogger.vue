<template>
<div>
  <p>{{pageTitle}}}</p>
</div>
</template>
<script>
import axios from 'axios'

export default {
  name: 'WorkoutLogger',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'Workout Logger',
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
