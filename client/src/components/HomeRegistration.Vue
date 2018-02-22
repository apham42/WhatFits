<template>
    <div class = "Registration">
            <div class = "container">
                <h1>Registration for Whatfits</h1>
                <form>
                    <h2>Address</h2>
                    <input type = "address" placeholder = "Street and number">
                    <h2>City</h2>
                    <input type = "city" placeholder = "Must be in LA or OC">
                    <h2>State</h2>
                    <input type = "state">
                    <h2>Zip Code</h2>
                    <input type = "zipCode">
                    <h2>Security Question 1</h2>
                    <input type = "securityQues1">
                    <h2>Security Question 2</h2>
                    <input type = "securityQues2">
                    <h2>Security Question 3</h2>
                    <input type = "securityQues3">
                    <div class = "checkbox">
                    Agree To Terms and Conditions<input type = "checkbox" name = "terms">
                    </div>
                    <button type = "register" class = "register-button">Register</button>
                </form>
            </div>
    </div>
</template>

<script>
export default {
  name: 'Registration'
}

</script>

<style>
</style>
