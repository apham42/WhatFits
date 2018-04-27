<template>
    <div>
      <div v-if="nextComponent == false">
        <p>Question: {{ Question1 }}</p>
        <div id="Answer1" class="field">
          <p class="control has-icons-left">
          <input class="input is-small" v-model="A1" type="text" placeholder="Username">
          </p>
        </div>
        <p>Question: {{ Question2 }}</p>
        <div id="Answer2" class="field">
            <p class="control has-icons-left">
            <input class="input is-small" v-model="A2" type="text" placeholder="Username">
            </p>
        </div>
        <p>Question: {{ Question3 }}</p>
        <div id="Answer3" class="field">
            <p class="control has-icons-left">
            <input class="input is-small" v-model="A3" type="text" placeholder="Username">
            </p>
        </div>
        <button class="button is-primary" @click="EnterAnswers">Submit</button>
      </div>
      <p v-if="failanswer == true" class="help is-danger">Incorrect Answers!</p>
      <div>
        <EnterNewPassword v-if="nextComponent == true" :IncommingUsername="SentUsername"></EnterNewPassword>
      </div>
    </div>
</template>
<script>
import axios from 'axios'
import EnterNewPassword from '@/components/Auth/Rest/EnterNewPassword.vue'
export default {
  name: 'AnswerQuestions',
  components: {
    'EnterNewPassword': EnterNewPassword
  },
  props: ['Questions'],
  mounted: function () {
    for (var key in this.Questions.incommingQs) {
      if (this.$data.Question1 === '') {
        this.$data.Question1 = this.Questions.incommingQs[key]
      } else if (this.$data.Question2 === '') {
        this.$data.Question2 = this.Questions.incommingQs[key]
      } else if (this.$data.Question3 === '') {
        this.$data.Question3 = this.Questions.incommingQs[key]
      }
    }
  },
  data () {
    return {
      Question1: '',
      A1: '',
      Question2: '',
      A2: '',
      Question3: '',
      A3: '',
      nextComponent: false,
      failanswer: false,
      SentUsername: {
        username: ''
      }
    }
  },
  methods: {
    GetAnswersDict: function () {
      var answerlist = [this.$data.A1, this.$data.A2, this.$data.A3]
      var count = 0
      var answerdict = {}
      for (var k in this.Questions.incommingQs) {
        answerdict[k] = answerlist[count]
        count++
      }
      return answerdict
    },
    EnterAnswers: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/ResetPassword/GetAnswers',
        headers: this.$store.getters.getheader,
        data: {
          userCredential: {
            Username: this.Questions.Username,
            Password: ''
          },
          resetPasswordResponseDTO: {
            Answers: this.GetAnswersDict()
          }
        }
      })
        .then((response) => {
          console.log(response)
          this.$data.nextComponent = true
          this.$data.SentUsername.username = this.Questions.Username
        })
        .catch((error) => {
          console.log(error)
          this.$data.failanswer = true
          console.log(this.GetAnswersDict())
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
