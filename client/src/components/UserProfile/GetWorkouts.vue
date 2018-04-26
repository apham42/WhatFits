<template>
<div class = "LogContainer">
<div class = "Column">
<div v-for="value in results" :key="value">
      <div class="Cards">
        <div id="WorkoutType">
          {{value.WorkoutType}}
        <div class="Cardio" v-if="value.WorkoutType === 'Cardio'">
          <div id="details">
            Cardio Type : {{value.CardioType}}
            Distance in miles : {{value.Distance}}
            Time it took : {{value.Time}}
          </div>
          Date done : {{value.Date_Time}}
        </div>
        <div class="WeightLifting" v-if="value.WorkoutType === 'WeightLifting'">
          <div id="details">
            Lifting Type : {{value.LiftingType}}
            Sets : {{value.Sets}}
            Reps per set : {{value.Reps}}
          </div>
          Date done : {{value.Date_Time}}
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
      Username: this.$store.getters.getusername,
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
