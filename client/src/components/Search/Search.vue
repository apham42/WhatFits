<template>
    <div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'SearchBar',
  data: function () {
    return {
      userInput: '',
      searchType: 'searchNearby',
      errors: []
    }
  },
  methods: {
    searchUser () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Search/Test',
        data: {
          username: this.$data.userInput
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$data.errors.push(response.data)
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.$data.errors = []
          this.$data.errors.push(error.response.data.Messages)
        })
    }
  }
}
</script>

<style>

</style>
