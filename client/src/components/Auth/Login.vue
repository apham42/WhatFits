<template>
    <div>
        <div class="field">
            <p class="control has-icons-left has-icons-right">
                <input v-model="username" class="input" type="text" placeholder="Username">
                <span class="icon is-small is-left">
                    <i class="fas fa-user"></i>
                </span>
            </p>
        </div>
        <div class="field">
            <p class="control has-icons-left">
                <input v-model="password" class="input" type="password" placeholder="Password">
                <span class="icon is-small is-left">
                    <i class="fas fa-lock"></i>
                </span>
            </p>
        </div>
        <div class="level-right">
            <a class="button is-primary">Submit</a>
        </div>
    </div>
</template>

<script>
import HomeNavBar from '@/components/NavBar/HomeNavBar.vue'
export default {
  name: 'Login',
  data () {
    return {
      username: '',
      password: ''
    }
  },
  components: {
    'HomeNavBar': HomeNavBar
  },
  methods: {
  }
}
</script>

<style>

</style>
