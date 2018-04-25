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
      <div class="errorResponse">
            <p v-for="message in messages[0]" :key="message"> {{message}} </p>
      </div>
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
        url: 'http://localhost/server/v1/Search/SearchUser',
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
          // this.$data.messages = []
          // this.$data.messages.push(response.data.Messages)
          this.$store.dispatch('actviewprofile', {ViewProfile: this.$data.userInput})
          this.$router.push('/profile')
        })
        .catch((error) => {
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
