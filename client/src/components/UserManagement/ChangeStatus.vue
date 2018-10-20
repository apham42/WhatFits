<template>
<div>
  <h3 class="SectionTitle">Change Status of User</h3>
  <form name="ChangeStatus" action="http://localhost/server/v1/management/*" method="PUT">
      <div class="field has-addons has-addons-centered">
        <div class="control">
          <span class="select">
            <select v-model="status">
              <option selected="selected" disabled value="">Select Status</option>
              <option value="enable">Enable</option>
              <option value="disable">Disable</option>
            </select>
          </span>
        </div>
        <div class="control">
          <input v-model.trim="userName" @input="delayTouch($v.userName)" class="input" type="text" placeholder="UserName">
        </div>
        <div class="control">
          <button type="submit" class="button is-primary" @click.prevent="changeStatus">Apply {{status}}</button>
        </div>
      </div>
      <div class="errorMessage">
        <span v-show="!$v.userName.required && $v.userName.$dirty">A UserName is required</span>
        <span v-show="!$v.userName.minLength && $v.userName.$dirty">Username must have at least {{$v.userName.$params.minLength.min}} letters</span>
        <span v-show="!$v.userName.maxLength && $v.userName.$dirty">Username must have at most {{$v.userName.$params.maxLength.max}} letters</span>
        <span v-show="!validateCharacters(this.$data.userName) && $v.userName.$dirty && $v.userName.maxLength && $v.userName.minLength">Username has invalid characters</span>
      </div>
      <div v-if="this.errorFlag == true" class="errorMessage">
          <span>{{this.responseMessage}}</span>
      </div>
      <div v-if="this.errorFlag == false" class="successMessage">
          <span>{{this.responseMessage}}</span>
      </div>
      <br />
  </form>
</div>
</template>
<script>
import axios from 'axios'
import { required, minLength, maxLength } from 'vuelidate/lib/validators'
const touchMap = new WeakMap()

export default {
  name: 'ChangeStatus',
  data () {
    return {
      userName: '',
      status: '',
      responseMessage: '',
      errorFlag: ''
    }
  },
  validations: {
    userName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(64)
    }
  },
  methods: {
    // Registration methods
    // Checks the characters of userInput
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 1000))
    },

    // Checks the characters of userInput
    validateCharacters (userInput) {
      var regexPattern = /[^ 0-9a-zA-Z!@#$%^&*()-_=+{}[;:"'<,>.?|`~]/i
      if (userInput.match(regexPattern) == null) {
        return true
      } else {
        return false
      }
    },
    changeStatus: function () {
      if (this.status === 'enable') {
        axios({
          method: 'PUT',
          url: this.$store.getters.getURL + 'v1/UserManagement/EnableUser',
          data: {'UserName': this.userName},
          headers: this.$store.getters.getheader
        })
          .then(response => {
            this.responseMessage = response.data
            this.errorFlag = false
          })
          .catch(error => {
            if (error.response) {
              // Server responded with a status code outside of 2xx
              this.responseMessage = 'Error: ' + error.response.data
              this.errorFlag = true
            } else if (error.request) {
              // Request was made but no response
              this.responseMessage = 'Error: ' + error.response.data
              this.errorFlag = true
            } else {
              // Something happened when setting up request
              this.responseMessage = 'An error occured while setting up request.'
              this.errorFlag = true
            }
          })
      } else if (this.status === 'disable') {
        axios({
          method: 'PUT',
          url: this.$store.getters.getURL + 'v1/UserManagement/DisableUser',
          data: {
            'UserName': this.userName
          },
          headers: this.$store.getters.getheader
        })
          .then(response => {
            this.responseMessage = response.data
            this.errorFlag = false
          })
          .catch(error => {
            if (error.response) {
              this.responseMessage = 'Error: ' + error.response.data
              this.errorFlag = true
            } else if (error.request) {
              this.responseMessage = 'Error: ' + error.response.data
              this.errorFlag = true
            } else {
              this.responseMessage = 'An error occured while setting up request.'
              this.errorFlag = true
            }
          })
      } else {
      }
    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .SectionTitle {
      text-align: left;
      font-size: 2em;
      padding-left: 5%;
  }
  .successMessage {
      color: Green;
      text-align: center;
  }
  .errorMessage {
      color: red;
      text-align: center;
  }
</style>
