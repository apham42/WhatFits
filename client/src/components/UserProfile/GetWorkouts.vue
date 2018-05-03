<template>
  <div class="column" id="workoutlogs">
    <div v-for="(value,index) in results" :key="index">
      <div class="card" id="workoutCards">
        <div id="">
          <div class="card-header">
            <p class="card-header-title"><strong>Workout Type - {{value.WorkoutType}}</strong></p>
          </div>
          <div class="card-content" v-if="index == null">
            <div class="contentPadding">
              <strong>No Workouts in this profile :(</strong>
            </div>
           </div>
          <div class="card-content"  v-if="value.WorkoutType === 'Cardio'">
            <div class="contentPadding">
              <strong>Cardio Type</strong> : {{value.CardioType}}&emsp;
              <strong>Distance in miles</strong> : {{value.Distance}} mile(s)&emsp;
              <strong>Time it took</strong> : {{value.Time}} minute(s)&emsp;
              <br>
              <strong>Date done</strong> : {{trimDate(value.Date_Time)}}
            </div>
          </div>
          <div class="card-content" v-if="value.WorkoutType === 'WeightLifting'">
            <div id="contentPadding" >
              <strong>Lifting Type</strong> : {{value.LiftingType}}&emsp;
              <strong>Reps per set</strong> : {{value.Reps}}&emsp;
              <strong>Sets</strong> : {{value.Sets}}&emsp;
              <br>
              <strong>Date done</strong> : {{trimDate(value.Date_Time)}}
            </div>
          </div>
        </div>
      </div>
      <div id="spacing"></div>
    </div>
    <div class="card" id="workoutCards" v-if="results.length === 0">
      <div id="">
        <div class="card-content">
          <div class="contentPadding">
            <strong>No Workouts in this profile :(</strong>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'GetWorkouts',
  data: function () {
    return {
      Username: this.$store.getters.getviewprofile,
      results: []
    }
  },
  // function to display workouts on creation of the url
  beforeCreate () {
    axios({
      method: 'POST',
      url: this.$store.getters.getURL + 'v1/WorkoutLogger/GetWorkout',
      headers: this.$store.getters.getheader,
      data: {
        Username: this.$store.getters.getviewprofile
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
    // method used to trim the datetime from backend
    trimDate: function (input) {
      var trim = input.substring(0, 10)
      return trim
    }
  }
}
</script>

<style>
#workoutCards {
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
