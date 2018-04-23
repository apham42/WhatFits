<template>
<section class="hero ">
    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
        <div class="container has-text-centered homeBody">
            <h1 class="title body-text">
                Whatfits Homepage
            </h1>
            <h2 class="subtitle body-text">
                Clearly under construction
            </h2>
        </div>
    </div>
    <div class="hero-foot">
        <nav class="tabs">
            <div class="container">
                <ul>
                    <li class="is-active">
                        <router-link to="/signup">Register</router-link>
                    </li>
                    <li>
                        <router-link to="/usermanagement">UserManagement</router-link>
                    </li>
                    <li>
                        <router-link to="/Review">Review</router-link>
                    </li>
                    <li>
                        <router-link to="/profile">Profile</router-link>
                    </li>
                    <li>
                        <router-link to="/SearchBar">Search</router-link>
                    </li>
                    <li>
                        <router-link to="/chat">Chat</router-link>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</section>
</template>
<script>
export default {
  name: 'HeroBody',
  data: function () {
    return {
    }
  }

}

</script>
<style>
.form.h2{
    float: left;
    clear: right;
}
.form.input{
    float: right;
}
#homeIcons{
    height: 10em;
    width: 10em;
    padding-top: 2em;
}
#bodySection {
    background-color:#34495E;
}
.hero-body {
  height: 30em;
  background-image: url("../../../static/ProfileDummy/backgroundImage2.jpg");
}
.homeBody {
padding-top: 9em;
color: white;
}
.body-text {
  color:white;
}
</style>
