<template>
  <div class = "container">
    <h1>Whatfits</h1>
  </div>
</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
export default {
  name: 'Home',

  data: function () {
    return {
      username: '',
      isNameValid: false,
      password: '',
      isPassValid: false,
      response: ''
    }
  },

  // validations based on business rules
  validations: {
    username: {
      required
    },
    password: {
      required,
      maxLength: maxLength(64),
      minLength: minLength(8)
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs('password')
    }
  }
}

</script>

<style>
.form.h2{
    float: left;
    clear: right;
}
.form.input{
    float: right;
}
</style>
