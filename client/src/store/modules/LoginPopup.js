const state = {
  loginpopup: false
}

const getters = {
  popupStatus: function (state) {
    return state.loginpopup
  }
}

const actions = {
  openAction (context) {
    context.commit('openPopup')
  },
  closeAction (context) {
    context.commit('closePopup')
  }
}

const mutations = {
  openPopup (state) {
    state.loginpopup = true
  },
  closePopup (state) {
    state.loginpopup = false
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
