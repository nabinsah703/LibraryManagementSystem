<%@ Page Title="Author Details" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddAuthor.aspx.cs" Inherits="LMS_LibraryTraining.Admin.AddAuthor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container border mt-3 border-success">
        <div class="row ">
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
                    <asp:Button ID="btnUpdate" Text="Update" CssClass="btn btn-success" runat="server" Height="50px" Width="200px" Visible="false" OnClick="btnUpdate_Click" />
                    <asp:Button ID="btnCancel" Text="Cancel" CssClass="btn btn-danger" runat="server" Height="50px" Width="200px" Visible="false" OnClick="btnCancel_Click" />


                </div>
            </div>
        </div>
    </div>

    <div class="container">
        <div class="row">
            <div class="table-responsive">
                <h4>Author List</h4>
                <hr />
                <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">

                    <HeaderTemplate>
                        <table class="table table-bordered table-hover">
                            <thead class="alert-info">
                                <tr>
                                    <th><span>Author ID</span></th>
                                    <th><span>Author Name</span></th>
                                    <th>&nbsp;</th>

                                </tr>

                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("author_id") %></td>
                            <td><%#Eval("author_name") %></td>
                            <td style="width: 20%">
                                <asp:LinkButton ID="lnkEdit" class="table-link text-primary" CommandArgument='<%#Eval("author_id")%>' CommandName="edit" ToolTip="Record Edit" runat="server">
                                <span class="fa-stack">
                                    <i class="fa fa-square fa-stack-2x"></i>
                                    <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>

                                </span>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkdelete" class="table-link text-danger" CommandArgument='<%#Eval("author_id")%>' CommandName="delete" ToolTip="Record Delete" Text="Delete" runat="server" OnClientClick="return confirm('Do you want to delete record')">
                                 <span class="fa-stack">
                                     <i class="fa fa-square fa-stack-2x"></i>
                                     <i class="fa fa-trash fa-stack-1x fa-inverse"></i>

                                 </span>
                                </asp:LinkButton>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>

</asp:Content>
