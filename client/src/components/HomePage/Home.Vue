<template>
 <div>
<section class="hero ">
  <hero-body></hero-body>
</section>
  <div class="box cta">
    <p class="has-text-centered"><span class="tag is-info">Whats new?</span> We have launched!</p>
  </div>
   <section class="container">
     <quick-info></quick-info>
     <content-body></content-body>
   </section>
   <footer-bar></footer-bar>
   </div>
</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
import Footer from '@/components/HomePage/Footer'
import HeroBody from '@/components/HomePage/HeroBody'
import QuickInfo from '@/components/HomePage/QuickInfo'
import Content from '@/components/HomePage/Content'
export default {
  name: 'Home',
  components: {
    'footer-bar': Footer,
    'hero-body': HeroBody,
    'quick-info': QuickInfo,
    'content-body': Content
  },
  data: function () {
    return {
      username: '',
      isNameValid: false,
      password: '',
      isPassValid: false,
      response: ''
    }
  },
  // validations based on business rules
  validations: {
    username: {
      required
    },
    password: {
      required,
      maxLength: maxLength(64),
      minLength: minLength(8)
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs('password')
    }
  }
}

</script>

<style>
.center-Title {
  text-align: center;
}
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
