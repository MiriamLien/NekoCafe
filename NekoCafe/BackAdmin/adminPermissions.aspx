<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminPermissions.aspx.cs" Inherits="NekoCafe.BackAdmin.adminPermissions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>権限管理</h3>
        <asp:Button ID="btnAll" runat="server" Text="すべて" OnClick="btnAll_Click" />
        &emsp; &emsp;
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="検索" OnClick="btnSearch_Click" />
        
        <asp:PlaceHolder ID="plcUpdate" runat="server">
            <div>
                <h4>権限変更</h4>
                <div>
                    <p>ID：<asp:TextBox ID="txtID" runat="server" TextMode="Number" min="1" Enabled="false"></asp:TextBox></p>
                    <p>アカウント：<asp:TextBox ID="txtAccount" runat="server" Enabled="false"></asp:TextBox></p>
                    <p>LEVEL：
                    <asp:DropDownList ID="ddlLevel" runat="server">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="店長" Value="10"></asp:ListItem>
                        <asp:ListItem Text="店員" Value="4"></asp:ListItem>
                        <asp:ListItem Text="ダイニャーモンド会員" Value="3"></asp:ListItem>
                        <asp:ListItem Text="ゴールニャー会員" Value="2"></asp:ListItem>
                        <asp:ListItem Text="シルニャー会員" Value="1"></asp:ListItem>
                        <asp:ListItem Text="レギュラー会員" Value="0"></asp:ListItem>
                    </asp:DropDownList></p>
                </div>
                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancel_Click"/>
                </div>
            </div>
        </asp:PlaceHolder>
        
        <p></p>
        <table border="1">
            <tr align="center">
                <th>ID</th>
                <th>アカウント</th>
                <th>LEVEL</th>
                <th></th>
            </tr>
            <asp:Repeater runat="server" ID="rptPermissions">
                <ItemTemplate>
            <tr align="center">
                <td width="100px"><%# Eval("AccountID") %></td>
                <td width="180px"><%# Eval("Account") %> </td>
                <td width="100px"><%# Eval("Level") %> </td>
                <td width="80px"><asp:Button ID="btnUpdate" data-bs-toggle="modal" data-bs-target="#UpdateModal" CommandName='<%# Eval("AccountID") %>' runat="server" Text="変更" OnCommand="btnUpdate_Command" /></td>
            </tr>
            </ItemTemplate>
        </asp:Repeater>
        </table>
    </div>
</asp:Content>
