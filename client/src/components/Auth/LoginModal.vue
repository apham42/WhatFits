<template>
  <div class="modal is-active">
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
        <button id="loginbutton" class="button is-primary">Login</button>
        <button id="cancelbutton" class="button" @click="closeModal">Cancel</button>
      </div>
    </div>
  </div>
</template>

<script>
import { required, minLength, maxLength } from 'vuelidate/lib/validators'
export default {
  name: 'LoginModal',
  components: {
  },
  data () {
    return {
      username: '',
      password: ''
    }
  },
  methods: {
    closeModal: function () {
      this.$store.dispatch('closeAction')
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
</style>
