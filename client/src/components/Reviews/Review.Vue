<template>
<div class="container">

  <br>
  <div class="card">
    <div class="card-header">
      <span class="title center">Review
        <br>
        <ul class="list">
          <li v-for="star in maxRating" :key="star" :class="{ 'active': star <= Rating }" @click="rate(star)" class="star">
            <icon scale="2" :name="star <= Rating ? 'star' : 'star-o'" />
          </li>
        <span style="padding-left:1em; font-size:1.2em;" v-if="hasCounter">{{ Rating }} of {{ maxRating }}</span>
      </ul>
      </span>
    </div>

      <div class="message card-content">
        <br />
        <div class="content">
          <textarea class="textarea" v-model="ReviewMessage" placeholder="Input Review"></textarea>
        </div>
      </div>
  </div>
  <br>
<div style="padding-left:45%">
<button class="button is-primary" type="submit" @click.prevent="input">Submit</button>
</div>

</div>

</template>

<script>
import axios from 'axios'
import 'vue-awesome/icons/star'
import 'vue-awesome/icons/star-o'
import Icon from 'vue-awesome/components/Icon'
export default {
  name: 'Review',
  components: { Icon },
  props: {
    maxRating: {
      type: Number,
      default: 5
    },
    hasCounter: {
      type: Boolean,
      default: true
    }
  },
  data: function () {
    return {
      Username: this.$store.getters.getusername,
      Rating: this.Rating,
      ReviewMessage: '',
      TargetUser: this.$store.getters.getviewprofile,
      DateAndTime: new Date().toLocaleDateString()
    }
  },
  methods: {
    rate (star) {
      if (typeof star === 'number' && star <= this.maxRating && star >= 0) {
        this.Rating = this.Rating === star ? star - 1 : star
      }
    },
    isNumber: function (evt) {
      evt = (evt) || window.event
      var charCode = (evt.which) || evt.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57))) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    goBackToProfile: function () {
      this.$store.dispatch('actviewprofile', {ViewProfile: this.$store.getters.getusername})
      this.$router.push('/profile')
    },
    input: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/Review/CreateReview',
        data: {
          Rating: this.$data.Rating,
          ReviewMessage: this.$data.ReviewMessage,
          TargetUser: this.$data.TargetUser,
          Username: this.$data.Username,
          DateAndTime: this.$data.DateAndTime
        },
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8080',
          'Content-Type': 'application/json'
        }
      }).then(response => {
        console.log(response)
        this.goBackToProfile()
      }).catch((error) => {
        if (error.response.status === 400) {
        // Your custom messages that appears on the screen
          console.log(error.response)
          this.goBackToProfile()
          alert('Review did not go through. Check console for errors.')
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
.center {
  margin: auto;
    font-size:2em;
    text-align: center;
}
  .review {
    font-family: 'Avenir', Helvetica, Arial, sans-serif;
    font-size: 22px;
    color: #a7a8a8;
  }
  .list {
    margin: 0 0 5px 0;
    padding: 0;
    list-style-type: none;
  }
  .star {
    display: inline-block;
    cursor: pointer;
  }
  .active {
    color: #34495E;
  }
  textarea {
    width: 50%;
    height: 50%;
  }
</style>
