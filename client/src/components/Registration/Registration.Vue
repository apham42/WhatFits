<template>
<div class="container">
  <p class="title" style="text-align: center; padding-top:1em;">Registration</p>
  <hr>
<span class="subTitleLeft">Credential Information</span>
<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">UserName</label>
  </div>
  <div class="field-body">
    <div class="field is-expanded">
      <div class="field has-addons">
        <p class="control is-expanded">
          <input class="input" type="tel" placeholder="UserName A-Z,a-z,0-9 characters only [2-64]Characters" v-model.trim="username" @input="delayTouch($v.username)" v-bind:class="{error: $v.username.$error, valid: $v.username.$dirty && !$v.username.$invalid}">
        </p>
        <br>
      </div>
       <div class="errorMessage help">
                <span  v-show="!$v.username.required && $v.username.$dirty">Field is required</span>
                <span  v-show="!$v.username.minLength && $v.username.$dirty">Username must have at least {{$v.username.$params.minLength.min}} letters</span>
                <span  v-show="!$v.username.maxLength && $v.username.$dirty">Username must have at most {{$v.username.$params.maxLength.max}} letters</span>
                <span  v-show="!validateCharacters(this.$data.username) && $v.username.$dirty && $v.username.maxLength && $v.username.minLength">Username has invalid characters</span>
        </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
        <div class="field-label is-normal">
          <label class="label">Password</label>
        </div>
        <div class="field-body has-icons-left has-icons-right">
          <input class="input" v-model.trim="password" @input="delayTouch($v.password)"  v-on:keyup="checkPassword" type="password" placeholder="Password" value="" v-bind:class="{error: $v.password.$error || this.weakPassword, valid: $v.password.$dirty && !$v.password.$invalid && !this.weakPassword}">
        </div>
      </div>
      <div class="errorMessage help">
        <span v-show="this.weakPassword === true">This is a vulnerable password. Try again.</span>
          <span v-show="!$v.password.minLength && $v.password.$dirty">Minimum length is {{$v.password.$params.minLength.min}}</span>
          <span v-show="!$v.password.maxLength && $v.password.$dirty">Maximum length is {{$v.password.$params.maxLength.max}}</span>
          <span v-show="!$v.password.required && $v.password.$dirty">A password is required</span>
          <span v-show="!validateCharacters(this.$data.password) && $v.password.$dirty && $v.password.maxLength && $v.password.minLength">Password has invalid characters</span>
        </div>
      <div class="field is-horizontal">

        <div class="field-label is-normal">
    <label class="label">Confirm Password</label>
  </div>
        <div class="field-body has-icons-left has-icons-right">
          <input class="input" type="password" placeholder="Confirm Password" v-model.trim="confirmPassword" @input="delayTouch($v.confirmPassword)" v-bind:class="{error: $v.confirmPassword.$error, valid: $v.confirmPassword.$dirty && !$v.confirmPassword.$invalid}">
        </div>
      </div>
       <div class="errorMessage help">
          <span v-show="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Passwords must be identical</span>
        </div>
      <br>
      <span class="subTitleLeft">Personal Information</span>
