import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
import Home from '@/components/Home'
import Chat from '@/components/Chat'
import Test from '@/components/Test'
import HomeRegistration from '@/components/HomeRegistration'
import Profile from '@/components/ProfilePage'
import Registration from '@/components/Registration'
import Terms from '@/components/Terms'
import Review from '@/components/Review'

Vue.component('Terms', Terms)
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
      path: '/',
      name: 'HomeRegistration',
      component: HomeRegistration
    },
    {
      path: '/Test',
      name: 'Test',
      component: Test
    }
  ]
})
