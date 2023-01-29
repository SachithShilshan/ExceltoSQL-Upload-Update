<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EtoSQL3.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>



    <form id="form1" runat="server">
        <h2>UPLOAD</h2>
        <div>
            <asp:Label ID="Label1" runat="server">
                <asp:FileUpload runat="server" ID="FileUpload"></asp:FileUpload>   
                <asp:Button runat="server" Text="Upload" OnClick="Upload_Click"></asp:Button>
                <asp:Label runat="server" ID="Label3"></asp:Label>
            </asp:Label>
        </div>

        <h2>DELETE_UPLOAD</h2>
        <div>
            <asp:Label runat="server" >
                <asp:FileUpload runat="server" ID="FileUpload2"></asp:FileUpload>
                <asp:Button runat="server" Text="Delete_Upload" OnClick="Delete_Upload_Click"></asp:Button>
                <asp:Label runat="server" ID="Label5"></asp:Label>
            </asp:Label>
        </div>

    </form>
</body>
</html>