<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Full Name</label>
  </div>
  <div class="field-body">
    <div class="field">
      <p class="control is-expanded">
        <input class="input" type="text" placeholder="FirstName" v-model.trim="firstName" @input="delayTouch($v.firstName)" v-bind:class="{error: $v.firstName.$error, valid: $v.firstName.$dirty && !$v.firstName.$invalid}">
      </p>
          <div class="errorMessage help">
                <span v-show="!$v.firstName.required && $v.firstName.$dirty">Field is required</span>
                <span v-show="!$v.firstName.minLength && $v.firstName.$dirty">First name must have at least {{$v.firstName.$params.minLength.min}} letters</span>
                <span v-show="!$v.firstName.maxLength && $v.firstName.$dirty">First name must have at most {{$v.firstName.$params.maxLength.max}} letters</span>
                <span v-show="!validateCharacters(this.$data.firstName) && $v.firstName.$dirty && $v.firstName.maxLength && $v.firstName.minLength">First name has invalid characters</span>
            </div>
    </div>
    <div class="field">
      <p class="control is-expanded">
        <input class="input" type="text" placeholder="LastName" v-model.trim="lastName" @input="delayTouch($v.lastName)" v-bind:class="{error: $v.lastName.$error, valid: $v.lastName.$dirty && !$v.lastName.$invalid}">
      </p>
      <div class="errorMessage help">
                <span v-show="!$v.lastName.required && $v.lastName.$dirty">Field is required</span>
                <span v-show="!$v.lastName.minLength && $v.lastName.$dirty">Last name must have at least {{$v.lastName.$params.minLength.min}} letters</span>
                <span v-show="!$v.lastName.maxLength && $v.lastName.$dirty">Last name must have at most {{$v.lastName.$params.maxLength.max}} letters</span>
                <span v-show="!validateCharacters(this.$data.lastName) && $v.lastName.$dirty && $v.lastName.maxLength && $v.lastName.minLength">Last name has invalid characters</span>
            </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Address</label>
  </div>
  <div class="field-body">
    <div class="field is-expanded">
      <div class="field has-addons">
        <p class="control is-expanded">
          <input class="input" type="address" placeholder="Address must be in LA or Orange County" v-model.trim="address" @input="delayTouch($v.address)" v-bind:class="{error: $v.address.$error, valid: $v.address.$dirty && !$v.address.$invalid}">
        </p>
        <div class="errorMessage help">
                <span v-show="!$v.address.maxLength && $v.address.$dirty">Maximum length is {{$v.address.$params.maxLength.max}}</span>
                <span v-show="!$v.address.required && $v.address.$dirty">Field is required</span>
        </div>
      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">City</label>
  </div>
  <div class="field-body">
    <div class="field is-expanded">
      <div class="field has-addons">
        <p class="control is-expanded">
          <input class="input" type="address" placeholder="City" v-model.trim="city" @input="delayTouch($v.city)" v-bind:class="{error: $v.city.$error, valid: $v.city.$dirty && !$v.city.$invalid}">
        </p>
          <div class="errorMessage help">
                <span v-show="!$v.city.maxLength && $v.city.$dirty">Maximum length is {{$v.city.$params.maxLength.max}}</span>
                <span v-show="!$v.city.required && $v.city.$dirty">Field is required</span>
            </div>

      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">State</label>
  </div>
  <div class="field-body">
    <div class="field is-expanded">
      <div class="field has-addons">
        <p class="control is-expanded">
          <input class="input" type="address" placeholder="State"  v-model.trim="state" @input="delayTouch($v.state)" v-bind:class="{error: $v.state.$error, valid: $v.state.$dirty && !$v.state.$invalid}">
        </p>
          <div class="errorMessage help">
                <span v-show="!$v.state.maxLength && $v.state.$dirty">Maximum length is {{$v.state.$params.maxLength.max}}</span>
                <span v-show="!$v.state.required && $v.state.$dirty">Field is required</span>
            </div>

      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">ZipCode</label>
  </div>
  <div class="field-body">
    <div class="field is-expanded">
      <div class="field has-addons">
        <p class="control is-expanded">
          <input class="input" type="address" placeholder="Zipcode" v-model.trim="zipCode" @input="delayTouch($v.zipCode)" v-bind:class="{error: $v.zipCode.$error, valid: $v.zipCode.$dirty && !$v.zipCode.$invalid}">
          </p>
          <div class="errorMessage help">
                <span v-show="!$v.zipCode.maxLength && $v.zipCode.$dirty">Maximum length is {{$v.zipCode.$params.maxLength.max}}</span>
                <span v-show="!$v.zipCode.minLength && $v.zipCode.$dirty">Minimum length is {{$v.zipCode.$params.minLength.min}}</span>
                <span v-show="!$v.zipCode.required && $v.zipCode.$dirty">Field is required</span>
            </div>

      </div>
    </div>
  </div>
</div>
<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Skill Level</label>
  </div>
  <div class="field-body">
    <div class="field is-narrow">
      <div class="control">
        <div class="select is-fullwidth">
           <select v-model="skill">
              <option selected disabled>Select Skill Level</option>
              <option v-for="skillLevel in skillLevels" :key="skillLevel"> {{skillLevel}} </option>
            </select>
        </div>
      </div>
    </div>
  </div>
