<template>
   <div>
      <nav class="navbar is-radiusless">
         <div class="container">
            <div class="navbar-brand">
               <a>
               <img id="navImage" src="../../assets/Images/NavbarLogo/navbarLogo.png" alt="Go to Whatfits Home" @click="toHome">
               </a>
               <span class="navbar-burger burger" data-target="navbarMenuHero2" @click="showham = !showham">
               <span></span>
               <span></span>
               <span></span>
               </span>
            </div>
            <div v-if="showham" id="navbarMenuHero2" class="navbar-menu is-active is-radiusless">
            <div class="navbar-end">
              <a class="navbar-item" @click="openModal">
                Login
              </a>
              <a class="navbar-item" @click="toRegistration">
                Registration
              </a>
            </div>
          </div>
            <div id="navbarMenuHero1" class="navbar-menu">
               <div class="navbar-end">
                  <a class="navbar-item" @click="toRegistration">
                  Registration
                  </a>
                  <span class="navbar-item">
                  <button id="button" class="button is-primary is-inverted" @click="openModal">
                  <span class="icon">
                  <i class="fa fa-sign-in-alt"></i>
                  </span>
                  <span>Login</span>
                  </button>
                  </span>
               </div>
            </div>
         </div>
      </nav>
      <LoginModal v-if="showLogin"></LoginModal>
   </div>
</template>

<script>
import LoginModal from '@/components/Auth/LoginModal.vue'
export default {
  name: 'HomeNavBar',
  components: {
    'LoginModal': LoginModal
  },
  computed: {
    showLogin: function () {
      return this.$store.getters.popupStatus
    }
  },
  data () {
    return {
      showham: false
    }
  },
  methods: {
    toRegistration: function () {
      this.$data.showham = false
      this.$router.push('signup')
    },
    toHome: function () {
      this.$router.push('/')
    },
    openModal: function () {
      this.$data.showham = false
      this.$store.dispatch('openAction')
    }
  }
}
</script>

<style>
#closebutton {
  margin-top: 45px;
}
#cancel {
  margin-top: -36px;
}
#navImage {
  height: 50px;
  padding-left: 20px;
  padding-top: 5px;
}
#homeIcons{
    height: 10em;
    width: 10em;
    padding-top: 2em;
}
</style>
