import Vue from 'vue'
import Router from 'vue-router'
import Vuelidate from 'vuelidate'
import store from '../store/index'
// import Terms from '@/components/Terms'

Vue.use(Router)
Vue.use(Vuelidate)

// Defining routes for web application
export default new Router({
  mode: 'history',
  routes: [
    // Reset
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
      // UserManagement Page
      path: '/usermanagement',
      name: 'UserManagement',
      component: () => import('@/components/UserManagement/UserManagement'),
      beforeEnter: (to, from, next) => {
        var claims = store.getters.getviewclaims
        var ClaimsLength = claims.length
        var found = false
        for (var i = 0; i < ClaimsLength; i++) {
          if (claims[i] === 'View User Managment') {
            found = true
          }
        }
        if (!found) {
          next({path: '/notallowed'})
        }
        next()
      }
    },
    {
      // UserProfile Page
      path: '/profile',
      name: 'UserProfile',
      component: () => import('@/components/UserProfile/ProfilePage'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === false) {
          next({path: '/notallowed'})
        } else {
          next()
        }
      }
    },
    {
      // Temporary Search bar page
      path: '/Search',
      name: 'Search',
      component: () => import('@/components/Search/Search'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === false) {
          next({path: '/notallowed'})
        } else {
          next()
        }
      }
    },
    {
      path: '/serverIssues',
      name: 'ServerIssues',
      component: () => import('@/components/ErrorPage/ServerIssues'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === false) {
          next({path: '/notallowed'})
        } else {
          next()
        }
      }
    },
    {
      path: '/editprofile',
      name: 'EditProfile',
      component: () => import('@/components/UserProfile/EditProfile'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === false) {
          next({path: '/notallowed'})
        } else {
          next()
        }
      }
    },
    {
      path: '/notallowed',
      name: 'NotAllowed',
      component: () => import('@/components/ErrorPage/NotAllowed')
    },
    {
      // Catch All Error Page
      path: '*',
      name: 'NotFound',
      component: () => import('@/components/ErrorPage/NotFound')

    },
    {
      path: '/Review',
      name: 'Review',
      component: () => import('@/components/Reviews/Review'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === false) {
          next({path: '/notallowed'})
        } else {
          next()
        }
      }
    }
    /*
    {
      path: '/GetUserReview',
      name: 'GetUserReview',
      component: () => import('@/components/Reviews/GetUserReview'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === true) {
          next()
        }
        next({path: '/notallowed'})
      }
    },
    */
    /*
    {
      // Chat Page
      path: '/chat',
      name: 'Chat',
      component: () => import('@/components/UserProfile/Chat'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === true) {
          next()
        }
        next({path: '/notallowed'})
      }
    },
    */
    /*
    {
      // Follow Page
      path: '/follows',
      name: 'Follows',
      component: () => import('@/components/UserProfile/Follows'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === true) {
          next()
        }
        next({path: '/notallowed'})
      }
    },
    */
    /*
    {
      // Workout Logger component
      path: '/WorkoutLogger',
      name: 'WorkoutLogger',
      component: () => import('@/components/UserProfile/WorkoutLogger'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === true) {
          next()
        }
        next({path: '/notallowed'})
      }
    },
     */
    /*
    {
      // Workout Logger component
      path: '/GetWorkouts',
      name: 'GetWorkouts',
      component: () => import('@/components/UserProfile/GetWorkouts'),
      beforeEnter: (to, from, next) => {
        if (store.getters.getisLogin === true) {
          next()
        }
        next({path: '/notallowed'})
      }
    },
    */
  ]
})
