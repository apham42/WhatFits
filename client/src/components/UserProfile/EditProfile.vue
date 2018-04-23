<template>
<div class="Container">
  <br>
    <h1 class="PageTitle">{{pageTitle}}</h1>
    <br>
    <!-- -->
    <div class="field is-horizontal">
        <div class="field-label is-normal">
          <label class="label">Upload Profile Image</label>
        </div>
        <div class="field-body">
          <label>
              <input class="file-input" type="file" name="resume">
              <span class="file-cta">
                <span class="file-icon"><i class="fa fa-upload"></i></span>
                <span class="file-label">Choose a file…</span>
              </span>
              <span class="file-name">sample.jpg</span>
          </label>
        </div>
    </div>
    <br>
    <div class="field is-horizontal">
        <div class="field-label is-normal">
          <label class="label">Full Name</label>
        </div>
        <div class="field-body">
          <div class="field">
            <p class="control is-expanded">
              <input class="input" type="text" placeholder="First Name" v-model.trim="firstName" @input="delayTouch($v.firstName)" v-bind:class="{error: $v.firstName.$error, valid: $v.firstName.$dirty && !$v.firstName.$invalid}">
            </p>
            <div class="errorMessage">
                <span v-show="!$v.firstName.required && $v.firstName.$dirty">First name is required</span>
                <span v-show="!$v.firstName.minLength && $v.firstName.$dirty">First name must have at least {{$v.firstName.$params.minLength.min}} letters</span>
                <span v-show="!$v.firstName.maxLength && $v.firstName.$dirty">First name can't be this long {{$v.firstName.$params.maxLength.max}} letters</span>
            </div>
            </div>
          <div class="field">
            <p class="control is-expanded">
              <input class="input" type="text" placeholder="Last Name" v-model.trim="lastName" @input="delayTouch($v.lastName)" v-bind:class="{error: $v.lastName.$error, valid: $v.lastName.$dirty && !$v.lastName.$invalid}">
            </p>
            <div class="errorMessage">
                <span v-show="!$v.lastName.required && $v.lastName.$dirty">First name is required</span>
                <span v-show="!$v.lastName.minLength && $v.lastName.$dirty">Last name must have at least {{$v.lastName.$params.minLength.min}} letters</span>
                <span v-show="!$v.lastName.maxLength && $v.lastName.$dirty">Last name can't be this long {{$v.lastName.$params.maxLength.max}} letters</span>
            </div>
          </div>
        </div>
    </div>
    <br>
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
              <option value="Beginner">Beginner</option>
              <option value="Intermediate">Intermediate</option>
              <option value="Advance">Advance</option>
            </select>
              </div>
            </div>
          </div>
        </div>
    </div>
    <br>
    <div class="field is-horizontal">
        <div class="field-label is-normal">
          <label class="label">Email</label>
        </div>
        <div class="field-body">
          <div class="field">
            <div class="control">
              <input class="input" type="text" placeholder="example@domain.com" v-model.trim="email" @input="delayTouch($v.email)" v-bind:class="{error: $v.email.$error, valid: $v.email.$dirty && !$v.email.$invalid}">
            </div>
            <div class="errorMessage">
                <span v-show="!$v.email.required && $v.email.$dirty">Email is required</span>
                <span v-show="!$v.email.maxLength && $v.email.$dirty">Last name can't be this long {{$v.email.$params.maxLength.max}} letters</span>
                <span v-show="!$v.email.email && $v.email.$dirty"> This is not a valid email format</span>
            </div>
          </div>
        </div>
    </div>
    <br>
    <div class="field is-horizontal">
        <div class="field-label is-normal">
            <label class="label">Gender</label>
        </div>
        <div class="field-body">
            <div class="field">
                <div class="control">
                    <input class="input" type="text" placeholder="Male/Female/etc." v-model.trim="gender" @input="delayTouch($v.gender)" v-bind:class="{error: $v.gender.$error, valid: $v.gender.$dirty && !$v.gender.$invalid}">
                </div>
                <div class="errorMessage">
                  <span v-show="!$v.gender.required && $v.gender.$dirty">Gender is required</span>
                  <span v-show="!$v.gender.minLength && $v.gender.$dirty">Gender must have at least {{$v.gender.$params.minLength.min}} letters</span>
                  <span v-show="!$v.gender.maxLength && $v.gender.$dirty">Gender can't be this long {{$v.gender.$params.maxLength.max}} letters</span>
            </div>
            </div>
        </div>
    </div>
    <br>
    <div class="field is-horizontal">
        <div class="field-label is-normal">
            <label class="label">Description</label>
        </div>
        <div class="field-body">
            <div class="field">
                <div class="control">
                    <textarea class="textarea" placeholder="Explain how we can help you" v-model.trim="description" @input="delayTouch($v.description)" v-bind:class="{error: $v.description.$error, valid: $v.description.$dirty && !$v.description.$invalid}"></textarea>
                </div>
                <div class="errorMessage">
                  <span v-show="!$v.description.required && $v.description.$dirty">Description is required</span>
                  <span v-show="!$v.description.minLength && $v.description.$dirty">Description must have at least {{$v.description.$params.minLength.min}} letters</span>
                  <span v-show="!$v.description.maxLength && $v.description.$dirty">Description can't be this long {{$v.description.$params.maxLength.max}} letters</span>
            </div>
            </div>
        </div>
    </div>
    <br>

    <div class="control ">
      <div class="field-label is-horizontal Buttons-Center">
        <span class="control">
          <button class="button  is-primary " :disabled="$v.$invalid"  @click.prevent="pushProfile" >Update My Profile</button>
          <button class="button is-secondary " @click="goBackToProfile" >Go to my Profile</button>
        </span>
      </div>
    </div>
    <br>
    <div v-if="this.errorFlag == true" class="errorMessage">
            <span class = "help">{{this.statusMessages}}</span>
        </div>
        <div v-if="this.errorFlag == false" class="successMessage">
            <span>{{this.statusMessages}}</span>
        </div>
