<template>
  <nav class="navbar is-primary">
    <div class="navbar-brand">
       <img id="navImage" src="../assets/NavbarLogo/navbarLogo.png" alt="Bulma: a modern CSS framework based on Flexbox">
    </div>
    <MainNavBar v-if="this.$route.name != 'Home'"></MainNavBar>
  </nav>
</template>

<script>
import MainNavBar from '@/components/NavBar/MainNavBar.vue'
export default {
  name: 'NavBar',
  components: {
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
