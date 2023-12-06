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

                        <div class="container mt-3">
                            <h2>Sign Up Screen</h2>
                            <br />
                            <!-- Nav tabs -->
                            <ul class="nav nav-tabs">
                                <li class="nav-item">
                                    <a class="nav-link active" data-toggle="tab" href="#signup">Create New Account</a>
                                </li>
                            </ul>

                            <!-- Tab panes -->
                            <div class="tab-content">
                                <div id="signup" class="container tab-pane active">
                                    <br />
                                    <h3>Create New Account</h3>
                                    <p></p>

                                    <!--design Login form -->

                                    <div class="container">
                                        <div class="row">
                                            <div class="col-md-12 mx-auto">
                                                <div class="card">
                                                    <div class="card-body">
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <img src="LogoIcon/user.png" alt="user img" width="150" />
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <center>
                                                                    <h3>Member/User Sign Up</h3>
                                                                </center>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col">
                                                                <hr />
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-4">
                                                                <label>Member ID</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtMemberID" placeHolder="Member ID" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Password</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtPassword" placeHolder="Password" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Enter Valid Password" ControlToValidate="txtPassword" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>
                                                                <label>Full Name</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtFullname" placeHolder="Full Name" CssClass="form-control" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter Full Name" ControlToValidate="txtFullname" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                                </div>


                                                            </div>
                                                            <div class="col-4">
                                                                <label>Contact No.</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtContact" placeHolder="Contact No" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>Email Address</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtEmail" placeHolder="Email ID" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Enter valid Email ID" ControlToValidate="txtEmail" SetFocusOnError="True" Display="Dynamic" ForeColor="Red"></asp:RequiredFieldValidator>
                                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Enter valid Email ID" ControlToValidate="txtEmail" SetFocusOnError="True" ForeColor="Red" Display="Dynamic" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                                                </div>
                                                                <label>Date of Birth</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtDob" placeHolder="Date of Birth" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                            <div class="col-4">
                                                                <label>Pin Code</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtpincode" placeHolder="Pin code" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                                <label>State</label>
                                                                <div class="form-group">
                                                                    <asp:DropDownList ID="ddlstate" CssClass="form-control" runat="server">
                                                                        <asp:ListItem Value="Please Select" Text="Select" />
                                                                        <asp:ListItem Value="Koshi" Text="Koshi" />
                                                                        <asp:ListItem Value="Madhesh" Text="Madhesh" />
                                                                        <asp:ListItem Value="Bagmati" Text="Bagmati" />
                                                                        <asp:ListItem Value="Gandaki" Text="Gandaki" />
                                                                        <asp:ListItem Value="Lumbini" Text="Lumbini" />
                                                                        <asp:ListItem Value="Karnali" Text="Karnali" />
                                                                        <asp:ListItem Value="Sundar Paschim" Text="Sundar Paschim" />
                                                                    </asp:DropDownList>

                                                                </div>
                                                                <label>City</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtCity" placeHolder="City" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-12">
                                                                <label>Full Address</label>
                                                                <div class="form-group">
                                                                    <asp:TextBox ID="txtfulladdress" placeHolder="Full Address" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="row">
                                                            <div class="col-6">
                                                                <div class="form-group">
                                                                    <asp:Button ID="btnsignup" CssClass="btn btn-block btn-success btn-lg" runat="server" Text="Sign Up" OnClick="btnsignup_Click" />
                                                                </div>
                                                            </div>
                                                            <%-- <div class="form-group">
                                                                <a href="SignUp.aspx">
                                                                    <input type="button" class="btn btn-block btn-lg btn-info" value="Sign Up" />
                                                                </a>
                                                            </div>--%>
                                                        </div>

                                                    </div>
                                                </div>
                                                <a href="#"><< Back to Home Page</a>
                                            </div>
                                        </div>
                                    </div>


                                    <!--end login form-->
                                </div>
                            </div>
                        </div>

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
