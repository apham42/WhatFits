const state = {
  requestedSearch: '',
  searchType: ''
}

const getters = {
  getSearchType: function (state) {
    return state.searchType
  },
  getRequestedSearch: function (state) {
    return state.requestedSearch
  }
}

const actions = {
  actSearchType (context, payload) {
    context.commit('setSearchType', payload)
  },
  actRequestedSearch (context, payload) {
    context.commit('setRequestedSearch', payload)
  }
}

const mutations = {
  setSearchType (state, payload) {
    state.searchType = payload.searchType
  },
  setRequestedSearch (state, payload) {
    state.requestedSearch = payload.requestedSearch
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
