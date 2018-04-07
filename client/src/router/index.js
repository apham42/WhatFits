import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
// import Home from '@/components/Home'
// import Chat from '@/components/Chat'
// import Test from '@/components/Test'
// import Registration from '@/components/Registration'
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
      // component: Home
      component: () => import('@/components/Home')
    },
    {
      // Registration Page
      path: '/SignUp',
      name: 'Registration',
      // component: Registration
      component: () => import('@/components/Registration')
    },
    {
      // Chat Page
      path: '/Chat',
      name: 'Chat',
      // component: Chat
      component: () => import('@/components/Chat')
    },
    {
      // UserManagement Page
      path: '/usermanagement',
      name: 'UserManagement',
      component: () => import('@/components/UserManagement/UserManagement')
    },
    {
      // ????? -Rob
      path: '/Test',
      name: 'Test',
      // component: Test
      component: () => import('@/components/Test')
    },
    {
      // Catch All Error Page
      path: '*',
      name: 'ErrorPage',
      component: () => import('@/components/ErrorPage/ErrorPage')

    }
  ]
})
