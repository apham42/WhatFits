<template>
    <div>
        <button v-on:click="TestPOST">{{ testingdata }}</button>
    </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'Test',
  data () {
    return {
      testingdata: 'Test Button',
      jwt: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJodHRwczovL3d3dy5XaGF0Zml0cy5zb2NpYWwvIiwic3ViIjoiYXBoYW00MiIsImF1ZCI6IkdlbmVyYWwiLCJpYXQiOiIxNTIxNTA5NTUyIiwibmJmIjoiMTUyMTUwOTU1MiIsImV4cCI6IjE1MjE1MTMxNTIifQ.Ez2eYtv1NwkzZ3aAeoJQkYJW2_fqRnn0qKDBzYlnOok'}
  },
  methods: {
    TestingMethod () {
      this.$data.testingdata = 'buttonworks'
    },
    TestPOST () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/UACTEST/one',
        headers: {
          'contentType': 'application/json; charset=utf-8',
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Token': this.$data.jwt
        }
      }).then((response) => {
        this.$data.testingdata = response.data
        console.log(response)
      }).catch((error) => {
        this.$data.hasErrored = true
        this.$data.pageError = 'XHR request failed'
        if (error.response) {
          // Server returned a response, but was not 200 OK
          this.$log('Request FAILED')
        } else if (error.request) {
          // Unable to complete request
          this.$log('Request Timeout or request not able to be executed')
        } else {
          // Error in callback
          this.$log('Callback error')
        }
      })
    }
  }
}
</script>
