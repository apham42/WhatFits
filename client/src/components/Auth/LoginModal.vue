<template>
  <div class="modal is-active">
    <div class="modal-background" @click="closeModal"></div>
    <div class="modal-content">
      <div class="box">
        <img src="../../assets/Images/NavbarLogo/navbarLogo.png" alt="Go to Whatfits Home">
        <div class="field">
          <p class="control has-icons-left">
            <input class="input" type="text" placeholder="Username">
            <span class="icon is-small is-left">
              <i class="fa fa-user"></i>
            </span>
          </p>
        </div>
        <div class="field">
          <p class="control has-icons-left">
            <input class="input" type="password" placeholder="Password">
            <span class="icon is-small is-left">
              <i class="fa fa-lock"></i>
            </span>
          </p>
        </div>
        <a class="button is-primary">Login</a>
        <a class="button" @click="closeModal">Cancel</a>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: 'LoginModal',
  components: {
  },
  data () {
    return {
    }
  },
  methods: {
    closeModal: function () {
      this.$store.dispatch('controlPopup', {modalStatus: false})
    }
  }
}
</script>

<style>
</style>
