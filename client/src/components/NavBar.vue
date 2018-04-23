<template>
  <div>
    <HomeNavBar v-if="showNavBar"></HomeNavBar>
    <MainNavBar v-else></MainNavBar>
  </div>
</template>

<script>
import HomeNavBar from '@/components/NavBar/HomeNavBar.vue'
import MainNavBar from '@/components/NavBar/MainNavBar.vue'
export default {
  name: 'NavBar',
  components: {
    'HomeNavBar': HomeNavBar,
    'MainNavBar': MainNavBar
  },
  computed: {
    showNavBar: function () {
      return this.$route.name === 'Home' || this.$route.name === 'Registration' || this.$route.name === 'ResetPassword'
    }
  },
  methods: {

  }
}
</script>

<style>
</style>
