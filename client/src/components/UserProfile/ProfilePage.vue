<template>
    <div>
      <div v-if="this.errorFlag == true">
        <div>
          <error-page404></error-page404>
          <home-button></home-button>
        </div>
      </div>
      <div v-else>
        <user-info id="ProfileInfo" :userData="userData"></user-info>
        <!-- NOTE: Add your components here. If the page does not load it will go to an error page  -->
        <chat-bar></chat-bar>
      </div>
    </div>
</template>

<script>
import axios from 'axios'
import UserInfo from '@/components/UserProfile/UserInfo'
import ErrorPage from '@/components/ErrorPage/NotFound'
import HomeButton from '@/components/Common/HomeButton'
import Chat from '@/components/UserProfile/Chat'

export default {
  name: 'ProfilePage',
  components: {
    'user-info': UserInfo,
    'error-page404': ErrorPage,
    'home-button': HomeButton,
    'chat-bar': Chat
  },
  data () {
    return {
      userName: '',
      errorFlag: '',
      userData: {
        firstName: '',
        lastName: '',
        description: '',
        skillLevel: '',
        gender: '',
        profileImage: '',
        myProfile: true
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
        // this.$store.mutations.mutateFirstName = 'Test'
        this.userData.lastName = response.data.LastName
        this.userData.description = response.data.Description
        this.userData.skillLevel = response.data.SkillLevel
        this.userData.gender = response.data.Gender
        this.userData.profileImage = response.data.ProfilePicture
        console.log(this.$store.getters.getusername)
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

  }
}
</script>

<style scoped>

#ProfileInfo{
  padding-left: 10em;
  width:auto;
  max-width:450px;
}
@media only screen and (min-width: 300px){
  #ProfileInfo{
    padding-left: 0em;
    width: auto;
  }
}
</style>
