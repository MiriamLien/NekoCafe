<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminCats.aspx.cs" Inherits="NekoCafe.BackAdmin.adminCats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>ネコ情報管理</h3>
        <asp:Button runat="server" ID="btnNekoChange" Text="ネコ管理" OnClick="btnNekoChange_Click" CssClass="nes-pointer" />
        <asp:Button runat="server" ID="btnStatusChange" Text="ネコステータス管理" OnClick="btnStatusChange_Click" CssClass="nes-pointer" />
        <asp:Button runat="server" ID="btnOthersChange" Text="その他の管理" OnClick="btnOthersChange_Click" CssClass="nes-pointer" /><br />
        <div style="height: 8px;"></div>
        <asp:PlaceHolder ID="plcCat" runat="server">
            <asp:Button runat="server" ID="btnAddNeko" Text="ネコ追加" OnClick="btnAddNeko_Click" CssClass="nes-pointer" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcCatState" runat="server">
            <asp:Button runat="server" ID="btnAddStatus" Text="ネコステータス追加" OnClick="btnAddStatus_Click" CssClass="nes-pointer" />&emsp;&emsp;
            <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>&nbsp;
            <asp:Button runat="server" ID="btnSearch" Text="検索" OnClick="btnSearch_Click" CssClass="nes-pointer" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcOthers" runat="server">
            <asp:Button runat="server" ID="btnAddOthers" Text="ネコの品種追加" OnClick="btnAddOthers_Click" CssClass="nes-pointer" />
        </asp:PlaceHolder>
        <p></p>
        <asp:PlaceHolder ID="plcUpdateCat" runat="server">
            <h4>ネコ変更</h4>
            <div>
                <p>ネコID：<asp:TextBox ID="txtID_uc" runat="server" Enabled="false"></asp:TextBox></p>
                <p>名前：<asp:TextBox ID="txtName_uc" runat="server"></asp:TextBox></p>
                <p>品種ID：<asp:TextBox ID="txtBreedID_uc" runat="server" Enabled="false"></asp:TextBox></p>
                <p>性別：<asp:TextBox ID="txtSex_uc" runat="server" Enabled="false"></asp:TextBox></p>
                <p>誕生日：<asp:TextBox ID="txtBirth_uc" runat="server" Enabled="false"></asp:TextBox></p>
                <p>コンテンツ：<asp:TextBox ID="txtContent_uc" runat="server" TextMode="MultiLine" Rows="3" Width="300px" ></asp:TextBox></p>
            </div>
            <div>
                <asp:Button ID="btnUpdateCat" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnUpdateCat_Click" />
                &nbsp;
                <asp:Button ID="btnCancelUpdateCat" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancelUpdateCat_Click" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcUpdateCatState" runat="server">
            <h4>ネコステータス変更</h4>
            <div>
                <p><asp:TextBox ID="txtCatStateID_us" runat="server" Text="ネコステータスID：" Enabled="false" Visible="false"></asp:TextBox></p>
                <p><asp:TextBox ID="txtCatID_us" runat="server" Enabled="false" Text="ネコID：" Visible="false"></asp:TextBox></p>
                <p>名前：<asp:TextBox ID="txtName_us" runat="server" Enabled="false"></asp:TextBox></p>
                <p>日時：<asp:TextBox ID="txtTime_us" runat="server" TextMode="DateTime"></asp:TextBox></p>
                <p>
                    勤務状況：：
                    <asp:RadioButton ID="rbtWork_us" runat="server" GroupName="Work" Text="仕事中" />&nbsp;
                    <asp:RadioButton ID="rbtRest_us" runat="server" GroupName="Work" Text="休憩" />
                </p>

            </div>
            <div>
                <asp:Button ID="btnUpdateState" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnUpdateState_Click" />&nbsp;
                <asp:Button ID="btnCancelUpdateState" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancelUpdateState_Click" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcAddCat" runat="server">
            <h4>ネコ追加</h4>
            <div>
                <p>名前：<asp:TextBox ID="txtName_ac" runat="server"></asp:TextBox></p>
                <p>品種ID：<asp:DropDownList ID="ddlBreedID" runat="server"></asp:DropDownList></p>
                <p>
                    性別：
                    <asp:RadioButton ID="rbtMale_ac" runat="server" GroupName="sex" Checked="true" />男の子&nbsp;
                    <asp:RadioButton ID="rbtFemale_ac" runat="server" GroupName="sex" />女の子
                </p>
                <p>誕生日：<asp:TextBox ID="txtBirth_ac" runat="server" TextMode="Date"></asp:TextBox></p>
                <p>コンテンツ：<asp:TextBox ID="txtContent_ac" runat="server" TextMode="MultiLine" Rows="3" Width="300px"></asp:TextBox></p>
            </div>
            <div>
                <asp:Button ID="btnAddCat" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddCat_Click" />
                &nbsp;
                <asp:Button ID="btnCancalAddCat" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancalAddCat_Click" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcAddState" runat="server">
            <h4>ネコステータス追加</h4>
            <div>
                <p>名前：<asp:DropDownList ID="ddlCatID_as" runat="server"></asp:DropDownList></p>
                <p>
                    日時：<asp:TextBox ID="txtDate_as" runat="server" TextMode="Date"></asp:TextBox>
                    &nbsp;
                    <asp:TextBox ID="txtTime_as" runat="server" TextMode="Time"></asp:TextBox>
                </p>
                <p>
                    勤務状況：
                    <asp:RadioButton ID="rbtWork_as" runat="server" GroupName="Work" Checked="true" Text="仕事中" />&nbsp;
                    <asp:RadioButton ID="rbtRest_as" runat="server" GroupName="Work" Text="休憩" />
                </p>

            </div>
            <div>
                <asp:Button ID="btnAddState" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddState_Click" />
                &nbsp;
                <asp:Button ID="btnCancelAddState" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancelAddState_Click" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcAddBreed" runat="server">
            <h4>ネコの品種追加</h4>
            <div>
                <p>品種：<asp:TextBox ID="txtBreed_ab" runat="server"></asp:TextBox></p>
            </div>
            <div>
                <asp:Button ID="btnAddBreed" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddBreed_Click" />
                &nbsp;
                <asp:Button ID="btnCancelAddBreed" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancelAddBreed_Click" />
            </div>
        </asp:PlaceHolder>
        <p></p>
        <asp:PlaceHolder runat="server" ID="plcCats1">
            <table border="1">
                <tr align="center">
                    <th>ID</th>
                    <th>名前</th>
                    <th>品種ID</th>
                    <th>性別</th>
                    <th>誕生日</th>
                    <th>コンテンツ</th>
                    <th></th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptCats1">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="60px"><%# Eval("CatID") %></td>
                            <td width="150px"><%# Eval("CatName") %> </td>
                            <td width="80px"><%# Eval("CatBreedID") %></td>
                            <td width="80px"><%# Eval("Sex") %> </td>
                            <td width="120px"><%# Eval("strBirth") %> </td>
                            <td width="280px"><%# Eval("Contents") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnUpdate1" CommandName='<%# Eval("CatID") %>' runat="server" Text="変更" OnCommand="btnUpdate1_Command" CssClass="nes-pointer" /></td>
                            <td width="60px">
                                <asp:Button ID="btnDelete1" CommandName='<%# Eval("CatID") %>' runat="server" Text="削除" OnCommand="btnDelete1_Command" CssClass="nes-pointer" OnClientClick="return confirm('削除してもよろしいですか？')"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="plcCats2">
            <table border="1">
                <tr align="center">
                    <th>ネコステータスID</th>
                    <%--<th>ネコID</th>--%>
                    <th>名前</th>
                    <th>日時</th>
                    <th>勤務状況</th>
                    <th></th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptCats2">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="140px"><%# Eval("CatStateID") %></td>
                            <%--<td width="60px"><%# Eval("CatID") %></td>--%>
                            <td width="150px"><%# Eval("CatName") %> </td>
                            <td width="240px"><%# Eval("Date") %></td>
                            <td width="150px"><%# Eval("Work") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnUpdate2" CommandName='<%# Eval("CatStateID") %>' runat="server" Text="変更" OnCommand="btnUpdate2_Command" CssClass="nes-pointer" />
                            <td width="60px">
                                <asp:Button ID="btnDelete2" CommandName='<%# Eval("CatStateID") %>' runat="server" Text="削除" OnCommand="btnDelete2_Command" CssClass="nes-pointer" OnClientClick="return confirm('削除してもよろしいですか？')"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>
        <asp:PlaceHolder runat="server" ID="plcCats3">
            <table border="1">
                <tr align="center">
                    <th>品種ID</th>
                    <th>品種</th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptCats3">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="60px"><%# Eval("CatBreedID") %></td>
                            <td width="150px"><%# Eval("Breed") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnDelete3" CommandName='<%# Eval("CatBreedID") %>' runat="server" Text="削除" OnCommand="btnDelete3_Command" CssClass="nes-pointer" OnClientClick="return confirm('削除してもよろしいですか？')"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>
        <div>
            <br />
            <br />
        </div>
    </div>
</asp:Content>
