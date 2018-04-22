const state = {
  username: '',
  token: '',
  viewclaims: null,
  firstName: ''
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
  getFirstName: function (state) {
    return state.firstName
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
  actFirstName (context, payload) {
    context.commit('mutateFirstName', payload)
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
  mutateFirstName (state, payload) {
    state.firstName = payload.firstName
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
