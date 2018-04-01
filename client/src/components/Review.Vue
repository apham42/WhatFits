<template>
  <div class="review">
    <form>
      <ul class="list">
        <li v-for="star in maxRating" :class="{ 'active': star <= Rating }" @click="rate(star)" class="star">
          <icon scale="2" :name="star <= Rating ? 'star' : 'star-o'" />
        </li>
        <span v-if="hasCounter">{{ Rating }} of {{ maxRating }}</span>
      </ul>
      <div class="message">
        <br />
        <textarea v-model="ReviewMessage" class="form-control" placeholder="Input Review"></textarea>
      </div>
      <input type="number" id="UserID" size="8" placeholder="UserID" />
      <input type="number" id="RevieweeID" size="8" placeholder="RevieweeID" />
      <input type="number" id="ReviewID" size="8" placeholder="ReviewID"/>
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
      DateAndTime: new Date().toLocaleDateString(),
      ReviewID: '',
      results: ''
    }
  },
  methods: {
    rate (star) {
      if (typeof star === 'number' && star <= this.maxRating && star >= 0) {
        this.Rating = this.Rating === star ? star - 1 : star
      }
    },
    isNumber: function (evt) {
      evt = (evt) ? evt : window.event;
      var charCode = (evt.which) ? evt.which : evt.keyCode;
      if ((charCode > 31 && (charCode < 48 || charCode > 57)) && charCode !== 46) {
        evt.preventDefault();;
      } else {
        return true;
      }
    },
    input () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/Review/CreateReview',
        data: {
          Rating: this.$data.Rating,
          ReviewMessage: this.$data.ReviewMessage,
          UserID: this.$data.UserID,
          RevieweeID: this.$data.RevieeID,
          DateAndTime: this.$data.DateAndTime,
          ReviewID: this.$data.ReviewID
        },
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
            color: $active-color;
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
    color: $active-color;
  }
  textarea {
    width: 500px;
    height: 300px;
  }
</style>
