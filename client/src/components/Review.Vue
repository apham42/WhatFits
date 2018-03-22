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
      <input type="number" name="UserID" size="10" />
      <button v-on:click.once="Submit">Submit</button>
    </form>
  </div>
</template>

<script>
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
      Rating: this.grade,
      ReviewMessage: '',
      UserID: ''
    }
  },
  methods: {
    rate (star) {
      if (typeof star === 'number' && star <= this.maxRating && star >= 0) {
        this.Rating = this.Rating === star ? star - 1 : star
      }
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
