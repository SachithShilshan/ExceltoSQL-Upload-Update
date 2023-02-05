<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EtoSQL3.WebForm1" %>


<style>
    .button {
        background-color: blue;
        color: white;
        padding: 6px 10px;
        border-radius: 4px;
        text-align: center;
        text-decoration: none;
        display: inline-block;
        font-size: 16px;
    }
</style>

<style>
    .file-upload {
        display: inline-block;
        padding: 5px 10px;
        background-color: lightblue;
        color: white;
        border-radius: 4px;
        text-align: center;
        text-decoration: none;
        font-size: 16px;
        cursor: pointer;
        border: none;
    }

        .file-upload input[type="file"] {
            display: none;
        }
</style>
<style type="text/css">
  .grid-view {
    font-family: Arial, sans-serif;
    font-size: 12px;
    width: 100%;
    border-collapse: collapse;
  }

  .grid-view th {
    background-color: #ddd;
    padding: 8px;
    border: 1px solid #999;
  }

  .grid-view td {
    padding: 8px;
    border: 1px solid #999;
  }
</style>
<style>
    h1 {
  font-size: 36px;
  font-weight: bold;
  color: #333;
  text-align: center;
  padding: 20px;
    background-color: #c2d5ea54;
}

h2 {
  font-size: 28px;
  font-weight: bold;
  color: #555;
  text-align: left;
  padding: 15px;
}

h3 {
  font-size: 22px;
  font-weight: bold;
  color: #777;
  text-align: left;
  padding: 10px;
}

</style>

<style>
    header {
  background-color: #0a1751df;
  color: #fff;
  padding: 20px;
}

header nav ul {
  list-style: none;
  margin: 0;
  padding: 0;
  display: flex;
  justify-content: space-between;
}

header nav li {
  display: inline-block;
  margin-right: 20px;
}

header nav a {
  color: #fff;
  text-decoration: none;
}

</style>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <header>
  <nav>
    <ul>
      <li><a href="#">Home</a></li>
      <li><a href="#">Plan Upload</a></li>
      <li><a href="#">Contact</a></li>
    </ul>
  </nav>
