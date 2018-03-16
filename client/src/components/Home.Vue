<template>
  <div class = "container">
        <h1>Register for Whatfits</h1>
        <form>
            <h2>Username</h2>
            <input type = "username" placeholder = "Enter Username" v-model.trim = "username">
            <h2>Password</h2>
                <input type = "password" placeholder = "Enter Password"  v-model.trim = "password" @input="$v.password.$touch()">
                <span class="form-password-message" v-if="!$v.password.minLength">Minimum length is 8</span>
                <span class="form-password-message" v-if="!$v.password.maxLength">Maximum length is 64</span>
                <pre>{{$v.password}}</pre>
                <h2>Confirm Password</h2>
                <input type = "password" placeholder = "Confirm Password" @input="$v.confirmPassword.$touch()">
                <span class="form-password-message" v-if="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Password is not the same</span>
                <pre>{{$v.confirmPassword}}</pre>

                <div class = "checkbox">
                    LA/OC resident<input type = "checkbox" name = "resident" value = "LA/OC resident"><br>
                    18 years or older<input type = "checkbox" name = "year" value = "18 years or older">
                </div>
                <div id = "RegisterButton">
                    <router-link to = "/registration" tag = "button" @click.native = "sendCredentials" >Continue Registration</router-link>
                </div>
            </form>
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
