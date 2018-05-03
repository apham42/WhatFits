<template>
  <div>
      <nav class="navbar is-radiusless">
         <div class="container">
            <div class="navbar-brand">
               <a>
               <img id="navImage" src="../../assets/Images/NavbarLogo/navbarLogo.png" alt="Go to your Profile" @click="toProfile">
               </a>
               <span class="navbar-burger burger" data-target="navbarMenuHero2" @click="showburger = !showburger">
               <span></span>
               <span></span>
               <span></span>
               </span>
            </div>
            <div v-if="showburger" id="navbarMenuHero2" class="navbar-menu is-active is-radiusless">
            <div class="navbar-end">
              <a class="navbar-item" @click="search">
                Search
              </a>
              <a class="navbar-item" @click="logout">
                Logout
              </a>
              <a v-if="checkUserMan" class="navbar-item" @click="userman">
                User Managment
              </a>
            </div>
          </div>
            <div id="navbarMenuHero1" class="navbar-menu">
               <div class="navbar-end">
                 <div v-if="this.$route.name !== 'Search'" class ="search">
                  <SearchBar></SearchBar>
                </div>
                  <span v-if="checkUserMan" class="navbar-item">
                    <button id="button" class="button is-primary is-inverted" @click="userman">
                    <span class="icon">
                    <i class="fas fa-cogs"></i>
                    </span>
                    <span>User Managment</span>
                    </button>
                  </span>
                  <span class="navbar-item">
                    <button id="button" class="button is-primary is-inverted" @click="logout">
                    <span class="icon">
                    <i class="fa fa-sign-out-alt"></i>
                    </span>
                    <span>Logout</span>
                    </button>
                  </span>
               </div>
            </div>
         </div>
      </nav>
   </div>
</template>

<script>
import axios from 'axios'
import SearchBar from '@/components/Search/SearchBar'
export default {
  name: 'MainNavBar',
  components: {
    'SearchBar': SearchBar
  },
  computed: {
    checkUserMan: function () {
      for (var i = 0; i < this.$store.getters.getviewclaims.length; i++) {
        if (this.$store.getters.getviewclaims[i] === 'View User Managment') {
          return true
        }
      }
      return false
    }
  },
  data () {
    return {
      showburger: false
    }
  },
  methods: {
    userman: function () {
      this.$router.push('/usermanagement')
      this.$data.showburger = false
    },
    toProfile: function () {
      this.$router.push('/profile')
      this.$data.showburger = false
    },
    search: function () {
      this.$router.push('/Search')
      this.$data.showburger = false
    },
    logout: function () {
      axios({
        method: 'POST',
        url: this.$store.getters.getURL + 'v1/logout/logout',
        headers: this.$store.getters.getheader,
        data: {
          Username: this.$store.getters.getusername,
          Token: this.$store.getters.gettoken
        }
      })
        .then((response) => {
          this.$store.dispatch('actusername', {Username: ''})
          this.$store.dispatch('acttoken', {Token: ''})
          this.$store.dispatch('actviewclaims', {Viewclaims: null})
          this.$store.dispatch('actisLogin', {islogin: false})
          this.$store.dispatch('actRequestedSearch', {requestedSearch: ''})
          this.$store.dispatch('actSearchType', {searchType: ''})
          this.$router.push('/')
          this.$store.dispatch('actheader')
          this.$data.showburger = false
        })
        .catch((error) => {
          if (error.response.status === 400) {
            // Your custom messages that appears on the screen
          } else if (error.response.status === 404) {
            // Redirects you to the 404 page
            this.$router.push('/notfound')
          } else if (error.response.status === 403) {
            // Redirects you to the Forbidden page
            this.$router.push('/notAllowed')
          } else if (error.response.status === 500) {
            // Redirects you to the server issue page
            this.$router.push('/serverissue')
          }
        })
    }
  }
}
</script>

<style>
#navImage {
  height: 50px;
  padding-left: 20px;
  padding-top: 5px;
}
.search {
  padding-top:.6em;
  padding-right: 20em;
}
</style>
