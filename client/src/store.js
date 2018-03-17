import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    username: ['lol', 'me', 'hi', 'test']
  },
  getters: {
    users: function (state) {
      return state.username
    }
  },
  mutations: {
    addUser: function (payload) {
      this.state.username.push(payload)
    }
  }
})
