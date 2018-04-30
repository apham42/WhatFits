<template>
  <div id="app">
    <NavBar></NavBar>
    <router-view></router-view>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue'
// import axios from 'axios'
export default {
  name: 'App',
  components: {
    'NavBar': NavBar
  }
}
</script>

<style src="./assets/CSS/Globaltheme/bulmaTheme.css">

</style>
