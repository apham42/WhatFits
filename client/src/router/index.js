import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
import Terms from '@/components/Terms'

Vue.component('Terms', Terms)
Vue.use(Router)
Vue.use(Vuelidate)

// Defining routes for web application
export default new Router({
  routes: [
    {
      // HomePage
      path: '/',
      name: 'Home',
      component: () => import('@/components/Home')
    },
    {
      // Registration Page
      path: '/signup',
      name: 'Registration',
      component: () => import('@/components/Registration')
    },
    {
      // Chat Page
      path: '/chat',
      name: 'Chat',
      component: () => import('@/components/Chat')
    },
    {
      // UserManagement Page
      path: '/usermanagement',
      name: 'UserManagement',
      component: () => import('@/components/UserManagement/UserManagement')
    },
    {
      // UserProfile Page
      path: '/profile',
      name: 'UserProfile',
      component: () => import('@/components/UserProfile/ProfilePage')
    },
    {
      // Catch All Error Page
      path: '*',
      name: 'ErrorPage',
      component: () => import('@/components/ErrorPage/ErrorPage')

    }
  ]
})
