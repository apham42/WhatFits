<template>
<form name="DeleteUser">
        <div class="field has-addons has-addons-centered">
            <div class="control">
                <input v-model="userNameDelete" class="input" type="text" placeholder="UserName">
            </div>
            <div class="control">
                <button type="submit" class="button is-primary" @click.prevent="deleteUser">Delete</button>
            </div>
        </div>
        <div v-if="this.$data.deleteUserError == true" class="errorMessage">
            <span>{{this.$data.response.deleteUser}}</span>
        </div>
        <div v-if="this.$data.deleteUserError == false" class="successMessage">
            <span>{{this.$data.response.deleteUser}}</span>
        </div>
        <br />
        <span class="control">
            <a class="button is-link" @click="goBack" >Back</a>
            </span>
        <br>
    </form>
</template>
<script>
module.exports = {
  name: 'DeleteUser',
  data () {
    return {

    }
  }
}

</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
