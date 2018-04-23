<template>
    <div>
      <template v-if="searchType == 'searchUser'">
        <input v-model.trim = "userInput" placeholder="Enter username" key="searchUser-input">
      </template>
      <template v-else>
        <input v-model.trim = "userInput" placeholder="Enter address" key="searchNearby-input">
      </template>
      <select v-model="searchType">
        <option value = 'searchNearby'>Search Nearby Users</option>
        <option value = 'searchUser'>Search User</option>
      </select>
      <button type="submit" class="register-button" @click.prevent="searchUser">Search</button>
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
      messages: []
    }
  },
  methods: {
    searchUser () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Search/' + this.$data.searchType,
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
          this.$data.messages = []
          this.$data.messages.push(response.data.Messages)
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.$data.messages = []
          this.$data.messages.push(error.response.data.Messages)
        })
    }
  }
}
</script>

<style>

</style>
