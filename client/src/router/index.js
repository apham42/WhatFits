import Vue from 'vue'
import Router from 'vue-router'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'Chat',
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
    }
  ]
})
