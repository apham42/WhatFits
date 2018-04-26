<template>
    <div>
      <form class = "filterForm">
        <h3 class = "skillFilter">Skill</h3>
          <select v-model="SearchNearby.skill">
              <option value ="">Any</option>
              <option v-for="skill in skills" :key="skill"> {{skill}} </option>
          </select>
        <h3 class = "distanceFilter">Distance</h3>
          <select v-model="SearchNearby.distance">
              <option v-for="distance in distances" :key="distance"> {{distance}} </option>
          </select>
      </form>
      <button @click.prevent="next">Next</button>
      <button @click.prevent="back">Back</button>
      <div class="response" v-show="this.$data.messages.length > 0">
            <p v-for="message in messages[0]" :key="message"> {{message}} </p>
      </div>
      <div v-if ="this.$data.filteredResults.length > 0">
        <div class="card" v-for="searchResult in filteredResults[0].slice(this.$data.nextTen,this.$data.nextTen + 10)" :key="searchResult">
          <div class = "container">
            <p>{{searchResult.User}}</p>
            <p>{{searchResult.FirstName}} {{searchResult.LastName}}</p>
            <p>Skill Level: {{searchResult.Skill}}</p>
            <p>Distance: {{searchResult.Distance}} mile</p>
          </div>
        </div>
      </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'Search',
  data: function () {
    return {
      SearchUser: {
        requestedUser: this.$store.getters.getRequestedSearch,
        requestedBy: this.$store.getters.getusername
      },
      SearchNearby: {
        requestedUser: this.$store.getters.getusername,
        requestedSearch: this.$store.getters.getRequestedSearch,
        skill: '',
        distance: 25
      },
      skills: ['Beginner', 'Intermediate', 'Advanced'],
      distances: [5, 10, 15, 20, 25],
      messages: [],
      nextTen: 0,
      filteredResults: [],
      searchResults: []
    }
  },
  methods: {
    next () {
      if (this.$data.nextTen + 10 <= this.$data.filteredResults[0].length) {
        this.$data.nextTen += 10
      }
    },
    back () {
      if (this.$data.nextTen - 10 >= 0) {
        this.$data.nextTen -= 10
      }
    },
    searchUser () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Search/SearchUser',
        data: {
          SearchUserCriteria: this.$data.SearchUser
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages = []
          this.$data.filteredResults = []
          this.$data.messages.push(response.data.Messages)
          this.$data.filteredResults.push(response.data.SearchResults)
          this.$data.searchResults.push(response.data.SearchResults)
          // this.$store.dispatch('actviewprofile', {ViewProfile: this.$data.SearchUser.requestedUser})
          // this.$router.push('/profile')
        })
        .catch((error) => {
          // Pushes the error messages into error to display
          this.$data.messages = []
          this.$data.messages.push(error.response.data.Messages)
        })
    },
    searchNearbyUsers () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Search/SearchNearby',
        data: {
          Criteria: this.$data.SearchNearby
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages = []
          this.$data.filteredResults = []
          this.$data.messages.push(response.data.Messages)
          this.$data.filteredResults.push(response.data.SearchResults)
          this.$data.searchResults.push(response.data.SearchResults)
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.$data.messages = []
          this.$data.messages.push(error.response.data.Messages)
        })
    },
    search () {
      var searchType = this.$store.getters.getSearchType
      if (searchType === 'searchNearby') {
        this.searchNearbyUsers()
      } else {
        this.searchUser()
      }
    }
  },
  beforeMount () {
    this.search()
  }
}
</script>

<style>
.card {
    margin: auto;
    box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
    transition: 0.3s;
    width: 50%;
}

.container {
    padding: 14px 16px;
}
</style>
