<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminSetting.aspx.cs" Inherits="NekoCafe.BackAdmin.adminSetting" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .pwdMsg {
            font-size: 14px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>パスワード変更</h3>
        現在のパスワード <asp:TextBox runat="server" ID="txtOldPwd" TextMode="Password"></asp:TextBox><br />
        <br />
        新しいパスワード <asp:TextBox runat="server" ID="txtNewPwd" TextMode="Password"></asp:TextBox><br />
        <br />
        新しいパスワード（確認）<asp:TextBox runat="server" ID="txtNewPwdCheck" TextMode="Password"></asp:TextBox><br />
        <br />
        <span class="pwdMsg">パスワードを変更すると、自動的にログアウトされます。新しいパスワードで再度ログインしてください。</span><br />
        <br />
        <asp:Button runat="server" ID="btnChangePwd" Text="変更する" OnClick="btnChangePwd_Click" />
        <asp:Button runat="server" ID="btnCancel" Text="戻る" OnClick="btnCancel_Click" />
    </div>
</asp:Content>
