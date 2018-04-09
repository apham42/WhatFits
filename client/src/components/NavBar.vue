<template>
  <nav class="navbar is-primary">
    <div class="navbar-brand">
      <h1>
        WHAT FITS
      </h1>
    </div>
    <HomeNavBar v-if="this.$route.name == 'Home'"></HomeNavBar>
    <MainNavBar v-else></MainNavBar>
  </nav>
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
  },
  methods: {
  }
}

</script>

<style>

</style>
