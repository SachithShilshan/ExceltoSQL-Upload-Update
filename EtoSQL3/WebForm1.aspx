﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EtoSQL3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="UPLOAD">
                <asp:FileUpload runat="server" ID="FileUpload"></asp:FileUpload>   
                <asp:Button runat="server" Text="Upload" OnClick="Unnamed_Click"></asp:Button>
                <asp:Label runat="server" ID="Label3"></asp:Label>
            </asp:Label>
        </div>


        <div>
            <asp:Label runat="server" Text="UPDATE">
                <asp:FileUpload runat="server" ID="FileUpload1"></asp:FileUpload>
                <asp:Button runat="server" Text="Update" OnClick="Unnamed3_Click"></asp:Button>
                <asp:Label runat="server" ID="Label4"></asp:Label>
            </asp:Label>
        </div>
    </form>
</body>
</html>