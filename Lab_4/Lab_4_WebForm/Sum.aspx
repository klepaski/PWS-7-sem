<%@ Page Title="Sum" Language="C#" AutoEventWireup="true" CodeBehind="Sum.aspx.cs" Inherits="Lab_4_WebForm.Sum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox runat="server" ID="A1_s" placeholder="string"/>
            <asp:TextBox runat="server" ID="A1_k" placeholder="int"/>
            <asp:TextBox runat="server" ID="A1_f" placeholder="float"/><br/>

            <asp:TextBox runat="server" ID="A2_s" placeholder="string"/>
            <asp:TextBox runat="server" ID="A2_k" placeholder="int"/>
            <asp:TextBox runat="server" ID="A2_f" placeholder="float"/>

            <asp:Button runat="server" ID="sum" OnClick="Sum_Click" Text="Sum" />
        </div>
        <div>
            <asp:TextBox runat="server" ID="result_s" />
            <asp:TextBox runat="server" ID="result_k" />
            <asp:TextBox runat="server" ID="result_f" />
        </div>
    </form>
</body>
</html>