</div>
</template>

<script>

import axios from 'axios'
import {required, minLength, maxLength, email} from 'vuelidate/lib/validators'
const touchMap = new WeakMap()
export default {
  name: 'EditProfile',
  components: {
  },
  data () {
    return {
      pageTitle: 'Edit Profile Console',
      firstName: '',
      lastName: '',
      description: '',
      skillLevel: '',
      gender: '',
      profileImage: '',
      email: '',
      errorFlag: true,
      statusMessages: ''
    }
  },
  validations: {
    firstName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(35)
    },
    lastName: {
      required,
      minLength: minLength(2),
      maxLength: maxLength(35)
    },
    email: {
      email,
      required,
      maxLength: maxLength(128)
    },
    gender: {
      required,
      minLength: minLength(1),
      maxLength: maxLength(64)
    },
    description: {
      required,
      minLength: minLength(0),
      maxLength: maxLength(256)
    }
  },
  beforeCreate () {
    axios({
      method: 'POST',
      url: 'http://localhost/server/v1/UserProfile/ProfileData',
      headers: {
        'Access-Control-Allow-Origin': 'http://localhost:8081',
        'Content-Type': 'application/json'
      },
      data: {
        'Username': this.$store.getters.getusername
      }
    })
      // redirect to Home page
      .then(response => {
        console.log(response.data)
        // NOTE: Is there a better way to store data?
        this.firstName = response.data.FirstName
        this.lastName = response.data.LastName
        this.description = response.data.Description
        this.email = response.data.Email
        this.skillLevel = response.data.SkillLevel
        this.gender = response.data.Gender
        this.profileImage = response.data.ProfilePicture
      }).catch((error) => {
      // Pushes the error messages into error to display
        if (error.response) {
          this.statusMessages = 'Error: An Error Occurd.'
          console.log('An Error Occured')
          this.errorFlag = true
          console.log(error.response)
        } else if (error.request) {
          this.statusMessages = 'Error: Server Error'
          this.errorFlag = true
          console.log(error.request)
        } else {
          this.statusMessages = 'An error occured while setting up request.'
          this.errorFlag = true
        }
      })
  },
  methods: {
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 1000))
    },
    goBackToProfile: function () {
      this.$router.push('/profile')
    },
    pushProfile: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/UserProfile/EditProfile',
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8081',
          'Content-Type': 'application/json'
        },
        data: {
          'UserName': this.$store.getters.getusername,
          'FirstName': this.firstName,
          'LastName': this.lastName,
          'Email': this.email,
          'Description': this.description,
          'SkillLevel': this.skillLevel,
          'Gender': this.gender,
          'ProfilePicture': '../../../static/ProfileDummy/profilePicture.jpg'
        }
      })
      // redirect to Home page
        .then(response => {
          console.log(response.data)
          this.statusMessages = 'Your profile has been updated.'
          this.errorFlag = false
        }).catch((error) => {
        // Pushes the error messages into error to display
          if (error.response) {
            this.statusMessages = 'An error occured while Processing your request.'
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.statusMessages = 'A'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.statusMessages = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }
  }
}
</script>

<style scoped>

#ProfileInfo{
  padding-left: 0em;
}
@media only screen and (min-width: 400px){
  #ProfileInfo{
    padding-left: 5em;
  }
}
  .PageTitle {
      font-size: 2.5em;
      text-align: center;
  }
  .backButton {
      padding-left: 50%;
  }
  .Container {
    width: auto;
    height: auto;
    padding-right: 5%;
    padding-left: 5%;
  }
  .Buttons-Center {

      text-align: center;
  }
    .successMessage {
      color: Green;
      text-align: center;
  }

  .errorMessage {
      color: red;
      text-align: center;
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
</style>
