<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminAccount.aspx.cs" Inherits="NekoCafe.BackAdmin.adminAccount" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>アカウント管理</h3>
        <asp:Button runat="server" ID="btnMember" Text="会員" OnClick="btnMember_Click" />
        <asp:Button runat="server" ID="btnStaff" Text="スタッフ" OnClick="btnStaff_Click" />
        <asp:Button ID="btnAll" runat="server" Text="全員" OnClick="btnAll_Click" />
        &emsp; &emsp;
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="検索" OnClick="btnSearch_Click" />

        <asp:PlaceHolder ID="plcAccUpdate" runat="server">
            <div>
                <h4>アカウント変更</h4>
                <div>
                    <p>ID：<asp:TextBox ID="txtID" runat="server" TextMode="Number" Enabled="false"></asp:TextBox></p>
                    <p>アカウント：<asp:TextBox ID="txtAcc" runat="server"></asp:TextBox></p>
                    <p>パスワード：<asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></p>
                    <p>作成日：<asp:TextBox ID="txtDate" runat="server" Enabled="false"></asp:TextBox></p>
                </div>
                <div>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnUpdate_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <p></p>
        <asp:PlaceHolder runat="server" ID="plcAcc">
            <table border="1">
                <tr align="center">
                    <th>ID</th>
                    <th>アカウント</th>
                    <th>作成日</th>
                    <th></th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptAccount">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="100px">
                                <%#DataBinder.Eval(Container.DataItem,"AccountID") %>
                            </td>
                            <td width="180px">
                                <%#DataBinder.Eval(Container.DataItem,"Account1") %>
                            </td>
                            <td width="250px">
                                <%#DataBinder.Eval(Container.DataItem,"CreateDate") %>
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnAccUpdate" CommandName='<%# Eval("AccountID") %>' runat="server" Text="変更" OnCommand="btnAccUpdate_Command" />
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnAccDelete" CommandName='<%# Eval("AccountID") %>' runat="server" Text="削除" OnCommand="btnAccDelete_Command" OnClientClick="return confirm('削除してもよろしいですか？')" />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

                <asp:Repeater runat="server" ID="rptMember">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="100px">
                                <%#DataBinder.Eval(Container.DataItem,"AccountID") %>
                            </td>
                            <td width="180px">
                                <%#DataBinder.Eval(Container.DataItem,"Account") %>
                            </td>
                            <td width="250px">
                                <%#DataBinder.Eval(Container.DataItem,"CreateDate") %>
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnMemUpdate" CommandName='<%# Eval("AccountID") %>' runat="server" Text="変更" OnCommand="btnMemUpdate_Command" />
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnMemDelete" CommandName='<%# Eval("AccountID") %>' runat="server" Text="削除" OnCommand="btnMemDelete_Command" OnClientClick="return confirm('削除してもよろしいですか？')" />
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>

            </table>
        </asp:PlaceHolder>
    </div>
</asp:Content>
