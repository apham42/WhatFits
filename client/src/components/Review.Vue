<template>
  <div class="review">
    <ul class="list">
      <li v-for="star in maxStars" :class="{ 'active': star <= stars }" @click="rate(star)" class="star">
        <icon scale="2" :name="star <= stars ? 'star' : 'star-o'" />
      </li>
      <span v-if="hasCounter">{{ stars }} of {{ maxStars }}</span>
    </ul>
    <div class="message">
      <br />
      <textarea v-model="reviewText" class="form-control" placeholder="Input Review"></textarea>
    </div>
    <button v-on:click.once="Submit">Submit</button>
  </div>
</template>

<script>
import axios from 'axios'
import 'vue-awesome/icons/star'
import 'vue-awesome/icons/star-o'
import Icon from 'vue-awesome/components/Icon'
export default {
  name: 'Rating',
  components: { Icon },
  props: {
    grade: {
      type: Number,
      required: true
    },
    maxStars: {
      type: Number,
      default: 5
    },
    hasCounter: {
      type: Boolean,
      default: true
    }
  },
  data () {
    return {
      stars: this.grade
    }
  },
  methods: {
    rate (star) {
      if (typeof star === 'number' && star <= this.maxStars && star >= 0) {
        this.stars = this.stars === star ? star - 1 : star
      }
    }
    },
    Submit: function (event) {
      if (event) {
        Rating.RatingDataPush()
      }
    },
    RatingDataPush: function () {
     axios.post('http://localhost/server/Review/')
      .then(respons => {
        this.titlePost = respons.data
        alert('Rating Submitted to Server!')
      })
      .catch(e => {
        this.error.push(e)
      })
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
