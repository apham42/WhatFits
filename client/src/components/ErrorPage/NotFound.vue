<template>
<div class="error-container">
<h1 is-1>There's been a glitch</h1>
<P is-small>its a 404 error</P>
<p>Don't know what happend or how you got here. This will take you <router-link to="/home">home</router-link>.</p>
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
      pageTitle: '404 Page Not Found'
    }
  },
  methods: {
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
  .NotFound {
    background-color: lightblue;
    width: auto;
    height: auto;
    text-align: center;
  }
  .is-small {
    text-align: center;
  }
  /* Google Docs Dark UI by UGoBoom         */
/* Version 1.0                            */
/* Published Oct 26 2015                  */
/* Aesthetic inspired by Vertex-gtk theme */

@namespace url(http://www.w3.org/1999/xhtml);
</style>
