<template>
   <div>
      <h1 class="PageTitle">{{pageTitle}}</h1>
      <br>
      <h3 class="SectionTitle">Create User</h3>
      <div>
         <label class="SubLabel">Credentials</label>
      </div>
      <div class="field is-horizontal">
         <div class="field-label is-normal">
         </div>
         <div class="field-body">
            <div class="field">
               <p class="control is-expanded has-icons-left">
                  <input class="input" type="text" placeholder="UserName">
                  <span class="icon is-small is-left">
                  <i class="fas fa-user"></i>
                  </span>
               </p>
            </div>
            <div class="field">
               <p class="control is-expanded has-icons-left has-icons-right">
                  <input class="input" type="password" placeholder="Password">
                  <span class="icon is-small is-left">
                  <i class="fas fa-key"></i>
                  </span>
               </p>
            </div>
         </div>
      </div>
      <br>
      <div>
         <label class="SubLabel">Location</label>
      </div>
      <div class="field is-horizontal">
         <div class="field-label is-normal">
         </div>
         <div class="field-body">
            <div class="field">
               <p class="control is-expanded has-icons-left">
                  <input class="input" type="text" placeholder="Address">
                  <span class="icon is-small is-left">
                  <i class="fas fa-home"></i>
                  </span>
               </p>
            </div>
            <div class="field">
               <p class="control is-expanded has-icons-left has-icons-right">
                  <input class="input" type="password" placeholder="City">
                  <span class="icon is-small is-left">
                  <i class="fas fa-building"></i>
                  </span>
               </p>
            </div>
         </div>
      </div>
      <div class="field is-horizontal">
         <div class="field-label is-normal">
         </div>
         <div class="field-body">
            <div class="field">
               <p class="control is-expanded has-icons-left">
                  <input class="input" type="text" placeholder="State">
                  <span class="icon is-small is-left">
                  <i class="fas fa-flag"></i>
                  </span>
               </p>
            </div>
            <div class="field">
               <p class="control is-expanded has-icons-left has-icons-right">
                  <input class="input" type="text" placeholder="Zipcode">
                  <span class="icon is-small is-left">
                  <i class="fas fa-map-marker-alt"></i>
                  </span>
               </p>
            </div>
         </div>
      </div>
      <div class="">
         <div class="field is-horizontal">
            <div class="field-label is-normal">
               <label class="label">User Type</label>
            </div>
            <div class="field-body">
               <div class="field is-narrow">
                  <div class="control">
                     <div class="select is-fullwidth">
                        <select>
                           <option>General User</option>
                           <option>Administrator</option>
                        </select>
                     </div>
                  </div>
               </div>
            </div>
         </div>
         <br>
         <div>
            <label class="SubLabel">Password Recovery</label>
         </div>
         <div class="field is-horizontal">
            <div class="field-label is-normal">
               <label class="label">Security Question 1</label>
            </div>
            <div class="field-body">
               <p class="control">
                  <span class="select">
                     <select>
                        <option>Question 1</option>
                        <option>£</option>
                        <option>€</option>
                     </select>
                  </span>
               </p>
               <p class="control">
                  <input class="input" type="text" placeholder="Answer">
               </p>
            </div>
         </div>
         <div class="field is-horizontal">
            <div class="field-label is-normal">
               <label class="label">Security Question 2</label>
            </div>
            <div class="field-body">
               <p class="control">
                  <span class="select">
                     <select>
                        <option>Question 2</option>
                        <option>£</option>
                        <option>€</option>
                     </select>
                  </span>
               </p>
               <p class="control">
                  <input class="input" type="text" placeholder="Answer">
               </p>
            </div>
         </div>
         <div class="field is-horizontal">
            <div class="field-label is-normal">
               <label class="label">Security Question 3</label>
            </div>
            <div class="field-body">
               <p class="control">
                  <span class="select">
                     <select>
                        <option>Question 3</option>
                        <option>£</option>
                        <option>€</option>
                     </select>
                  </span>
               </p>
               <p class="control">
                  <input class="input" type="text" placeholder="Answer">
               </p>
            </div>
         </div>
      </div>
      <div class="field is-horizontal">
         <div class="field-label">
            <br>
         </div>
         <div class="field-body">
            <div class="field">
               <div class="control">
                  <button class="button is-primary">
                  Add User
                  </button>
                  <button class="button is-secondary">
                  Clear
                  </button>
               </div>
            </div>
         </div>
      </div>
      <br>
      <div>
         <h3 class = "SectionTitle">Change Status of User</h3>
         <form name="ChangeStatus" action="http://localhost:8080/#/UserManagement" method="Get">
            <div class="field has-addons has-addons-centered">
               <div class="control">
                  <span class="select">
                     <select v-model="status">
                        <option value="enable">Enable</option>
                        <option value="disable">Disable</option>
                     </select>
                     {{status}}
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
         </form>
      </div>
      <br>
      <h3 class="SectionTitle">Delete User</h3>
      <form name="ChangeStatus" action="http://localhost:8080/#/management/" method="PUT">
            <div class="field has-addons has-addons-centered">
               <div class="control">
                  <input v-model="userName" class="input" type="text" placeholder="userName123">
               </div>
               <div class="control">
                  <button type="submit" class="button is-primary" @click="changeStatus">Delete</button>
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
</template>

<script>
// import axios from 'axios'
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
      changeStatusResponse: '',
      status: '',
      userName: 'amay',
      pageError: ''
    }
  },
  methods: {
    /*
    changeStatus: function () {
      if (this.$data.userName === '' || this.$data.status === '') {
        this.$data.hasErrored = true
        this.$data.pageError = 'Invalid username and/or status'
        return false
      }
      if (this.$data.status === 'enable') {
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/enable',
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

          this.pageError = 'An error ocurred.'
          console.log(error)
        })
      }else if (tihs.$data.status === 'disable'){
        axios({
          method: 'PUT',
          url: 'http://localhost/server/v1/management/disable',
          data: {'UserName': this.$data.userName},
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

          this.pageError = 'An error ocurred.'
          console.log(error)
        })
      }

    },
    createNewUser: function () {

    },
    goBack: function () {
      this.$router.go(-1)
    }
  }
  */
  }
/*
function: validateUserName(userName) {
  if(userName.length < 10){
    console.log('This is less than 10 characters.');
    return false;
  }else{
    console.log('This is greater than 10 characters.')
    return true;
  }
  */
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
button:hover {
    cursor: pointer;
}
.SectionTitle {
  text-align: left;
  font-size: 1.32em;
  padding-left: 3em;
}
.PageTitle {
font-size: 2em;
}
.SubLabel {
font-size: 1em;
text-align: left;
}
.CenteredBody{
  padding-left: 12em;

}
</style>
