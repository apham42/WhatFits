<template>
    <div class = "log">
        <form @submit.prevent = "addWorkout">
            <select v-model = WorkoutLogger.WorkoutType>
                <option v-for="type in WorkoutOptions" :key="type">{{ type }}</option>
            </select>
            <p1>
                <div v-if = "WorkoutLogger.WorkoutType === 'WeightLifting'">
                    <select v-model = WorkoutLogger.LiftingType>
                      <option v-for="type in LiftingOptions" :key="type">{{ type }}</option>
                    </select>
                    <label for="Reps">Reps</label>
                    <input v-model="WorkoutLogger.Reps" placeholder="'0'" />
                    <label for="Sets">Sets</label>
                    <input v-model="WorkoutLogger.Sets" placeholder="'0'" />
                </div>
                <div v-if = "WorkoutLogger.WorkoutType === 'Cardio'">
                    <select v-model = WorkoutLogger.CardioType>
                      <option v-for="type in CardioOptions" :key="type">{{ type }}</option>
                    </select>
                    <label for="Distance">Distance</label>
                    <input v-model="WorkoutLogger.Distance" placeholder="'0.00'" />
                    <label for="Time">Time</label>
                    <input v-model="WorkoutLogger.Time" placeholder="'0:00'" />
                </div>
            </p1>
          <button v-on:click.prevent="submit">Add Workout</button>
        </form>
        <div id="preview">
          <h3> Preview Log </h3>
          <p> {{WorkoutLogger.WorkoutType}} </p>
          <p v-if = "WorkoutLogger.WorkoutType === 'WeightLifting'">
              {{WorkoutLogger.LiftingType}}
              {{WorkoutLogger.Sets}}
              {{WorkoutLogger.Reps}}
          </p>
          <p v-if = "WorkoutLogger.WorkoutType === 'Cardio'">
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
        userName: this.$store.getters.getusername,
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
      WorkoutOptions: ['Cardio', 'Lifting'],
      CardioOptions: ['Sprinting', 'Running', 'Swimming'],
      LiftingOptions: ['BenchPress', 'Curls', 'PullUps']
    }
  },
  methods: {
    AddLog: function () {}
  },
  submit () {
    if(this.WorkoutType === 'Cardio'){
      axios({
        method: 'POST',
        url: 'http://localhost/server/WorkoutLog/CreateWorkout',
        data: {
          userName: this.WorkoutLogger.userName,
          WorkoutType: this.WorkoutLogger.WorkoutType,
          Date_Time: this.WorkoutLogger.Date_Time,
          CardioType: this.CardioType,
          Distance: this.Distance,
          Time: this.Time
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
    else if(this.WorkoutType === 'WeightLifting'){
      axios({
        method: 'POST',
        url: 'http://localhost/server/WorkoutLog/CreateWorkout',
        data: {
          userName:  this.WorkoutLogger.userName,
          WorkoutType: this.WorkoutLogger.WorkoutType,
          Date_Time: this.WorkoutLogger.Date_Time,
          LiftingType: this.LiftingType,
          Reps: this.Reps,
          Sets: this.Sets
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
}
</script>

<style scoped>

</style>
