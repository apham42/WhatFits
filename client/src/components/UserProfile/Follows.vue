<template>
<div>
  <div id="checkcondition">
    <span v-if="this.isfollow === true">
      <button id="isfollow" placeholder="UnFollow" v-on:click="UnFollow()">UnFollow</button>
    </span>
    <span v-else>
      <button id="isfollow" placeholder="Follow" v-on:click="Follow()">Follow</button>
    </span>
  </div>
</div>
</template>
<script>
import axios from 'axios'
// import store from '../../store/modules/User'

export default {
  name: 'FollowersList',
  data () {
    return {
      userName: 'test',
      errorFlag: '',
      errorMessage: 'Page Failed to load.',
      followers: [],
      isfollow: this.IsFollow(),
      follow: 'Follow',
      unfollow: 'UnFollow'
    }
  },
  methods: {
    Follow: function () {
      var vm = this
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/Addfollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': this.$store.getters.getusername + ' ' + this.$store.getters.getviewprofile
        },
        headers: this.$store.getters.getheader
      })
        // redirect to Home page
        .then(response => {
          vm.isfollow = !vm.isfollow
          return response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    },
    UnFollow: function () {
      var vm = this
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/Deletefollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': this.$store.getters.getusername + ' ' + this.$store.getters.getviewprofile
        },
        headers: this.$store.getters.getheader
      })
        // redirect to Home page
        .then(response => {
          vm.isfollow = !vm.isfollow
          return response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    },
    IsFollow: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/Isfollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': this.$store.getters.getusername + ' ' + this.$store.getters.getviewprofile
        },
        headers: this.$store.getters.getheader
      })
        // redirect to Home page
        .then(response => {
          this.$data.isfollow = response.data
          return response.data
        }).catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.errorMessage = 'Error: An Error Occurd.'
            this.errorFlag = true
          } else if (error.request) {
            this.errorMessage = 'Error: Server Error'
            this.errorFlag = true
          } else {
            this.errorMessage = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }
  }
}
</script>
<style>
#isfollow{
  border-radius: 10px 10px 10px 10px;
  border: solid #34495e;
  width: 120px;
  height: 35px;
  position: left;
  background: #34495e;
  color:white;
  transition: 0.5s;
  text-transform: uppercase;
  font-family: sans-serif;
  box-shadow: 0 5px 5px rgba(0,0,0,0.2);
  cursor: pointer;
}
#isfollow:hover{
  background: white;
  text-shadow: 0 5px 5px rgba(0,0,0,0.2);
  color: grey;
}
</style>
