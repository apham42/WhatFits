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
      jwt: 'eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFwaGFtNDIiLCJ3ZWJzaXRlIjoiV2hhdGZpdHMuc29jaWFsIiwiV09SS09VVF9BREQiOiJBREQiLCJuYmYiOjE1MjA1NjUxMjEsImV4cCI6MTUyMDU2ODcyMSwiaWF0IjoxNTIwNTY1MTIxfQ.HFFQr8QtI6efVh2kqbbVDShUXyaHQM72sbj5cxAJs-U'}
  },
  methods: {
    TestingMethod () {
      this.$data.testingdata = 'buttonworks'
    },
    TestPOST () {
      var token = ('input[name="__RequestVerificationToken"]').val()
      axios({
        method: 'POST',
        url: 'http://localhost/server/UACTEST/one',
        headers: {
          'contentType': 'application/json; charset=utf-8',
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Token': this.$data.jwt,
          '__RequestVerificationToken': token
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
