<template>
    <div class = "RegistrationForm">
        <form>
            <div class = "UserCredentials">
              <h3>Username</h3>
              <input id = "username" placeholder = "Enter Username" v-model.trim = "username" @input="delayTouch($v.username)">
                <div class = "usernameValidations">
                  <span v-show ="!$v.username.required && $v.username.$dirty">Field is required</span>
                  <span v-show ="!$v.username.minLength && $v.username.$dirty">Username must have at least {{$v.username.$params.minLength.min}} letters</span>
                  <span v-show ="!$v.username.maxLength && $v.username.$dirty">Username must have at most {{$v.username.$params.maxLength.max}} letters</span>
                  <span v-show = "!validateCharacters(this.$data.username) && $v.username.$dirty && $v.username.maxLength && $v.username.minLength">Username has invalid characters</span>
                </div>
              <h3>Password</h3>
              <input type = "password" id = "userPassword" placeholder = "Enter Password"  v-model.trim = "password" @input="delayTouch($v.password)">
                <div class = "passwordValidations">
                  <span v-show ="!$v.password.minLength && $v.password.$dirty">Minimum length is {{$v.password.$params.minLength.min}}</span>
                  <span v-show ="!$v.password.maxLength && $v.password.$dirty">Maximum length is {{$v.password.$params.maxLength.max}}</span>
                  <span v-show ="!$v.password.required && $v.password.$dirty">Field is required</span>
                  <span v-show = "!validateCharacters(this.$data.password) && $v.password.$dirty && $v.password.maxLength && $v.password.minLength">Password has invalid characters</span>
                </div>
              <h3>Confirm Password</h3>
              <input type = "password" id = "confirmPassword" placeholder = "Confirm Password" v-model.trim = "confirmPassword" @input="delayTouch($v.confirmPassword)">
                <div class = "confirmPassValidations">
                  <span v-show ="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Passwords must be identical</span>
                </div>
              </div>

            <div class = "Location">
              <h3>Street</h3>
              <input id = "address" placeholder = "Enter Street Address" v-model.trim = "address" @input = "delayTouch($v.address)">
                <div class = "addressValidations">
                  <span v-show ="!$v.address.maxLength && $v.address.$dirty">Maximum length is {{$v.address.$params.maxLength.max}}</span>
                  <span v-show ="!$v.address.required && $v.address.$dirty">Field is required</span>
                </div>
              <h3>City</h3>
              <input id = "city" placeholder = "Enter City" v-model.trim = "city" @input = "delayTouch($v.city)">
                <div class = "cityValidations">
                  <span v-show ="!$v.city.maxLength && $v.city.$dirty">Maximum length is {{$v.city.$params.maxLength.max}}</span>
                  <span v-show ="!$v.city.required && $v.city.$dirty">Field is required</span>
                </div>
              <h3>State</h3>
              <input id = "state" placeholder = "Enter State" v-model.trim = "state" @input = "delayTouch($v.state)">
                <div class = "stateValidations">
                  <span v-show ="!$v.state.maxLength && $v.state.$dirty">Maximum length is {{$v.state.$params.maxLength.max}}</span>
                  <span v-show ="!$v.state.required && $v.state.$dirty">Field is required</span>
                </div>
              <h3>Zip Code</h3>
              <input id = "zipCode" placeholder = "Enter Zip Code" v-model.trim = "zipCode" @input = "delayTouch($v.zipCode)">
              <div class = "zipValidations">
                  <span v-show ="!$v.zipCode.maxLength && $v.zipCode.$dirty">Maximum length is {{$v.zipCode.$params.maxLength.max}}</span>
                  <span v-show ="!$v.zipCode.minLength && $v.zipCode.$dirty">Minimum length is {{$v.zipCode.$params.minLength.min}}</span>
                  <span v-show ="!$v.zipCode.required && $v.zipCode.$dirty">Field is required</span>
              </div>
            </div>
            <div class = "Security Questions">
              <h3>Security Question 1</h3>
                <select v-model ="securityQues1">
                  <option disabled value =""></option>
                  <option v-for="securityQuestion1 in securityQuestionSet1" :key="securityQuestion1"> {{securityQuestion1}} </option>
                </select>
              <input id = "firstAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues1" @input = "delayTouch($v.answerToSecQues1)">
                <div class = "secQues1Validations">
                  <span v-show ="!$v.answerToSecQues1.maxLength && $v.answerToSecQues1.$dirty">Maximum length is {{$v.answerToSecQues1.$params.maxLength.max}}</span>
                  <span v-show ="!$v.answerToSecQues1.required && $v.answerToSecQues1.$dirty">Field is required</span>
                  <span v-show ="$v.answerToSecQues1.$dirty && securityQues1 == ''">Must select a question</span>
                </div>
              <h3>Security Question 2</h3>
                <select v-model ="securityQues2">
                  <option disabled value=""></option>
                  <option v-for ="securityQuestion2 in securityQuestionSet2" :key ="securityQuestion2"> {{securityQuestion2}} </option>
                </select>
              <input id = "secondAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues2" @input = "delayTouch($v.answerToSecQues2)">
                <div class = "secQues2Validations">
                  <span v-show ="!$v.answerToSecQues2.maxLength && $v.answerToSecQues2.$dirty">Maximum length is {{$v.answerToSecQues2.$params.maxLength.max}}</span>
                  <span v-show ="!$v.answerToSecQues2.required && $v.answerToSecQues2.$dirty">Field is required</span>
                  <span v-show ="$v.answerToSecQues2.$dirty && securityQues2 == ''">Must select a question</span>
                </div>
              <h3>Security Question 3</h3>
                <select v-model="securityQues3">
                    <option disabled value=""></option>
                    <option v-for="securityQuestion3 in securityQuestionSet3" :key="securityQuestion3"> {{securityQuestion3}} </option>
                </select>
              <input id = "ThirdAnswer" placeholder = "Answer" v-model.trim = "answerToSecQues3" @input = "delayTouch($v.answerToSecQues3)">
                <div class = "secQues3Validations">
                  <span v-show ="!$v.answerToSecQues3.maxLength && $v.answerToSecQues3.$dirty">Maximum length is {{$v.answerToSecQues3.$params.maxLength.max}}</span>
                  <span v-show ="!$v.answerToSecQues3.required && $v.answerToSecQues3.$dirty">Field is required</span>
                  <span v-show ="$v.answerToSecQues3.$dirty && securityQues3 == ''">Must select a question</span>
                </div>
            </div>

            <div class = "termsAndCondition">
                <button @click = "showTerms = true">Agree To Terms and Conditions</button>
                <div v-show = "showTerms">
                  <div class="modal is-active">
                    <div class="modal-background" @click="showTerms = false"></div>
                    <div class="modal-content">
                      <Terms></Terms>
                        <div class="closeModal">
                            <a id="cancel" class="button is-danger" @click="showTerms = false">Cancel</a>
                        </div>
                    </div>
                  </div>
                </div>
            </div>

            <input type = "checkbox" name = "terms" v-model = termsChecked>

            <div class = "errorResponse">
                <p v-for="error in errors[0]" :key="error"> {{error}} </p>
            </div>

            <div class = "registerButton">
              <button type = "submit" class = "register-button" :disabled= "!termsChecked || $v.$invalid || !validateCharacters(this.$data.username) || !validateCharacters(this.$data.password)" @click = "registerUser">Register</button>
            </div>
        </form>
    </div>
