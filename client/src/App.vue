<template>
  <div id="app">
    <NavBar></NavBar>
    <router-view/>
  </div>
</template>

<script>
import NavBar from '@/components/NavBar.vue'
// import axios from 'axios'
export default {
  name: 'App',
  components: {
    'NavBar': NavBar
  },
  mounted: function () {
    window.onunload = this.leaving
  },
  methods: {
    // leaving: function () {
    //   console.log('WHY THE FUCK IS THIS NOT WORKING LIKE WTF THE FUCK')
    //   axios({
    //     method: 'POST',
    //     url: 'http://localhost/server/v1/logout/sendToBlackList',
    //     headers: {
    //       'Access-Control-Allow-Origin': 'http://localhost:8080',
    //       'Content-Type': 'application/json'
    //     },
    //     data: {
    //       Username: this.$store.getters.getusername,
    //       Token: this.$store.getters.gettoken
    //     }
    //   })
    //     .then((response) => {
    //       console.log(response)
    //     })
    //     .catch((error) => {
    //       console.log(error)
    //     })
    // }
  }
}
</script>

<style src="./assets/CSS/Globaltheme/bulmaTheme.css">
#app {
}
</style>
