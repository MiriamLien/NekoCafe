<%@ Page Title="" Language="C#" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminReservation.aspx.cs" Inherits="NekoCafe.BackAdmin.adminReservation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>予約一覧（当月）</h3>
        <asp:Button ID="btnThisMonReserv" runat="server" Text="当月" OnClick="btnThisMonReserv_Click"/>
        <asp:Button runat="server" ID="btnHistoryReserv" Text="過去の予約" OnClick="btnHistoryReserv_Click" />
        <asp:Button runat="server" ID="btnAll" Text="すべて" OnClick="btnAll_Click" />
        &emsp; &emsp;
        <asp:TextBox runat="server" ID="txtSearch"></asp:TextBox>
        <asp:Button runat="server" ID="btnSearch" Text="検索" OnClick="btnSearch_Click" />
        <h6>&emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp; &emsp;例 : 12 31 2022 12:00AM</h6>
        <asp:PlaceHolder ID="plcUpdate" runat="server">
            <div>
                <h4>予約変更</h4>
                <div>
                    <p>オーダーID：<asp:TextBox ID="txtOID" runat="server" TextMode="Number" Enabled="false"></asp:TextBox></p>
                    <p>日時：<asp:TextBox ID="txtTime" runat="server" TextMode="DateTime"></asp:TextBox></p>
                    <p>人数：<asp:TextBox ID="txtNPR" runat="server" TextMode="Number"></asp:TextBox></p>
                    <p>付注：<asp:TextBox ID="txtNote" runat="server"></asp:TextBox></p>
                </div>
                <div>
                    <asp:Button ID="btnUpdate" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnUpdate_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <p></p>
        <asp:PlaceHolder runat="server" ID="plcReserv">
            <table border="1">
                <tr align="center">
                    <th>OID</th>
                    <th>名前</th>
                    <th>性別</th>
                    <th>電話番号</th>
                    <th>メールアドレス</th>
                    <th>日時</th>
                    <th>人数</th>
                    <th>付注</th>
                    <th></th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptReservation">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="50px"><%# Eval("OrderID") %></td>
                            <td width="100px"><%# Eval("Name") %> </td>
                            <td width="50px"><%# Eval("Sex") %> </td>
                            <td width="120px"><%# Eval("Phone") %> </td>
                            <td width="200px"><%# Eval("Mail") %> </td>
                            <td width="90px"><%# Eval("Date_Time") %> </td>
                            <td width="50px"><%# Eval("NPR") %> </td>
                            <td width="100px"><%# Eval("Note") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnUpdate" CommandName='<%# Eval("OrderID") %>' runat="server" Text="変更" OnCommand="btnUpdate_Command" />
                            </td>
                            <td width="60px">
                                <asp:Button ID="btnDelete" CommandName='<%# Eval("OrderID") %>' runat="server" Text="削除" OnCommand="btnDelete_Command" OnClientClick="return confirm('削除してもよろしいですか？')" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>

        <asp:PlaceHolder runat="server" ID="plcHisReserv" Visible="false">
            <table border="1">
                <tr align="center">
                    <th>OID</th>
                    <th>名前</th>
                    <th>性別</th>
                    <th>電話番号</th>
                    <th>メールアドレス</th>
                    <th>日時</th>
                    <th>人数</th>
                    <th>付注</th>
                </tr>
                <asp:Repeater runat="server" ID="rptHisReservation" Visible="false">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="50px"><%# Eval("OrderID") %></td>
                            <td width="100px"><%# Eval("Name") %> </td>
                            <td width="50px"><%# Eval("Sex") %> </td>
                            <td width="120px"><%# Eval("Phone") %> </td>
                            <td width="200px"><%# Eval("Mail") %> </td>
                            <td width="90px"><%# Eval("Date_Time") %> </td>
                            <td width="50px"><%# Eval("NPR") %> </td>
                            <td width="100px"><%# Eval("Note") %> </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>

    </div>
</asp:Content>
