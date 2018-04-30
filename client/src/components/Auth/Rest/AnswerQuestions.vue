<template>
    <div>
      <div v-if="nextComponent == false">
        <p>Question: {{ Question1 }}</p>
        <div id="Answer1" class="field">
          <input class="input is-small" v-model="A1"  @input="delayTouch($v.A1)" v-bind:class="{error: $v.A1.$error, valid: $v.A1.$dirty && !$v.A1.$invalid}" type="text" placeholder="Answer">
          <div class="errorMessage">
            <span v-show="!$v.A1.required && $v.A1.$dirty">Answer is required</span>
          </div>
        </div>
        <p>Question: {{ Question2 }}</p>
        <div id="Answer2" class="field">
            <input class="input is-small" v-model="A2"  @input="delayTouch($v.A2)" v-bind:class="{error: $v.A2.$error, valid: $v.A2.$dirty && !$v.A2.$invalid}" type="text" placeholder="Answer">
          <div class="errorMessage">
            <span v-show="!$v.A2.required && $v.A2.$dirty">Answer is required</span>
          </div>
        </div>
        <p>Question: {{ Question3 }}</p>
        <div id="Answer3" class="field">
            <input class="input is-small" v-model="A3" @input="delayTouch($v.A3)" v-bind:class="{error: $v.A3.$error, valid: $v.A3.$dirty && !$v.A3.$invalid}" type="text" placeholder="Answer" @keyup.enter="EnterAnswers">
          <div class="errorMessage">
            <span v-show="!$v.A3.required && $v.A3.$dirty">Answer is required</span>
          </div>
        </div>
        <button class="button is-primary" @click="EnterAnswers" :disabled="$v.$invalid">Submit</button>
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
import {required} from 'vuelidate/lib/validators'
const touchMap = new WeakMap()
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
  validations: {
    A1: {
      required
    },
    A2: {
      required
    },
    A3: {
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
          this.$data.failanswer = false
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
