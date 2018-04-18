<template>
  <div>
    <HomeNavBar v-if="showNavBar"></HomeNavBar>
  </div>
</template>

<script>
import HomeNavBar from '@/components/NavBar/HomeNavBar.vue'
export default {
  name: 'NavBar',
  components: {
    'HomeNavBar': HomeNavBar
  },
  computed: {
    showNavBar: function () {
      return this.$route.name === 'Home' || this.$route.name === 'Registration'
    }
  },
  methods: {

  }
}
</script>

<style>
</style>
