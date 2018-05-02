<template>
<div class="modal is-active">
      <div class="modal-background" @click="showSuccess = false" ></div>
      <div class="modal-card">
        <header class="modal-card-head">
          <p class="modal-card-title center" style="font-size:2em">Registration Successful!</p>
        </header>
        <section class="modal-card-body">
  <div class="termModal">
    <div class="terms">
        <img id="imageStyle" class="center" src="../../../static/ProfileDummy/RegSuccessGif.gif" alt="HighFive Gif">
        <br>
        <p class="center" style="font-size: 2em">Thanks for giving us a try 🤝</p>
        <p class="center" style="font-size: 1.2em">Please head to your profile and edit your information! Upload a picture for others to see and maybe include a little description of yourself. Other than that, we encourage you to look at other users based on your location and connect with others to begin your workouts.</p>
    </div>
  </div>
   </section>
        <footer class="modal-card-foot">
          <div class="closeModal buttonCenter">
           <button class="button is-success " @click="goHome">Go home and Login!</button>
          </div>
        </footer>
      </div>
    </div>
</template>

<script>
export default {
  name: 'RegisterSuccess',
  methods: {
    goHome () {
      this.$router.push('/')
    },
    close () {
      this.$emit('close')
    }
  }
}
</script>
<!--
Note: Scoped the Style tags. For Some reason when clicking on the terms
and agreements it doesn't show any text unless you scoped them. -Rob
-->
<style>
  .terms {
    background: #FFFFFF;
    overflow-x: auto;
    display: flex;
    flex-direction: column;
  }
  #imageStyle{
    width:auto;
    height: 23em;
  }
  .center{
    display: block;
    margin-left: auto;
    margin-right: auto;
    width:50%;
    text-align: center;
  }
  .buttonCenter {
    padding-left:36%;
  }
</style>
