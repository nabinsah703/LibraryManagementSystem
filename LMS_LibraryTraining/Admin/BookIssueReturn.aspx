<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="BookIssueReturn.aspx.cs" Inherits="LMS_LibraryTraining.Admin.BookIssueReturn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Book Issuing</h4>
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <center>
                                    <img alt="book img " src="../LogoIcon/books_library_1767.ico" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtmemberID" CssClass="form-control" placeHolder="Member ID" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ValidationGroup="s1" runat="server" ErrorMessage="*Enter Valid Member ID" ForeColor="Red" ControlToValidate="txtmemberID"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtBookID" CssClass="form-control" placeHolder="Book ID" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="s1" runat="server" ErrorMessage="*Enter Valid Book ID" ForeColor="Red" ControlToValidate="txtBookID"></asp:RequiredFieldValidator>
                                    <asp:Button ID="btnsearch" ValidationGroup="s1" CssClass="btn btn-dark" OnClick="btnsearch_Click" runat="server" Text="Search" />
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Member Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtmembername" CssClass="form-control" placeHolder="Member Name" ReadOnly="true" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Book Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtbookname" CssClass="form-control" ReadOnly="true" placeHolder="Book Name" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtissuedate" CssClass="form-control" placeHolder="Issue Date" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Due Date</label>
                                <div class="form-group">
                                    <asp:TextBox ID="txtduedate" CssClass="form-control" placeHolder="Due Date" TextMode="Date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <label>Issue Date</label>
                                <div class="form-group">
                                    <asp:Button ID="btnissuebook" CssClass="btn btn-lg btn-block btn-primary" runat="server" Text="Issue Book" OnClick="btnissuebook_Click" />
                                </div>
                            </div>
                            <div class="col-md-6">
                                <label>Due Date</label>
                                <div class="form-group">
                                    <asp:Button ID="btnreturnbook" CssClass="btn btn-lg btn-block btn-success" runat="server" Text="Return Book" OnClick="btnreturnbook_Click"/>
                                </div>
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
                                    <h4>Issued Book List</h4>
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
                                <asp:GridView AutoGenerateColumns="false" EmptyDataText="No Record Found..." CssClass="table table-striped table-bordered" ID="GridView1" runat="server">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="Member ID" SortExpression="member_id" />
                                        <asp:BoundField DataField="member_name" HeaderText="Member Name" SortExpression="member_name" />
                                        <asp:BoundField DataField="book_id" HeaderText="Book ID" SortExpression="book_id" />
                                        <asp:BoundField DataField="book_name" HeaderText="Book Name" SortExpression="book_name" />
                                        <asp:BoundField DataField="issue_date" HeaderText="Issue Date" SortExpression="issue_date" />
                                        <asp:BoundField DataField="due_date" HeaderText="Due Date" SortExpression="due_date" />

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
