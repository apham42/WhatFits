<template>
 <div id="navbarExampleTransparentExample" class="navbar-menu">
    <div class="navbar-start">
        <a class="navbar-item" href="http://localhost:8081">
        Home
      </a>
        <a class="navbar-item" href="http://localhost:8081">
        About
      </a>
    </div>
    <div class="navbar-end">
        <div class="navbar-item">
            <div class="field is-grouped">
                <p class="control">
                    <a class="button" @click="showLogin = true">
              <span class="icon">
                <i class="fas fa-sign-in-alt"></i>
              </span>
              <span>Login</span>
            </a>
                </p>
            </div>
        </div>
    </div>
    <div v-if="showLogin">
        <div class="modal is-active">
            <div class="modal-background" @click="showLogin = false"></div>
            <div class="modal-content">
                <div class="box">
                    <Login></Login>
                    <div class="level-left">
                        <a id="cancel" class="button is-danger" @click="showLogin = false">Cancel</a>
                    </div>
                </div>
            </div>
            <button id="closebutton" class="modal-close is-large" aria-label="close" @click="showLogin = false"></button>
        </div>
    </div>
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
