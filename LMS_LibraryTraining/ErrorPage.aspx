<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="LMS_LibraryTraining.ErrorPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ErrorPage</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img src="LogoIcon/Pure-CSS-404-Error-Page.png" alt="404 Error" />
            <div>
                <asp:Label ID="ErrorDesc" runat="server" Text=" " ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
