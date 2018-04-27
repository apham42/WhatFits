<template>
  <div>
    <div v-if="this.nextComp == false">
      <i id="lock" class="fas fa-lock"></i>
      <br>
      <br>
      <div id="inputnewpass" class="field">
          <p class="control has-icons-left">
          <input class="input is-small" v-model="usernamePassReset" type="text" placeholder="Username" @keyup.enter="GetQuestions">
          <span class="icon is-small is-left">
          <i class="fa fa-user"></i>
          </span>
          </p>
      </div>
      <button class="button is-primary" @click="GetQuestions">Reset Password</button>
      <p v-if="noUsers" class="help is-danger">Invalid Credentials</p>
    </div>
    <div>
      <AnswerQuestions v-if="nextComp == true" :Questions="sentQuestions"></AnswerQuestions>
    </div>
  </div>
</template>
<script>
import axios from 'axios'
import AnswerQuestions from '@/components/Auth/Rest/AnswerQuestions'
export default {
  name: 'EnterUsername',
  components: {
    'AnswerQuestions': AnswerQuestions
  },
  data () {
    return {
      usernamePassReset: '',
      noUsers: false,
      questions: null,
      nextComp: false,
      sentQuestions: {
        Username: '',
        incommingQs: null
      }
    }
  },
  methods: {
    GetQuestions: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/ResetPassword/GetQuestions',
        headers: this.$store.getters.getheader,
        data: {
          Username: this.$data.usernamePassReset
        }
      })
        .then((response) => {
          console.log(response)
          this.$data.questions = response.data
          this.$data.sentQuestions.Username = this.$data.usernamePassReset
          this.$data.sentQuestions.incommingQs = response.data.Questions
          this.$data.nextComp = true
        })
        .catch((error) => {
          this.$data.noUsers = true
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
