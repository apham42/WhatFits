const state = {
  username: '',
  token: '',
  viewclaims: null,
  viewprofile: ''
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
  getviewprofile: function (state) {
    return state.viewprofile
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
  actviewprofile (context, payload) {
    context.commit('mutateviewprofile', payload)
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
  mutateviewprofile (state, payload) {
    state.viewprofile = payload.ViewProfile
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
