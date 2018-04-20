<template>
  <div>
    <button @click="storeusername">button</button>
    <input class="input" v-model="username" id="username" type="text" placeholder="Username">
    {{ username }}
  </div>
</template>

<script>
import LoginModal from '@/components/Auth/LoginModal'
export default {
  name: 'Test',
  components: {
    'LoginModal': LoginModal
  },
  data () {
    return {
      username: '',
      persistedusername: ''
    }
  },
  computed: {
    showLogin: function () {
      return this.$store.getters.popupStatus
    }
  },
  methods: {
    openModal: function () {
      this.$store.dispatch('openAction')
    },
    storeusername: function () {
      this.$store.dispatch('openAction')
      this.$store.dispatch('actusername', {Username: this.username})
    }
  }
}
</script>
