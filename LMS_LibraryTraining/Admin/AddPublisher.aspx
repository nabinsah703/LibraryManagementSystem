<%@ Page Title="Publisher Details" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddPublisher.aspx.cs" Inherits="LMS_LibraryTraining.Admin.AddPublisher" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-4 border border-dark mt-3 mb-3">
                <div class="row">
                    <div class="col-12">
                        <h4>Add Publisher</h4>
                        <div class="form-group">
                            <asp:TextBox ID="txtpublisherID" CssClass="form-control" placeHolder="Pulisher ID" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpublisherName" CssClass="form-control" placeHolder="Publisher Name" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:Button ID="btnAdd" Text="Add" CssClass="btn btn-success" Width="120" Height="40" runat="server" OnClick="btnAdd_Click" />
                    <asp:Button ID="btnUpdate" Text="Update" runat="server" Width="120" Height="40" CssClass="btn btn-success" OnClick="btnUpdate_Click" Visible="false" />
                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn btn-danger" Width="120" Height="40" OnClick="btnCancel_Click" Visible="false"/>
                </div>
            </div>
            <div class="col-8 border border-success mt-3 mb-3">
                <div class="table table-responsive">
                    <h4>Show all Publisher</h4>
                    <asp:Repeater ID="rptRepeater" runat="server" OnItemCommand="rptRepeater_ItemCommand">

                        <HeaderTemplate>
                            <table class="table table-bordered table-hover">
                                <thead class="alert-info">
                                    <tr>
                                        <th><span>Publisher ID</span></th>
                                        <th><span>Publisher Name</span></th>
                                        <th>&nbsp;</th>

                                    </tr>

                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td><%#Eval("publisher_id") %></td>
                                <td><%#Eval("publisher_name") %></td>
                                <td style="width: 20%">
                                    <asp:LinkButton ID="lnkEdit" class="table-link text-primary" CommandArgument='<%#Eval("publisher_id")%>' CommandName="edit" ToolTip="Record Edit" runat="server">
                 <span class="fa-stack">
                     <i class="fa fa-square fa-stack-2x"></i>
                     <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>

                 </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkdelete" class="table-link text-danger" CommandArgument='<%#Eval("publisher_id")%>' CommandName="delete" ToolTip="Record Delete" Text="Delete" runat="server" OnClientClick="return confirm('Do you want to delete record')">
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
    </div>
</asp:Content>
