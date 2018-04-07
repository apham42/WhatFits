<template>
<div>

   <h1>{{pageTitle}}</h1>
   <h3>Create User</h3>
   <div>
     <p> Stuff to create Users</p>
   </div>
   <div>
      <h3>Change Status of User</h3>
      <form name="ChangeStatus" action="http://localhost:8081/#/UserManagement" method="Get">
         <div class="field has-addons has-addons-centered">
            <div class="control">
               <span class="select">
                  <select v-model="status">
                     <option>Enable</option>
                     <option>Disable</option>
                  </select>
               </span>
            </div>
            <div class="control">
               <input v-model="userName" class="input" type="text" placeholder="userName123">
            </div>
            <div class="control">
               <button type="submit" class="button is-primary" @click="changeStatus">Apply</button>
            </div>
            <span>{{changeStatusResponse}}</span>
         </div>

         <div v-show="hasErrored === true">
            <span class ="error">
            {{pageError}}
            </span>
         </div>
         <br />
         <span class="control">
         <a class="button is-link" @click="goBack" >Back</a>
         </span>
         <br>
      </form>
   </div>
</div>
</template>

<script>
import axios from 'axios'
export default {
  name: 'UserManagement',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: 'UserManagement Page',
      hasErrored: false,
      changeStatusResponse: 'asdf',
      status: '',
      userName: 'amay',
      pageError: ''
    }
  },
  methods: {
    changeStatus: function () {
      // Changing status of User
      if (this.$data.userName === '' || this.$data.status === '') {
        this.$data.hasErrored = true
        this.$data.pageError = 'Invalid username and/or status'
        return false
      }
      axios({
        method: 'PUT',
        url: 'http://localhost/server/UserManagement/ChangeStatus',
        data: {'UserName': this.$data.userName, 'Type': this.$data.status},
        headers: {
          'Access-Control-Allow-Origin': 'http://localhost:8081'
        }
      })
        .then(function (response) {
          console.log(response.data)
          this.data.changeStatusResponse = 'Success'
          this.$data.hasErrored = false
        })
        .catch(error => {
          // *
          this.pageError = 'An error ocurred.'
          console.log(error)
          // */
          /*
          this.$data.hasErrored = true
          this.$data.pageError = 'XHR request failed'

          if (error.response) {
            // Server returned a response, but was not 200 OK
            this.$log('Request FAILED')
          } else if (error.request) {
            // Unable to complete request
            this.$log('Request Timeout or request not able to be executed')
          } else {
            // Error in callback
            this.$log('Callback error')
          }
          // */
        })
    },
    createNewUser: function () {

    },
    goBack: function () {
      this.$router.go(-1)
    }
  }
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
button:hover {
    cursor: pointer;
}
</style>