</div>
<span class="subTitleLeft">Password Recovery</span>
<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Security Question 1</label>
  </div>
  <div class="field-body">
    <div class="field">
      <div class="control">
        <!-- <input class="input" type="text" placeholder="e.g. Partnership opportunity"> -->
         <select class="select is-fullwidth" v-model="securityQues1">
                  <option disabled value ="">Select A Question</option>
                  <option v-for="securityQuestion1 in securityQuestionSet1" :key="securityQuestion1"> {{securityQuestion1}} </option>
                </select>
                <input class="input" type="text" placeholder="Answer" v-model.trim="answerToSecQues1" @input="delayTouch($v.answerToSecQues1)" v-bind:class="{error: $v.answerToSecQues1.$error, valid: $v.answerToSecQues1.$dirty && !$v.answerToSecQues1.$invalid}">
            <div class="errorMessage help">
                <span v-show="!$v.answerToSecQues1.maxLength && $v.answerToSecQues1.$dirty">Maximum length is {{$v.answerToSecQues1.$params.maxLength.max}}</span>
                <span v-show="!$v.answerToSecQues1.required && $v.answerToSecQues1.$dirty">Field is required</span>
                <span v-show="$v.answerToSecQues1.$dirty && securityQues1 == ''">Must select a question</span>
            </div>
      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Security Question 2</label>
  </div>
  <div class="field-body">
    <div class="field">
      <div class="control">
         <select class="select is-fullwidth" v-model="securityQues2">
                  <option disabled value ="">Select A Question</option>
                  <option v-for ="securityQuestion2 in securityQuestionSet2" :key ="securityQuestion2"> {{securityQuestion2}} </option>
                </select>
                <input class="input" type="text" placeholder="Answer" v-model.trim="answerToSecQues2" @input="delayTouch($v.answerToSecQues2)" v-bind:class="{error: $v.answerToSecQues2.$error, valid: $v.answerToSecQues2.$dirty && !$v.answerToSecQues2.$invalid}">
            <div class="errorMessage help">
                <span v-show="!$v.answerToSecQues2.maxLength && $v.answerToSecQues2.$dirty">Maximum length is {{$v.answerToSecQues2.$params.maxLength.max}}</span>
                <span v-show="!$v.answerToSecQues2.required && $v.answerToSecQues2.$dirty">Field is required</span>
                <span v-show="$v.answerToSecQues2.$dirty && securityQues2 == ''">Must select a question</span>
            </div>
      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Security Question 3</label>
  </div>
  <div class="field-body">
    <div class="field">
      <div class="control">
        <!-- <input class="input" type="text" placeholder="e.g. Partnership opportunity"> -->
         <select class="select is-fullwidth" v-model="securityQues3">
                  <option disabled value ="">Select A Question</option>
                  <option v-for="securityQuestion3 in securityQuestionSet3" :key="securityQuestion3"> {{securityQuestion3}} </option>
                </select>
                <input class="input" type="text" placeholder="Answer" v-model.trim="answerToSecQues3" @input="delayTouch($v.answerToSecQues3)" v-bind:class="{error: $v.answerToSecQues3.$error, valid: $v.answerToSecQues3.$dirty && !$v.answerToSecQues3.$invalid}">
            <div class="errorMessage help">
                <span v-show="!$v.answerToSecQues3.maxLength && $v.answerToSecQues3.$dirty">Maximum length is {{$v.answerToSecQues3.$params.maxLength.max}}</span>
                <span v-show="!$v.answerToSecQues3.required && $v.answerToSecQues3.$dirty">Field is required</span>
                <span v-show="$v.answerToSecQues3.$dirty && securityQues3 == ''">Must select a question</span>
            </div>
      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-body">
    <div class="field">
      <div class="control">
        <label class="checkbox" style="padding-left: 18%;">
          <input type="checkbox" name="terms" v-model = termsChecked>
          I agree to the <a @click="showTerms = true">terms and conditions</a>
        </label>
      </div>
    </div>
  </div>
</div>

