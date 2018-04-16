<template>
<form name="CreateUser" id="createUser" action="http://localhost/server/v1/management/CreateAdmin" method="POST">
        <div class="field">
            <label class="label">Username</label>
            <div class="control has-icons-left has-icons-right">
                <input class="input " v-model="userNameCreate" type="text" placeholder="UserName" value="">
                <span class="icon is-small is-left">
      <i class="fas fa-user"></i>
    </span>
                <span class="icon is-small is-right">
      <i class="fas fa-check"></i>
    </span>
            </div>
            <p class="help is-success">This username is available</p>
        </div>
        <div class="field">
            <label class="label">Password</label>
            <div class="control has-icons-left has-icons-right">
                <input class="input" type="password" placeholder="Password" value="">
                <span class="icon is-small is-left">
      <i class="fas fa-lock"></i>
    </span>
                <span class="icon is-small is-right">
      <i class="fas fa-exclamation-triangle"></i>
    </span>
            </div>
            <p class="help is-danger">This email is invalid</p>
        </div>
        <div class="field">
            <label class="label">Address</label>
            <div class="control">
                <input class="input" type="text" placeholder="Address">
            </div>
            <label class="label">City</label>
            <div class="control">
                <input class="input" type="text" placeholder="City Name">
            </div>
            <label class="label">Zipcode</label>
            <div class="control">
                <input class="input" type="text" placeholder="Zipcode">
            </div>
            <label class="label">State</label>
            <div class="control">
                <input class="input" type="text" placeholder="State">
            </div>
        </div>
        <div class="field">
            <label class="label">User Type</label>
            <div class="control">
                <div class="select">
                    <select>
        <option selected disabled>Select dropdown</option>
        <option>Administrator</option>
        <option>General</option>
      </select>
                </div>
            </div>
        </div>
        <div class="field">
            <div class="control">
                <label class="checkbox">
      <input type="checkbox">
      I agree to the <a href="#">terms and conditions</a>
    </label>
            </div>
        </div>
        <div class="field is-grouped">
            <div class="control">
                <button class="button is-primary">Submit</button>
            </div>
            <div class="control">
                <button class="button is-secondary">Cancel</button>
            </div>
        </div>
    </form>
</template>
<script>
module.exports = {
  name: 'CreateUserComponent',
  data () {
    return {

    }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
