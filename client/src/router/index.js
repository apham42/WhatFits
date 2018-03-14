import Vue from 'vue'
import Router from 'vue-router'
<<<<<<< HEAD
=======
import Chat from '@/components/Chat'
import Test from '@/components/Test'
>>>>>>> master

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Chat',
<<<<<<< HEAD
      component: () => import('@/components/Chat')
    },
    {
      path: '/',
      name: 'Home',
      component: () => import('@/components/Home')
    },
    {
      path: '/Review',
      name: 'Review',
      component: () => import('@/components/Review')
    },
    {
      path: '/Rating',
      name: 'Rating',
      component: () => import('@/components/Rating')
=======
      component: Chat
    },
    {
      path: '/Test',
      name: 'Test',
      component: Test
>>>>>>> master
    }
  ]
})
