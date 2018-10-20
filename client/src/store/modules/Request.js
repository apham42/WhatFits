const state = {
  headers: {
    'Access-Control-Allow-Origin': 'http://localhost:8080',
    'Content-Type': 'application/json',
    'Authorization': null,
    'X-Requested-With': 'XMLHttpRequest'
  },
  // for dat production life
  url: 'http://localhost/server/'
  // url: 'http://longnlong.com/server/'
}

const getters = {
  getheader: function (state) {
    return state.headers
  },
  getURL: function (state) {
    return state.url
  }
}

const actions = {
  actheadertoken (context, payload) {
    context.commit('mutateheadertoken', payload)
  },
  actheader (context) {
    context.commit('mutateheader')
  }
}

const mutations = {
  mutateheadertoken: function (state, payload) {
    state.headers.Authorization = 'Bearer ' + payload.TokenHeader
  },
  mutateheader: function (state) {
    state.headers.Authorization = null
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
