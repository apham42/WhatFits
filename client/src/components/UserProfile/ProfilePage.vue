<template>
  <div class="container">
    <div class="columns is-desktop">
      <div class="column" >
        <user-info id="ProfileInfo" :userData="userData"></user-info>
      </div>
      <div class="column" id="workoutsColumn">

        <h1 id="title">Workout Logs</h1>
        <hr>
        <div v-if="this.userData.myProfile == true">
          <workout-logger id="Logger"></workout-logger>
        </div>
        <workout-log ></workout-log>
      </div>
      <div class="column" id="workoutsColumn" >
        <h1 id="title" >Reviews on Me</h1>
          <hr>
          <get-reviews ></get-reviews>
        <!--
        <h1 id="title">Events</h1>
        <hr>
        <div id="munnyColumn">
          <P style="padding-top:5em;padding-bottom:5em;" id="title">List of Events</P>
        </div>
        <div style="padding-top:2em;"></div>
        <div id="munnyColumn">
          <P style="padding-top:5em;padding-bottom:5em " id="title">Potential Ad Space $$$$</P>
        </div>
        -->
      </div>
    </div>
    <chat-bar></chat-bar>
  </div>
</template>
<script>
import GetWorkouts from '@/components/UserProfile/GetWorkouts'
import UserInfo from '@/components/UserProfile/UserInfo'
import ErrorPage from '@/components/ErrorPage/NotFound'
import HomeButton from '@/components/Common/HomeButton'
import Chat from '@/components/UserProfile/Chat'
import WorkoutLogger from '@/components/UserProfile/WorkoutLogger'
import GetUserReview from '@/components/Reviews/GetUserReview'
import Review from '@/components/Reviews/Review'
import axios from 'axios'

export default {
  name: 'ProfilePage',
  components: {
    'user-info': UserInfo,
    'error-page404': ErrorPage,
    'home-button': HomeButton,
    'chat-bar': Chat,
    'workout-log': GetWorkouts,
    'workout-logger': WorkoutLogger,
    'get-reviews': GetUserReview,
    'review': Review
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
        profileImagePath: '',
        myProfile: true
      }
    }
  },
  watch: {
  },
  created () {
    if (this.$store.getters.getviewprofile === this.$store.getters.getusername) {
      this.myProfile = true
    } else {
      this.myProfile = false
    }
    axios({
      method: 'POST',
      url: this.$store.getters.getURL + 'v1/UserProfile/ProfileData',
      headers: this.$store.getters.getheader,
      data: {
        'Username': this.$store.getters.getviewprofile,
        'LoggedinUser': this.$store.getters.userName
      }
    })
    // redirect to Home page
      .then(response => {
        this.userData.firstName = response.data.FirstName
        this.userData.lastName = response.data.LastName
        this.userData.description = response.data.Description
        this.userData.skillLevel = response.data.SkillLevel
        this.userData.gender = response.data.Gender
        this.userData.profileImagePath = this.$store.getters.getprofilepicture + response.data.ProfilePicture
        this.errorFlag = false
        if (this.$store.getters.getviewprofile === this.$store.getters.getusername) {
          this.userData.myProfile = true
        } else {
          this.userData.myProfile = false
        }
      }).catch((error) => {
      // Pushes the error messages into error to display
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
  },
  methods: {
  }
}
</script>

<style scoped>

#ProfileInfo{

  width:30em;
  max-width:100%;
  float:left;
  position: relative;
}
#workoutsColumn {
  padding-left:2em;
  padding-top:2em;
}
#Logger{
  padding-top: 1.5%;
  padding-bottom:2.5%;
  padding-left: 1%;
  left:1.8%;
  position: relative;
}
#Reviews{
  float:left;
  max-width:30%;
  overflow:auto;
  padding-right:3%;
  padding-top:0.5%;
}
#munnyColumn {
border-style: dotted;
text-align: center;
}
</style>
