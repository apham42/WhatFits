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
      TargetUser: this.$store.getters.viewprofile,
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
      }).catch((error) => {
        console.log(error.response)
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
