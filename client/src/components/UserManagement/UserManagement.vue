<template>
<div>
  <br>
    <h1 class="PageTitle">{{pageTitle}}</h1>
    <br>
    <h3 class="SectionTitle">Create User</h3>
    <form name="CreateUser" id="createUser">
      <div class="field">
        <label class="label">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input " v-model.trim="userName" @input="delayTouch($v.userName)" type="text" placeholder="UserName" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-user"></i>
          </span>
          <!--
          <span class="icon is-small is-right">
          <i class="fas fa-check"></i>
          </span>
          -->
        </div>
        <div class="errorMessage">
                <span v-show="!$v.userName.required && $v.userName.$dirty">A UserName is required</span>
                <span v-show="!$v.userName.minLength && $v.userName.$dirty">Username must have at least {{$v.userName.$params.minLength.min}} letters</span>
                <span v-show="!$v.userName.maxLength && $v.username.$dirty">Username must have at most {{$v.userName.$params.maxLength.max}} letters</span>
                <span v-show="!validateCharacters(this.$data.userName) && $v.userName.$dirty && $v.userName.maxLength && $v.userName.minLength">Username has invalid characters</span>
        </div>
        <!-- <p class="help is-success">This userName is available</p>-->
      </div>
      <div class="field">
        <label class="label">Password</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input" v-model.trim="password" @input="delayTouch($v.password)" type="password" placeholder="Password" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.password.minLength && $v.password.$dirty">Minimum length is {{$v.password.$params.minLength.min}}</span>
          <span v-show="!$v.password.maxLength && $v.password.$dirty">Maximum length is {{$v.password.$params.maxLength.max}}</span>
          <span v-show="!$v.password.required && $v.password.$dirty">A password is required</span>
          <span v-show="!validateCharacters(this.$data.password) && $v.password.$dirty && $v.password.maxLength && $v.password.minLength">Password has invalid characters</span>
        </div>
        <!--<p class="help is-danger">This email is invalid</p>-->
      </div>
      <div class="field">
        <label class="label">Confirm Password</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input" v-model.trim="confirmPassword" @input="delayTouch($v.confirmPassword)" type="password" placeholder="Password" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.confirmPassword.sameAsPassword && $v.confirmPassword.$dirty">Passwords must be identical</span>
        </div>
        <!-- <p class="help is-danger">This email is invalid</p> -->
      </div>
      <div class="field">
        <label class="label">Address</label>
        <div class="control has-icons-left">
          <input class="input" v-model.trim="address" @input="delayTouch($v.address)" type="text" placeholder="Address">
          <span class="icon is-small is-left">
          <i class="fas fa-home"></i>
          </span>
        </div>
        <div class="errorMessage">
          <span v-show="!$v.address.maxLength && $v.address.$dirty">Maximum length is {{$v.address.$params.maxLength.max}}</span>
          <span v-show="!$v.address.required && $v.address.$dirty">Field is required</span>
        </div>
        <label class="label">City</label>
        <div class="control">
          <input class="input" v-model.trim="city" @input="delayTouch($v.city)" type="text" placeholder="City Name">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.city.maxLength && $v.city.$dirty">Maximum length is {{$v.city.$params.maxLength.max}}</span>
          <span v-show="!$v.city.required && $v.city.$dirty">Field is required</span>
        </div>
        <label class="label">Zipcode</label>
        <div class="control">
          <input class="input" v-model.trim="zipCode" @input="delayTouch($v.zipCode)" type="text" placeholder="Zipcode">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.zipCode.maxLength && $v.zipCode.$dirty">Maximum length is {{$v.zipCode.$params.maxLength.max}}</span>
          <span v-show="!$v.zipCode.minLength && $v.zipCode.$dirty">Minimum length is {{$v.zipCode.$params.minLength.min}}</span>
          <span v-show="!$v.zipCode.required && $v.zipCode.$dirty">Field is required</span>
        </div>
        <label class="label">State</label>
        <div class="control">
          <input class="input" v-model.trim="state" @input="delayTouch($v.state)" type="text" placeholder="State">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.state.maxLength && $v.state.$dirty">Maximum length is {{$v.state.$params.maxLength.max}}</span>
          <span v-show="!$v.state.required && $v.state.$dirty">Field is required</span>
        </div>
      </div>
      <div class="field-body">
        <label class="label">Name:</label>
            <div class="field">
              <p class="control is-expanded">
                <input class="input" type="text" placeholder="First Name" v-model.trim="firstName" @input="delayTouch($v.firstName)">
              </p>
            </div>
            <div class="errorMessage">
              <span v-show="!$v.firstName.required && $v.firstName.$dirty">First name is required</span>
              <span v-show="!$v.firstName.minLength && $v.firstName.$dirty">First name must have at least {{$v.firstName.$params.minLength.min}} letters</span>
              <span v-show="!$v.firstName.maxLength && $v.firstName.$dirty">First name can't be this long {{$v.firstName.$params.maxLength.max}} letters</span>
            </div>
            <div class="field">
              <p class="control is-expanded">
                <input class="input" type="text" placeholder="Last Name" v-model.trim="lastName" @input="delayTouch($v.lastName)">
              </p>
            </div>
            <div class="errorMessage">
              <span v-show="!$v.lastName.required && $v.lastName.$dirty">First name is required</span>
              <span v-show="!$v.lastName.minLength && $v.lastName.$dirty">Last name must have at least {{$v.lastName.$params.minLength.min}} letters</span>
              <span v-show="!$v.lastName.maxLength && $v.lastName.$dirty">Last name can't be this long {{$v.lastName.$params.maxLength.max}} letters</span>
            </div>
        </div>
         <div class="field is-horizontal">
        <div class="field-label is-normal">
            <label class="label">Skill Level</label>
        </div>
        <div class="field-body">
            <div class="field is-narrow">
                <div class="control">
                    <!--NOTE: Create lookup table of skill levels -->
                    <div class="select is-fullwidth">

                        <select v-model="skillLevel">
                            <option value="Beginner" selected>Beginner</option>
                            <option value="Intermediate">Intermediate</option>
                            <option value="Advance">Advance</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
    </div>
      <div class="field">
        <label class="label">Security Questions</label>
        <label class="label">Question #1</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues1">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion1 in securityQuestionsSet1" :key="securityQuestion1"> {{securityQuestion1}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues1" @input="delayTouch($v.answerToSecQues1)" type="text" placeholder="Answer">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues1.maxLength && $v.answerToSecQues1.$dirty">Maximum length is {{$v.answerToSecQues1.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues1.required && $v.answerToSecQues1.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues1.$dirty && securityQues1 == ''">Must select a question</span>
        </div>
      </div>
      <div class="field">
        <label class="label">Question #2</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues2">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion2 in securityQuestionsSet2" :key="securityQuestion2"> {{securityQuestion2}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues2" @input="delayTouch($v.answerToSecQues2)" type="text" placeholder="Answer">
        </div>
        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues2.maxLength && $v.answerToSecQues2.$dirty">Maximum length is {{$v.answerToSecQues2.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues2.required && $v.answerToSecQues2.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues2.$dirty && securityQues2 == ''">Must select a question</span>
        </div>

      </div>
      <div class="field">
        <label class="label">Question #3</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select v-model="securityQues3">
              <option selected disabled>Select Question</option>
              <option v-for="securityQuestion3 in securityQuestionsSet3" :key="securityQuestion3"> {{securityQuestion3}} </option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model.trim="answerToSecQues3" @input="delayTouch($v.answerToSecQues3)" type="text" placeholder="Answer">
        </div>

        <div class="errorMessage">
          <span v-show="!$v.answerToSecQues3.maxLength && $v.answerToSecQues3.$dirty">Maximum length is {{$v.answerToSecQues3.$params.maxLength.max}}</span>
          <span v-show="!$v.answerToSecQues3.required && $v.answerToSecQues3.$dirty">Field is required</span>
          <span v-show="$v.answerToSecQues3.$dirty && securityQues3 == ''">Must select a question</span>
        </div>

      </div>
      <div class="field">
        <label class="label">User Type</label>
        <div class="control">
          <div class="select" >
            <select v-model="userType">
              <option  disabled selected >Select dropdown</option>
              <option>Administrator</option>
              <option >General</option>
            </select>
          </div>
        </div>
      </div>
      <div class="field is-grouped">
        <div class="control">
          <button class="button is-primary" :disabled="$v.$invalid || !validateCharacters(this.$data.userName) || !validateCharacters(this.$data.password)" @click.prevent="createNewUser">Create {{userType}}</button>
        </div>
        <div class="control">
          <button class="button is-secondary" @click.prevent="clearForm">Clear</button>
        </div>
      </div>

      <div v-if="this.errorFlags.createUserFlag == true" class="errorMessage">
            <span class = "help">{{this.statusMessages.createUserResponse}}</span>
        </div>
        <div v-if="this.errorFlags.createUserFlag == false" class="successMessage">
            <span>{{this.statusMessages.createUserResponse}}</span>
        </div>
    </form>
    <br>
    <change-status></change-status>
    <br>
    <delete-User></delete-User>
    <br>
    <back-button></back-button>
