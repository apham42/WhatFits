<template>
  <div class = "log">
    <div class="field has-addons">
      <div class="control is-expanded">
        <div class="select is-fullwidth">
          <select v-model = WorkoutLogger.WorkoutType>
            <option  selected="true" disabled="true">Type of Workout</option>
            <option v-for="type in WorkoutOptions" :key="type">{{ type }}</option>
          </select>
        </div>
        <div id="workOutInput" >
          <div v-if = "WorkoutLogger.WorkoutType === 'WeightLifting'" class="card">
            <div class="card-header">
              <p class="card-header-title"><strong>New WeightLifting Log</strong></p>
            </div>
            <div class="card-content">
              <p >WeightLifting Type</p>
              <div class="select is-fullwidth">
                <select v-model = WorkoutLogger.LiftingType>
                  <option v-for="type in LiftingOptions" :key="type">{{ type }}</option>
                </select>
              </div>
              <!-- <label for="Reps">Reps</label>-->
              <p >Reps</p>
              <input  class="input" type="text" v-model="WorkoutLogger.Reps" placeholder="'0'" v-on:keypress="isNumber(event)"/>
              <!-- <label for="Sets">Sets</label>-->
              <p >Sets</p>
              <input  class="input" type="text" v-model="WorkoutLogger.Sets" placeholder="'0'" v-on:keypress="isNumber(event)"/>
            </div>
          </div>
          <div v-if = "WorkoutLogger.WorkoutType === 'Cardio'" class="card">
            <div class="card-header">
              <p class="card-header-title"><strong>New Cardio Log</strong></p>
            </div>
            <div class="card-content">
              <p >Cario Type</p>
              <div class="select is-fullwidth">
                <select v-model = WorkoutLogger.CardioType>
                  <option v-for="type in CardioOptions" :key="type">{{ type }}</option>
                </select>
              </div>
              <!-- <label for="Distance" >Distance in Miles</label> -->
              <p>Distance (Mi)</p>
              <input class="input" type="text" v-model="WorkoutLogger.Distance" placeholder="'0.00'" v-on:keypress="isFloat(event)"/>
              <!-- <label for="Time">Time in Minutes</label> -->
              <p>Time (Mins)</p>
              <input class="input" type="text" v-model="WorkoutLogger.Time" placeholder="'0:00'" v-on:keypress="isTime(event)"/>
            </div>
          </div>
        </div>
        <div id="spacing"></div>
        <div class="card" v-if = "WorkoutLogger.WorkoutType === 'WeightLifting' ||WorkoutLogger.WorkoutType === 'Cardio' ">
          <div class="card-header">
            <p class="card-header-title"><strong>Preview</strong></p>
          </div>
          <div id="preview" class="card-content">
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
      </div>
      <div class="control" id="reduceHeight">
        <button type="submit" class="button is-primary" @click.prevent="submit">Log it</button>
      </div>
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
  props: { event },
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
    isNumber: function (event) {
      event = (event) || window.event
      var charCode = (event.which) || event.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57))) {
        event.preventDefault()
      } else {
        return true
      }
    },
    isTime: function (event) {
      event = (event) || window.event
      var charCode = (event.which) || event.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57) && charCode !== 58)) {
        event.preventDefault()
      } else {
        return true
      }
    },
    isFloat: function (event) {
      event = (event) || window.event
      var charCode = (event.which) || event.keyCode
      if ((charCode > 31 && (charCode < 48 || charCode > 57) && charCode !== 46)) {
        event.preventDefault()
      } else {
        return true
      }
    },
    submit: function () {
      if (this.WorkoutLogger.WorkoutType === 'Cardio') {
        axios({
          method: 'POST',
          url: this.$store.getters.getURL + 'v1/WorkoutLogger/CreateWorkout',
          data: {
            Username: this.$data.WorkoutLogger.Username,
            WorkoutType: this.$data.WorkoutLogger.WorkoutType,
            Date_Time: this.$data.WorkoutLogger.Date_Time,
            CardioType: this.$data.WorkoutLogger.CardioType,
            Distance: this.$data.WorkoutLogger.Distance,
            Time: this.$data.WorkoutLogger.Time
          },
          headers: this.$store.getters.getheader
        })
          .then(response => {
            location.reload()
          })
          .catch(error => {
            if (error.response.status === 400) {
            // Your custom messages that appears on the screen
              console.log(error.response)
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
      } else {
        axios({
          method: 'POST',
          url: this.$store.getters.getURL + 'v1/WorkoutLogger/CreateWorkout',
          data: {
            Username: this.$data.WorkoutLogger.Username,
            WorkoutType: this.$data.WorkoutLogger.WorkoutType,
            Date_Time: this.$data.WorkoutLogger.Date_Time,
            LiftingType: this.$data.WorkoutLogger.LiftingType,
            Reps: this.$data.WorkoutLogger.Reps,
            Sets: this.$data.WorkoutLogger.Sets
          },
          headers: this.$store.getters.getheader
        })
          .then(response => {
            location.reload()
          })
          .catch(error => {
            if (error.response.status === 400) {
              // Your custom messages that appears on the screen
              console.log(error.response)
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
      }
    }
  }
}
</script>

<style scoped>
#workOutInput {
padding-top: 1em;
}
#spacing {
padding-top:1em;
padding-bottom:1em;
}
#reduceHeight {
  height: 3em;
}
</style>
