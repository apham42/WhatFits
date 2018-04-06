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
      <label for="UserID">UserID</label>
      <input v-model="UserID" placeholder="'1'"/>
      <label for="RevieweeID">RevieweeID</label>
      <input v-model="RevieweeID" placeholder="'1'" />
      <button type="submit" @click="input">Submit</button>
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
      Rating: this.Rating,
      ReviewMessage: '',
      UserID: '',
      RevieweeID: '',
      DateAndTime: new Date().toLocaleDateString()
    }
  },
  methods: {
    rate (star) {
      if (typeof star === 'number' && star <= this.maxRating && star >= 0) {
        this.Rating = this.Rating === star ? star - 1 : star
      }
    },

    input () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/Review/CreateReview',
        data: {
          Rating: this.Rating,
          ReviewMessage: this.ReviewMessage,
          UserID: this.UserID,
          RevieweeID: this.RevieweeID,
          DateAndTime: this.DateAndTime
        },
        headers: {
          'Access-Control-Allow-Origin': '*',
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
    &:hover
      {
        .star
          {
            color: #FAFF5C;
          }
      }
  }
  .star {
    display: inline-block;
    cursor: pointer;
    &:hover
      {
        &~.star
          {
            &:not(.active)
            {
              color: inherit;
            }
          }
        }
  }
  .active {
    color: #FAFF5C;
  }
  textarea {
    width: 500px;
    height: 300px;
  }
</style>
