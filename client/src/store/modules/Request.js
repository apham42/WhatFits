const state = {
  headers: {
    'Access-Control-Allow-Origin': 'http://localhost:8080',
    'Content-Type': 'application/json',
    'Authorization': null,
    'X-Requested-With': 'XMLHttpRequest'
  }
}

const getters = {
  getheader: function (state) {
    return state.headers
  }
}

const actions = {

}

const mutations = {
}

export default {
  state,
  getters,
  actions,
  mutations
}
