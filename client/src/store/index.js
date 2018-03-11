import Vue from 'vue'
import Vuex from 'vuex'

Vue.use(Vuex)

export default new Vuex.Store({
  state: {
    user: {
      name: 'Me'
    },
    sessions: [
      {
        id: 1,
        user: {
          name: 'friend1'
        },
        messages: [
          {
            content: 'Hello',
            date: new Date()
          },
          {
            content: 'Whazzzzzzzup',
            date: new Date()
          }
        ]
      },
      {
        id: 2,
        user: {
          name: 'friend2'
        },
        messages: []
      }
    ],
    currentSessionId: 1
  },
  mutations: {
    INIT_DATA (state) {
      var data = localStorage.getItem('')
      if (data) {
        state.sessions = JSON.parse(data)
      }
    },
    SEND_MESSAGE ({sessions, currentSessionId}, content) {
      var session = sessions.find(item => item.id === currentSessionId)
      session.messages.push({
        content: content,
        date: new Date(),
        self: true
      })
    },
    SELECT_SESSION (state, id) {
      state.currentSessionId = id
    }
  },
  actions: {
    initdata: ({dispatch}) => dispatch('INIT_DATA'),
    sendMessage: ({dispatch}, content) => dispatch('SEND_MESSAGE', content),
    selectSession: ({dispatch}, id) => dispatch('SELECT_SESSION', id)
  }
})
