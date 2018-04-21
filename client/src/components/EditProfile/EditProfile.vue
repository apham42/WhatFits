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
      </div>
    </div>
</template>

<script>
import axios from 'axios'

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
      errorMessage: 'Page Failed to load.',
      userData: {
        firstName: '',
        lastName: '',
        description: '',
        skillLevel: '',
        gender: '',
        profileImage: '../../assets/Images/ProfileDummy/backgroundImage.jpg',
        myProfile: false
      }
    }
  },
  methods: {

  }
}
</script>

<style scoped>


</style>