</div>
</template>

<script>
import axios from 'axios'
import DeleteUser from '@/components/UserManagement/DeleteUser'
import ChangeStatus from '@/components/UserManagement/ChangeStatus'
import BackButton from '@/components/Common/Backbutton'
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
const touchMap = new WeakMap()

export default {
  name: 'UserManagement',
  components: {
    'delete-User': DeleteUser,
    'changeStatus': ChangeStatus,
    'back-button': BackButton
  },
  data () {
    return {
      pageTitle: 'UserManagement Console',
      // Create User Data
      userName: 'TestUser',
      password: 'asdfasdf',
      confirmPassword: '',
      address: '321 W. 119th St.',
      city: 'Los Angeles',
      state: 'California',
      zipCode: '90061',
      answerToSecQues1: 'TEST',
      answerToSecQues2: 'TEST',
      answerToSecQues3: 'TEST',
      firstName: '',
      lastName: '',
      skillLevel: '',
      securityQues1: 'Who was the company you first worked for?',
      securityQues2: 'What is your favorite song?',
      securityQues3: 'What was the name of your first crush?',
      securityQuestionsSet1: [
        'Who was the company you first worked for?',
        'Where did you go to highschool or college?',
        'What was the name of the teacher who gave you your first failing grade?'
      ],
      securityQuestionsSet2: [
        'What is your favorite song?',
        'What is your mother\'s maiden name?',
        'What is your favorite sports team?'
      ],
      securityQuestionsSet3: [
        'What was the name of your first crush?',
        'What is the first name of the person you first kissed?',
        'In what city or town does your nearest sibling live?'
      ],
      userType: '',
      terms: '',
      // Change Status Data
      changeStatusUser: {
        userName: ''
      },
      // Delete User Data
      deleteCurrentUser: {
        userName: ''
      },
      // Status Messages, displays a message on the status of the request
      // such as validation errors, request successses, and request failures.
      statusMessages: {
        createUserResponse: '',
        changeStatusResponse: '',
        deleteResponse: ''
      },
      // Error Flags, controls what is being displayed undernieth each
      errorFlags: {
        createUserFlag: false,
        changeStatusFlag: false,
        deleteUserFlag: false
      }
    }
  },
  // validations based on business rules
  validations: {
    firstName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(50)
    },
    lastName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(50)
    },
    skillLevel: {
      required
    },
    userName: {
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
    // Registration methods
    // Checks the characters of userInput
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 1000))
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
    clearForm: function () {
      this.userName = ''
      this.password = ''
      this.confirmPassword = ''
      this.address = ''
      this.city = ''
      this.state = ''
      this.zipCode = ''
      this.answerToSecQues1 = ''
      this.answerToSecQues2 = ''
      this.answerToSecQues3 = ''
      this.securityQues1 = ''
      this.securityQues2 = ''
      this.securityQues3 = ''
    },
    createNewUser: function () {
      // Validate incoming data
      if (this.userType === 'General') {
        axios({
          method: 'POST',
          url: this.$store.getters.getURL + 'v1/SignUp/Register',
          data: {
            UserCredInfo: {
              username: this.userName,
              password: this.password
            },
            SecurityQandAs: [
              {
                question: this.securityQues1,
                answer: this.answerToSecQues1
              },
              {
                question: this.securityQues2,
                answer: this.answerToSecQues2
              },
              {
                question: this.securityQues3,
                answer: this.answerToSecQues3
              }
            ],
            UserLocation: {
              street: this.address,
              city: this.city,
              state: this.state,
              zipCode: this.zipCode
            },
            UserProfile: {
              firstName: this.$data.firstName,
              lastName: this.$data.lastName,
              skill: this.$data.skillLevel,
              userType: 'Enable'
            }
          },
          headers: this.$store.getters.getheader
        })
          // redirect to Home page
          .then(response => {
            this.statusMessages.createUserResponse = 'User ' + this.userName + ' has been created.'
            this.errorFlags.createUserFlag = false
          }).catch((error) => {
          // Pushes you to an error page if something happended
            if (error.response.status === 400) {
              this.statusMessages.createUserResponse = 'There was an error processing your request'
              this.errorFlags.createUserFlag = true
            } else if (error.response.status === 404) {
              this.$router.push('/notfound')
            } else if (error.response.status === 401) {
              this.$router.push('/notAllowed')
            } else if (error.response.status === 500) {
              this.$router.push('/serverissue')
            }
          })
      } else if (this.userType === 'Administrator') {
        axios({
          method: 'POST',
          url: this.$store.getters.getURL + 'v1/UserManagement/CreateAdmin',
          data: {
            UserCredInfo: {
              username: this.userName,
              password: this.password
            },
            SecurityQandAs: [
              {
                question: this.securityQues1,
                answer: this.answerToSecQues1
              },
              {
                question: this.securityQues2,
                answer: this.answerToSecQues2
              },
              {
                question: this.securityQues3,
                answer: this.answerToSecQues3
              }
            ],
            UserLocation: {
              street: this.address,
              city: this.city,
              state: this.state,
              zipCode: this.zipCode
            },
            UserProfile: {
              firstName: this.firstName,
              lastName: this.lastName,
              skill: this.skillLevel,
              userType: 'Enable'
            }
          },
          headers: this.$store.getters.getheader
        })
          .then(response => {
            this.statusMessages.createUserResponse = 'User ' + this.userName + ' has been created.'
            this.errorFlags.createUserFlag = false
          }).catch((error) => {
          // Pushes the error messages into error to display
            if (error.response.status === 404) {
              console.log('adsfads')
              this.errorFlags.createUserFlag = true
            } else if (error.response.status === 404) {
              this.$router.push('/notfound')
            } else if (error.response.status === 403) {
              this.$router.push('/notAllowed')
            } else if (error.response.status === 500) {
              this.$router.push('/serverissue')
            }
          })
      } else {
        this.statusMessages.createUserResponse = 'Error: Must choose a valid User Type.'
        this.errorFlags.createUserFlag = true
      }
    }
  }
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped >
  button:hover {
      cursor: pointer;
  }

  .SectionTitle {
      text-align: left;
      font-size: 2em;
      padding-left: 5%;
  }

  .PageTitle {
      font-size: 2.5em;
      text-align: center;
  }

  .SubLabel {
      font-size: 4em;
      text-align: left;
  }

  .CenteredBody {
      padding-left: 12em;

  }

  #createUser {
      padding-left: 5%;
      padding-right: 5%;
  }

  .successMessage {
      color: Green;
      text-align: center;
  }

  .errorMessage {
      color: red;
      text-align: center;
  }
</style >
