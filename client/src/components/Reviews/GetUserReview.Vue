<template>
  <div id="content">
    <h1>{{pageTitle}}</h1>
    <form>
      <div>
        <label for="Username">Username</label>
        <input v-model="Username" placeholder= "abcd" />
      </div>
      <span>
        <button @click="displayReviews">Search Button</button>
      </span>
    </form>
    <div class="body">
      <ul id="Review_List">
        <!--Iterates through results list with review as index key. Grabs all the reviews
            Items located on the index are DTO objects, seperated by variable name-->
        <li v-for="review in results" :key="review">
          <section id="specificReviews">
            <div id="messageFormat">
              User Review: '{{ review.ReviewMessage }}' &nbsp;&nbsp;&nbsp;&nbsp; Recevied Rating : '{{ review.Rating }}'
            </div>
            <div id="dateFormat">
              <!--To be fixed when implemented onto profile page CSS-->
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date Reviewed: '{{ review.DateAndTime }}'
            </div>
          </section>
        </li>
      </ul>
    </div>
  </div>
</template>
<script>
import axios from 'axios'
export default {
  name: 'GetUserReview',
  data: function (results) {
    return {
      pageTitle: 'User Review',
      Username: '',
      results: []
    }
  },
  methods: {
    displayReviews: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/review/getuserreview/',
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        },
        data: {
          Username: this.$data.Username
        }
      })
        .then(response => {
          this.results = response.data
          console.log(response)
        })
        .catch(error => {
          console.log(error.response)
        })
    }
  }
}
</script>
<style>
.content {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  font-size: 22px;
  color: #a7a8a8;
}
section {
  border: 1px solid gray;
  padding: 1em;
  overflow: hidden;
  border-collapse: seperate;
  border-spacing: 15px;
}
</style>
