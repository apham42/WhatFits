<template>
 <div class="hero-head">
        <nav class="navbar">
            <div class="container">
                <div class="navbar-brand">
                    <a>
              <img id="navImage" src="../../assets/Images/LogoNavbarLogo/navbarLogo.png" alt="Logo">
            </a>
                    <span class="navbar-burger burger" data-target="navbarMenuHero1">
              <span></span>
                    <span></span>
                    <span></span>
                    </span>
                </div>
                <div id="navbarMenuHero1" class="navbar-menu">
                    <div class="navbar-end">
                        <a class="navbar-item">
                Home
              </a>
                        <a class="navbar-item">
                Examples
              </a>
                        <a class="navbar-item">
                Documentation
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
                          <a class="button is-primary is-primary">
                  <span class="icon">
                   <i class="fas fa-plus-circle"></i>
                  </span>
                        <span>Register</span>
                        </a>
                <a class="button is-primary is-inverted">
                  <span class="icon">
                   <i class="fas fa-sign-in-alt"></i>
                  </span>
                        <span>Login</span>
                        </a>

                        </span>
                    </div>
                </div>
            </div>
        </nav>
    </div>
</template>

<script>
import Login from '@/components/Auth/Login.vue'
export default {
  name: 'HomeNavBar',
  components: {
    'Login': Login
  },
  data () {
    return {
      showLogin: false
    }
  },
  methods: {
    closeLog: function () {
      this.showLogin = false
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
</style>
