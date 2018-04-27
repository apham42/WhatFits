<template>
<div class = "LogContainer">
<div class = "Column">
<div v-for="(value,index) in results" :key="index">
      <div class="Cards">
        <div id="WorkoutType">
          <strong>Workout Type - {{value.WorkoutType}}</strong>
        <div class="Cardio" v-if="value.WorkoutType === 'Cardio'">
          <div id="details">
            <strong>Cardio Type</strong> : {{value.CardioType}}&emsp;
            <strong>Distance in miles</strong> : {{value.Distance}} mile(s)&emsp;
            <strong>Time it took</strong> : {{value.Time}} minute(s)&emsp;
          </div>
          <strong>Date done</strong> : {{value.Date_Time}}
        </div>
        <div class="WeightLifting" v-if="value.WorkoutType === 'WeightLifting'">
          <div id="details">
            <strong>Lifting Type</strong> : {{value.LiftingType}}&emsp;
            <strong>Sets</strong> : {{value.Sets}}&emsp;
            <strong>Reps per set</strong> : {{value.Reps}}&emsp;
          </div>
          <strong>Date done</strong> : {{value.Date_Time}}
        </div>
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
  created () {
    axios({
      method: 'POST',
      url: 'http://localhost/server/v1/WorkoutLogger/GetWorkout',
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
    displayWorkouts: function () {
      axios({
        method: 'POST',
        url: 'http://localhost/server/v1/WorkoutLogger/GetWorkout',
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
    }
  }
}
</script>

<style>
div.LogContainer {
overflow: auto;
}
div.Column{
  align-items: stretch;
  display: flex;
  flex-direction: column;
  flex-wrap: nowrap;
  overflow-x: auto;
  overflow-y: hidden;
}
div.Cards {
  max-height: 33.333%;
  padding: .75rem;
  margin-bottom: 2rem;
  border: 0;
  flex-basis: 33.333%;
  flex-grow: 0;
  flex-shrink: 0;
}
</style>
