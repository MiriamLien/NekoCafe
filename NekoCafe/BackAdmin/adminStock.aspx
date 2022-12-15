<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminStock.aspx.cs" Inherits="NekoCafe.BackAdmin.adminStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>在庫管理</h3>
        <p></p>
        <table border="1">
            <tr align="center">
                <th>ID</th>
                <th>商品</th>
                <th>数量</th>
                <th></th>
                <th></th>
                <th></th>
            </tr>
            <asp:Repeater runat="server" ID="rptAccount">
                <ItemTemplate>
            <tr align="center">
                <td width="60px"><%# Eval("ID") %></td>
                <td width="150px"><%# Eval("Name") %> </td>
                <td width="60px"><%# Eval("Amount") %> </td>
                <td width="250px"><%# Eval("") %> </td>
                <td width="80px"><asp:Button runat="server" Text="変更" /></td>
                <td width="80px"><asp:Button runat="server" Text="削除" /></td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>
