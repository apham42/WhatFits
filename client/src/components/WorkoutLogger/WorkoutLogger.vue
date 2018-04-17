<template>
    <div class = "log">
        <form @submit.prevent = "addWorkout">
            <input type = "text" placeholder = "WorkoutType" v-model="WorkoutType" v-validate="'min:3'" name = "WorkoutType">
            
            
        </form>
        <ul>
            <transition-group name ="list" enter-active-class="animated bounceInUp">
                
            </transition-group>
        </ul>
    </div>
</template>

<script>
import axios from 'axios'
export default {
    name: 'Workout',
    data: function () {
        return {
            WorkoutType: '',
            CardioType: '',
            LiftingType: '',
            Reps: '',
            Sets: '',
            Time: '',
            Distance: '',
            Date_Time: new Date().toLocaleDateString()
        }
    },

    input () {
        axios({
            method: 'POST',
            url: 'http://localhost/server/WorkoutLog/CreateWorkout',
            data: {
                WorkoutType: this.WorkoutType,
                Date_Time: this.Date_Time
            },
            headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
            }
        }).then(response => {
            console.log(response)
        }).catch((error) => {
            console.log(error.response)
        })
    }
}
</script>