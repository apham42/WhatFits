<template>
  <div></div>
</template>

<script>
import HomeNavBar from '@/components/NavBar/HomeNavBar.vue'
export default {
  name: 'LoginModal',
  components: {
    'HomeNavBar': HomeNavBar
  },
  data () {
    return {
      showLogin: false
    }
  }
}
</script>

<style>

</style>
