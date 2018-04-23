<template>
<div>
    <i id="lock" class="fas fa-lock"></i>
    <br>
    <br>
    <div id="inputnewpass" class="field">
        <p class="control has-icons-left">
        <input class="input is-small" v-model="username" type="text" placeholder="Username">
        <span class="icon is-small is-left">
        <i class="fa fa-user"></i>
        </span>
        </p>
    </div>
    <button class="button is-primary">Reset Password</button>
</div>
</template>
<script>
export default {
  name: 'PasswordReset',
  data () {
    return {
      Question1: 'q1',
      Answer1: '',
      Question2: 'q2',
      Answer2: '',
      Question3: 'q3',
      Answer3: ''
    }
  },
  methods: {
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
