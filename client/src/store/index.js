import Vue from 'vue'
import Vuex from 'vuex'
import CreatePersistedState from 'vuex-persistedstate'
import loginpopup from './modules/LoginPopup'
import User from './modules/User'

const persistedstate = new CreatePersistedState({
  key: 'WhatFitsStore',
  storage: window.localStorage,
  reducer: state => ({
    User: state.User
  })
})

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    loginpopup,
    User
  },
  plugins: [persistedstate]
})
