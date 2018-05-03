<template>
<div class="Container">
    <br>
    <h1 class="PageTitle">{{pageTitle}}</h1>
    <br>
    <div class="field is-horizontal">
        <div class="field-label is-normal">
            <label class="label">Upload Profile Image</label>
        </div>
        <div class="field-body">
            <div class="file has-name">
                <label class="file-label">
                    <input class="file-input" type="file" @change="onFileSelected" name="image">
                    <span class="file-cta">
                      <span class="file-icon">
                        <i class="fas fa-upload"></i>
                      </span>
                      <span class="file-label">Choose an Image...</span>
                    </span>
                    <span class="file-name">
                      {{this.newProfileImageName}}
                    </span>
                </label>
            </div>
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
                    <input class="input" type="text" placeholder="First Name" v-model.trim="userData.firstName" @input="delayTouch($v.userData.firstName)" v-bind:class="{error: $v.userData.firstName.$error, valid: $v.userData.firstName.$dirty && !$v.userData.firstName.$invalid}">
                </p>
                <div class="errorMessage">
                    <span v-show="!$v.userData.firstName.required && $v.userData.firstName.$dirty">First name is required</span>
                    <span v-show="!$v.userData.firstName.minLength && $v.userData.firstName.$dirty">First name must have at least {{$v.userData.firstName.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.firstName.maxLength && $v.userData.firstName.$dirty">First name can't be this long {{$v.userData.firstName.$params.maxLength.max}} letters</span>
                </div>
            </div>
            <div class="field">
                <p class="control is-expanded">
                    <input class="input" type="text" placeholder="Last Name" v-model.trim="userData.lastName" @input="delayTouch($v.userData.lastName)" v-bind:class="{error: $v.userData.lastName.$error, valid: $v.userData.lastName.$dirty && !$v.userData.lastName.$invalid}">
                </p>
                <div class="errorMessage">
                    <span v-show="!$v.userData.lastName.required && $v.userData.lastName.$dirty">First name is required</span>
                    <span v-show="!$v.userData.lastName.minLength && $v.userData.lastName.$dirty">Last name must have at least {{$v.userData.lastName.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.lastName.maxLength && $v.userData.lastName.$dirty">Last name can't be this long {{$v.userData.lastName.$params.maxLength.max}} letters</span>
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
                        <select v-model="userData.skillLevel">
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
                    <input class="input" type="text" placeholder="example@domain.com" v-model.trim="userData.email" @input="delayTouch($v.userData.email)" v-bind:class="{error: $v.userData.email.$error, valid: $v.userData.email.$dirty && !$v.userData.email.$invalid}">
                </div>
                <div class="errorMessage">
                    <span v-show="!$v.userData.email.required && $v.userData.email.$dirty">Email is required</span>
                    <span v-show="!$v.userData.email.maxLength && $v.userData.email.$dirty">Last name can't be this long {{$v.userData.email.$params.maxLength.max}} letters</span>
                    <span v-show="!$v.userData.email.email && $v.userData.email.$dirty"> This is not a valid email format</span>
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
                    <input class="input" type="text" placeholder="Male/Female/etc." v-model.trim="userData.gender" @input="delayTouch($v.userData.gender)" v-bind:class="{error: $v.userData.gender.$error, valid: $v.userData.gender.$dirty && !$v.userData.gender.$invalid}">
                </div>
                <div class="errorMessage">
                    <span v-show="!$v.userData.gender.required && $v.userData.gender.$dirty">Gender is required</span>
                    <span v-show="!$v.userData.gender.minLength && $v.userData.gender.$dirty">Gender must have at least {{$v.userData.gender.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.gender.maxLength && $v.userData.gender.$dirty">Gender can't be this long {{$v.userData.gender.$params.maxLength.max}} letters</span>
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
                    <textarea class="textarea" placeholder="Explain how we can help you" v-model.trim="userData.description" @input="delayTouch($v.userData.description)" v-bind:class="{error: $v.userData.description.$error, valid: $v.userData.description.$dirty && !$v.userData.description.$invalid}"></textarea>
                </div>
                <div class="errorMessage">
                    <span v-show="!$v.userData.description.required && $v.userData.description.$dirty">Description is required</span>
                    <span v-show="!$v.userData.description.minLength && $v.userData.description.$dirty">Description must have at least {{$v.userData.description.$params.minLength.min}} letters</span>
                    <span v-show="!$v.userData.description.maxLength && $v.userData.description.$dirty">Description can't be this long {{$v.userData.description.$params.maxLength.max}} letters</span>
                </div>
            </div>
        </div>
    </div>
    <br>

    <div class="control ">
        <div class="field-label is-horizontal Buttons-Center">
            <span class="control">
          <button class="button  is-primary " :disabled="$v.$invalid && this.isValidImage"  @click.prevent="pushProfile" >Update My Profile</button>
          <button class="button is-secondary " @click="goBackToProfile" >Go to my Profile</button>
        </span>
        </div>
    </div>
    <br>
    <div v-if="this.errorFlag == true" class="errorMessage">
        <span class="help">{{this.statusMessages}}</span>
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
      userData: {
        firstName: '',
        lastName: '',
        description: '',
        skillLevel: '',
        gender: '',
        profileImage: '',
        email: ''
      },
      errorFlag: true,
      statusMessages: '',
      newProfileImageName: 'example.jpg',
      newProfileImage: '',
      isValidImage: false,
      isUpdatingImage: false
    }
  },
  validations: {
    userData: {
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
      email: {
        email,
        required,
        maxLength: maxLength(128)
      },
      gender: {
        required,
        minLength: minLength(2),
        maxLength: maxLength(64)
      },
      description: {
        required,
        minLength: minLength(0),
        maxLength: maxLength(256)
      }
    }
  },
  created: function () {
    axios({
      method: 'POST',
      url: this.$store.getters.getURL + 'v1/UserProfile/ProfileData',
      headers: this.$store.getters.getheader,
      data: {
        'Username': this.$store.getters.getusername
      }
    })
      // redirect to Home page
      .then(response => {
        this.userData.firstName = response.data.FirstName
        this.userData.lastName = response.data.LastName
        this.userData.description = response.data.Description
        this.userData.email = response.data.Email
        this.userData.skillLevel = response.data.SkillLevel
        this.userData.gender = response.data.Gender
        this.userData.profileImage = response.data.ProfilePicture
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
    onFileSelected (event) {
      console.log(event)
      // Validate Image
      var fileName = event.target.files[0].name
      var extension = fileName.substring(fileName.lastIndexOf('.') + 1).toLowerCase()
      if (extension !== 'png' && extension !== 'jpg') {
        this.isValidImage = false
        this.newProfileImageName = 'Invalid Image'
        return
      }
      if (fileName.length > 50) {
        this.isValidImage = false
        this.newProfileImageName = 'Name too long'
        return
      }
      this.newProfileImage = event.target.files[0]
      this.newProfileImageName = event.target.files[0].name
      this.isValidImage = true
      this.isUpdatingImage = true
    },
    delayTouch ($v) {
      $v.$reset()
      if (touchMap.has($v)) {
        clearTimeout(touchMap.get($v))
      }
      touchMap.set($v, setTimeout($v.$touch, 1000))
    },
    goBackToProfile: function () {
      this.$store.dispatch('actviewprofile', {ViewProfile: this.$store.getters.getusername})
      this.$router.push('/profile')
    },
    pushProfile: function () {
      const formData = new FormData()
      formData.append('ProfilePicture', this.newProfileImage, this.newProfileImageName)
      formData.append('UserName', this.$store.getters.getusername)
      formData.append('FirstName', this.userData.firstName)
      formData.append('LastName', this.userData.lastName)
      formData.append('Email', this.userData.email)
      formData.append('SkillLevel', this.userData.skillLevel)
      formData.append('Gender', this.userData.gender)
      formData.append('Description', this.userData.description)
      formData.append('IsThereImage', this.isUpdatingImage)
      // Manual Change
      var headers = {
        'Content-type': 'application/x-www-form-urlencoded',
        // 'Access-Control-Allow-Origin': 'http://localhost:8081',
        'Access-Control-Allow-Origin': this.$store.getters.getURL,
        'Authorization': 'Bearer ' + this.$store.getters.gettoken
      }
      axios.post(this.$store.getters.getURL + 'v1/UserProfile/EditProfile', formData, headers)
      // redirect to Home page
        .then(response => {
          this.statusMessages = 'Your profile has been updated.'
          this.errorFlag = false
        }).catch((error) => {
        // Pushes the error messages into error to display
          if (error.response.status === 400) {
            this.statusMessages.createUserResponse = 'There was an error processing your request'
            this.errorFlags.createUserFlag = true
          } else if (error.response.status === 404) {
            this.$router.push('/notfound')
          } else if (error.response.status === 403) {
            this.$router.push('/notAllowed')
          } else if (error.response.status === 500) {
            this.$router.push('/serverissue')
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
