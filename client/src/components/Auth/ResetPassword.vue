<template>
<div>
  <div id="resetcontainer" class="container">
    <div id="resetbox" class="box has-text-centered">
        <EnterUsername></EnterUsername>
    </div>
  </div>
</div>
</template>
<script>
import EnterUsername from '@/components/Auth/Rest/EnterUsername.vue'
export default {
  name: 'PasswordReset',
  components: {
    'EnterUsername': EnterUsername
  },
  data () {
    return {
    }
  },
  methods: {
  }
}
</script>

<style>
#resetcontainer {
  padding-top: 10em;
  padding-right: 25%;
  padding-left: 25%;
}
</style>
