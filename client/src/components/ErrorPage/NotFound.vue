<template>
<div class="plain error-page-wrapper background-color background-image">
    <div class="content-container">
        <div class="head-line secondary-text-color">404</div>
        <div class="subheader primary-text-color">
            Oops, the page you're
            <br> looking for does not exist.
        </div>
        <hr>
        <div class="clearfix"></div>
        <div class="context primary-text-color">
            <p>
                You may want to head back to the homepage.<br /> If you think something is broken, report a problem.
            </p>
        </div>
        <div class="buttons-container">
            <a class="border-button" href="http://localhost:8081/#/" target="_blank">Go To Homepage</a>
        </div>
    </div>
</div>
</template>
<script>
export default {
  name: '404NotFound',
  computed: {
    isAuthenticated: function () {
      return this.$store.getters.isAuthenticated
    }
  },
  data () {
    return {
      pageTitle: '404 Page Not Found',
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

    .background-color {
      background-color: rgba(0, 0, 0, 1) !important;
    }

    .primary-text-color {
      color: #FFFFFF !important;
    }

    .secondary-text-color {
      color: rgb(0, 110, 255) !important;
    }

    .sign-text-color {
      color: #FFBA00 !important;
    }

    .sign-frame-color {
      color: #343C3F;
    }

    .pane {
      background-color: #FFFFFF !important;
    }

    .border-button {
      color: #FFFFFF !important;
      border-color: #FFFFFF !important;
    }
    .button {
      background-color: #FFFFFF !important;
      color: #FFFFFF !important;
    }

    .shadow {
      box-shadow: 0 0 60px #000000;
    }
</style>
