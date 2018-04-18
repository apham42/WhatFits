<template>
        <nav class="navbar is-radiusless">
            <div class="container">
            <div class="navbar-brand">
                <a>
                <img id="navImage" src="../../assets/Images/NavbarLogo/navbarLogo.png" alt="Go to Whatfits Home" @click="toHome">
                </a>
                <span class="navbar-burger burger" data-target="navbarMenuHero1">
                    <span></span>
                    <span></span>
                    <span></span>
                </span>
            </div>
            <div id="navbarMenuHero1" class="navbar-menu">
                <div class="navbar-end">
                <a class="navbar-item" @click="toRegistration">
                    Registration
                </a>
                <div class="navbar-item has-dropdown is-hoverable">
                    <div class="navbar-link">
                        More
                    </div>
                    <div id="moreDropdown" class="navbar-dropdown ">
                        <a class="navbar-item " href="#">
                        <div class="level is-mobile">
                            <div class="level-left">
                            <div class="level-item">
                                <p>
                                <strong>Extensions</strong>
                                <br>
                                <small>Side projects to enhance Bulma</small>
                                </p>
                            </div>
                            </div>
                        </div>
                        </a>
                    </div>
                    </div>
                <span class="navbar-item">
                    <button class="button is-primary is-inverted" @click="openModal">
                        <span class="icon">
                            <i class="fa fa-sign-in-alt"></i>
                        </span>
                        <span>Login</span>
                        <LoginModal v-show='showLogin'></LoginModal>
                    </button>
                </span>
                </div>
            </div>
            </div>
        </nav>
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
    }
  },
  methods: {
    toRegistration: function () {
      this.$router.push('signup')
    },
    toHome: function () {
      this.$router.push('/')
    },
    openModal: function () {
      this.$store.dispatch('controlPopup', {modalStatus: true})
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
