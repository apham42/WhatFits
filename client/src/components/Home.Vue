<template>
  <div>
    <header>
        <div class = "container">
            <div id = "brand">
                <h1>Whatfits</h1>
            </div>
            <nav>
                <ul>
                    <li><a href = "index.html">Home</a></li>
                    <li><a href = "index.html">About</a></li>
                    <li><a href = "index.html">Contact Us</a></li>
                </ul>
            </nav>
        </div>
    </header>

    <section id = "showcase">
        <div class = "container">
            <h1>Find what fitness fits with you</h1>
            <p>Fitness based social media platform that will connect others </p>
        </div>
    </section>

    <section id ="Home-Registration">
        <div class = "container">
            <h1>Register for Whatfits</h1>
            <form>
                <h2>Username</h2>
                <input type = "username" placeholder = "Enter Username">
                <h2>Password</h2>
                <input type = "password" placeholder = "Enter Password">
                <h2>Confirm Password</h2>
                <input type = "confirmPassword" placeholder = "Confirm Password">
                <div class = "checkbox">
                    LA/OC resident<input type = "checkbox" name = "resident" value = "LA/OC resident"><br>
                    18 years or older<input type = "checkbox" name = "year" value = "18 years or older">
                </div>
                <div id = "RegisterButton">
                    <router-link to = "/registration" tag = "button" @click.native = "checkCredentials" >Continue Registration</router-link>
                </div>
            </form>
        </div>
    </section>

  </div>
</template>

<script>
import axios from 'axios'

export default {
//   name: 'Home',
//   methods: {
//     checkCredentials () {
//       alert('HEllo')
//       }
//   }
  data () {
    return {
      posts: [],
      errors: []
    }
  },

  created () {
    alert('get')
    axios.get('http://localhost/newtest')
      .then(response => {
        this.posts = response.data
      })
      .catch(e => {
        alert('error')
        this.errors.push(e)
      })
  }
}

</script>

<style>
.form.h2 {
  float: left;
  clear: right;
}
.form.input {
  float: right;
}
</style>
