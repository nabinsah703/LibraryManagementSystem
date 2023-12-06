<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="updateMemberStatus.aspx.cs" Inherits="LMS_LibraryTraining.Admin.updateMemberStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div class="row">
            <div class="col-sm-4">
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
            <div class="col-sm-8">
                <h4>Show all member list</h4>
                <div class="table table-responsive">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" AllowPaging="true" OnPageIndexChanging="GridView1_PageIndexChanging" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating" OnRowEditing="GridView1_RowEditing" PageSize="5">

                        <HeaderStyle BackColor="#0066FF" Font-Bold="true" ForeColor="White" />
                        <FooterStyle BackColor="#3366CC" />
                        <Columns>
                            <asp:BoundField DataField="member_id" HeaderText="Member ID" />
                            <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                            <asp:BoundField DataField="dob" HeaderText="DOB" />
                            <asp:BoundField DataField="contact_no" HeaderText="Contact No" />
                            <asp:BoundField DataField="email" HeaderText="Email ID" />
                            <asp:BoundField DataField="state" HeaderText="State" />
                            <asp:BoundField DataField="pincode" HeaderText="Pin Code" />
                            <asp:BoundField DataField="full_address" HeaderText="Full Address" />
                            <asp:BoundField DataField="city" HeaderText="City" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkEdit" class="table-link text-primary" ToolTip="Record Edit" CommandName="Edit" runat="server">
                                         <span class="fa-stack">
                                             <i class="fa fa-square fa-stack-2x"></i>
                                             <i class="fa fa-pencil fa-stack-1x fa-inverse"></i>
                                         </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkdelete" class="table-link text-danger" ToolTip="Record Delete" CommandName="Delete" Text="Delete" runat="server" OnClientClick="return confirm('Do you want to delete record')">
                                          <span class="fa-stack">
                                              <i class="fa fa-square fa-stack-2x"></i>
                                              <i class="fa fa-trash fa-stack-1x fa-inverse"></i>
                                          </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkUpdate" class="table-link text-success" Text="Update" CommandName="Update" ToolTip="Update Record" runat="server">
                                         <span class="fa-stack">
                                             <i class="fa fa-square fa-stack-2x"></i>
                                             <i class="fa fa-spinner fa-stack-1x fa-inverse"></i>
                                         </span>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkCancel" class="table-link text-danger" ToolTip="Cancel" Text="Cancel Record" CommandName="Cancel" runat="server">
                                      <span class="fa-stack">
                                          <i class="fa fa-square fa-stack-2x"></i>
                                          <i class="fa fa-times-circle fa-stack-1x fa-inverse"></i>
                                      </span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <EditItemTemplate></EditItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <PagerSettings Mode="NextPreviousFirstLast" PageButtonCount="4" FirstPageText="First" LastPageText="Last" />
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
