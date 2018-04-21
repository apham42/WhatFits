<template>
   <div id="loginModal" class="modal is-active">
      <div id="background" class="modal-background" @click="closeModal"></div>
      <div class="modal-content">
         <div class="box has-text-centered">
            <img id="loginImage" src="../../assets/Images/NavbarLogo/navbarLogo.png">
            <div class="field">
               <p class="control has-icons-left">
                  <input class="input" v-model="username" id="username" type="text" placeholder="Username">
                  <span v-show="!$v.username.required && $v.username.$dirty">Field is required</span>
                  <span class="icon is-small is-left">
                  <i class="fa fa-user"></i>
                  </span>
               </p>
            </div>
            <div class="field">
               <p class="control has-icons-left">
                  <input class="input" v-model="password" id="password" type="password" placeholder="Password">
                  <span v-show="!$v.password.required && $v.password.$dirty">Field is required</span>
                  <span class="icon is-small is-left">
                  <i class="fa fa-lock"></i>
                  </span>
               </p>
            </div>
            <p v-show="invalid" class="help is-danger">Invalid Credentials</p>
            <button id="loginbutton" class="button is-primary" @click="sendUserCredential">Login</button>
            <button id="cancelbutton" class="button" @click="closeModal">Cancel</button>
         </div>
      </div>
   </div>
</template>

<script>
import { required, minLength, maxLength } from 'vuelidate/lib/validators'
import axios from 'axios'
export default {
  name: 'LoginModal',
  components: {
  },
  data () {
    return {
      username: '',
      password: '',
      invalid: false
    }
  },
  methods: {
    closeModal: function () {
      this.$store.dispatch('closeAction')
    },
    sendUserCredential: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/login/Login',
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        },
        data: {
          Username: this.$data.username,
          Password: this.$data.password
        }
      })
        .then((response) => {
          this.$store.dispatch('actusername', {Username: response.data.username})
          this.$store.dispatch('acttoken', {Token: response.data.token})
          this.$store.dispatch('actviewclaims', {Viewclaims: response.data.viewclaims})
          this.$router.push('/profile')
          this.$store.dispatch('closeAction')
          console.log(response)
        })
        .catch((error) => {
          console.log(error)
          // console.log('error')
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
      required,
      maxLength: maxLength(64),
      minLength: minLength(8)
    }
  }
}
</script>

<style>
#loginImage {
  height: 70px;
  padding-left: 20px;
  padding-top: 5px;
}
#loginModal {
  background: none;
}
</style>