<div class="field is-horizontal">
  <div class="field-label">

  </div>
  <div class="field-body">
    <div class="field">
      <div class="control">
        <button type="submit" class="button is-primary" :disabled="!termsChecked || $v.$invalid || this.weakPassword || !validateCharacters(this.$data.username) || !validateCharacters(this.$data.firstName) || !validateCharacters(this.$data.lastName) || !validateCharacters(this.$data.password)" @click.prevent="registerUser">Register</button>
      </div>
    </div>
  </div>
</div>

<div class="termsAndCondition">
  <div v-if="showTerms">
    <div class="modal is-active">
      <div class="modal-background" @click="showTerms = false" ></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title">Terms and Agreement</p>
        </header>
        <section class="modal-card-body">
          <Terms></Terms>
        </section>
        <footer class="modal-card-foot">
          <div class="closeModal">
           <button class="button" @click="showTerms = false">Cancel</button>
          </div>
        </footer>
      </div>
    </div>
  </div>
</div>

<div class="termsAndCondition">
  <div v-if="this.showSuccess">
    <reg-success></reg-success>
  </div>
</div>

<div class="errorResponse">
    <p v-for="message in messages[0]" :key="message"> {{message}} </p>
</div>
</div>

</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
import axios from 'axios'
import Terms from '@/components/Registration/Terms'
import sha1 from 'sha1'
import debounce from 'debounce'
import RegisterSuccess from '@/components/Registration/RegisterSuccess'

const touchMap = new WeakMap()

export default {
  name: 'Registration',

  components: {
    'Terms': Terms,
    'reg-success': RegisterSuccess
  },

  data: function () {
    return {
      showSuccess: false,
      weakPassword: false,
      pageTitle: 'Registration',
      username: '',
      firstName: '',
      lastName: '',
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
      skill: '',
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
      messages: [],
      skillLevels: ['Beginner', 'Intermediate', 'Advanced'],
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
    firstName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(64)
    },
    lastName: {
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
    },
    skill: {
      required
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
    checkPassword: debounce(function (e) {
      // Hashes the password to SHA1 for webservice consumption
      if (this.password.length < 8) {
        return
      }
      var hashedPassword = sha1(this.password)
      // Parsing the hash into two variables, one to be send and one to be compared
      var preffix = hashedPassword.substring(0, 5)
      var suffix = hashedPassword.slice(5)
      // Creating GET request to pwnedpassword service
      axios({
        method: 'GET',
        url: 'https://api.pwnedpasswords.com/range/' + preffix
      })
        .then(response => {
          var payload = response.data
          // Process Results
          var suffixList = payload.split('\n')
          for (var i = 0; i < suffixList.length; i++) {
            var row = suffixList[i].split(':')
            if (suffix === row[0].toLowerCase()) {
              if (row[0] < 250) {
                this.weakPassword = false
                return
              } else {
                this.weakPassword = true
                return
              }
            }
          }
          this.weakPassword = false
        })
        .catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.statusMessages = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.statusMessages = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.statusMessages = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }, 1000),
    // Checks the characters of userInput
    validateCharacters (userInput) {
      var regexPattern = /[^ 0-9a-zA-Z!@#$%^/&*()-_=+{}[;:"'<,>.?|`~\\]]/i
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
        url: this.$store.getters.getURL + 'v1/SignUp/Register',
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
          UserProfile: {
            firstName: this.$data.firstName,
            lastName: this.$data.lastName,
            skill: this.$data.skill,
            userType: 'Enable'
          }
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages.push(response.data.Messages)
          this.showSuccess = true
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.$data.messages = []
          this.$data.messages.push(error.response.data.Messages)
        })
    }
  }

}
</script>

<style scoped>
.subTitleLeft {
  text-align: left;
  font-size: 18px;
}
.error {
  border-color: red;
  background: #FDD;
}
.error:focus {
  outline-color: #F99;
}
.valid {
  border-color: #5A5;
  background: #EFE;
}
.valid:focus {
  outline-color: #8E8;
}
.successMessage {
  color: Green;
  text-align: center;
}
.errorMessage {
  color: red;
  text-align: center;
}
</style>
