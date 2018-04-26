<template>
<div>Follow
  <button id = "add" name="add" v-on:click="Follow()"></button>
  UnFollow
  <button id ="delete" name="delete" v-on:click="UnFollow()"></button>
  IsFollow
  <button id ="isfollow" name="isfollo" v-on:click="IsFollow()"></button>
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
      followers: []
    }
  },
  watch: {
  },
  mounted () {
    console('mounted')
  },
  methods: {
    Follow: function () {
      console.log('call add follow')
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/addfollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': 'chattest1' + ' ' + 'chattest5'
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then(response => {
          console.log(response.data)
          return response.data
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
    UnFollow: function () {
      console.log('call delete follow')
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/deletefollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': 'chattest1' + ' ' + 'chattest5'
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then(response => {
          console.log(response.data)
          return response.data
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
    IsFollow: function () {
      console.log('call is follow')
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/follows/isfollows',
        data: {
          // 'Username': this.$store.getters.getusername,
          'Username': 'chattest1' + ' ' + 'chattest5'
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then(response => {
          console.log(response.data)
          return response.data
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
  },
  GetFollows: function () {
    console.log('call follows')
    axios({
      method: 'POST',
      url: 'http://localhost/server/v1/follows/getfollows',
      data: {
        'Username': this.$store.getters.getusername
      },
      headers: {
        'Access-Control-Allow-Origin': 'http://localhost:8080',
        'Content-Type': 'application/json'
      }
    })
      // redirect to Home page
      .then(response => {
        console.log(response.data)
        return response.data
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
</script>
