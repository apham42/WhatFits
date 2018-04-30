<template>
   <div class="container">
      <div class="columns">
         <div class="column is-one-third">
           <br>
           <p class="secondary-title">Additional Filters</p>
           <div>
            <p id="Label">Skill</p>
           </div>

            <div class="control">
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
            <div class="field is-grouped">
              <p class="control">
                <a class="button is-primary"  @click.prevent="next">
                  Next
                </a>
              </p>
              <p class="control">
                <a class="button is-secondary" @click.prevent="back">
                  Back
                </a>
              </p>
            </div>
         </div>
         <div class="column is-two-thirds">
            <h1 id="title">Search Results</h1>
            <hr>
              <div class="response card" v-show="this.$data.messages.length > 0">
               <p v-for="message in messages[0]" :key="message"> {{message}} </p>
              </div>

            <div v-if ="this.$data.filteredResults.length > 0">
         <div class="card" v-for="searchResult in filteredResults[0].slice(this.$data.nextTen,this.$data.nextTen + 10)" :key="searchResult">
            <div class = "container">
               <p class ='view-profile' @click="setViewProfile(searchResult.User)">{{searchResult.User}}</p>
               <p>{{searchResult.FirstName}} {{searchResult.LastName}}</p>
               <p>Skill Level: {{searchResult.Skill}}</p>
               <p>Distance: {{searchResult.Distance}} mile</p>
            </div>
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
      filteredResults: [],
      searchResults: [],
      searchType: this.$store.getters.getSearchType,
      m: this.$store.getters.getRequestedSearch
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
        headers: this.$store.getters.getheader
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
        headers: this.$store.getters.getheader
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
      if (this.$data.searchType === 'searchNearby') {
        this.searchNearbyUsers()
      } else {
        this.searchUser()
      }
    },
    setViewProfile (user) {
      this.$store.dispatch('actviewprofile', {ViewProfile: user})
      this.$router.push('/profile')
    }
  },
  mounted () {
    this.search()
  },
  /*
  computed: {
    t: function () {
      return this.$store.getters.getRequestedSearch
    },
    l: function () {
      return this.$store.getters.getSearchType
    }
  },
  */
  watch: {
    searchType: function () {
      if (this.$data.m !== this.$store.getters.getRequestedSearch) {
        this.search()
      }
    },
    m: function () {
      if (this.$data.searchType !== this.$store.getters.getSearchType) {
        this.search()
      }
    }
  }
}
</script>

<style scoped>
.secondary-title{
  font-size: 14px;
}
.container {
    padding-top:2em;
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
