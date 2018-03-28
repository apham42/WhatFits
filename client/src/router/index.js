import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
import Home from '@/components/Home'
import Chat from '@/components/Chat'
import Test from '@/components/Test'
import Registration from '@/components/Registration'

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
      path: '/SignUp',
      name: 'Registration',
      component: Registration
    },
    {
      path: '/Chat',
      name: 'Chat',
      component: Chat
    },
    {
      path: '/Test',
      name: 'Test',
      component: Test
    }
  ]
})
