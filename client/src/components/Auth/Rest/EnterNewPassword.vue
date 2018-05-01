<template>
    <div>
        <div id="inputnewpass" class="field">
            <p class="control has-icons-left">
              <input class="input is-small" v-model="newPassword" @input="delayTouch($v.newPassword)" v-bind:class="{error: $v.newPassword.$error, valid: $v.newPassword.$dirty && !$v.newPassword.$invalid}" type="Password" placeholder="New Password" @keyup.enter="CreateNewPassword">
            </p>
            <div class="errorMessage">
              <span v-show="!$v.newPassword.required && $v.newPassword.$dirty">Password is required</span>
            </div>
        </div>
        <button class="button is-primary" @click="CreateNewPassword" :disabled="$v.$invalid">Submit New Password</button>
        <p v-if="incorrectPass" class="help is-danger">Invalid Password</p>
    </div>
</template>
<script>
import axios from 'axios'
import {required} from 'vuelidate/lib/validators'
const touchMap = new WeakMap()
export default {
  name: 'EnterNewPassword',
  props: ['IncommingUsername'],
  data () {
    return {
      incorrectPass: false,
      username: this.IncommingUsername.username,
      newPassword: ''
    }
  },
  validations: {
    newPassword: {
      required
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
    CreateNewPassword: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/ResetPassword/SetPassword',
        headers: this.$store.getters.getheader,
        data: {
          Username: this.$data.username,
          Password: this.$data.newPassword
        }
      })
        .then((response) => {
          console.log(response)
          this.$router.push('/')
        })
        .catch((error) => {
          console.log(error)
        })
    }
  }
}
</script>

<style scoped>
#lock {
  font-size: 7em;
  align-items: center;
}
#inputnewpass {
  padding-left: 10%;
  padding-right: 10%;
}
</style>
