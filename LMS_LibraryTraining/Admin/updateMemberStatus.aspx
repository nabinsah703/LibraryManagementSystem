<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="updateMemberStatus.aspx.cs" Inherits="LMS_LibraryTraining.Admin.updateMemberStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-5">
                <div class="row mt-3">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:TextBox ID="txtMemberID" placeHolder="Member ID" CssClass="form-control" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Enter valid Member ID" ValidationGroup="btnSearch" ControlToValidate="txtMemberID" Display="Dynamic" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>

                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <div class="form-group">
                            <asp:Button ID="btnsearch" ValidationGroup="btnSearch" CssClass="btn btn-secondary" runat="server" Text="Search" OnClick="btnsearch_Click" />
                            <asp:Button ID="btnactive" ValidationGroup="btnSearch" CssClass="btn btn-success" runat="server" Text="Active" OnClick="btnactive_Click" />
                            <asp:Button ID="btnpending" ValidationGroup="btnSearch" CssClass="btn btn-info" runat="server" Text="Pending" OnClick="btnpending_Click" />
                            <asp:Button ID="btndeactivate" ValidationGroup="btnSearch" CssClass="btn btn-danger" runat="server" Text="Deactivate" OnClick="btndeactivate_Click" />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">

                        <div class="form-group">
                            <asp:TextBox ID="txtFullname" placeHolder="Full Name" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="form-group">
                    <asp:TextBox ID="txtContact" placeHolder="Contact No" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" placeHolder="Email ID" TextMode="Email" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtDob" placeHolder="Date of Birth" TextMode="Date" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtpincode" placeHolder="Pin code" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlstate" CssClass="form-control" runat="server"></asp:DropDownList>

                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtCity" placeHolder="City" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtfulladdress" placeHolder="Full Address" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>
        </div>
        <div class="col-sm-7">
            <div class="row">
                <div class="table table-responsive">
                    <h4>Show all member list</h4>
                </div>
            </div>
        </div>

    </div>
</asp:Content>
