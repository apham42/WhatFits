<template>
  <div>
    <div>
      <ul id="Review_List">
        <!--Iterates through results list with review as index key. Grabs all the reviews
          Items located on the index are DTO objects, seperated by variable name-->
        <li v-for="(review,index) in results" :key="index">
          <section id="specificReviews">
            <div id="messageFormat">
              User Review: '{{ review.ReviewMessage }}' &nbsp;&nbsp;&nbsp;&nbsp; Recevied Rating : '{{ review.Rating }}'
            </div>
            <div id="dateFormat">
              <!--To be fixed when implemented onto profile page CSS-->
              &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date Reviewed: '{{ trimDate(review.DateAndTime) }}'
            </div>
            <br>
          </section>
        </li>
        <p v-if="results.length === 0">
          <strong>No Reviews in this profile :(</strong>
        </p>
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
      pageTitle: 'Review List',
      Username: this.$store.getters.getviewprofile,
      results: []
    }
  },
  created () {
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
  },
  methods: {
    trimDate: function (input) {
      var trim = input.substring(0, 10)
      return trim
    },
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
          if (error.response.status === 400) {
            // Your custom messages that appears on the screen
            console.log(error.response)
          } else if (error.response.status === 404) {
            // Redirects you to the 404 page
            this.$router.push('/notfound')
          } else if (error.response.status === 403) {
            // Redirects you to the Forbidden page
            this.$router.push('/notAllowed')
          } else if (error.response.status === 500) {
            // Redirects you to the server issue page
            this.$router.push('/serverissue')
          }
        })
    }
  }
}
</script>
<style>
.title{
  text-align: center;
}
</style>
