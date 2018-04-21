<template>
    <div>
      <div v-if="this.errorFlag == true">
        <div>
          <error-page404></error-page404>
          <home-button></home-button>
        </div>
      </div>
      <div v-else>
        <user-info id="ProfileInfo"></user-info>
        <!-- NOTE: Add your components here. If the page does not load it will go to an error page  -->
      </div>

    </div>
</template>

<script>
import axios from 'axios'
import UserInfo from '@/components/UserProfile/UserInfo'
import ErrorPage from '@/components/ErrorPage/404NotFound'
import HomeButton from '@/components/Common/HomeButton'

export default {
  name: 'ProfilePage',
  components: {
    'user-info': UserInfo,
    'error-page404': ErrorPage,
    'home-button': HomeButton
  },
  data () {
    return {
      userName: '',
      errorFlag: '',
      errorMessage: 'Page Failed to load.'
    }
  },
  beforeCreate () {
    axios({
      method: 'GET',
      url: 'http://localhost/server/v1/UserProfile/GetProfileData',
      headers: {
        'Access-Control-Allow-Origin': 'http://localhost:8081',
        'Content-Type': 'application/json'
      }
    })
      // redirect to Home page
      .then(response => {
        console.log(response.data)
        // NOTE: Is there a better way to store data?
        /*
        this.firstName = response.data.FirstName
        this.lastName = response.data.LastName
        this.description = response.data.Description
        this.skillLevel = response.data.SkillLevel
        this.gender = response.data.Gender
        this.profileImage = response.data.ProfilePictureDirectory
        */
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
  },
  methods: {

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
</style>
