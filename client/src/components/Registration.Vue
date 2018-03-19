<template>
    <div class = "RegistrationForm">
        <form>
            <div class = "UserCredentials">
              <h3>Username</h3>
              <input id = "username" placeholder = "Enter Username" v-model.trim = "username" @input="delayTouch($v.username)">
                <div class = "usernameValidations">
                  <span class = "validations" v-show="!$v.username.required && $v.username.$dirty">Field is required</span>
                  <span class = "validations" v-show="!$v.username.minLength && $v.username.$dirty">Username must have at least {{$v.username.$params.minLength.min}} letters</span>
                  <span class = "validations" v-show="!$v.username.maxLength && $v.username.$dirty">Username must have at most {{$v.username.$params.maxLength.max}} letters</span>
                  <pre>{{$v.username}}</pre>
                </div>
              <h3>Password</h3>
              <input type = "password" id = "userPassword" placeholder = "Enter Password"  v-model.trim = "password" @input="delayTouch($v.password)">
                  <div class = "passwordValidations">
                    <span class = "validations" v-show="!$v.password.minLength && $v.password.$dirty">Minimum length is {{$v.password.$params.minLength.min}}</span>
                    <span class = "validations" v-show="!$v.password.maxLength && $v.password.$dirty">Maximum length is {{$v.password.$params.maxLength.max}}</span>
                    <span class = "validations" v-show="!$v.password.required && $v.password.$dirty">Field is required</span>
                    <pre>{{$v.password}}</pre>
                  </div>
              <h3>Confirm Password</h3>
              <input type = "password" id = "confirmPassword" placeholder = "Confirm Password" v-model.trim = "confirmPassword" @input="delayTouch($v.confirmPassword)">
                  <div class = "confirmPassValidations">
                    <span class = "validations" v-show="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Passwords must be identical</span>
                    <pre>{{$v.confirmPassword}}</pre>
                  </div>
              </div>

            <div class = "Location">
              <h3>Street</h3>
              <input id = "address" placeholder = "Enter Street Address" v-model.trim = "address">
              <h3>City</h3>
              <input id = "city" placeholder = "Enter City" v-model.trim = "city">
              <h3>State</h3>
              <input id = "state" placeholder = "Enter State" v-model.trim = "state">
              <h3>Zip Code</h3>
              <input id = "zipCode" placeholder = "Enter Zip Code" v-model.trim = "zipCode">
            </div>
            <div class = "Security Questions">
              <h3>Security Question 1</h3>
                <select v-model="securityQues1">
                  <option disabled value=""></option>
                  <option v-for="securityQuestion in securityQuestionSet1" :key="securityQuestion"> {{securityQuestion.question}} </option>
                </select>
              <input id = "firstAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues1">

              <h3>Security Question 2</h3>
                <select v-model="securityQues2">
                  <option disabled value=""></option>
                  <option v-for="securityQuestion in securityQuestionSet2" :key="securityQuestion"> {{securityQuestion.question}} </option>
                </select>
              <input id = "secondAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues2">

              <h3>Security Question 3</h3>
                <select v-model="securityQues3">
                    <option disabled value=""></option>
                    <option v-for="securityQuestion in securityQuestionSet3" :key="securityQuestion"> {{securityQuestion.question}} </option>
                </select>
              <input id = "ThirdAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues3">
            </div>

            <div class = "checkbox">
                <p>Agree To Terms and Conditions</p>
                <input type = "checkbox" name = "terms">
            </div>
            <button type = "submit" class = "register-button" v-on:click = "register">Register</button>
        </form>
    </div>
</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
// import Terms from '@/components/Terms'

const touchMap = new WeakMap()

export default {
  name: 'Registration',
  // component: Terms,
  data: function () {
    return {
      username: '',
      password: '',
      confirmPassword: '',
      address: '',
      city: '',
      state: '',
      zipCode: '',
      answerToSecQues1: '',
      answerToSecQues2: '',
      answerToSecQues3: '',
      securityQues1: '',
      securityQues2: '',
      securityQues3: '',
      securityQuestionSet1: [
        { question: 'Who was the company you first worked for?' },
        { question: 'Where did you go to highschool or college?' },
        { question: 'What was the name of the teacher who gave you your first failing grade?' }
      ],
      securityQuestionSet2: [
        { question: 'What is your favorite song?' },
        { question: 'What is your mother\'s maiden name?' },
        { question: 'What is your favorite sports team?' }
      ],
      securityQuestionSet3: [
        { question: 'What was the name of your first crush?' },
        { question: 'What is the first name of the person you first kissed?' },
        { question: 'In what city or town does your nearest sibling live?' }
      ]
    }
  }, // data
  // validations based on business rules
  validations: {
    username: {
      required,
      minLength: minLength(4),
      maxLength: maxLength(64)
    },
    password: {
      required,
      maxLength: maxLength(64),
      minLength: minLength(8)
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs('password')
    },
    address: {
      required,
      maxLength: maxLength(200)
    },
    city: {
      required,
      maxLength: maxLength(150)
    },
    state: {
      required,
      maxLength: maxLength(150)
    },
    zipCode: {
      required,
      minLength: minLength(5),
      maxLength: maxLength(16)
    },
    securityQues1: {
      required
    },
    securityQues2: {
      required
    },
    securityQues3: {
      required
    },
    answerToSecQues1: {
      required,
      maxLength: maxLength(150)
    },
    answerToSecQues2: {
      required,
      maxLength: maxLength(150)
    },
    answerToSecQues3: {
      required,
      maxLength: maxLength(150)
    }
  },

  methods: {
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 2000))
    },
    register () {
      this.$router.push('Home')
    }
  }
}

</script>

<style>
</style>
