<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="NekoCafe.Menu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #header-space-menu {
            height: 200px;
        }

        .foodpic {
            width: auto;
        }

        .osuprice {
            width: 280px;
            height: 100px;
            font-size: 18px;
        }

        .spa {
            height: 20px;
        }

        .coffee,
        .tea,
        .others,
        .dessert {
            width: 260px;
            height: 100px;
            margin: 15px;
        }

        #titleMenu {
            /*border: 3px solid #000000;*/
            background-color: #ffbab2;
            padding: 10px;
        }

        .title2 {
            background-color: #ffbc70;
            text-align: left;
        }

        #titleMenu,
        .title2 {
            margin-top: 20px;
            margin-bottom: 15px;
        }

        #menuFootspace {
            height: 150px;
        }

        .pushDiv {
            padding-left: 60px;
        }
    </style>
    <script>
        document.querySelector("#aTop", "#aTop2", "#aTop3", "#aTop4", "#aTop5").onclick = function () {
            document.querySelector("#titleMenu").scrollIntoView(true);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="header-space-menu"></div>
    <div class="container" style="border: 5px double #000000;">
        <div class="row">
            <div class="col-12">
                <h1 id="titleMenu" align="center">メニュー</h1>
            </div>
        </div>

        <div class="row">
            <div class="col-12">
                <h2 class="title2" id="titleOsu">おすすめ</h2>
            </div>
        </div>
        <div class="row" align="center">
            <asp:Repeater ID="rptOsu" runat="server">
                <ItemTemplate>
                    <div class="col-lg-4 col-md-6 col-sm-12 recommand">
                        <div class="foodpic">
                            <asp:Image ID="osuPic" runat="server" Style="border: 5px solid #000000;" ImageUrl='<%#Eval("PicRoute") %>' />
                        </div>
                        <br>
                        <div class="nes-btn osuprice">
                            <asp:Label ID="lblOsuName" runat="server" Text=""><%# Eval("Name") %></asp:Label><br>
                            <asp:Label ID="lblOsuPrice" runat="server" Text="">$<%# Eval("Price") %></asp:Label>
                        </div>
                        <div class="spa"></div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <div align="right">
                    ▲ <a href="#" id="aTop1">TOP</a>
                </div>
            </div>

            <%-- Coffee --%>
            <div class="row">
                <div class="col-12">
                    <h2 class="title2" id="titleCoffee">コーヒー</h2>
                </div>
            </div>
            <div class="row">
                <div align="left" class="pushDiv">
                    <asp:Repeater ID="rptCoffee" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-12 nes-btn coffee">
                                <asp:Label ID="lblCoffeeName" runat="server"><%# Eval("Name") %></asp:Label><br />
                                <asp:Label ID="lblCoffeePrice" runat="server">$<%# Eval("Price") %></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <div align="right">
                    ▲ <a href="#" id="aTop2">TOP</a>
                </div>
            </div>

            <%-- Tea --%>
            <div class="row">
                <div class="col-12">
                    <h2 class="title2" id="titleTea">お茶</h2>
                </div>
            </div>
            <div class="row">
                <div align="left" class="pushDiv">
                    <asp:Repeater ID="rptTea" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-12 nes-btn tea">
                                <asp:Label ID="lblTeaName" runat="server"><%# Eval("Name") %></asp:Label><br />
                                <asp:Label ID="lblTeaPrice" runat="server">$<%# Eval("Price") %></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div align="right">
                    ▲ <a href="#" id="aTop3">TOP</a>
                </div>
                </div>
            </div>

            <%-- Other --%>
            <div class="row">
                <div class="col-12">
                    <h2 class="title2" id="titleOthers">その他</h2>
                </div>
            </div>
            <div class="row">
                <div align="left" class="pushDiv">
                    <asp:Repeater ID="rptOther" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-12 nes-btn others">
                                <asp:Label ID="lblOtherName" runat="server"><%# Eval("Name") %></asp:Label><br />
                                <asp:Label ID="lblOtherPrice" runat="server">$<%# Eval("Price") %></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div align="right">
                    ▲ <a href="#" id="aTop4">TOP</a>
                </div>
                </div>
            </div>

            <%-- Dessert --%>
            <div class="row">
                <div class="col-12">
                    <h2 class="title2" id="titleDessert">デザート</h2>
                </div>
            </div>
            <div class="row">
                <div align="left" class="pushDiv">
                    <asp:Repeater ID="rptDessert" runat="server">
                        <ItemTemplate>
                            <div class="col-lg-4 col-md-6 col-sm-12 nes-btn dessert">
                                <asp:Label ID="lblDessertName" runat="server"><%# Eval("Name") %></asp:Label><br />
                                <asp:Label ID="lblDessertPrice" runat="server">$<%# Eval("Price") %></asp:Label>
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                    <div align="right">
                    ▲ <a href="#" id="aTop5">TOP</a>
                </div>
                </div>
            </div>
        

        <div id="menuFootspace"></div>
    </div>
</asp:Content>
