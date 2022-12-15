<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminCalendar.aspx.cs" Inherits="NekoCafe.BackAdmin.adminCalendar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>カレンダー管理</h3>
        <asp:Button runat="server" Text="カレンダー追加" />
        <asp:Button runat="server" Text="変更" />
        <asp:Button runat="server" Text="削除" />
    </div>
</asp:Content>
