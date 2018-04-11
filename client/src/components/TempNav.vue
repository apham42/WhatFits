<template>
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

</template>

<script>
import jQuery from 'jquery'

export default {
  name: 'TempNav',
  components: {

  },
  computed: {
  },
  methods: {
  }
}

jQuery(document).ready(function ($) {
  var $toggle = $('#nav-toggle')
  var $menu = $('#nav-menu')

  $toggle.click(function () {
    $(this).toggleClass('is-active')
    $menu.toggleClass('is-active')
  })

  $('.modal-button').click(function () {
    var target = $(this).data('target')
    $('html').addClass('is-clipped')
    $(target).addClass('is-active')
  })

  $('.modal-background, .modal-close').click(function () {
    $('html').removeClass('is-clipped')
    $(this).parent().removeClass('is-active')
  })

  $('.modal-card-head .delete, .modal-card-foot .button').click(function () {
    $('html').removeClass('is-clipped')
    $('#modal-ter').removeClass('is-active')
  })

  var $highlights = $('.highlight')

  $highlights.each(function () {
    var $el = $(this)
    var copy = '<button class="copy">Copy</button>'
    var expand = '<button class="expand">Expand</button>'
    $el.append(copy)

    if ($el.find('pre code').innerHeight() > 600) {
      $el.append(expand)
    }
  })

  var $highlightButtons = $('.highlight .copy, .highlight .expand')

  $highlightButtons.hover(function () {
    $(this).parent().css('box-shadow', '0 0 0 1px #ed6c63')
  }, function () {
    $(this).parent().css('box-shadow', 'none')
  })

  $('.highlight .expand').click(function () {
    $(this).parent().children('pre').css('max-height', 'none')
  })
})

</script>

<style>

</style>
