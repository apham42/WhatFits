import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
import Home from '@/components/Home'
import Registration from '@/components/HomeRegistration'

Vue.use(Router)
Vue.use(Vuelidate)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Home',
      component: Home
    },

    {
      path: '/registration',
      name: 'Registration',
      component: Registration
    }
  ]
})
