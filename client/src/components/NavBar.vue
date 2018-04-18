<template>
  <nav class="navbar is-primary">
    <HomeNavBar v-if="this.$route.name == 'Home'"></HomeNavBar>
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