</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
import axios from 'axios'
import Terms from '@/components/Terms'

const touchMap = new WeakMap()

export default {
  name: 'Registration',

  components: {
    'Terms': Terms
  },

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
        'Who was the company you first worked for?',
        'Where did you go to highschool or college?',
        'What was the name of the teacher who gave you your first failing grade?'
      ],
      securityQuestionSet2: [
        'What is your favorite song?',
        'What is your mother\'s maiden name?',
        'What is your favorite sports team?'
      ],
      securityQuestionSet3: [
        'What was the name of your first crush?',
        'What is the first name of the person you first kissed?',
        'In what city or town does your nearest sibling live?'
      ],
      termsChecked: false,
      errors: [],
      showTerms: false
    }
  }, // data
  // validations based on business rules
  validations: {
    username: {
      required,
      minLength: minLength(2),
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
    // Delay Touch delays vuelidate's $touch so error messages can be delayed
    // $v is the validation attribute
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 2000))
    },

    // Checks the characters of userInput
    validateCharacters (userInput) {
      var regexPattern = /[^ 0-9a-zA-Z!@#$%^&*()-_=+{}[;:"'<,>.?|`~]/i
      if (userInput.match(regexPattern) == null) {
        return true
      } else {
        return false
      }
    },

    // Sends the request to the server
    registerUser () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/SignUp/Register',
        data: {
          UserCredInfo: {
            username: this.$data.username,
            password: this.$data.password
          },
          SecurityQandAs: [
            {
              question: this.$data.securityQues1,
              answer: this.$data.answerToSecQues1
            },
            {
              question: this.$data.securityQues2,
              answer: this.$data.answerToSecQues2
            },
            {
              question: this.$data.securityQues3,
              answer: this.$data.answerToSecQues3
            }
          ],
          UserLocation: {
            street: this.$data.address,
            city: this.$data.city,
            state: this.$data.state,
            zipCode: this.$data.zipCode
          },
          UserType: 'General'
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$router.push('/')
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.$data.errors = []
          this.$data.errors.push(error.response.data.Messages)
        })
    }
  }
}

</script>

<style>
</style>
