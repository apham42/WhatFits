<template>
    <div>
      <p>Hello</p>
      <p> {{ ShowUsername }} </p>
      <p> {{ GetToken }} </p>
      <p> {{ GetViewClaims }} </p>
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
  computed: {
    ShowUsername: function () {
      return this.$store.getters.getusername
    },
    // remove get token function just for testing
    GetToken: function () {
      return this.$store.getters.gettoken
    },
    GetViewClaims: function () {
      return this.$store.getters.getviewclaims
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
</style>
