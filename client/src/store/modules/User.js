const state = {
  username: '',
  currentUserName: '',
  token: '',
  viewclaims: null,
  firstName: '',
  lastName: '',
  description: '',
  gender: '',
  skillLevel: '',
  email: '',
  myProfile: ''
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
  getCurrentUserName: function (state) {
    return state.currentUserName
  },
  getFirstName: function (state) {
    return state.firstName
  },
  getLastName: function (state) {
    return state.lastName
  },
  getDescription: function (state) {
    return state.description
  },
  getSkillLevel: function (state) {
    return state.skillLevel
  },
  getGender: function (state) {
    return state.gender
  },
  getEmail: function (state) {
    return state.email
  },
  getMyProfile: function (state) {
    return state.myProfile
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
  actCurrentUserName (context, payload) {
    context.commit('mutateCurrentUserName', payload)
  },
  actFirstName (context, payload) {
    context.commit('mutateFirstName', payload)
  },
  actLastName (context, payload) {
    context.commit('mutateLastName', payload)
  },
  actDescription (context, payload) {
    context.commit('mutateDescription', payload)
  },
  actGender (context, payload) {
    context.commit('mutateGender', payload)
  },
  actSkillLevel (context, payload) {
    context.commit('mutateSkillLevel', payload)
  },
  actEmail (context, payload) {
    context.commit('mutateEmail', payload)
  },
  actMyProfile (context, payload) {
    context.commit('mutateMyProfile', payload)
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
  mutateCurrentUserName (state, payload) {
    state.currentUserName = payload.currentUserName
  },
  mutateFirstName (state, payload) {
    state.firstName = payload.firstName
  },
  mutateLastName (state, payload) {
    state.lastName = payload.lastName
  },
  mutateDescription (state, payload) {
    state.description = payload.description
  },
  mutateSkillLevel (state, payload) {
    state.skillLevel = payload.skillLevel
  },
  mutateGender (state, payload) {
    state.gender = payload.gender
  },
  mutateEmail (state, payload) {
    state.email = payload.email
  },
  mutateMyProfile (state, payload) {
    state.myProfile = payload.myProfile
  }
}

export default {
  state,
  getters,
  actions,
  mutations
}
