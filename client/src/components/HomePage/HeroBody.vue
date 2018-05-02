<template>
<section class="hero ">
    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
        <div class="container has-text-centered homeBody">
            <p class="title body-text-Title">
                Find What Fits For You
            </p>
            <br>
        </div>
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
  background-color: #34495E;
  background-image: url("../../assets/Images/stockImages/backgroundImage2.jpg");
  background-size: cover;
  background-repeat: no-repeat;
  background-attachment: fixed;
  background-position: center;
}
.homeBody {
padding-top: 9em;
color: white;
}
.body-text {
  color:white;
}
.body-text-Title {
  color:white;
  size: 21px;
  text-align: left;
}
</style>
