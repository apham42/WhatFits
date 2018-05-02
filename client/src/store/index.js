import Vue from 'vue'
import Vuex from 'vuex'
import CreatePersistedState from 'vuex-persistedstate'
import loginpopup from './modules/LoginPopup'
import User from './modules/User'
import Request from './modules/Request'
import Search from './modules/Search'

Vue.use(Vuex)

const persistedstate = new CreatePersistedState({
  key: 'WhatFitsStore',
  storage: window.sessionStorage,
  reducer: state => ({
    User: state.User,
    Request: state.Request
  })
})

const store = new Vuex.Store({
  modules: {
    loginpopup,
    User,
    Request,
    Search
  },
  plugins: [persistedstate]
})
export default store
