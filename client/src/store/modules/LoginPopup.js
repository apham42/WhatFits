const state = {
  loginpopup: false
}

const getters = {
  popupStatus: function (state) {
    return state.loginpopup
  }
}

const actions = {
  controlPopup (context, payload) {
    context.commit('controlPopup', payload)
  }
}

const mutations = {
  controlPopup (state, payload) {
    state.loginpopup = payload.modalStatus
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
