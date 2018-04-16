<template>
<div>
    <h1 class="PageTitle">{{pageTitle}}</h1>
    <br>
    <h3 class="SectionTitle">Create User</h3>
    <form name="CreateUser" id="createUser" action="http://localhost/server/v1/management/CreateAdmin" method="POST">
      <div class="field">
        <label class="label">Username</label>
        <div class="control has-icons-left has-icons-right">
          <input class="input " v-model="createUser.userName" type="text" placeholder="UserName" value="">
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
          <input class="input" v-model="createUser.password" type="password" placeholder="Password" value="">
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
          <input class="input" v-model="createUser.address" type="text" placeholder="Address">
        </div>
        <label class="label">City</label>
        <div class="control">
          <input class="input" v-model="createUser.city" type="text" placeholder="City Name">
        </div>
        <label class="label">Zipcode</label>
        <div class="control">
          <input class="input" v-model="createUser.zipcode" type="text" placeholder="Zipcode">
        </div>
        <label class="label">State</label>
        <div class="control">
          <input class="input" v-model="createUser.state" type="text" placeholder="State">
        </div>
      </div>
      <div class="field">
        <label class="label">Security Questions</label>
        <label class="label">Question #1</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select>
              <option selected disabled>Select Question</option>
              <option>q1</option>
              <option>q2</option>
              <option>q3</option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model="a" type="text" placeholder="Answer">
        </div>
      </div>
      <div class="field">
        <label class="label">Question #2</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select>
              <option selected disabled>Select Question</option>
              <option>q1</option>
              <option>q2</option>
              <option>q3</option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model="a" type="text" placeholder="Answer">
        </div>
      </div>
      <div class="field">
        <label class="label">Question #3</label>
        <div class="control">
          <div class="select is-fullwidth" >
            <select>
              <option selected disabled>Select Question</option>
              <option>q1</option>
              <option>q2</option>
              <option>q3</option>
            </select>
          </div>
        </div>
        <br>
         <div class="control">
          <input class="input" v-model="a" type="text" placeholder="Answer">
        </div>
      </div>
      <div class="field">
        <label class="label">User Type</label>
        <div class="control">
          <div class="select" >
            <select>
              <option selected disabled>Select dropdown</option>
              <option>Administrator</option>
              <option>General</option>
            </select>
          </div>
        </div>
      </div>
      <div class="field">
        <div class="control">
          <label class="checkbox">
          <input type="checkbox" v-model="createUser.terms">
          I agree to the <a href="#">terms and conditions</a>
          </label>
        </div>
      </div>
      <div class="field is-grouped">
        <div class="control">
          <button class="button is-primary">Submit</button>
        </div>
        <div class="control">
          <button class="button is-secondary">Cancel</button>
        </div>
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
        <div v-if="this.$data.errorFlags.changeStatusFlag == true" class="errorMessage">
            <span>{{this.$data.statusMessages.changeStatusResponse}}</span>
        </div>
        <div v-if="this.$data.errorFlags.changeStatusFlag == false" class="successMessage">
            <span>{{this.$data.statusMessages.changeStatusResponse}}</span>
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
        <div v-if="this.$data.errorFlags.deleteUserFlag == true" class="errorMessage">
            <span>{{this.$data.statusMessages.deleteResponse}}</span>
        </div>
        <div v-if="this.$data.errorFlags.deleteUserFlag == false" class="successMessage">
            <span>{{this.$data.statusMessages.deleteResponse}}</span>
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
      createUser: {
        userName: '',
        password: '',
        address: '',
        city: '',
        zipcode: '',
        state: '',
        terms: true
      },
      a: '',
      securityQuestionsSet1: [
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
      changeStatusUser: {
        userName: '',
        status: ''
      },
      deleteCurrentUser: {
        userName: ''
      },
      statusMessages: {
        createUserResponse: '',
        changeStatusResponse: '',
        deleteResponse: ''
      },
      errorFlags: {
        createUserFlag: false,
        changeStatusFlag: false,
        deleteUserFlag: false
      }
    }
  },
  methods: {
    createNewUser: function () {
      console.log('Not implemented yet. - Rob')
    },
    deleteUser: function () {
      // Validate userName before making request
      if (!validateUserName(this.$data.deleteCurrentUser.userName)) {
        // Give error message to page
        this.$data.statusMessages.deleteResponse = 'Error: Not a valid UserName'
        this.$data.errorFlags.deleteUserFlag = true
        return false
      } else {
        // Valide userName at this point
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/delete',
          data: {
            'UserName': this.$data.deleteCurrentUser.userName
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(function (response) {
            // Got a 200 response from the server
            // Printing response.data
            console.log(response.data)
            // Set up success message
            this.$data.statusMessages.deleteResponse = 'This was a success!'
            this.$data.errorFlags.deleteUserFlag = false
          })
          .catch(error => {
            // An error has occured, filtering error types.
            if (error.response) {
              this.$data.statusMessages.deleteResponse = 'An error occured, server response was bad.'
              this.$data.errorFlags.deleteUserFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.$data.statusMessages.deleteResponse = 'An error occured, no response from server.'
              this.$data.errorFlags.deleteUserFlag = true
              console.log(error.request)
              console.log(this.$data.statusMessages.deleteResponse, this.$data.errorFlags.deleteUserFlag)
            } else {
              this.$data.statusMessages.deleteResponse = 'An error occured while setting up request.'
              this.$data.errorFlags.deleteUserFlag = true
            }
          })
      }
    },
    changeStatus: function () {
      if (!validateUserName(this.$data.changeStatusUser.userName) || this.$data.changeStatusUser.status === '') {
        // Give error message to page
        this.$data.statusMessages.changeStatusResponse = 'Error: Not a valid UserName / status'
        this.$data.errorFlags.changeStatusFlag = true
        return false
      }
      if (this.$data.changeStatusUser.status === 'enable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/enable',
          data: {'UserName': this.$data.changeStatusUser.userName},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(function (response) {
            console.log(response.data)
            // NOTE: The following line does not work. - Rob
            // this.statusMessages.changeStatusResponse = response.data
            this.$data.errorFlags.changeStatusFlag = false
          })
          .catch(error => {
            if (error.response) {
              // Server responded with a status code outside of 2xx
              this.$data.statusMessages.changeStatusResponse = 'An error occured, server response was bad.'
              this.$data.changeStatusFlag = true
              console.log(error.response)
            } else if (error.request) {
              // Request was made but no response
              this.$data.statusMessages.changeStatusResponse = 'An error occured, no response from server.'
              this.$data.changeStatusFlag = true
              console.log(error.request)
            } else {
              // Something happened when setting up request
              this.$data.statusMessages.changeStatusResponse = 'An error occured while setting up request.'
              this.$data.changeStatusFlag = true
              console.log('Error: ', error.message)
            }
          })
      } else if (this.$data.changeStatusUser.status === 'disable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/disable',
          data: {'UserName': this.$data.changeStatusUser.userName},
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8081'
          }
        })
          .then(function (response) {
            console.log(response.data)
            // NOTE: The following line does not work. - Rob
            // this.statusMessages.changeStatusResponse = response.data
            this.$data.errorFlags.changeStatusFlag = false
          })
          .catch(error => {
            if (error.response) {
              this.$data.statusMessages.changeStatusResponse = 'An error occured, server response was bad.'
              this.$data.errorFlags.changeStatusFlag = true
              console.log(error.response)
            } else if (error.request) {
              this.$data.statusMessages.changeStatusResponse = 'An error occured, no response from server.'
              this.$data.errorFlags.changeStatusFlag = true
              console.log(error.request)
            } else {
              this.$data.statusMessages.changeStatusResponse = 'An error occured while setting up request.'
              this.$data.errorFlags.changeStatusFlag = true
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
<style scoped>
button:hover {
    cursor: pointer;
}
.SectionTitle {
  text-align: left;
  font-size: 2em;
  padding-left:5%;
}
.PageTitle {
font-size: 2.5em;
text-align: center;
}
.SubLabel {
font-size: 4em;
text-align: left;
}
.CenteredBody{
  padding-left: 12em;

}
#createUser {
  padding-left: 5%;
  padding-right:5%;
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
</style>
