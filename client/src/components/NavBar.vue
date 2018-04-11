<template>
  <nav class="navbar is-primary">
    <div class="navbar-brand">
       <img id="navImage" src="../assets/NavbarLogo/navbarLogo.png" alt="Bulma: a modern CSS framework based on Flexbox">
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
#navImage {
  height: 50px;
  padding-left: 20px;
  padding-top: 5px;
}
</style>
