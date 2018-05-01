<template>
<div>
  <div class="field has-addons has-addons-centered">
    <p class="control">
      <span class="select">
        <select v-model="searchType">
        <option value = 'searchNearby'>Search Nearby Users</option>
        <option value = 'searchUser'>Search User</option>
      </select>
      </span>
    </p>
    <p class="control">
      <template v-if="searchType == 'searchUser'">
        <input class="input" type="text" v-model.trim = "userInput" placeholder="Enter username" key="searchUser-input">
      </template>
       <template v-else>
        <input class="input" type="text" v-model.trim = "userInput" placeholder="Enter address" key="searchNearby-input">
      </template>
    </p>
    <p class="control" >
      <a class="button is-primary" style="background-color: #2F7F82" @click.prevent="searchBar">
    <span class="icon">
     <i class="fas fa-search"></i>
    </span>
    <span>Search</span>
  </a>
      <!-- <button type="submit" class="search-button" @click.prevent="searchBar">Search</button>-->
    </p>
      <div class="errorResponse">
            <p v-for="message in messages[0]" :key="message"> {{message}} </p>
      </div>

    </div>
</div>

</template>

<script>
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
    searchBar () {
      this.$store.dispatch('actRequestedSearch', {requestedSearch: this.$data.userInput})
      this.$store.dispatch('actSearchType', {searchType: this.$data.searchType})
      this.$router.push('/Search')
      // TODO: use emit to Search and SearchBar
    }
  }
}
</script>

<style>

</style>
