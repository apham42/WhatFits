<template>
  <div class="container">
    <div class="columns">
      <div class="column is-one-third">
        <br>
        <p  class="secondaryTitleLeft">Search Bar</p>
        <br>
        <div id = "searchType">
          <div class="field has-addons has-addons-centered">
          <p class="control">
            <span class="select">
              <select v-model="searchType">
              <option value = 'searchNearby'>Search Nearby Users</option>
              <option value = 'searchUser'>Search User</option>
            </select>
            </span>
          </p>

            <div id = "userInput control" class="control">
            <template v-if="searchType == 'searchUser'">
              <input class="input" type="text" v-model.trim ="SearchUser.requestedUser" placeholder="Enter username" key="searchUser-input">
            </template>
            <template v-else>
              <input class="input" type="text" v-model.trim ="SearchNearby.requestedSearch" placeholder="Enter address" key="searchNearby-input">
            </template>
          </div>
          <p class="control">
            <a class="button is-primary" @click.prevent="search" >
              Search
            </a>
          </p>
        </div>

        </div>
        <br>
        <div v-if="searchType !== 'searchUser'" id = "SearchNearbyForm">
          <div id class="control">
            <div>
              <p id="Label">Skill</p>
            </div>
            <div class="select">
              <select v-model="SearchNearby.skill">
                <option value ="">Any</option>
                <option v-for="skill in skills" :key="skill"> {{skill}} </option>
              </select>
            </div>
          </div>
          <br>
          <div>
            <p>Distance</p>
          </div>
          <div class="control ">
            <div class="select is-one-third">
              <select v-model="SearchNearby.distance">
                <option v-for="distance in distances" :key="distance"> {{distance}} </option>
              </select>
            </div>
          </div>
          <br>
        </div>
      </div>
      <div class="column is-two-thirds">

        <span class="title">Search Results</span>

        <hr>

        <div class="response card" v-show="this.$data.messages.length > 0">
          <p style="text-align:center;" v-for="message in messages[0]" :key="message"> {{message}} </p>
        </div>
        <div id="spacing"></div>

        <div id="displayResults" v-if ="this.$data.searchResults.length > 0">
          <div v-if ="this.$data.searchResults[0].length > 10" class="field is-grouped">
            <p class="control">
              <a class="button is-secondary" @click.prevent="back">Back</a>
            </p>
            <p class="control">
              <a class="button is-primary"  @click.prevent="next">Next</a>
            </p>
          </div>

          <div v-for="searchResult in searchResults[0].slice(this.$data.nextTen,this.$data.nextTen + 10)" :key="searchResult.User">
            <div class="card">
              <div class="card-header cardTitle">
                <p class ='view-profile' @click="setViewProfile(searchResult.User)">{{searchResult.User}}</p>
              </div>
              <div class="card-content cardBody">
                <p>{{searchResult.FirstName}} {{searchResult.LastName}}</p>
                <p>Skill Level: {{searchResult.Skill}}</p>
                <p>Distance: {{searchResult.Distance}} mile</p>
              </div>
            </div>
            <div id="spacing"></div>
          </div>
          <div v-if ="this.$data.searchResults[0].length > 10" class="field is-grouped">
            <p class="control">
              <a class="button is-secondary" @click.prevent="back">Back</a>
            </p>
            <p class="control">
              <a class="button is-primary"  @click.prevent="next">Next</a>
            </p>
          </div>

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
      searchResults: [],
      searchType: this.$store.getters.getSearchType
    }
  },
  methods: {
    next () {
      if (this.$data.nextTen + 10 <= this.$data.searchResults[0].length) {
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
        url: this.$store.getters.getURL + 'v1/Search/SearchUser',
        data: {
          SearchUserCriteria: this.$data.SearchUser
        },
        headers: this.$store.getters.getheader
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages.push(response.data.Messages)
          this.$data.searchResults.push(response.data.SearchResults)
        })
        .catch((error) => {
          // Pushes the error messages into error to display
          this.$data.messages.push(error.response.data.Messages)
        })
    },
    searchNearbyUsers () {
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/Search/SearchNearby',
        data: {
          Criteria: this.$data.SearchNearby
        },
        headers: this.$store.getters.getheader
      })
        // redirect to Home page
        .then((response) => {
          this.$data.messages.push(response.data.Messages)
          this.$data.searchResults.push(response.data.SearchResults)
        }).catch((error) => {
          // Pushes the error messages into error to display
          this.messages.push(error.response.data.Messages)
        })
    },
    search () {
      this.$data.nextTen = 0
      this.$data.messages = []
      this.$data.searchResults = []
      if (this.$data.searchType === 'searchNearby') {
        this.searchNearbyUsers()
      } else if (this.$data.searchType === 'searchUser') {
        this.searchUser()
      } else {
        this.$data.messages = []
        this.$data.messages.push(['Please enter a search criteria'])
      }
    },
    setViewProfile (user) {
      this.$store.dispatch('actSearchType', {searchType: this.$data.searchType})
      if (this.$data.searchType === 'searchNearby') {
        this.$store.dispatch('actRequestedSearch', {requestedSearch: this.$data.SearchNearby.requestedSearch})
      } else {
        this.$store.dispatch('actRequestedSearch', {requestedSearch: this.$data.SearchUser.requestedUser})
      }
      this.$store.dispatch('actviewprofile', {ViewProfile: user})
      this.$router.push('/profile')
    }
  },
  created () {
    if (this.$data.searchType === 'searchNearby') {
      this.$data.SearchUser.requestedUser = ''
    } else {
      this.$data.SearchNearby.requestedSearch = ''
    }
    if (this.$data.searchType !== '') {
      this.search()
    }
  }
}
</script>

<style scoped>
.cardTitle{
  font-size:1.5em;
  padding-left: 1em;
}
.cardBody {
  font-size:1.2em;
}
.titleSearch{
  font-size:25px;
}

.secondaryTitleLeft{
  font-size: 22px;
}

.container {
    padding-top:2em;
}
#spacing {
padding-top:1em;
padding-bottom:1em;
}
.view-profile {
    color: #1abc9c;
    background-color: Transparent;
    background-repeat:no-repeat;
    border: none;
    cursor:pointer;
    overflow: hidden;
    outline:none;
}
</style>
