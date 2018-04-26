<template>
<div>follow</div>
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
      console('call follow')
    },
    UnFollow: function () {
    },
    IsFollow: function () {
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
