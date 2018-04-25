<template>
    <div>
      <div class = "result"> 
        <p></p>
      </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'Search',
  data: function () {
    return {
      Search: {
        requestedUser: '',
        skill: '',
        distance: 25,
      },
      messages: [],
      searchResults: []
    }
  },
  methods: {
    searchNearbyUsers () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Search/SearchNearby',
        data: {
          SearchCriteria: this.$data.Search
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages.push(response.data.Messages)
          this.$data.searchResults.push(response.data.SearchResults)
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
