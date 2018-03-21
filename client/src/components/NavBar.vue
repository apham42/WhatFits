<template>
  <nav class="navbar is-primary">
    <div class="navbar-brand">
      <a class="navbar-item" href="http://localhost:8080">
        <img src="https://bulma.io/images/bulma-logo.png" alt="WhatFits" width="112" height="28">
      </a>
    </div>
    <HomeNavBar v-if="this.$route.name == 'HomeRegistration'"></HomeNavBar>
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
  }
}
</script>

<style>

</style>
