<template>
    <div class = "log">
        <form>
            <select v-model = WorkoutLogger.WorkoutType>
                <option v-for="type in WorkoutOptions" :key="type">{{ type }}</option>
            </select>
            <div>
                <div v-if = "WorkoutLogger.WorkoutType === 'WeightLifting'">
                    <select v-model = WorkoutLogger.LiftingType>
                      <option v-for="type in LiftingOptions" :key="type">{{ type }}</option>
                    </select>
                    <label for="Reps">Reps</label>
                    <input v-model="WorkoutLogger.Reps" placeholder="'0'" v-on:keypress="isNumber(event)"/>
                    <label for="Sets">Sets</label>
                    <input v-model="WorkoutLogger.Sets" placeholder="'0'" v-on:keypress="isNumber(event)"/>
                </div>
                <div v-if = "WorkoutLogger.WorkoutType === 'Cardio'">
                    <select v-model = WorkoutLogger.CardioType>
                      <option v-for="type in CardioOptions" :key="type">{{ type }}</option>
                    </select>
                    <label for="Distance">Distance in Miles</label>
                    <input v-model="WorkoutLogger.Distance" placeholder="'0.00'" v-on:keypress="isFloat(event)"/>
                    <label for="Time">Time in Minutes</label>
                    <input v-model="WorkoutLogger.Time" placeholder="'0:00'" v-on:keypress="isTime(event)"/>
                </div>
            </div>
          <button type="submit" @click.prevent="submit">Add Workout</button>
        </form>
        <div id="preview">
          <h3> Preview Log </h3>
          <p><strong>Workout Type - {{WorkoutLogger.WorkoutType}} </strong></p>
          <p v-if = "WorkoutLogger.WorkoutType === 'WeightLifting'">
              <strong>Lifting Type</strong> : {{WorkoutLogger.LiftingType}}&emsp;
              <strong>Sets</strong> : {{WorkoutLogger.Sets}}&emsp;
              <strong>Reps per set</strong> : {{WorkoutLogger.Reps}}&emsp;
          </p>
          <p v-if = "WorkoutLogger.WorkoutType === 'Cardio'">
              <strong>Cardio Type</strong> : {{WorkoutLogger.CardioType}}&emsp;
              <strong>Distance in miles</strong> : {{WorkoutLogger.Distance}} mile(s)&emsp;
              <strong>Time it took</strong> : {{WorkoutLogger.Time}} minute(s)&emsp;
          </p>
        </div>
    </div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'WorkoutLogger',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data: function () {
    return {
      WorkoutLogger: {
        Username: this.$store.getters.getusername,
        WorkoutType: '',
        CardioType: '',
        LiftingType: '',
        Reps: '',
        Sets: '',
        Time: '',
        Distance: '',
        Date_Time: new Date().toLocaleDateString()
      },
      pageTitle: 'Workout Logger',
      hasErrored: false,
      container: '',
      containerHeight: '',
      WorkoutOptions: ['Cardio', 'WeightLifting'],
      CardioOptions: ['Sprinting', 'Running', 'Swimming'],
      LiftingOptions: ['BenchPress', 'Curls', 'PullUps']
    }
  },
  methods: {
    isNumber: function (evt) {
      evt = (evt) || window.event
      var charCode = (evt.which) || evt.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57))) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    isTime: function (evt) {
      evt = (evt) || window.event
      var charCode = (evt.which) || evt.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57) && charCode !== 58)) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    isFloat: function (evt) {
      evt = (evt) || window.event
      var charCode = (evt.which) || evt.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57) && charCode !== 46)) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    submit: function () {
      if (this.WorkoutLogger.WorkoutType === 'Cardio') {
        axios({
          method: 'POST',
          url: 'http://localhost/server/v1/WorkoutLogger/CreateWorkout',
          data: {
            Username: this.$data.WorkoutLogger.Username,
            WorkoutType: this.$data.WorkoutLogger.WorkoutType,
            Date_Time: this.$data.WorkoutLogger.Date_Time,
            CardioType: this.$data.WorkoutLogger.CardioType,
            Distance: this.$data.WorkoutLogger.Distance,
            Time: this.$data.WorkoutLogger.Time
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8080',
            'Content-Type': 'application/json'
          }
        })
          .then(response => {
            console.log(response)
          })
          .catch(error => {
            console.log(error.response)
          })
      } else {
        axios({
          method: 'POST',
          url: 'http://localhost/server/v1/WorkoutLogger/CreateWorkout',
          data: {
            Username: this.$data.WorkoutLogger.Username,
            WorkoutType: this.$data.WorkoutLogger.WorkoutType,
            Date_Time: this.$data.WorkoutLogger.Date_Time,
            LiftingType: this.$data.WorkoutLogger.LiftingType,
            Reps: this.$data.WorkoutLogger.Reps,
            Sets: this.$data.WorkoutLogger.Sets
          },
          headers: {
            'Access-Control-Allow-Origin': 'http://localhost:8080',
            'Content-Type': 'application/json'
          }
        })
          .then(response => {
            console.log(response)
          })
          .catch(error => {
            console.log(error.response)
          })
      }
    }
  }
}
</script>

<style scoped>

</style>
