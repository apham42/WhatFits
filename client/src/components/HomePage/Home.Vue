<template>
 <div>
<section class="hero ">
    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
        <div class="container has-text-centered homeBody">
            <h1 class="title body-text">
                Whatfits Homepage
            </h1>
            <h2 class="subtitle body-text">
                Clearly under construction
            </h2>
        </div>
    </div>
    <!-- Hero footer: will stick at the bottom -->
    <div class="hero-foot">
        <nav class="tabs">
            <div class="container">
                <ul>
                    <li class="is-active">
                        <router-link to="/signup">Register</router-link>
                    </li>
                    <li>
                        <router-link to="/usermanagement">UserManagement</router-link>
                    </li>
                    <li>
                        <router-link to="/Review">Review</router-link>
                    </li>
                    <li>
                        <router-link to="/profile">Profile</router-link>
                    </li>
                    <li>
                        <router-link to="/SearchBar">Search</router-link>
                    </li>
                    <li>
                        <router-link to="/chat">Chat</router-link>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</section>
<div class="box cta">
      <p class="has-text-centered">
         <span class="tag is-warning">lol</span> Login FINALLY works
      </p>
   </div>
   <section class="container">
      <div class="columns features">
         <div class="column is-4">
            <div class="card is-shady">
               <div class="card-image has-text-centered">
                  <i class="fa fa-home" id="homeIcons"></i>
               </div>
               <div class="card-content">
                  <div class="content">
                     <h4>Coming Soon</h4>
                     <p>Purus semper eget duis at tellus at urna condimentum mattis. Non blandit massa enim nec. Integer enim neque volutpat ac tincidunt vitae semper quis. Accumsan tortor posuere ac ut consequat semper viverra nam.</p>
                     <p><a href="#">Learn more</a></p>
                  </div>
               </div>
            </div>
         </div>
         <div class="column is-4">
            <div class="card is-shady">
               <div class="card-image has-text-centered">
                  <i class="fa fa-audio-description" id="homeIcons"></i>
               </div>
               <div class="card-content">
                  <div class="content">
                     <h4>Coming Soon</h4>
                     <p>Ut venenatis tellus in metus vulputate. Amet consectetur adipiscing elit pellentesque. Sed arcu non odio euismod lacinia at quis risus. Faucibus turpis in eu mi bibendum neque egestas cmonsu songue. Phasellus vestibulum lorem sed risus.</p>
                     <p><a href="#">Learn more</a></p>
                  </div>
               </div>
            </div>
         </div>
         <div class="column is-4">
            <div class="card is-shady">
               <div class="card-image has-text-centered">
                  <i class="fa fa-id-card" id="homeIcons"></i>
               </div>
               <div class="card-content">
                  <div class="content">
                     <h4> Leo integer malesuada nunc vel risus. </h4>
                     <p>Imperdiet dui accumsan sit amet nulla facilisi morbi. Fusce ut placerat orci nulla pellentesque dignissim enim. Libero id faucibus nisl tincidunt eget nullam. Commodo viverra maecenas accumsan lacus vel facilisis.</p>
                     <p><a href="#">Learn more</a></p>
                  </div>
               </div>
            </div>
         </div>
      </div>
      <div class="intro column is-8 is-offset-2">
         <h2 class="title">Perfect for developers or designers!</h2>
         <br>
         <p class="subtitle">Vel fringilla est ullamcorper eget nulla facilisi. Nulla facilisi nullam vehicula ipsum a. Neque egestas congue quisque egestas diam in arcu cursus.</p>
      </div>
      <div class="sandbox">
         <div class="tile is-ancestor">
            <div class="tile is-parent is-shady">
               <article class="tile is-child notification is-white">
                  <p class="title">Hello World</p>
                  <p class="subtitle">What is up?</p>
               </article>
            </div>
            <div class="tile is-parent is-shady">
               <article class="tile is-child notification is-white">
                  <p class="title">Foo</p>
                  <p class="subtitle">Bar</p>
               </article>
            </div>
            <div class="tile is-parent is-shady">
               <article class="tile is-child notification is-white">
                  <p class="title">Third column</p>
                  <p class="subtitle">With some content</p>
                  <div class="content">
                     <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ornare magna eros, eu pellentesque tortor vestibulum ut. Maecenas non massa sem. Etiam finibus odio quis feugiat facilisis.</p>
                  </div>
               </article>
            </div>
         </div>
         <div class="tile is-ancestor">
            <div class="tile is-vertical is-8">
               <div class="tile">
                  <div class="tile is-parent is-vertical">
                     <article class="tile is-child notification is-white">
                        <p class="title">Vertical tiles</p>
                        <p class="subtitle">Top box</p>
                     </article>
                     <article class="tile is-child notification is-white">
                        <p class="title">Vertical tiles</p>
                        <p class="subtitle">Bottom box</p>
                     </article>
                  </div>
                  <div class="tile is-parent">
                     <article class="tile is-child notification is-white">
                        <p class="title">Middle box</p>
                        <p class="subtitle">With an image</p>
                        <figure class="image is-4by3">
                           <img src="http://bulma.io/images/placeholders/640x480.png">
                        </figure>
                     </article>
                  </div>
               </div>
               <div class="tile is-parent is-shady">
                  <article class="tile is-child notification is-white">
                     <p class="title">Wide column</p>
                     <p class="subtitle">Aligned with the right column</p>
                     <div class="content">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ornare magna eros, eu pellentesque tortor vestibulum ut. Maecenas non massa sem. Etiam finibus odio quis feugiat facilisis.</p>
                     </div>
                  </article>
               </div>
            </div>
            <div class="tile is-parent is-shady">
               <article class="tile is-child notification is-white">
                  <div class="content">
                     <p class="title">Tall column</p>
                     <p class="subtitle">With even more content</p>
                     <div class="content">
                        <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam semper diam at erat pulvinar, at pulvinar felis blandit. Vestibulum volutpat tellus diam, consequat gravida libero rhoncus ut. Morbi maximus, leo sit amet vehicula eleifend, nunc dui porta orci, quis semper odio felis ut quam.</p>
                        <p>Suspendisse varius ligula in molestie lacinia. Maecenas varius eget ligula a sagittis. Pellentesque interdum, nisl nec interdum maximus, augue diam porttitor lorem, et sollicitudin felis neque sit amet erat. Maecenas imperdiet felis nisi, fringilla luctus felis hendrerit sit amet. Aenean vitae gravida diam, finibus dignissim turpis. Sed eget varius ligula, at volutpat tortor.</p>
                        <p>Integer sollicitudin, tortor a mattis commodo, velit urna rhoncus erat, vitae congue lectus dolor consequat libero. Donec leo ligula, maximus et pellentesque sed, gravida a metus. Cras ullamcorper a nunc ac porta. Aliquam ut aliquet lacus, quis faucibus libero. Quisque non semper leo.</p>
                     </div>
                  </div>
               </article>
            </div>
         </div>
         <div class="tile is-ancestor">
            <div class="tile is-parent">
               <article class="tile is-child notification is-white">
                  <p class="title">Side column</p>
                  <p class="subtitle">With some content</p>
                  <div class="content">
                     <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ornare magna eros, eu pellentesque tortor vestibulum ut. Maecenas non massa sem. Etiam finibus odio quis feugiat facilisis.</p>
                  </div>
               </article>
            </div>
            <div class="tile is-parent is-8 is-shady">
               <article class="tile is-child notification is-white">
                  <p class="title">Main column</p>
                  <p class="subtitle">With some content</p>
                  <div class="content">
                     <p>Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ornare magna eros, eu pellentesque tortor vestibulum ut. Maecenas non massa sem. Etiam finibus odio quis feugiat facilisis.</p>
                  </div>
               </article>
            </div>
         </div>
      </div>

   </section>
   <footer-bar></footer-bar>
   </div>
</template>

<script>
import { required, minLength, maxLength, sameAs } from 'vuelidate/lib/validators'
import Footer from '@/components/HomePage/Footer'
export default {
  name: 'Home',
  components: {
    'footer-bar': Footer
  },
  data: function () {
    return {
      username: '',
      isNameValid: false,
      password: '',
      isPassValid: false,
      response: ''
    }
  },
  // validations based on business rules
  validations: {
    username: {
      required
    },
    password: {
      required,
      maxLength: maxLength(64),
      minLength: minLength(8)
    },
    confirmPassword: {
      required,
      sameAsPassword: sameAs('password')
    }
  }
}

</script>

<style>
.form.h2{
    float: left;
    clear: right;
}
.form.input{
    float: right;
}
#homeIcons{
    height: 10em;
    width: 10em;
    padding-top: 2em;
}
#bodySection {
    background-color:#34495E;
}
.hero-body {
  height: 30em;
  background-image: url("../../../static/ProfileDummy/backgroundImage2.jpg");
}
.homeBody {
padding-top: 9em;
color: white;
}
.body-text {
  color:white;
}
</style>
