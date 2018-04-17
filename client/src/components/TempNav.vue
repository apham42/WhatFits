<template>
<!--
<nav class="navbar ">
    <div class="navbar-brand">
      <a class="navbar-item" href="http://bulma.io">
        <img src="../assets/NavbarLogo/navbarLogo.png" alt="Bulma: a modern CSS framework based on Flexbox" width="112" height="28">
      </a>
      <a class="navbar-item is-hidden-desktop" href="https://github.com/apham42/WhatFits" target="_blank">
        <span class="icon" style="color: #333;">
          <i class="fab fa-github"></i>
        </span>
      </a>
      <div class="navbar-burger burger" data-target="navMenuExample1">
        <span></span>
        <span></span>
        <span></span>
      </div>
    </div>
    <div id="navMenuExample1" class="navbar-menu">
      <div class="navbar-start">
        <a class="navbar-item " href="#">
          Home
        </a>
        <div class="navbar-item has-dropdown is-hoverable">
          <a class="navbar-link " href="#">
            Docs
          </a>
          <div class="navbar-dropdown ">
            <a class="navbar-item " href="#">
              Overview
            </a>
            <a class="navbar-item " href="#">
              Modifiers
            </a>
            <a class="navbar-item " href="#">
              Grid
            </a>
            <a class="navbar-item " href="#">
              Form
            </a>
            <a class="navbar-item " href="#">
              Elements
            </a>
            <a class="navbar-item is-active" href="#">
              Components
            </a>
            <a class="navbar-item " href="#">
              Layout
            </a>
            <hr class="navbar-divider">
            <div class="navbar-item">
              <div>version
                <p class="has-text-info is-size-6-desktop">0.4.3</p>
              </div>
            </div>
          </div>
        </div>
        <div class="navbar-item has-dropdown is-hoverable">
          <a class="navbar-link " href="#blog/">
            Blog
          </a>
          <div id="blogDropdown" class="navbar-dropdown " data-style="width: 18rem;">
            <a class="navbar-item" href="/2017/03/10/new-field-element/">
              <div class="navbar-content">
                <p>
                  <small class="has-text-info">10 Mar 2017</small>
                </p>
                <p>New field element (for better controls)</p>
              </div>
            </a>
            <a class="navbar-item" href="/2016/04/11/metro-ui-css-grid-with-bulma-tiles/">
              <div class="navbar-content">
                <p>
                  <small class="has-text-info">11 Apr 2016</small>
                </p>
                <p>Metro UI CSS grid with Bulma tiles</p>
              </div>
            </a>
            <a class="navbar-item" href="/2016/02/09/blog-launched-new-responsive-columns-new-helpers/">
              <div class="navbar-content">
                <p>
                  <small class="has-text-info">09 Feb 2016</small>
                </p>
                <p>Blog launched, new responsive columns, new helpers</p>
              </div>
            </a>
            <a class="navbar-item" href="#blog/">
              More posts
            </a>
            <hr class="navbar-divider">
            <div class="navbar-item">
              <div class="navbar-content">
                <div class="level is-mobile">
                  <div class="level-left">
                    <div class="level-item">
                      <strong>Stay up to date!</strong>
                    </div>
                  </div>
                  <div class="level-right">
                    <div class="level-item">
                      <a class="button is-rss is-small" href="#atom.xml">
                        <span class="icon is-small">
                          <i class="fa fa-rss"></i>
                        </span>
                        <span>Subscribe</span>
                      </a>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="navbar-end">
        <a class="navbar-item" href="https://github.com/jgthms/bulma" target="_blank">
          Github
        </a>
        <a class="navbar-item" href="https://twitter.com/jgthms" target="_blank">
          Twitter
        </a>
        <div class="navbar-item">
          <div class="field is-grouped">
            <p class="control">
              <a id="twitter" class="button">
                <span>Tweet</span>
              </a>
            </p>
            <p class="control">
              <a class="button is-primary" href="https://github.com/jgthms/bulma/archive/0.4.3.zip">
                <span class="icon">
                <i class="fas fa-sign-in-alt"></i>
                </span>
                <span>Login</span>
              </a>
            </p>
          </div>
        </div>
      </div>
    </div>
  </nav>
-->
<div>
<section class="hero ">
    <!-- Hero head: will stick at the top -->
    <div class="hero-head">
        <nav class="navbar">
            <div class="container">
                <div class="navbar-brand">
                    <a>
              <img id="navImage" src="../assets/Images/NavbarLogo/navbarLogo.png" alt="Logo">
            </a>
                    <span class="navbar-burger burger" data-target="navbarMenuHero1">
              <span></span>
                    <span></span>
                    <span></span>
                    </span>
                </div>
                <div id="navbarMenuHero1" class="navbar-menu">
                    <div class="navbar-end">
                        <a class="navbar-item">
                Home
              </a>
                        <a class="navbar-item">
                Examples
              </a>
                        <a class="navbar-item">
                Documentation
              </a>
                        <div class="navbar-item has-dropdown is-hoverable">
                            <div class="navbar-link">
                                More
                            </div>
                            <div id="moreDropdown" class="navbar-dropdown ">
                                <a class="navbar-item " href="#">
                                    <div class="level is-mobile">
                                        <div class="level-left">
                                            <div class="level-item">
                                                <p>
                                                    <strong>Extensions</strong>
                                                    <br>
                                                    <small>Side projects to enhance Bulma</small>
                                                </p>
                                            </div>
                                        </div>
                                    </div>
                                </a>
                            </div>
                        </div>
                        <span class="navbar-item">
                          <a class="button is-primary is-primary">
                  <span class="icon">
                   <i class="fas fa-plus-circle"></i>
                  </span>
                        <span>Register</span>
                        </a>
                <a class="button is-primary is-inverted">
                  <span class="icon">
                   <i class="fas fa-sign-in-alt"></i>
                  </span>
                        <span>Login</span>
                        </a>

                        </span>
                    </div>
                </div>
            </div>
        </nav>
    </div>
    <!-- Hero content: will be in the middle -->
    <div class="hero-body">
        <div class="container has-text-centered">
            <h1 class="title">
                Title
            </h1>
            <h2 class="subtitle">
                Subtitle
            </h2>
        </div>
    </div>
    <!-- Hero footer: will stick at the bottom -->
    <div class="hero-foot">
        <nav class="tabs">
            <div class="container">
                <ul>
                    <li class="is-active">
                        <a>Overview</a>
                    </li>
                    <li>
                        <a>Modifiers</a>
                    </li>
                    <li>
                        <a>Grid</a>
                    </li>
                    <li>
                        <a>Elements</a>
                    </li>
                    <li>
                        <a>Components</a>
                    </li>
                    <li>
                        <a>Layout</a>
                    </li>
                </ul>
            </div>
        </nav>
    </div>
</section>
<div class="box cta">
      <p class="has-text-centered">
         <span class="tag is-primary">New</span> Login Still Doesn't Work
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
                     <h4>Potential Ad Revenue Machine</h4>
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
   </div>
</template>

<script>
export default {
  name: 'TempNav',
  components: {

  },
  computed: {
  },
  methods: {
  }
}
</script>

<style>
#navImage {
  height: 50px;
  padding-left: 20px;
  padding-top: 5px;
}
#homeIcons{
    height: 10em;
    width: 10em;
    padding-top: 2em;
}
</style>