</header>

   
    <form id="form1" runat="server" >
        <h1>UPLOAD</h1>
                <div>
            <asp:Label runat="server" ID="Label3"></asp:Label>
            
        </div>
        <div>
            <asp:Label runat="server" ID="ctl149">
                <asp:FileUpload runat="server" ID="FileUpload" class="file-upload"></asp:FileUpload>
                <asp:Button CssClass="button" runat="server" Text="Upload" OnClick="Upload_Click"></asp:Button>
             
            </asp:Label>
        </div>
        
        <h1>UPDATE</h1>
        <div>
            <asp:Label runat="server" ID="Label5"></asp:Label>
            
        </div>

        <div>
            <asp:Label runat="server">
                <asp:FileUpload runat="server" ID="FileUpload2" class="file-upload"></asp:FileUpload>
                <asp:Button CssClass="button" runat="server" Text="Upload" OnClick="Delete_Upload_Click"></asp:Button>
                <h3>Table</h3>
                <asp:GridView runat="server" ID="GridView" AllowPaging="True" PageSize="5" CssClass="grid-view"></asp:GridView>
            </asp:Label>
        </div>

                
        <h1>DATA TABLE</h1>
        <asp:Button CssClass="button" runat="server" Text="Retrieve Data From MS Access" ></asp:Button>
         <asp:Button CssClass="button" runat="server" Text="Export" OnClick="ViewDataClick"></asp:Button>

        <asp:GridView runat="server" ID="GridView1" DataSourceID="SqlDataSource1" AutoGenerateColumns="false" CellPadding="4" ForeColor="#333333" Width="600px"  CssClass="grid-view">
            <Columns>
                <asp:BoundField DataField="module" HeaderText="module" SortExpression="module"></asp:BoundField>
                <asp:BoundField DataField="material" HeaderText="material" SortExpression="material"></asp:BoundField>
                <asp:BoundField DataField="fG_Referance" HeaderText="fG_Referance" SortExpression="fG_Referance"></asp:BoundField>
                <asp:BoundField DataField="customer_Style" HeaderText="customer_Style" SortExpression="customer_Style"></asp:BoundField>
                <asp:BoundField DataField="Color_Description" HeaderText="Color_Description" SortExpression="Color_Description"></asp:BoundField>
                <asp:BoundField DataField="subcon_Type" HeaderText="subcon_Type" SortExpression="subcon_Type"></asp:BoundField>
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description"></asp:BoundField>
                <asp:BoundField DataField="fabric_Design" HeaderText="fabric_Design" SortExpression="fabric_Design"></asp:BoundField>
                <asp:BoundField DataField="order_Reason" HeaderText="order_Reason" SortExpression="order_Reason"></asp:BoundField>
                <asp:BoundField DataField="special_Services" HeaderText="special_Services" SortExpression="special_Services"></asp:BoundField>
                <asp:BoundField DataField="cpo" HeaderText="cpo" SortExpression="cpo"></asp:BoundField>
                <asp:BoundField DataField="region_Country" HeaderText="region_Country" SortExpression="region_Country"></asp:BoundField>
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name"></asp:BoundField>
                <asp:BoundField DataField="season" HeaderText="season" SortExpression="season"></asp:BoundField>
                <asp:BoundField DataField="external_Material_Group" HeaderText="external_Material_Group" SortExpression="external_Material_Group"></asp:BoundField>
                <asp:BoundField DataField="customer" HeaderText="customer" SortExpression="customer"></asp:BoundField>
                <asp:BoundField DataField="customer_Dept" HeaderText="customer_Dept" SortExpression="customer_Dept"></asp:BoundField>
                <asp:BoundField DataField="sales_Order" HeaderText="sales_Order" SortExpression="sales_Order"></asp:BoundField>
                <asp:BoundField DataField="item" HeaderText="item" SortExpression="item"></asp:BoundField>
                <asp:BoundField DataField="prod_order" HeaderText="prod_order" SortExpression="prod_order"></asp:BoundField>
                <asp:BoundField DataField="so_qty" HeaderText="so_qty" SortExpression="so_qty"></asp:BoundField>
                <asp:BoundField DataField="order_qty" HeaderText="order_qty" SortExpression="order_qty"></asp:BoundField>
                <asp:BoundField DataField="smv" HeaderText="smv" SortExpression="smv"></asp:BoundField>
                <asp:BoundField DataField="effi" HeaderText="effi" SortExpression="effi"></asp:BoundField>
                <asp:BoundField DataField="emp" HeaderText="emp" SortExpression="emp"></asp:BoundField>
                <asp:BoundField DataField="pcs_day" HeaderText="pcs_day" SortExpression="pcs_day"></asp:BoundField>
                <asp:BoundField DataField="days" HeaderText="days" SortExpression="days"></asp:BoundField>
                <asp:BoundField DataField="cut_date" HeaderText="cut_date" SortExpression="cut_date"></asp:BoundField>
                <asp:BoundField DataField="startdate" HeaderText="startdate" SortExpression="startdate"></asp:BoundField>
                <asp:BoundField DataField="finishdate" HeaderText="finishdate" SortExpression="finishdate"></asp:BoundField>
                <asp:BoundField DataField="expected_prod_end_date" HeaderText="expected_prod_end_date" SortExpression="expected_prod_end_date"></asp:BoundField>
                <asp:BoundField DataField="deliv_date" HeaderText="deliv_date" SortExpression="deliv_date"></asp:BoundField>
                <asp:BoundField DataField="del_status" HeaderText="del_status" SortExpression="del_status"></asp:BoundField>
                <asp:BoundField DataField="cut_qty" HeaderText="cut_qty" SortExpression="cut_qty"></asp:BoundField>
                <asp:BoundField DataField="in_qty" HeaderText="in_qty" SortExpression="in_qty"></asp:BoundField>
                <asp:BoundField DataField="out_qty" HeaderText="out_qty" SortExpression="out_qty"></asp:BoundField>
                <asp:BoundField DataField="fab_In_H_date" HeaderText="fab_In_H_date" SortExpression="fab_In_H_date"></asp:BoundField>
                <asp:BoundField DataField="acc_In_H_date" HeaderText="acc_In_H_date" SortExpression="acc_In_H_date"></asp:BoundField>
                <asp:BoundField DataField="qco" HeaderText="qco" SortExpression="qco"></asp:BoundField>
                <asp:BoundField DataField="product_category_Name" HeaderText="product_category_Name" SortExpression="product_category_Name"></asp:BoundField>
                <asp:BoundField DataField="gender" HeaderText="gender" SortExpression="gender"></asp:BoundField>
                <asp:BoundField DataField="relative_Similarity" HeaderText="relative_Similarity" SortExpression="relative_Similarity"></asp:BoundField>
                <asp:BoundField DataField="remarks" HeaderText="remarks" SortExpression="remarks"></asp:BoundField>
                <asp:BoundField DataField="l_Curve" HeaderText="l_Curve" SortExpression="l_Curve"></asp:BoundField>
                <asp:BoundField DataField="planning_Fab" HeaderText="planning_Fab" SortExpression="planning_Fab"></asp:BoundField>
                <asp:BoundField DataField="planning_acc" HeaderText="planning_acc" SortExpression="planning_acc"></asp:BoundField>
                <asp:BoundField DataField="approval_DD" HeaderText="approval_DD" SortExpression="approval_DD"></asp:BoundField>
                <asp:BoundField DataField="section" HeaderText="section" SortExpression="section"></asp:BoundField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server"  ConnectionString="<%$ ConnectionStrings:test2ConnectionString2 %>" SelectCommand="SELECT * FROM [plan2]"></asp:SqlDataSource>
       
         
    </form>
</body>

</html>
