<template>
<div>
  <div id="resetcontainer" class="container">
    <div id="resetbox" class="box has-text-centered">
        <EnterUsername v-if="yo"></EnterUsername>
        <AnswerQuestions v-if="!yo"></AnswerQuestions>
        <button @click="click">Click me!</button>
    </div>
  </div>
</div>
</template>
<script>
import EnterUsername from '@/components/Auth/Rest/EnterUsername.vue'
import AnswerQuestions from '@/components/Auth/Rest/AnswerQuestions.vue'
import EnterNewPassword from '@/components/Auth/Rest/EnterNewPassword.vue'
export default {
  name: 'PasswordReset',
  components: {
    'EnterUsername': EnterUsername,
    'AnswerQuestions': AnswerQuestions,
    'EnterNewPassword': EnterNewPassword
  },
  data () {
    return {
      yo: true
    }
  },
  methods: {
    click: function () {
      if (this.$data.yo === true) {
        this.$data.yo = false
      } else {
        this.$data.yo = true
      }
    }
  }
}
</script>

<style>
#resetcontainer {
  padding-top: 10em;
  padding-right: 25%;
  padding-left: 25%;
}
</style>
