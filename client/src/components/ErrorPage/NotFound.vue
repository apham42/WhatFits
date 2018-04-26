<template>
<div>
  <div class="NotFound" id="Title">
    {{pageTitle}}
    <h1>There's been a glitch</h1>
    <p>Don't know what happend or how you got here. This will take you <router-link to="/">home</router-link>.</p>
  </div>
</div>

</template>
<script>
export default {
  name: 'NotFound',
  computed: {
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
<style>
  .NotFound {
    padding-top: 20em;
    color:white;
    text-align: center;

    width: 100%;
    height: 100%;
    position: absolute;
    top: 60px;
    right: 0;
    bottom: 0;
    left: 0;
    background: #5e4934;
  }
  .is-small {
    text-align: center;
  }
</style>
