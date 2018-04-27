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
      <button type="submit" class="search-button" @click.prevent="searchBar">Search</button>
      <div class="errorResponse">
            <p v-for="message in messages[0]" :key="message"> {{message}} </p>
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
