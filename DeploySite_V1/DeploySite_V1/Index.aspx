﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="DeploySite_V1.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>

    <title>Team Name -</title>

    <!-- Bootstrap core CSS -->
    <link href="vendor/bootstrap/css/bootstrap.min.css" rel="stylesheet"/>

    <!-- Custom fonts for this template -->
    <link rel="stylesheet" href="vendor/font-awesome/css/font-awesome.min.css"/>
    <link rel="stylesheet" href="vendor/simple-line-icons/css/simple-line-icons.css"/>
    <link href="https://fonts.googleapis.com/css?family=Lato" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Catamaran:100,200,300,400,500,600,700,800,900" rel="stylesheet"/>
    <link href="https://fonts.googleapis.com/css?family=Muli" rel="stylesheet"/>

    <!-- Plugin CSS -->
    <link rel="stylesheet" href="device-mockups/device-mockups.min.css"/>

    <!-- Custom styles for this template -->
    <link href="css/new-age.min.css" rel="stylesheet"/>
</head>
<body id="page-top">
    <form id="form1" runat="server">
    <!-- Navigation -->
    <nav class="navbar navbar-expand-lg navbar-light fixed-top" id="mainNav">
      <div class="container">
        <a class="navbar-brand js-scroll-trigger" href="#page-top">Welcome</a>
        <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse" data-target="#navbarResponsive" aria-controls="navbarResponsive" aria-expanded="false" aria-label="Toggle navigation">
          Menu
          <i class="fa fa-bars"></i>
        </button>
        <div class="collapse navbar-collapse" id="navbarResponsive">
          <ul class="navbar-nav ml-auto">
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#intro">Introduction</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#mentors">Mentors</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#team">Team</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#meetings">Meetings</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#milestones">Milestones</a>
            </li>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#videos">Videos</a>
            </li>
            <%--<li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#features">Features</a>
            </li>--%>
            <li class="nav-item">
              <a class="nav-link js-scroll-trigger" href="#contact">Contact</a>
            </li>
          </ul>
        </div>
      </div>
    </nav>

    <header class="masthead">
      <div class="container h-100">
        <div class="row h-100">
          <div class="col-lg-7 my-auto">
            <div class="header-content mx-auto">
              <h1 class="mb-5">Short abstract description</h1>
              <a href="#intro" class="btn btn-outline btn-xl js-scroll-trigger">Explore</a>
            </div>
          </div>
          <%--<div class="col-lg-5 my-auto">
            <div class="device-container">
              <div class="device-mockup iphone6_plus portrait white">
                <div class="device">
                  <div class="screen">
                    <!-- Demo image for screen mockup, you can put an image here, some HTML, an animation, video, or anything else! -->
                    <img src="img/demo-screen-1.jpg" class="img-fluid" alt="">
                  </div>
                  <div class="button">
                    <!-- You can hook the "home button" to some JavaScript events or just remove it -->
                  </div>
                </div>
              </div>
            </div>
          </div>--%>
        </div>
      </div>
    </header>

    <section class="download bg-primary text-center" id="intro">
      <div class="container">
        <div class="row">
          <div class="col-md-8 mx-auto">
            <h2 class="section-heading">What we are about</h2>
            <p>Make intro as long as possible</p>
            <%--<div class="badges">
              <a class="badge-link" href="#"><img src="img/google-play-badge.svg" alt=""></a>
              <a class="badge-link" href="#"><img src="img/app-store-badge.svg" alt=""></a>
            </div>--%>
          </div>
        </div>
      </div>
    </section>

        <!--Description About Mentors-->
    <section class="features" id="mentors">
      <div class="container">
        <div class="section-heading text-center">
          <h2>This is our team</h2>
          <p class="text-muted">Description</p>
          <hr>
        </div>
        <div class="row">
          <%--<div class="col-lg-4 my-auto">
            <div class="device-container">
              <div class="device-mockup iphone6_plus portrait white">
                <div class="device">
                  <div class="screen">
                    <!-- Demo image for screen mockup, you can put an image here, some HTML, an animation, video, or anything else! -->
                    <img src="img/demo-screen-1.jpg" class="img-fluid" alt="">
                  </div>
                  <div class="button">
                    <!-- You can hook the "home button" to some JavaScript events or just remove it -->
                  </div>
                </div>
              </div>
            </div>
          </div>--%>
          <div class="col-lg-12 my-auto">
            <div class="container-fluid">
              <div class="row">
                <div class="col-lg-6">
                  <div class="feature-item">
                    <%--<i class="icon-screen-smartphone text-primary"></i>--%>
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <h3>Mentor 1</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
                <div class="col-lg-6">
                  <div class="feature-item">
                    <%--<i class="icon-camera text-primary"></i>--%>
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <h3>Mentor 2</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
              </div>
              <%--<div class="row">
                <div class="col-lg-6">
                  <div class="feature-item">
                    <i class="icon-present text-primary"></i>
                    <h3>Vipasha Rana</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
                <div class="col-lg-6">
                  <div class="feature-item">
                    <i class="icon-lock-open text-primary"></i>
                    <h3>Roshini</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
              </div>--%>
            </div>
          </div>
        </div>
      </div>
    </section>
        <!--Description about Team-->
    <section class="features" id="team">
      <div class="container">
        <div class="section-heading text-center">
          <h2>This is our team</h2>
          <p class="text-muted">Description</p>
          <hr>
        </div>
        <div class="row">
          <%--<div class="col-lg-4 my-auto">
            <div class="device-container">
              <div class="device-mockup iphone6_plus portrait white">
                <div class="device">
                  <div class="screen">
                    <!-- Demo image for screen mockup, you can put an image here, some HTML, an animation, video, or anything else! -->
                    <img src="img/demo-screen-1.jpg" class="img-fluid" alt="">
                  </div>
                  <div class="button">
                    <!-- You can hook the "home button" to some JavaScript events or just remove it -->
                  </div>
                </div>
              </div>
            </div>
          </div>--%>
          <div class="col-lg-12 my-auto">
            <div class="container-fluid">
              <div class="row">
                <div class="col-lg-6">
                  <div class="feature-item">
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <%--<i class="icon-screen-smartphone text-primary"></i>--%>
                    <h3>Siddharth Lucky</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
                <div class="col-lg-6">
                  <div class="feature-item">
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <%--<i class="icon-camera text-primary"></i>--%>
                    <h3>Krishna Teja</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
              </div>
              <div class="row">
                <div class="col-lg-6">
                  <div class="feature-item">
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <%--<i class="icon-present text-primary"></i>--%>
                    <h3>Vipasha Rana</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
                <div class="col-lg-6">
                  <div class="feature-item">
                    <img src="img/sdl_logo.png" class="img-fluid" alt="">
                    <%--<i class="icon-lock-open text-primary"></i>--%>
                    <h3>Roshini</h3>
                    <p class="text-muted">Description</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>

    <section class="cta">
      <div class="cta-content">
        <div class="container">
          <h2>Think of content or can delete</h2>
          <a href="#contact" class="btn btn-outline btn-xl js-scroll-trigger">Button</a>
        </div>
      </div>
      <div class="overlay"></div>
    </section>

    <section class="contact bg-primary" id="contact">
      <div class="container">
        <h2>We
          <i class="fa fa-heart"></i>
          new friends!</h2>
        <ul class="list-inline list-social">
          <li class="list-inline-item social-twitter">
            <a href="#">
              <i class="fa fa-twitter"></i>
            </a>
          </li>
          <li class="list-inline-item social-facebook">
            <a href="#">
              <i class="fa fa-facebook"></i>
            </a>
          </li>
          <li class="list-inline-item social-google-plus">
            <a href="#">
              <i class="fa fa-google-plus"></i>
            </a>
          </li>
        </ul>
      </div>
    </section>

    <footer>
      <div class="container">
        <p>&copy; Your Website 2018. All Rights Reserved.</p>
        <%--<ul class="list-inline">
          <li class="list-inline-item">
            <a href="#">Privacy</a>
          </li>
          <li class="list-inline-item">
            <a href="#">Terms</a>
          </li>
          <li class="list-inline-item">
            <a href="#">FAQ</a>
          </li>
        </ul>--%>
      </div>
    </footer>

    <!-- Bootstrap core JavaScript -->
    <script src="vendor/jquery/jquery.min.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.bundle.min.js"></script>

    <!-- Plugin JavaScript -->
    <script src="vendor/jquery-easing/jquery.easing.min.js"></script>

    <!-- Custom scripts for this template -->
    <script src="js/new-age.min.js"></script>
    </form>
</body>
</html>
