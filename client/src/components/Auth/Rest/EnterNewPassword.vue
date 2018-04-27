<template>
    <div>
        <div id="inputnewpass" class="field">
            <p class="control has-icons-left">
            <input class="input is-small" v-model="newPassword" type="Password" placeholder="New Password" @keyup.enter="CreateNewPassword">
            </p>
        </div>
        <button class="button is-primary" @click="CreateNewPassword">Submit New Password</button>
        <p v-if="incorrectPass" class="help is-danger">Invalid Password</p>
    </div>
</template>
<script>
import axios from 'axios'
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
  methods: {
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
