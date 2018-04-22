<template>
    <div>
      <h1 class="PageTitle">{{pageTitle}}</h1>
      <!-- -->
      <label class="label">Upload New Profile Picture</label>
      <div class="file has-name">
          <label class="file-label">
            <input class="file-input" type="file" name="resume">
            <span class="file-cta">
              <span class="file-icon">
                <i class="fa fa-upload"></i>
              </span>
              <span class="file-label">
                Choose a file…
              </span>
            </span>
            <span class="file-name">
              NEED FILE NAME HERE
            </span>
          </label>
        </div>
        <br>
      <div class="field is-horizontal">
  <div class="field-label is-normal">
    <label class="label">Full Name</label>
  </div>
  <div class="field-body">
    <div class="field">
      <p class="control is-expanded">
        <input class="input" type="text" placeholder="First Name">
      </p>
    </div>
    <div class="field">
      <p class="control is-expanded">
        <input class="input" type="text" placeholder="Last Name" value="Sanchez">
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
        <div class="select is-fullwidth">
          <select>
            <option>Beginner - Causal exercising (2 days or less per week)</option>
            <option>Intermediate - Consistant exercising (2-3 days per week)  </option>
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
        <input class="input is-danger" type="text" placeholder="e.g. Partnership opportunity">
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
        <input class="input is-danger" type="text" placeholder="e.g. Partnership opportunity">
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
        <textarea class="textarea" placeholder="Explain how we can help you"></textarea>
      </div>
    </div>
  </div>
</div>
<br>
<div class="control is-horizontal ">
  <div class="field-label">
     <span class="control">
    <a class="button is-link " @click="pushProfile" >PushProfile</a>
  </span>
  <span class="control">
    <a class="button is-link " @click="goBackToProfile" >My Profile</a>
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
      pageTitle: 'Edit Profile'
    }
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
          'FirstName': 'Felix',
          'LastName': 'Huang',
          'Description': 'This is a request to controller. It worked!!!',
          'SkillLevel': 'Missing',
          'Gender': 'Male',
          'ProfilePicture': '../../../static/genericProfileImage.jpg'
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
</style>
