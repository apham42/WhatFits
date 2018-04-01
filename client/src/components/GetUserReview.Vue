<template>
  <div>
    <h1>{{pageTitle}}</h1>
    <form>
      <div>
        <label for="UserName">UserName</label>
        <input v-model="UserName" placeholder="'abcd'"/>
      </div>
      <span>
        <button @click="displayReviews">Search Button</button>
      </span>
    </form>
    <div class="ReviewSection">
      <ul>
        <li v-for="value in results">
          {{ value }}
        </li>
      </ul>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'GetUserReview',
    data: function () {
      return {
        pageTitle: 'User Review',
        UserName: '',
        results: []
      }
  },
  methods: {
    displayReviews() {
      axios({
        method: 'GET',
        url: 'http://localhost/server/review/getuserreview/' + this.UserName,
        headers: {
          'Access-Control-Allow-Origin': '*',
          'Content-Type': 'application/json'
        }
      })
        .then(response => {
          this.results = response.data
          console.log(response)
        }).catch((error) => {
          console.log(error);
        })
    }
  }
}
</script>
