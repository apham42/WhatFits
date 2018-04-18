<template>
<div>
    <h1 class="PageTitle">{{pageTitle}}</h1>
    <br>
    <h3 class="SectionTitle">Create User</h3>
    <form name="CreateUser" id="createUser" action="http://localhost/server/v1/management/CreateAdmin" method="POST">
      <div class="field">
        <label class="label">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input " v-model="userName" type="text" placeholder="UserName" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-user"></i>
          </span>
          <span class="icon is-small is-right">
          <i class="fas fa-check"></i>
          </span>
        </div>
        <p class="help is-success">This username is available</p>
      </div>
      <div class="field">
        <label class="label">Password</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input" v-model="password" type="password" placeholder="Password" value="">
          <span class="icon is-small is-left">
          <i class="fas fa-lock"></i>
          </span>
          <span class="icon is-small is-right">
          <i class="fas fa-exclamation-triangle"></i>
          </span>
        </div>
        <p class="help is-danger">This email is invalid</p>
      </div>
      <div class="field">
        <label class="label">Address</label>
        <div class="control">
          <input class="input" v-model="address" type="text" placeholder="Address">
        </div>
        <label class="label">City</label>
        <div class="control">
          <input class="input" v-model="city" type="text" placeholder="City Name">
        </div>
        <label class="label">Zipcode</label>
        <div class="control">
          <input class="input" v-model="zipCode" type="text" placeholder="Zipcode">
        </div>
        <label class="label">State</label>
        <div class="control">
          <input class="input" v-model="state" type="text" placeholder="State">
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
          <input class="input" v-model="answerToSecQues1" type="text" placeholder="Answer">
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
          <input class="input" v-model="answerToSecQues2" type="text" placeholder="Answer">
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
          <input class="input" v-model="answerToSecQues3" type="text" placeholder="Answer">
        </div>
      </div>
      <div class="field">
        <label class="label">User Type</label>
        <div class="control">
          <div class="select" >
            <select v-model="userType">
              <option  disabled >Select dropdown</option>
              <option disabled>Administrator</option>
              <option selected>General</option>
            </select>
          </div>
        </div>
      </div>
      <div class="field">
        <div class="control">
          <label class="checkbox">
          <input type="checkbox" v-model="terms">
          I agree to the <a href="#">terms and conditions</a>
          </label>
        </div>
      </div>
      <div class="field is-grouped">
        <div class="control">
          <button class="button is-primary"  @click.prevent="createNewUser">Create {{userType}}</button>
        </div>
        <div class="control">
          <button class="button is-secondary">Cancel</button>
        </div>
      </div>
      <div v-if="this.errorFlags.createUserFlag == true" class="errorMessage">
            <span class = "help">{{this.statusMessages.createUserResponse}}</span>
        </div>
        <div v-if="this.errorFlags.createUserFlag == false" class="successMessage">
            <span>{{this.statusMessages.createUserResponse}}</span>
        </div>
    </form>
    <!--*********************************************************************************************************** -->
    <br>
    <h3 class="SectionTitle">Change Status of User</h3>
    <form name="ChangeStatus" action="http://localhost/server/v1/management/*" method="PUT">
        <div class="field has-addons has-addons-centered">
            <div class="control">
                <span class="select">
                    <select v-model="changeStatusUser.status">
                      <option selected="selected" disabled value="">Select Status</option>
                      <option value="enable">Enable</option>
                      <option value="disable">Disable</option>
                    </select>
                </span>
            </div>
            <div class="control">
                <input v-model="changeStatusUser.userName" class="input" type="text" placeholder="UserName">
            </div>
            <div class="control">
                <button type="submit" class="button is-primary" @click.prevent="changeStatus">Apply {{changeStatusUser.status}}</button>
            </div>
        </div>
        <div v-if="this.errorFlags.changeStatusFlag == true" class="errorMessage">
            <span>{{this.statusMessages.changeStatusResponse}}</span>
        </div>
        <div v-if="this.errorFlags.changeStatusFlag == false" class="successMessage">
            <span>{{this.statusMessages.changeStatusResponse}}</span>
        </div>
        <br />
    </form>
    <br>
    <!--*********************************************************************************************************** -->
    <h3 class="SectionTitle">Delete User</h3>
    <form name="DeleteUser">
        <div class="field has-addons has-addons-centered">
            <div class="control">
                <input v-model="deleteCurrentUser.userName" class="input" type="text" placeholder="UserName">
            </div>
            <div class="control">
                <button type="submit" class="button is-primary" @click.prevent="deleteUser">Delete</button>
            </div>
        </div>
        <div v-if="this.errorFlags.deleteUserFlag == true" class="errorMessage">
            <span>{{this.statusMessages.deleteResponse}}</span>
        </div>
        <div v-if="this.errorFlags.deleteUserFlag == false" class="successMessage">
            <span>{{this.statusMessages.deleteResponse}}</span>
        </div>
        <br />
        <span class="control backButton is-dark">
            <a class="button is-link " @click="goBack" >Back</a>
            </span>
        <br>
    </form>
