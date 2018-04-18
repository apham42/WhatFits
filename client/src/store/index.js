import Vue from 'vue'
import Vuex from 'vuex'
import loginpopup from './modules/LoginPopup'

Vue.use(Vuex)

export default new Vuex.Store({
  modules: {
    loginpopup
  }
})
