﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="LMS_LibraryTraining.Admin.Report" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../datatable/js/jquery.dataTables.min.js"></script>

<script type="text/javascript">
    $(document).ready(function () {
        $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
    });

</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="container">
     <div class="row">
         <div class="col-md-12">
             <div class="card">
                 <div class="card-body">
                     <div class="row">
                         <div class="col">
                             <center>
                                 <img width="100" src="../LogoIcon/books_library_1767.ico" />
                             </center>
                         </div>
                     </div>
                     <div class="row">
                         <div class="col">
                             <center>
                                 <h4>Your Issued Books</h4>
                                 <asp:Label class="badge badge-pill badge-info" ID="Label2" runat="server" Text="your books info"></asp:Label>
                             </center>
                         </div>
                     </div>
                     <div class="row">
                         <div class="col">
                             <hr>
                         </div>
                     </div>
                     <div class="row">
                         <div class="col">
                             <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" OnRowDataBound="GridView1_RowDataBound"></asp:GridView>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
     </div>
 </div>
</asp:Content>
