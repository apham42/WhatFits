import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
// import Terms from '@/components/Terms'

Vue.use(Router)
Vue.use(Vuelidate)

// Defining routes for web application
export default new Router({
  // mode: 'history',
  routes: [
    // {
    //   // HomePage
    //   path: '/home',
    //   name: 'Home',
    //   component: () => import('@/components/HomePage/Home')
    // },
    {
      path: '/resetpassword',
      name: 'ResetPassword',
      component: () => import('@/components/Auth/ResetPassword')
    },
    {
      // HomePage
      path: '/',
      name: 'Home',
      component: () => import('@/components/HomePage/Home')
    },
    {
      // Registration Page
      path: '/signup',
      name: 'Registration',
      component: () => import('@/components/Registration/Registration')
    },
    {
      // Chat Page
      path: '/chat',
      name: 'Chat',
      component: () => import('@/components/UserProfile/Chat')
    },
    {
      // Follow Page
      path: '/follows',
      name: 'Follows',
      component: () => import('@/components/UserProfile/Follows')
    },
    {
      // UserManagement Page
      path: '/usermanagement',
      name: 'UserManagement',
      component: () => import('@/components/UserManagement/UserManagement')
    },
    {
      path: '/Review',
      name: 'Review',
      component: () => import('@/components/Reviews/Review')
    },
    {
      path: '/GetUserReview',
      name: 'GetUserReview',
      component: () => import('@/components/Reviews/GetUserReview')
    },
    {
      // UserProfile Page
      path: '/profile',
      name: 'UserProfile',
      component: () => import('@/components/UserProfile/ProfilePage')
    },
    {
      // Temporary Search bar page
      path: '/SearchBar',
      name: 'SearchBar',
      component: () => import('@/components/Search/SearchBar')
    },
    {
      // Workout Logger component
      path: '/WorkoutLogger',
      name: 'WorkoutLogger',
      component: () => import('@/components/UserProfile/WorkoutLogger')
    },
    {
      // Workout Logger component
      path: '/GetWorkouts',
      name: 'GetWorkouts',
      component: () => import('@/components/UserProfile/GetWorkouts')
    },
    {
      path: '/serverIssues',
      name: 'ServerIssues',
      component: () => import('@/components/ErrorPage/ServerIssues')
    },
    {
      path: '/editprofile',
      name: 'EditProfile',
      component: () => import('@/components/UserProfile/EditProfile')
    },
    {
      // Catch All Error Page
      path: '*',
      name: 'NotFound',
      component: () => import('@/components/ErrorPage/NotFound')

    }
  ]
})
