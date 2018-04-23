<template>
<div class="Container">
    <h1 class="PageTitle">{{pageTitle}}</h1>
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
              <input class="input" type="text" placeholder="First Name" v-model.trim="userData.firstName">
            </p>
            </div>
          <div class="field">
            <p class="control is-expanded">
              <input class="input" type="text" placeholder="Last Name" v-model.trim="userData.lastName">
            </p>
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
                <select v-model="this.userData.skillLevel">
                  <option>Beginner - Causal exercising (2 days or less per week)</option>
                  <option>Intermediate - Consistant exercising (2-3 days per week) </option>
                  <option>Advance - Following Strict Regiment (3 or more days per week)</option>
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
              <input class="input" type="text" placeholder="example@domain.com" v-model.trim="userData.email">
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
                    <input class="input" type="text" placeholder="Male/Female/etc." v-model.trim="userData.gender">
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
                    <textarea class="textarea" placeholder="Explain how we can help you" v-model.trim="userData.description"></textarea>
                </div>
            </div>
        </div>
    </div>
    <br>
    <div class="control ">
      <div class="field-label is-horizontal Buttons-Center">
        <span class="control">
          <button class="button  is-primary " @click="pushProfile" >Update My Profile</button>
          <button class="button is-secondary " @click="goBackToProfile" >Go to my Profile</button>
        </span>
      </div>
    </div>
</div>
</template>

<script>
import axios from 'axios'

export default {
  name: 'EditProfile',
  components: {

  },
  data () {
    return {
      pageTitle: 'Edit Profile',
      userData: {
        firstName: '',
        lastName: '',
        description: '',
        skillLevel: '',
        gender: '',
        profileImage: '',
        email: ''
      }
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
        this.userData.firstName = response.data.FirstName
        this.userData.lastName = response.data.LastName
        this.userData.description = response.data.Description
        this.userData.skillLevel = response.data.SkillLevel
        this.userData.gender = response.data.Gender
        this.userData.profileImage = response.data.ProfilePicture
        this.errorFlag = false
      }).catch((error) => {
      // Pushes the error messages into error to display
        if (error.response) {
          this.errorMessage = 'Error: An Error Occurd.'
          console.log('An Error Occured')
          this.errorFlag = true
          console.log(error.response)
        } else if (error.request) {
          this.errorMessage = 'Error: Server Error'
          this.errorFlag = true
          console.log(error.request)
        } else {
          this.errorMessage = 'An error occured while setting up request.'
          this.errorFlag = true
        }
      })
  },
  methods: {
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
          'FirstName': 'Roberto',
          'LastName': 'Sanchez',
          'Description': 'This is a request to controller. It worked!!!',
          'SkillLevel': 'Missing',
          'Gender': 'Male',
          'ProfilePicture': '../../../static/ProfileDummy/profilePicture.jpg'
        }
      })
      // redirect to Home page
        .then(response => {
          console.log(response.data)
          this.errorFlag = false
        }).catch((error) => {
        // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.errorMessage = 'An error occured while setting up request.'
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
</style>
