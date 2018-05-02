<template>
  <div class="review">
    <form>
      <ul class="list">
        <li v-for="star in maxRating" :key="star" :class="{ 'active': star <= Rating }" @click="rate(star)" class="star">
          <icon scale="2" :name="star <= Rating ? 'star' : 'star-o'" />
        </li>
        <span v-if="hasCounter">{{ Rating }} of {{ maxRating }}</span>
      </ul>
      <div class="message">
        <br />
        <textarea v-model="ReviewMessage" class="form-control" placeholder="Input Review"></textarea>
      </div>
      <button type="submit" @click.prevent="input">Submit</button>
    </form>
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
  // props used to help determine number of stars counted
  props: {
    maxRating: {
      type: Number,
      default: 5
    },
    hasCounter: {
      type: Boolean,
      default: true
    },
    event
  },
  data: function () {
    return {
      Username: this.$store.getters.getusername,
      Rating: this.Rating,
      ReviewMessage: '',
      TargetUser: this.$store.getters.getviewprofile,
      Date_Time: new Date().toLocaleTimeString('en-US')
    }
  },
  methods: {
    // takes in which star is highlighted in list and return a rating
    rate (star) {
      if (typeof star === 'number' && star <= this.maxRating && star >= 0) {
        this.Rating = this.Rating === star ? star - 1 : star
      }
    },
    // method used to validate inputs to be only integers
    isNumber: function (evt) {
      evt = (evt) || window.event
      var charCode = (evt.which) || evt.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57))) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    // method to go back to profiler of user just revied
    goBackToProfile: function () {
      this.$store.dispatch('actviewprofile', {ViewProfile: this.$store.getters.getusername})
      this.$router.push('/profile')
    },
    // sending data via axios after submit button is clicked
    input: function () {
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/Review/CreateReview',
        data: {
          Rating: this.$data.Rating,
          ReviewMessage: this.$data.ReviewMessage,
          TargetUser: this.$data.TargetUser,
          Username: this.$data.Username,
          DateAndTime: this.$data.DateAndTime
        },
        headers: this.$store.getters.getheader
      }).then(response => {
        this.goBackToProfile()
      }).catch((error) => {
        if (error.response.status === 400) {
          this.goBackToProfile()
          alert('Review did not go through')
        } else if (error.response.status === 404) {
          this.$router.push('/notfound')
        } else if (error.response.status === 403) {
          this.$router.push('/notAllowed')
        } else if (error.response.status === 500) {
          this.$router.push('/serverissue')
        }
      })
    }
  }
}
</script>

<style>
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
    color: #FAFF5C;
  }
  textarea {
    width: 500px;
    height: 300px;
  }
</style>