</div>
</template>

<script>
import axios from 'axios'
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
export default {
  name: 'UserManagement',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'UserManagement Page',
      // Create User Data
      userName: 'TestUser',
      password: '12345610987134',
      confirmPassword: '123456',
      address: '321 W. 119th St.',
      city: 'Los Angeles',
      state: 'California',
      zipCode: '90061',
      answerToSecQues1: 'TEST',
      answerToSecQues2: 'TEST',
      answerToSecQues3: 'TEST',
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
        userName: '',
        status: ''
      },
      // Delete User Data
      deleteCurrentUser: {
        userName: ''
      },
      // Status Messages, displays a message on the status of the request
      // such as validation errors, request successses, and request failures.
      statusMessages: {
        createUserResponse: 'PlaceHolder',
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
    // Registration methods
    // Checks the characters of userInput
    validateCharacters (userInput) {
      var regexPattern = /[^ 0-9a-zA-Z!@#$%^&*()-_=+{}[;:"'<,>.?|`~]/i
      if (userInput.match(regexPattern) == null) {
        return true
      } else {
        return false
      }
    },
    createNewUser: function () {
      // Validate incoming data
      if (this.userType === 'General') {
        console.log('Inside createUser Method')
        axios({
          method: 'POST',
          url: 'http://localhost/server/v1/SignUp/Register',
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
            UserType: 'General'
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081',
            'Content-Type': 'application/json'
          }
        })
          // redirect to Home page
          .then(response => {
          // NOTE: CHANGE THIS BEFORE PRODUCTION
            console.log(response)
            this.statusMessages.createUserResponse = response.data.Messages
            this.errorFlags.createUserFlag = false
          }).catch((error) => {
          // Pushes the error messages into error to display
            if (error.response) {
              this.statusMessages.createUserResponse = 'Error: ' + error.response.data.Messages
              this.errorFlags.createUserFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.statusMessages.createUserResponse = 'Error: ' + error.response.data.Messages
              this.errorFlags.createUserFlag = true
              console.log(error.request)
            } else {
              this.statusMessages.createUserResponse = 'An error occured while setting up request.'
              this.errorFlags.createUserFlag = true
            }
          })
      } else if (this.userType === 'Administrator') {
        console.log('Error: Can not make admins yet - Rob')
        axios({
          method: 'POST',
          url: 'http://localhost/server/v1/SignUp/Register',
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
            UserType: 'General'
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081',
            'Content-Type': 'application/json'
          }
        })
          // redirect to Home page
          .then(response => {
          // NOTE: CHANGE THIS BEFORE PRODUCTION
            console.log(response)
            this.statusMessages.createUserResponse = response.data
            this.errorFlags.createUserFlag = false
          }).catch((error) => {
          // Pushes the error messages into error to display
            if (error.response) {
              this.statusMessages.createUserResponse = 'Error: ' + error.response.data
              this.errorFlags.createUserFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.statusMessages.createUserResponse = 'Error: ' + error.response.data
              this.errorFlags.createUserFlag = true
              console.log(error.request)
            } else {
              this.statusMessages.createUserResponse = 'An error occured while setting up request.'
              this.errorFlags.createUserFlag = true
            }
          })
      } else {
        this.statusMessages.createUserResponse = 'Error: Must choose a valid User Type.'
        this.errorFlags.createUserFlag = true
      }
    },
    deleteUser: function () {
      // Validate userName before making request
      if (!validateUserName(this.deleteCurrentUser.userName)) {
        // Give error message to page
        this.statusMessages.deleteResponse = 'Error: Not a valid UserName'
        this.errorFlags.deleteUserFlag = true
        return false
      } else {
        // Valide userName at this point
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/delete',
          data: {
            'UserName': this.deleteCurrentUser.userName
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(response => {
            // Got a 2xx response from the server
            // Printing response.data
            console.log(response.data)
            // Set up success message
            this.statusMessages.deleteResponse = response.data
            this.errorFlags.deleteUserFlag = false
          })
          .catch(error => {
            // An error has occured, filtering error types.
            if (error.response) {
              this.statusMessages.deleteResponse = 'Error: ' + error.response.data
              this.errorFlags.deleteUserFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.statusMessages.deleteResponse = 'Error: ' + error.response.data
              this.errorFlags.deleteUserFlag = true
              console.log(error.request)
            } else {
              this.statusMessages.deleteResponse = 'An error occured while setting up request.'
              this.errorFlags.deleteUserFlag = true
            }
          })
      }
    },
    changeStatus: function () {
      if (!validateUserName(this.changeStatusUser.userName) || this.changeStatusUser.status === '') {
        // Give error message to page
        this.statusMessages.changeStatusResponse = 'Error: Not a valid UserName / status'
        this.errorFlags.changeStatusFlag = true
        return false
      }
      if (this.changeStatusUser.status === 'enable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/enable',
          data: {'UserName': this.changeStatusUser.userName},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(response => {
            console.log(response.data)
            // NOTE: The following line does not work. - Rob
            // this.statusMessages.changeStatusResponse = response.data
            this.statusMessages.changeStatusResponse = response.data
            this.errorFlags.changeStatusFlag = false
          })
          .catch(error => {
            if (error.response) {
              // Server responded with a status code outside of 2xx
              this.statusMessages.changeStatusResponse = 'Error: ' + error.response.data
              this.changeStatusFlag = true
              console.log(error.response)
            } else if (error.request) {
              // Request was made but no response
              this.statusMessages.changeStatusResponse = 'Error: ' + error.response.data
              this.changeStatusFlag = true
              console.log(error.request)
            } else {
              // Something happened when setting up request
              this.statusMessages.changeStatusResponse = 'An error occured while setting up request.'
              this.changeStatusFlag = true
              console.log('Error: ', error.message)
            }
          })
      } else if (this.changeStatusUser.status === 'disable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/disable',
          data: {'UserName': this.changeStatusUser.userName},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(response => {
            console.log(response.data)
            // NOTE: The following line does not work. - Rob
            this.statusMessages.changeStatusResponse = response.data
            this.errorFlags.changeStatusFlag = false
          })
          .catch(error => {
            if (error.response) {
              this.statusMessages.changeStatusResponse = 'Error: ' + error.response.data
              this.errorFlags.changeStatusFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.statusMessages.changeStatusResponse = 'Error: ' + error.response.data
              this.errorFlags.changeStatusFlag = true
              console.log(error.request)
            } else {
              this.statusMessages.changeStatusResponse = 'An error occured while setting up request.'
              this.errorFlags.changeStatusFlag = true
              console.log('Error: ', error.message)
            }
          })
      } else {
        console.log('Error: Invalid Status')
      }
    },
    goBack: function () {
      this.$router.go(-1)
    }
  }
}
function validateUserName (userName) {
  if (userName.length < 2 || userName.length > 64 || userName === '') {
    return false
  } else {
    return true
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

  .backButton {
      padding-left: 50%;
  }
</style >
