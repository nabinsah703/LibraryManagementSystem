<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="LMS_LibraryTraining.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Sign Up</title>
    <%-- 1 BootStrap css--%>
    <link href="bootstrap/css/bootstrap.min.css" rel="stylesheet" />
    <%--2 datatabel css--%>
    <link href="datatable/css/jquery.dataTables.min.css" rel="stylesheet" />
    <%--3 fontawesome css --%>
    <link href="fontawesome/css/all.css" rel="stylesheet" />
    <%--4 jquery js--%>
    <script src="bootstrap/js/jquery-3.3.1.slim.min.js"></script>
    <%--5 popper js--%>
    <script src="bootstrap/js/popper.min.js"></script>
    <%--6 Bootstrap js--%>
    <script src="bootstrap/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <nav class="navbar navbar-expand-sm navbar-dark bg-primary">
                <a class="navbar-brand" href="default.aspx">
                    <img src="LogoIcon/books_library_1767.ico" alt="logo" width="49" height="49" />LMS Application </a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#collapsibleNavbar">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <div class="collapse navbar-collapse" id="collapsibleNavbar">
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="default.aspx"><b>Home</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>About</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Library Application</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Archives</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Contact Us</b></a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#"><b>Application</b></a>
                        </li>
                    </ul>
                    <!-- right menu-->

                    <div class="pmd-navbar-right-icon ml-auto">
                        <%--<a class="btn btn-sm btn-primary" href="#">Sign Up</a>--%>
                        <a class="btn btn-sm btn-primary" href="Login.aspx">Log In</a>
                    </div>
                </div>
            </nav>

            <div class="jumbotron text-center alert alert-primary" style="margin-bottom">
                <h1>Library Management System</h1>
                <p>Builing Communitity. Inspiring readers. Expanding book access.</p>
            </div>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-sm-2 border border-info">
                        <h4>Filter</h4>
                        <h5>Category</h5>
                        <div class="fakeimg">Fake Image </div>
                        <p>Some text about me in the library management system</p>
                        <h3>Some Links</h3>
                        <ul class="nav nav-pills flex-column">
                            <li class="nav-item">
                                <a class="nav-link active" href="#">Active</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="#">Link</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link disabled" href="#">Disabled</a>
                            </li>
                        </ul>
                    </div>
                    <div class="col-sm-10 border border-info">
                        <!-- Sign up code here-->


                        <!-- End code here -->

                    </div>
                </div>

            </div>

            <div class="jumbotron text-center alert alert-danger" style="margin-bottom: 0; border: 2px solid red">
                <p>Footer</p>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="footer-pad">
                                <h4>Heading1</h4>
                                <ul class="list-unstyled">
                                    <li><a href="#"></a></li>
                                    <li><a href="#">Payment Center</a></li>
                                    <li><a href="#">News and Updates</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="footer-pad">
                                <h4>Heading1</h4>
                                <ul class="list-unstyled">
                                    <li><a href="#"></a></li>
                                    <li><a href="#">Website</a></li>
                                    <li><a href="#">Desclaimer</a></li>
                                </ul>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="footer-pad">
                                <h4>Follow Us</h4>
                                <ul class="social-network social-circle">
                                    <li><a href="#"></a></li>
                                    <li><a href="#" title="Facebook"><i class="fa fa-facebook">facebook</i></a></li>
                                    <li><a href="#">News and Updates</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 fa-copyright border-dark">
                            <p class="text-center">&copy; Copright 2023 - Navin Sah Library. All rights reserved.</p>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
