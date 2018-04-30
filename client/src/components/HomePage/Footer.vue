<template>
    <footer class="footer-distributed">
      <div class="container">
        <div class="footer-left">
          <img id="logoFooter" src="../../assets/Images/NavbarLogo/navbarLogo.png">
          <p class="footer-company-name">Whatfits &copy; 2018</p>
        </div>
        <div class="footer-center">
          <div>
            <span class="fa-icon-size">
              <i class="fa fa-map-marker"></i>
            </span>

              <span style="padding-left:1em;"></span>
              <p>321 Fake St.<br> Los Angeles, California</p>
          </div>
          <br>
          <div>
            <i class="fa fa-phone"></i>
            <span style="padding-left:1em;"></span>
            <p>(123) 123-4567</p>
          </div>
          <br>
          <div>
            <i class="fa fa-envelope"></i>
            <span style="padding-left:1em;"></span>
            <p><a href="/cdn-cgi/l/email-protection#65161015150a171125060a0815040b1c4b060a08"><span class="__cf_email__" data-cfemail="a0d3d5d0d0cfd2d4e0c3cfcdd0c1ced98ec3cfcd">contact@whatfits.social</span></a></p>
          </div>
        </div>
        <div class="footer-right">
            <p class="footer-company-about"> <span>About the company</span> This is a fitness social media application. Need something to fill this space in. Heres the <a href="https://github.com/apham42/WhatFits">github.</a></p>
            <div class="footer-icons">
              <a href="https://github.com/apham42/WhatFits"><i class="fab fa-github"></i></a>
              <a href="#"><i class="fab fa-twitter-square"></i></a>
              <a href="#"><i class="fab fa-linkedin"></i></a>
              <a href="#"><i class="fab fa-github-square"></i></a>
            </div>
        </div>
      </div>
    </footer>
</template>
<script>
export default {
  name: 'Footer',
  data () {
    return {
    }
  },
  methods: {

  }
}
</script>
<style >
.fa-icon-size{
  height: 2em;
  width: 2em;
  padding-top: 2em;
}
#logoFooter{
  height: 6em;
  width: 20em;
}
.footer-distributed{
  background-color: #292c2f;
  box-shadow: 0 1px 1px 0 rgba(0, 0, 0, 0.12);
  box-sizing: border-box;
  width: 100%;
  text-align: left;
  font: bold 16px sans-serif;

  padding: 55px 50px;
  margin-top: 80px;
}

.footer-distributed .footer-left,
.footer-distributed .footer-center,
.footer-distributed .footer-right{
  display: inline-block;
  vertical-align: top;
}

/* Footer left */

.footer-distributed .footer-left{
  width: 40%;
}

/* The company logo */

.footer-distributed h3{
  color:  #ffffff;
  font: normal 36px 'Cookie', cursive;
  margin: 0;
}

.footer-distributed h3 span{
  color:  #5383d3;
}

/* Footer links */

.footer-distributed .footer-links{
  color:  #ffffff;
  margin: 20px 0 12px;
  padding: 0;
}

.footer-distributed .footer-links a{
  display:inline-block;
  line-height: 1.8;
  text-decoration: none;
  color:  inherit;
}

.footer-distributed .footer-company-name{
  color:  #8f9296;
  font-size: 14px;
  font-weight: normal;
  margin: 0;
}

/* Footer Center */

.footer-distributed .footer-center{
  width: 35%;
}

.footer-distributed .footer-center i{
  background-color:  #33383b;
  color: #ffffff;
  font-size: 25px;
  width: 38px;
  height: 38px;
  border-radius: 50%;
  text-align: center;
  line-height: 42px;
  margin: 10px 15px;
  vertical-align: middle;
}

.footer-distributed .footer-center p{
  display: inline-block;
  color: #ffffff;
  vertical-align: middle;
  margin:0;
}

.footer-distributed .footer-center p span{
  display:block;
  font-weight: normal;
  font-size:14px;
  line-height:2;
}

.footer-distributed .footer-center p a{
  color:  #5383d3;
  text-decoration: none;
}
/* Footer Right */
.footer-distributed .footer-right{
  width: 20%;
}

.footer-distributed .footer-company-about{
  line-height: 20px;
  color:  #92999f;
  font-size: 13px;
  font-weight: normal;
  margin: 0;
}

.footer-distributed .footer-company-about span{
  display: block;
  color:  #ffffff;
  font-size: 14px;
  font-weight: bold;
  margin-bottom: 20px;
}

.footer-distributed .footer-icons{
  margin-top: 25px;
}
/* If you don't want the footer to be responsive, remove these media queries */

@media (max-width: 880px) {

  .footer-distributed{
    font: bold 14px sans-serif;
  }

  .footer-distributed .footer-left,
  .footer-distributed .footer-center,
  .footer-distributed .footer-right{
    display: block;
    width: 100%;
    margin-bottom: 40px;
    text-align: center;
  }

  .footer-distributed .footer-center i{
    margin-left: 0;
  }
  }

</style>
