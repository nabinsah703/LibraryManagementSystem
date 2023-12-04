<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="LMS_LibraryTraining.Admin.AddAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-lg-10 px-lg-4">
                <h4 class="text-base-text-primary text-uppercase mb-4 text-center">Add Author</h4>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtID" CssClass="form-control border-0 shadow form-control-lg text-base" placeHolder="Autor ID" required="true" runat="server"></asp:TextBox>
                </div>
            </div>


            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:TextBox ID="txtAuthorName" CssClass="form-control border-0 shadow form-control-lg text-base" placeHolder="Author Name" required="true" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="col-lg-6 px-lg-4">
                <div class="form-group mb-4">
                    <asp:Button ID="btnSubmit" Text="Submit" CssClass="btn btn-success" runat="server" Height="50px" Width="200px" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>

</asp:Content>
