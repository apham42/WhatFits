const state = {
  username: '',
  currentUserName: '',
  token: '',
  viewclaims: null,
  viewProfile: ''
}

const getters = {
  getusername: function (state) {
    return state.username
  },
  gettoken: function (state) {
    return state.token
  },
  getviewclaims: function (state) {
    return state.viewclaims
  },
  getViewProfile: function (state) {
    return state.viewProfile
  }
}

const actions = {
  actusername (context, payload) {
    context.commit('mutateusername', payload)
  },
  acttoken (context, payload) {
    context.commit('mutatetoken', payload)
  },
  actviewclaims (context, payload) {
    context.commit('mutateclaims', payload)
  },
  actViewProfile (context, payload) {
    context.commit('mutateViewProfile', payload)
  }
}

const mutations = {
  mutateusername (state, payload) {
    state.username = payload.Username
  },
  mutatetoken (state, payload) {
    state.token = payload.Token
  },
  mutateclaims (state, payload) {
    state.viewclaims = Object.freeze(payload.Viewclaims)
  },
  mutateViewProfile (state, payload) {
    state.ViewProfile = payload.viewProfile
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
