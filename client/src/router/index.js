import Vue from 'vue'
import Router from 'vue-router'
import Chat from '@/components/Chat'
import Test from '@/components/Test'
import HomeRegistration from '@/components/HomeRegistration'
import Profile from '@/components/ProfilePage'

Vue.use(Router)

export default new Router({
  routes: [
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
    },
    {
      path: '/profile',
      name: 'Profile',
      component: Profile
    }
  ]
})
