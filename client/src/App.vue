<template>
  <div id="app">
    <NavBar></NavBar>
    <router-view/>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue'
export default {
  name: 'App',
  components: {
    'NavBar': NavBar
  }
}
</script>

<style src="./assets/CSS/Globaltheme/bulmaTheme.css">
#app {
}
</style>
