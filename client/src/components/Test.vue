<template>
  <div>
    <button @click='openModal'>button</button>
    <LoginModal v-if='showLogin'></LoginModal>
  </div>
</template>

<script>
import LoginModal from '@/components/Auth/LoginModal'
export default {
  name: 'Test',
  components: {
    'LoginModal': LoginModal
  },
  computed: {
    showLogin: function () {
      return this.$store.getters.popupStatus
    }
  },
  methods: {
    openModal: function () {
      this.$store.dispatch('openAction')
    }
  }
}
</script>
