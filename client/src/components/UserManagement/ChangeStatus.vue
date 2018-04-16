<template>
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
                <input v-model="userNameStatus" class="input" type="text" placeholder="UserName">
            </div>
            <div class="control">
                <button type="submit" class="button is-primary" @click.prevent="changeStatus">Apply {{status}}</button>
            </div>
        </div>
        <div v-if="this.$data.changeStatusError == true" class="errorMessage">
            <span>{{this.$data.response.changeStatus}}</span>
        </div>
        <div v-if="this.$data.changeStatusError == false" class="successMessage">
            <span>{{this.$data.response.changeStatus}}</span>
        </div>
        <br />
    </form>
</template>
<script>
import axios from 'axios'
module.exports = {
  name: 'ChangeStatus',
  data () {
    return {
      selected: '',
      userName: ''
    }
  },
  methods: {
    changeStatus: function () {
      if (!validateUserName(this.$data.userNameStatus) || this.$data.status === '') {
        this.$data.response.changeStatus = 'Invalid username and/or status'
        this.$data.changeStatusError = true
        return false
      }
      if (this.$data.status === 'enable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/enable',
          data: {'UserName': this.$data.userNameStatus},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(function (response) {
            console.log(response.data)
          })
          .catch(error => {
            if (error.response) {
              this.$data.response.changeStatus = 'An error occured, server response was bad.'
              this.$data.changeStatusError = true
              console.log(error.response)
            } else if (error.request) {
              this.$data.response.changeStatus = 'An error occured, no response from server.'
              this.$data.changeStatusError = true
              console.log(error.request)
            } else {
              this.$data.response.changeStatus = 'An error occured while setting up request.'
              this.$data.changeStatusError = true
              console.log('Error: ', error.message)
            }
          })
      } else if (this.$data.status === 'disable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/disable',
          data: {'UserName': this.$data.userNameStatus},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(function (response) {
            console.log(response.data)
            this.$data.changeStatusError = false
          })
          .catch(error => {
            if (error.response) {
              this.$data.response.changeStatus = 'An error occured, server response was bad.'
              this.$data.changeStatusError = true
              console.log(error.response)
            } else if (error.request) {
              this.$data.response.changeStatus = 'An error occured, no response from server.'
              this.$data.changeStatusError = true
              console.log(error.request)
            } else {
              this.$data.response.changeStatus = 'An error occured while setting up request.'
              this.$data.changeStatusError = true
              console.log('Error: ', error.message)
            }
          })
      } else {
        console.log('Error: Invalid Status')
      }
    }
  }
}
function validateUserName (userName) {
  if (userName.length < 2 || userName.length > 64) {
    return false
  } else {
    return true
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
