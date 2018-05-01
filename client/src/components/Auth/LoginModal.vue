<template>
   <div id="loginModal" class="modal is-active">
      <div id="background" class="modal-background" @click="closeModal"></div>
      <div class="modal-content">
         <div id="modalbox" class="box">
            <div class="level-item has-text-centered">
              <img id="loginImage" src="../../assets/Images/NavbarLogo/navbarLogo.png">
            </div>
            <br>
            <div class="field">
               <p class="control has-icons-left">
                  <input class="input" v-model.trim="username" @input="delayTouch($v.username)" v-bind:class="{error: $v.username.$error, valid: $v.username.$dirty && !$v.username.$invalid}" id="username" type="text" placeholder="Username">
                  <span class="icon is-small is-left">
                  <i class="fa fa-user"></i>
                  </span>
               </p>
               <div class="errorMessage">
                <span v-show="!$v.username.required && $v.username.$dirty">Username is required</span>
              </div>
            </div>
            <div class="field">
               <p class="control has-icons-left">
                  <input class="input" v-model.trim="password" @input="delayTouch($v.password)" v-bind:class="{error: $v.password.$error, valid: $v.password.$dirty && !$v.password.$invalid}" id="password" type="password" placeholder="Password" @keyup.enter="sendUserCredential">
                  <span class="icon is-small is-left">
                  <i class="fa fa-lock"></i>
                  </span>
               </p>
               <div class="errorMessage">
                  <span v-show="!$v.password.required && $v.password.$dirty">Password is required</span>
               </div>
            </div>
            <div class="level-left">
              <router-link class="md-accent" to="/resetpassword" @click.native="closeModal"> Forgot Password?</router-link>
            </div>
            <div class="level-item has-text-centered">
              <p v-show="invalid" class="help is-danger">Invalid Credentials</p>
            </div>
            <div class="level-item has-text-centered is-grouped">
              <button v-if="isLoading == false" id="loginbutton" class="button is-primary is-inverted is-outlined is-grouped" @click="sendUserCredential" :disabled="$v.$invalid">Login</button>
              <button v-if="isLoading == true" id="loginbutton" class="button is-loading">Login</button>
              <button id="cancelbutton" class="button is-danger is-inverted is-grouped" @click="closeModal">Cancel</button>
            </div>
         </div>
      </div>
   </div>
</template>

<script>
import axios from 'axios'
import {required} from 'vuelidate/lib/validators'
const touchMap = new WeakMap()
export default {
  name: 'LoginModal',
  components: {
  },
  data () {
    return {
      username: '',
      password: '',
      invalid: false,
      isLoading: false
    }
  },
  methods: {
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 1000))
    },
    closeModal: function () {
      this.$store.dispatch('closeAction')
    },
    sendUserCredential: function () {
      this.$data.isLoading = true
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/login/Login',
        headers: this.$store.getters.getheader,
        data: {
          Username: this.$data.username,
          Password: this.$data.password
        }
      })
        .then((response) => {
          this.$store.dispatch('actusername', {Username: response.data.username})
          this.$store.dispatch('actviewprofile', {ViewProfile: response.data.username})
          this.$store.dispatch('acttoken', {Token: response.data.token})
          this.$store.dispatch('actviewclaims', {Viewclaims: response.data.viewclaims})
          this.$router.push('/profile')
          this.$store.dispatch('closeAction')
          this.$store.dispatch('actheadertoken', {TokenHeader: response.data.token})
          console.log(response)
        })
        .catch((error) => {
          if (error.response.status === 400) {
            // Your custom messages that appears on the screen
            this.$data.isLoading = false
            this.invalid = true
            this.username = ''
            this.password = ''
          } else if (error.response.status === 404) {
            // Redirects you to the 404 page
            this.$data.isLoading = false
            this.invalid = true
            this.username = ''
            this.password = ''
            this.$router.push('/notfound')
          } else if (error.response.status === 403) {
            // Redirects you to the Forbidden page
            this.$data.isLoading = false
            this.invalid = true
            this.username = ''
            this.password = ''
            this.$router.push('/notAllowed')
          } else if (error.response.status === 500) {
            // Redirects you to the server issue page
            this.$data.isLoading = false
            this.invalid = true
            this.username = ''
            this.password = ''
            this.$router.push('/serverissue')
          }
          this.$data.isLoading = false
          this.invalid = true
          this.username = ''
          this.password = ''
        })
    }
  },
  validations: {
    username: {
      required
    },
    password: {
      required
    }
  }
}
</script>

<style>
#loginImage {
  align-items: center;
  height: 70px;
  padding-left: 20px;
  padding-top: 5px;
}
#loginModal {
  background: none;
}
#forgotpass {
  position: left
}
#modalbox {
  background-color:#34495E;
}
#loginbutton {
  margin-right: 15px;
}
.errorMessage {
      color: red;
      text-align: center;
  }
  .error {
  border-color: red;
  background: #FDD;
  }
</style>
