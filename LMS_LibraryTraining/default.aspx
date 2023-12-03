<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="LMS_LibraryTraining._default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div id="demo" class=" carousel slide" data-ride="carousel">
                <!--Indicators-->
                <ul class="carousel-indicators">
                    <li data-target="#demo" data-slide-to="0" class="active"></li>
                    <li data-target="#demo" data-slide-to="0"></li>
                    <li data-target="#demo" data-slide-to="0"></li>
                </ul>

                <!--The Slide show-->
                <div class="carousel-inner">
                    <div class="carousel-item active">
                        <img src="SlideImg/washington.jpg" alt="Washing Ton" width="1000" height="575" />
                    </div>
                    <div class="carousel-item">
                        <img src="SlideImg/chicago.jpg" alt="Chicago" width="1000" height="575" />
                    </div>
                    <div class="carousel-item">
                        <img src="SlideImg/newyork.jpeg" alt="New York" width="1000" height="575" />
                    </div>
                </div>

                <!--Left and right control button-->
                <a class="carousel-control-prev" href="#demo" data-slide="prev">
                    <span class="carousel-control-prev-icon"></span>
                </a>
                <a class="carousel-control-next" href="#demo" data-slide="next">
                    <span class="carousel-control-next-icon"></span>
                </a>

            </div>
        </div>
        <div class="row">
            <div class="col-sm-12">
                <h2>TITLE HEADING</h2>
                <h5>Title Description, Dec 3 2023</h5>
                <div class="fakeimg">fake Image</div>
                <p>Some Text....</p>
                <p>loremipsum32</p>
                <br />
                <h2>Heading 2</h2>
                <h5>Title Description, Dec 3 2023</h5>
                <div class="fakeimg">fake Image</div>
                <p>Some Text....</p>
                <p>loremipsum32</p>
                <br />
            </div>
        </div>
        <div class="row">
            <div class="container">
                <div class="row">
                    <div class="col-sm-4">
                        <div class="panel panel-primary">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="placeholder img" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift card</div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class=" panel panel-primary">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="placeholder img" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift card</div>
                        </div>
                    </div>
                    <div class="col-sm-4">
                        <div class=" panel panel-primary">
                            <div class="panel-heading">BLACK FRIDAY DEAL</div>
                            <div class="card-body">
                                <img src="https://placehold.it/150x80?text=IMAGE" class="img-responsive" style="width: 100%" alt="placeholder img" />
                            </div>
                            <div class="panel-footer">Buy 50 mobiles and get a gift card</div>
                        </div>
                    </div>
                    </div>
                    </div>

                </div>
            </div>

      
</asp:Content>
