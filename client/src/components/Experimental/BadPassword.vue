<template>
    <div>
      <input type="text"
         v-on:keyup="testPassword" v-model="text"
        placeholder="start typing..." />
    <pre>Input Value: {{text}}</pre>
    </div>
</template>

<script>
import axios from 'axios'
import debounce from 'debounce'
import sha1 from 'sha1'
export default {
  name: 'BadPassword',
  components: {

  },
  data () {
    return {
      text: '',
      payload: '',
      maxValue: 80
    }
  },
  methods: {
    testPassword: debounce(function (e) {
      // console.log('You have stopped typing')
      // Hashes the password to SHA1 for webservice consumption
      if (this.text.length < 8) {
        console.log('too short')
        return
      }
      console.log(this.text)
      var hashedPassword = sha1(this.text)
      console.log(hashedPassword)
      // Parsing the hash into two variables, one to be send and one to be compared
      var preffix = hashedPassword.substring(0, 5)
      console.log(preffix)
      var suffix = hashedPassword.slice(5)
      console.log(suffix)
      // Creating GET request to pwnedpassword service
      axios({
        method: 'GET',
        url: 'https://api.pwnedpasswords.com/range/' + preffix
      })
        .then(response => {
          console.log(response.data)
          var payload = response.data
          // Process Results
          var suffixList = payload.split('\n')
          for (var i = 0; i < suffixList.length; i++) {
            var row = suffixList[i].split(':')
            // console.log(row[0])
            // console.log('This is my suffix: ' + suffix)
            console.log(row[0])
            if (suffix === row[0].toLowerCase()) {
              console.log('Found')
              if (row[0] < 80) {
                return true
              } else {
                return false
              }
            }
          }
          console.log('Hash was not found in list.')
          return true
        })
        .catch((error) => {
          // Pushes the error messages into error to display
          if (error.response) {
            this.statusMessages = 'Error: An Error Occurd.'
            console.log('An Error Occured')
            this.errorFlag = true
            console.log(error.response)
          } else if (error.request) {
            this.statusMessages = 'Error: Server Error'
            this.errorFlag = true
            console.log(error.request)
          } else {
            this.statusMessages = 'An error occured while setting up request.'
            this.errorFlag = true
          }
        })
    }, 1000)
  }
}
</script>

<style scoped>

</style>
