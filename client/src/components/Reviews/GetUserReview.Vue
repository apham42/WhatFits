<template>
<div class="column" id="reviews">
    <div v-for="(review,index) in results" :key="index">
      <div class="card" id="reviewCards">
        <div id="">
          <div class="card-content">
            <div id="contentPadding" >
              <div id="messageFormat">
                Description : "{{ review.ReviewMessage }}"
              </div>
              <div id="ratingFormat">
                Received Rating : {{ review.Rating }}
              </div>
              <div id="dateFormat">
                <!--To be fixed when implemented onto profile page CSS-->
                Date Reviewed: {{ trimDate(review.DateAndTime) }}
              </div>
            </div>
          </div>
        </div>
      </div>
    <div id="spacing"></div>
  </div>
  <div class="card" id="reviewCards" v-if="results.length === 0">
      <div id="">
        <div class="card-content">
          <div class="contentPadding">
            <strong>No Reviews in this profile :(</strong>
            <strong>Be the first!</strong>
          </div>
        </div>
      </div>
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
      url: this.$store.getters.getURL + 'v1/review/getuserreview/',
      headers: this.$store.getters.getheader,
      data: {
        Username: this.$data.Username
      }
    })
      .then(response => {
        this.results = response.data
      })
      .catch(error => {
        if (error.response.status === 400) {
          // Your custom messages that appears on the screen
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
  },
  methods: {
    trimDate: function (input) {
      var trim = input.substring(0, 10)
      return trim
    },
    displayReviews: function () {
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/review/getuserreview/',
        headers: this.$store.getters.getheader,
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
#reviewCards {
  padding-bottom: 1em;
  position:inherit;
}
#spacing {
padding-top:1em;
padding-bottom:1em;
}
#title{
  font-size: 2em;
  text-align: center;
}
</style>
