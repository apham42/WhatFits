<template>
<div>
    <div class="content-container">
        <div class="head-line secondary-text-color">
            503
        </div>
        <div class="subheader primary-text-color">
            Looks like we're having <br> some server issues.
        </div>
        <hr>
        <div class="clearfix"></div>
        <div class="context primary-text-color">

            <p>
                Go back to the previous page and try again. If you think something is broken, report a problem.
            </p>
        </div>
        <div class="buttons-container">
            <a class="border-button" href="mailto:#" target="_blank">Report A Problem</a>
        </div>
    </div>
</div>
</template>
<script>
export default {
  name: '503ServerIssues',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: '503 Server Issues',
      hasErrored: true,
      container: '',
      containerHeight: ''
    }
  },
  methods: {
  }
}
</script>
<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>

</style>
