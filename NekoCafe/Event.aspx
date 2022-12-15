<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Event.aspx.cs" Inherits="NekoCafe.Event" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%-- 網路找的樣式 --%>
    <link href="https://fonts.googleapis.com/css?family=DotGothic16" rel="stylesheet">
    <link href="https://unpkg.com/nes.css/css/nes.css" rel="stylesheet" />
    <link rel="stylesheet" href="ccs/bootstrap.css">
    <script src="js/bootstrap.js"></script>
    <script src="js/jquery.js"></script>
    <%-- 套自己ㄉcss --%>
    <link href="css/EventStyle.css" rel="stylesheet" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id="topDiv"></div>
    <div class="container">
        <div class="row">
            <%--側邊標題--%>
            <div class="col-12" style="background-image:url(img/event/Meow.png); background-size: 40%; background-repeat: no-repeat; background-position: bottom right;">
                <asp:Repeater ID="rptEventbtn" runat="server">
                    <ItemTemplate>
                        <p class="nes-balloon from-left nes-pointer sideTitle">
                            <asp:Button ID="btnEvent" runat="server" Text='<%#Eval("Title") %>' CssClass="nes-pointer" BorderStyle="None" BackColor="White" Height="75px" CommandName='<%#Eval("Title") %>' OnCommand="btnEvent_Command" OnClientClick="TitleClick()" />
                        </p>
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <asp:PlaceHolder ID="plcEvent" runat="server">
                <div class="row">
                    <div class="col-12 align-items-end" id="Event">
                        <div class="nes-container is-rounded whiteBg">
                            <asp:Label ID="lblTitle" runat="server" CssClass="h1"></asp:Label><br />
                            <br />
                            <asp:Repeater ID="rptEventContent" runat="server">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%#Eval("Word") %>'></asp:Label>
                                    <asp:Image runat="server" ImageUrl='<%#Eval("Picture") %>' />
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
        <div style="height: 150px"></div>
    </div>


</asp:Content>
