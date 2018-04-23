<template>
  <div>
      <nav class="navbar is-radiusless">
         <div class="container">
            <div class="navbar-brand">
               <a>
               <img id="navImage" src="../../assets/Images/NavbarLogo/navbarLogo.png" alt="Go to Whatfits Home">
               </a>
               <span class="navbar-burger burger" data-target="navbarMenuHero2">
               <span></span>
               <span></span>
               <span></span>
               </span>
            </div>
            <div id="navbarMenuHero1" class="navbar-menu">
               <div class="navbar-end">
                  <span class="navbar-item">
                  <button id="button" class="button is-primary is-inverted" @click="logout">
                  <span class="icon">
                  <i class="fa fa-sign-out-alt"></i>
                  </span>
                  <span>Logout</span>
                  </button>
                  </span>
               </div>
            </div>
         </div>
      </nav>
   </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'MainNavBar',
  methods: {
    logout: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/logout/logout',
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        },
        data: {
          Username: this.$store.getters.getusername,
          Token: this.$store.getters.gettoken
        }
      })
        .then((response) => {
          this.$store.dispatch('actusername', {Username: ''})
          this.$store.dispatch('acttoken', {Token: ''})
          this.$store.dispatch('actviewclaims', {Viewclaims: null})
          this.$router.push('/')
        })
        .catch((error) => {
          console.log(error)
        })
    }
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
