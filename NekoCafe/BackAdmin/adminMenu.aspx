<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminMenu.aspx.cs" Inherits="NekoCafe.BackAdmin.adminMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>メニュー管理</h3>
        <asp:Button runat="server" ID="btnAddMenu" Text="商品追加" OnClick="btnAddMenu_Click" />
        <asp:Button runat="server" ID="btnAll" Text="すべて" OnClick="btnAll_Click" />
        &emsp;&emsp;
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="検索" OnClick="btnSearch_Click" />

        <asp:PlaceHolder ID="plcAdd" runat="server">
            <div>
                <h4>商品追加</h4>
                <div>
                    <p>
                        商品カテゴリーID：
                    <asp:DropDownList ID="ddlItemClassID" runat="server">
                        <asp:ListItem Text="" Value=""></asp:ListItem>
                        <asp:ListItem Text="コーヒー" Value="1"></asp:ListItem>
                        <asp:ListItem Text="お茶" Value="2"></asp:ListItem>
                        <asp:ListItem Text="デザート" Value="3"></asp:ListItem>
                        <asp:ListItem Text="その他" Value="4"></asp:ListItem>
                    </asp:DropDownList>
                    </p>
                    <p>商品：<asp:TextBox ID="addItemName" runat="server"></asp:TextBox></p>
                    <p>金額：<asp:TextBox ID="addPrice" runat="server" TextMode="Number" min="1"></asp:TextBox></p>
                </div>
                <div>
                    <asp:Button ID="btnAddSave" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnAddCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnAddCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>

        <asp:PlaceHolder ID="plcUpdate" runat="server">
            <div>
                <h4>メニュー変更</h4>
                <div>
                    <p>コード：<asp:TextBox ID="txtCode" runat="server" TextMode="Number" min="1" Enabled="false"></asp:TextBox></p>
                    <p>商品：<asp:TextBox ID="txtItemName" runat="server"></asp:TextBox></p>
                    <p>金額：<asp:TextBox ID="txtPrice" runat="server" TextMode="Number" min="1"></asp:TextBox></p>
                </div>
                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>

        <p></p>
        <table border="1">
            <tr align="center">
                <th>コード</th>
                <th>商品</th>
                <th>金額</th>
                <th></th>
                <th></th>
            </tr>

            <asp:Repeater runat="server" ID="rptMenu">
                <ItemTemplate>
                    <tr align="center">
                        <td width="100px"><%# Eval("ItemID") %></td>
                        <td width="260px"><%# Eval("Name") %> </td>
                        <td width="150px"><%# Eval("Price") %> </td>
                        <td width="80px">
                            <asp:Button ID="btnUpdate" data-bs-toggle="modal" data-bs-target="#UpdateModal" CommandName='<%# Eval("ItemID") %>' runat="server" Text="変更" OnCommand="btnUpdate_Command" /></td>
                        <td width="80px">
                            <asp:Button ID="btnDelete" CommandName='<%# Eval("ItemID") %>' runat="server" Text="削除" OnCommand="btnDelete_Command" OnClientClick="return confirm('削除してもよろしいですか？')" /></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>

    <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
        <script>
            alert("<%=this.alertMessage%>")
        </script>
    </asp:PlaceHolder>
</asp:Content>
