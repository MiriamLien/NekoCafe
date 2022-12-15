<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Cats.aspx.cs" Inherits="NekoCafe.Cats" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .c {
            position: relative;
            top: 460px;
            width: 100px;
        }

        .rc {
            border: 4px solid black;
        }

        .row {
            overflow: hidden;
        }

        [class*="col-"] {
            margin-bottom: -99999px;
            padding-bottom: 99999px;
        }

        .line {
            border: 4px solid black;
        }

        .page-space {
            height: 20px;
        }

        #page-end-space, #page-header-space {
            height: 90px;
        }

        #context {
            text-align: right;
            font-size: 45px;
        }

        #context2 {
            font-size: 45px;
        }

        #header-space {
            height: 100px;
        }

        #catFootspace {
            height: 130px;
        }
    </style>
    <script>
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="page-header-space"></div>
    <div class="container ">
        <div class="row align-items-end justify-content-start">

            <div class="col-3">
                <asp:ImageButton ID="btnoc2" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/oc2-1.png" OnClick="btnOC2_Click" />
            </div>

            <div class="col-3">
                <asp:ImageButton ID="btnDC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/dc.png" OnClick="btnDC_Click" />
            </div>

            <div class="col-3">
                <asp:ImageButton ID="btnBC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/bc.png" OnClick="btnBC_Click" />
            </div>

            <div class="col-3">
                <asp:ImageButton ID="btnDMC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/dmc.png" OnClick="btnDMC_Click" />
            </div>
            <div class="col-12" height="450px">
                <img src="img/cats/cat-home.png" class="rounded float-start" width="450" height="450">
                <div id="header-space"></div>
                <div class="row">
                    <div class="col-lg-atuo col-md-0 d-none d-lg-block">
                        <div id="context">
                            ねこちゃんをクリックしたら<br />
                            何か出るかも？ฅ^•ﻌ•^ฅ
                        </div>
                    </div>
                </div>
            </div>
            <!--連接資料庫修改-->
            <div class="container-fluid line">
                <div class="row align-items-start bg-dark">
                    <asp:PlaceHolder ID="plcOC2" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12">
                            <img src="img/cats/oc2.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat1" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName1" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed1" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth1" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex1" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState1" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent1" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcDC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/dc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat2" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName2" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed2" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth2" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex2" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState2" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent2" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcBC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/bc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat3" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName3" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed3" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth3" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex3" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState3" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent3" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcDMC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/dmc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat4" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName4" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed4" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth4" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex4" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState4" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent6" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>

    <div class="container ">
        <div class="row align-items-end justify-content-start">
            <div class="col-3">
                <asp:ImageButton ID="btnWC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/wc.png" OnClick="btnWC_Click" />
            </div>
            <div class="col-3">
                <asp:ImageButton ID="btnWC2" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/wc.png" OnClick="btnWC2_Click" />
            </div>
            <div class="col-3">
                <asp:ImageButton ID="btnOC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/oc.png" OnClick="btnOC_Click" />
            </div>
            <div class="col-3">
                <asp:ImageButton ID="btnSC" runat="server" CssClass="c nes-pointer" ImageUrl="~/img/cats/sc.png" OnClick="btnSC_Click" />
            </div>
            <div class="col-12" height="450">
                <img src="img/cats/cat-home2.png" class="rounded float-end" height="450">
                <div class="row">
                    <div class="col-lg-auto col-md-0 d-none d-lg-block">
                        <div id="context2">遊びにきてにゃฅ^-ﻌ-^ฅ</div>
                    </div>
                </div>
            </div>

            <!--連接資料庫修改-->
            <div class="container-fluid line">
                <div class="row align-items-start bg-dark">
                    <asp:PlaceHolder ID="plcWC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/wc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat5" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName5" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed5" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth5" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex5" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState5" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent5" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcWC2" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/wc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat6" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName6" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed6" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth6" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex6" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState6" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent6" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcOC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/oc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat7" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName7" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed7" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth7" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex7" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState7" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent7" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                    <asp:PlaceHolder ID="plcSC" runat="server">
                        <div class="page-space"></div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <img src="img/cats/sc.jpg" class="rc" />
                        </div>
                        <div class="col-lg-6 col-12 justify-content-center">
                            <div class="nes-container is-dark is-rounded">
                                <asp:Repeater ID="rptCat8" runat="server">
                                    <ItemTemplate>
                                        <h1>
                                            <asp:Label ID="lblCatName8" runat="server" Text='<%#Eval("CatName")%>'></asp:Label></h1>
                                        <p></p>
                                        <p>品種：<asp:Label ID="lblBreed8" runat="server" Text='<%#Eval("Breed")%>'></asp:Label></p>
                                        <p>誕生日：<asp:Label ID="lblBirth8" runat="server" Text='<%#Eval("strBirth")%>'></asp:Label></p>
                                        <p>性別：<asp:Label ID="lblSex8" runat="server" Text='<%#Eval("Sex")%>'></asp:Label></p>
                                        <p>仕事中：<asp:Label ID="lblState8" runat="server" Text='<%#Eval("Work")%>'></asp:Label></p>
                                        <p>紹介：</p>
                                        <p>
                                            <asp:Label ID="lblContent8" runat="server" Text='<%#Eval("Contents")%>'></asp:Label>
                                        </p>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        <div class="page-space"></div>
                    </asp:PlaceHolder>

                </div>
            </div>
            <div id="page-end-space"></div>
        </div>
    </div>
    <div id="catFootspace"></div>
</asp:Content>
