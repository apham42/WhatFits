import Vue from 'vue'
import Vuex from 'vuex'
import CreatePersistedState from 'vuex-persistedstate'
import loginpopup from './modules/LoginPopup'
import User from './modules/User'

Vue.use(Vuex)

const persistedstate = new CreatePersistedState({
  key: 'WhatFitsStore',
  storage: window.sessionStorage,
  reducer: state => ({
    User: state.User
  })
})

export default new Vuex.Store({
  modules: {
    loginpopup,
    User
  },
  plugins: [persistedstate]
})
