<template>
    <div class = "log">
        <form @submit.prevent = "addWorkout">
            <select v-model = WorkoutLogger.WorkoutType>
                <option v-for="type in WorkoutOptions" :key="type">{{ type }}</option>
            </select>
            <p1>
                <div v-if = "WorkoutLogger.WorkoutType === 'Lifting'">
                    <select v-model = WorkoutLogger.LiftingType>
                      <option v-for="liftingtype in LiftingOptions" :key="liftingtype">{{ liftingtype }}</option>
                    </select>
                    <label for="Reps">Reps</label>
                    <input v-model="WorkoutLogger.Reps" v-on:keypress="isInteger(event)" placeholder="0" />
                    <label for="Sets">Sets</label>
                    <input v-model="WorkoutLogger.Sets" v-on:keypress="isInteger(event)" placeholder="0" />
                </div>
                <div v-if = "WorkoutLogger.WorkoutType === 'Cardio'">
                    <select v-model = WorkoutLogger.CardioType>
                      <option v-for="cardiotype in CardioOptions" :key="cardiotype">{{ cardiotype }}</option>
                    </select>
                    <label for="Distance">Distance</label>
                    <input v-model="WorkoutLogger.Distance" v-on:keypress="isFloat(event)" placeholder="0.00" />
                    <label for="Time">Time</label>
                    <input v-model="WorkoutLogger.Time" v-on:keypress="isTime(event)" placeholder="0:00" />
                </div>
            </p1>
          <button v-on:click.prevent="submit">Add Workout</button>
        </form>
        <div id="preview">
          <h3> Preview Log </h3>
          <p> {{WorkoutLogger.WorkoutType}} </p>
          <!--error is here for some reason-->
          <p v-if = "WorkoutLogger.WorkoutType === 'Lifting'">
              {{WorkoutLogger.LiftingType}}
              {{WorkoutLogger.Reps}}
              {{WorkoutLogger.Sets}}
          </p>
          <p v-else-if = "WorkoutLogger.WorkoutType === 'Cardio'">
              {{WorkoutLogger.CardioType}}
              {{WorkoutLogger.Distance}}
              {{WorkoutLogger.Time}}
          </p>
        </div>
        <ul>
            <transition-group name ="list" enter-active-class="animated bounceInUp">
            </transition-group>
        </ul>
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
      WorkoutOptions: ['Lifting', 'Cardio'],
      LiftingOptions: ['BenchPress', 'Curls', 'PullUps'],
      CardioOptions: ['Sprinting', 'Running', 'Swimming']
    }
  },
  methods: {
    AddLog: function () {

    },
    isFloat: function (evt) {
      evt = evt || window.event
      var charCode = evt.which ? evt.which : evt.keyCode
      if (
        charCode > 31 &&
        (charCode < 48 || charCode > 57) &&
        charCode !== 46
      ) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    isTime: function (evt) {
      evt = evt || window.event
      var charCode = evt.which ? evt.which : evt.keyCode
      if (
        charCode > 31 &&
        (charCode < 48 || charCode > 57) &&
        charCode !== 58
      ) {
        evt.preventDefault()
      } else {
        return true
      }
    },
    isInteger: function (evt) {
      evt = evt || window.event
      var charCode = evt.which ? evt.which : evt.keyCode
      if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        evt.preventDefault()
      } else {
        return true
      }
    }
  },
  submit () {
    axios({
      method: 'POST',
      url: 'http://localhost/server/WorkoutLogger/CreateWorkout',
      data: {
        WorkoutType: this.WorkoutLogger.WorkoutType,
        Date_Time: this.WorkoutLogger.Date_Time
      },
      headers: {
        'Access-Control-Allow-Origin': '*',
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
</script>

<style>

</style>
