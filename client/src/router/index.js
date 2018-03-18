import Vue from 'vue'
import Router from 'vue-router'
import Chat from '@/components/Chat'
import Test from '@/components/Test'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
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
