<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AdminBookInventry.aspx.cs" Inherits="LMS_LibraryTraining.Admin.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5 font-weight-normal">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventry</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img id="imgView" src="../LogoIcon/books_library_1767.ico" alt="" height="200" width="200" />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:FileUpload CssClass="form-control" ID="FileUpload1" runat="server" />
                            </div>
                        </div>

                        <div class="row">

                            <div class="col-md-4">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbookid" CssClass="form-control" runat="server"></asp:TextBox>
                                        <asp:Button ID="btngo" runat="server" Text="Go" CssClass="form-control btn btn-primary" OnClick="btngo_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-8">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <div class="input-group">
                                        <asp:TextBox ID="txtbookname" CssClass="form-control" runat="server"></asp:TextBox>

                                    </div>
                                </div>
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Language</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddllanguage" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="English" Value="English" />
                                        <asp:ListItem Text="Nepali" Value="Nepali" />
                                        <asp:ListItem Text="Maithali" Value="Maithali" />
                                        <asp:ListItem Text="Bhojpuri" Value="Bhojpuri" />
                                        <asp:ListItem Text="Newari" Value="Newari" />
                                        <asp:ListItem Text="Tamang" Value="Tamang" />
                                    </asp:DropDownList>
                                </div>

                                <label>Publisher Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlpublishername" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Publisher 1" Value="Publisher 1" />
                                        <asp:ListItem Text="Publisher 2" Value="Publisher 2" />

                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Author Name</label>
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlauthor" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Author 1" Value="Author1" />
                                        <asp:ListItem Text="Author 2" Value="Author 2" />

                                    </asp:DropDownList>
                                </div>

                                <label>Publish Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpublishdate" CssClass="form-control" placeholder="Publish Date" TextMode="Date" runat="server"></asp:TextBox>
                                </div>

                            </div>
                            <div class="col-md-4">
                                <label>Genre</label>
                                <div class="form-group">
                                    <asp:ListBox CssClass="form-control" SelectionMode="Multiple" Rows="5" ID="ListBoxGenre" runat="server">
                                        <asp:ListItem Text="Action" Value="Action" />
                                        <asp:ListItem Text="Adventure" Value="Adventure" />
                                        <asp:ListItem Text="Cprogramming" Value="Cprogramming" />
                                        <asp:ListItem Text="Computer" Value="Computer" />
                                        <asp:ListItem Text="Civil" Value="Civil" />
                                        <asp:ListItem Text="Mechanical" Value="Mechanical" />
                                        <asp:ListItem Text="Arts" Value="Arts" />
                                        <asp:ListItem Text="Electrical" Value="Electrical" />
                                        <asp:ListItem Text="Electronics" Value="Electronics" />
                                        <asp:ListItem Text="Architecture" Value="Architecture" />
                                        <asp:ListItem Text="Social" Value="Social" />
                                        <asp:ListItem Text="Mathematics" Value="Mathematics" />
                                        <asp:ListItem Text="Data Algorithms" Value="Data Algorithms" />
                                        <asp:ListItem Text="Data Struture" Value="Data Struture" />
                                        <asp:ListItem Text=".Net" Value=".Net" />
                                        <asp:ListItem Text="Dart" Value="Dart" />
                                        <asp:ListItem Text="ROR" Value="ROR" />
                                        <asp:ListItem Text="React" Value="React" />
                                        <asp:ListItem Text="Next" Value="Next" />
                                        <asp:ListItem Text="JavaSript" Value="JavaScript" />

                                    </asp:ListBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-4">
                                <label>Edition</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtedition" CssClass="form-control" placeholder="Edition" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Book Cost</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtbookcost" CssClass="form-control" placeholder="Book Cost(unit price)" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pages</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtpages" CssClass="form-control" placeholder="Pages" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>



                        <div class="row">
                            <div class="col-md-4">
                                <label>Actual Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtactualstock" CssClass="form-control" placeholder="Actual Stock" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Current Stock</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtcurrentstock" CssClass="form-control" placeholder="Current Stock" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Issued Book </label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtissuebook" CssClass="form-control" placeholder="Issue Book" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-12">
                                <label>Book Description</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtbookdescription" CssClass="form-control" placeholder="Book Description" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-4">
                                <asp:Button ID="btnbookadd" CssClass="btn btn-lg btn-block btn-success" Text="Add" runat="server" OnClick="btnbookadd_Click" ToolTip="Add Book" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnbookupdate" CssClass="btn btn-lg btn-block btn-warning" runat="server" Text="Update" OnClick="btnbookupdate_Click" ToolTip="Update Book" />
                            </div>
                            <div class="col-4">
                                <asp:Button ID="btnbookdelete" CssClass="btn btn-lg btn-block btn-danger" runat="server" Text="Delete" OnClick="btnbookdelete_Click" ToolTip="Delete Book" />
                            </div>

                        </div>
                    </div>

                </div>
                <a href="AdminHome.aspx"><< Back to Home</a>
            </div>

            <div class="col-md-7">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Inventory</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <hr />

                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:GridView ID="GridView1" runat="server"></asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
