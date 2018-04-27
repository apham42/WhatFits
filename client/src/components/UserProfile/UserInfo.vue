<template>
<div id="profile">
   <div class="column">
         <div class="column" id= "profileCard">
            <div class="card " >
               <div class="card-image" id="imageBackground">
                  <!-- NOTE: This is a temporary image used as a profile picture-->
                   <figure class="image"> <img  id="circle-ProfileImage" v-bind:src=this.userData.profileImage> </figure>

               </div>
               <div class="card-content" align="center">
                  <span class="title is-1">{{this.userData.firstName}} {{this.userData.lastName}}</span>
                  <hr>
                  <span v-if="this.userData.myProfile == true" >
                      <button class="button is-primary is-rounded" id="buttonGap" @click="goEditProfile">Edit Profile</button>
                  </span>
                  <span v-else>
                        <folo></folo>
                        <button class="button is-secondary is-rounded" id="buttonGap">Review</button>
                  </span>
                  <hr>
               </div>
               <div class="card-content" id="NoUpperBorders">
                  <div class="content">
                    <p class="title is-3">About Me: </p>
                     <span class="subtitle is-4">{{this.userData.description}}</span>
                     <br>
                  </div>
                  <div class="content">
                      <p class="subtitle is-5">Gender: {{this.userData.gender}}</p>
                      <p class="subtitle is-5">Skill Level: {{this.userData.skillLevel}}</p>
                     <br>
                  </div>
               </div>
            </div>
         </div>
   </div>
</div>
</template>

<script>
export default {
  name: 'UserInfo',
  props: ['userData'],
  data () {
    return {
    }
  },
  methods: {
    goEditProfile: function () {
      this.$router.push('/editprofile')
    }
  }
}
</script>

<style>

#buttonGap{
  padding-left: 2.5em;
  padding-right: 2.5em;
}
#circle-ProfileImage {
  border-radius: 50%;
  width: 500px;
  height: 500px;
  max-height: 20em;
  max-width: 20em;
  margin-left: auto;
  margin-right: auto;
}
#imageBackground {
  background-image: url("../../../static/ProfileDummy/backgroundImage.jpg");
}
#NoUpperBorders {
  margin-top: -12%;
}
</style>
