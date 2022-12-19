<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="ReservationPage.aspx.cs" Inherits="NekoCafe.ReservationPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- 字體 --%>
    <link href="https://fonts.googleapis.com/css?family=Press+Start+2P" rel="stylesheet">
    <%-- 像素CSS --%>
    <link href="https://unpkg.com/nes.css/css/nes.css" rel="stylesheet" />
    <%-- bootstrap --%>
    <link rel="stylesheet" href="css/bootstrap.css">
    <script src="js/bootstrap.js"></script>
    <%-- jquery --%>
    <script src="js/jquery.js"></script>

    <%-- 套自己ㄉcss --%>
    <link rel="stylesheet" href="css/ReservationStyle.css">
    <link rel="stylesheet" href="css/Calendar.css">

    <%-- 行事曆的css --%>
    <link href="calendar/main.css" rel="stylesheet" />
    <script src="calendar/main.js"></script>
    <script src="https://polyfill.io/v3/polyfill.min.js?features=default"></script>

    <script>
        function initMap() {
            const myLatLng = { lat: 22.32862784836183, lng: 120.35432540703512 };
            const map = new google.maps.Map(document.getElementById("map"), {
                zoom: 15,
                center: myLatLng,
            });

            new google.maps.Marker({
                position: myLatLng,
                map,
                title: "Hello World!",
            });
        }

        //行事曆本身&選擇事件
        document.addEventListener('DOMContentLoaded', function () {
            var calendarEl = document.getElementById('calendar');

            var calendar = new FullCalendar.Calendar(calendarEl, {
                timeZone: 'UTC',
                initialView: 'dayGridMonth',
                editable: true,
                selectable: true,
                headerToolbar: {
                    left: '',
                    center: 'title',
                    right: ''
                },
                dateClick: function (info) {
                    var UcCheckDate = confirm(info.dateStr + 'を選択する。');

                    if (UcCheckDate) {
                        $('#calendarSelectDate').text(info.dateStr);
                    }
                    else
                        alert('ご希望の日付を選択してください。');
                },
                selectAllow: function (e) {
                    if (e.end.getTime() / 1000 - e.start.getTime() / 1000 <= 86400) {
                        return true;
                    }
                },
            });
            calendar.render();
        });

        //選擇時段
        function morning_click() {
            var morning = document.getElementById('btnMorning');
            var noon = document.getElementById('btnNoon');
            var night = document.getElementById('btnNight');

            morning.style.backgroundColor = "darkgray";
            noon.style.backgroundColor = "white";
            night.style.backgroundColor = "white";

            var btnCheck = document.getElementById('btnCheck');
            btnCheck.disabled = false;
        }

        function noon_click() {
            var morning = document.getElementById('btnMorning');
            var noon = document.getElementById('btnNoon');
            var night = document.getElementById('btnNight');

            noon.style.backgroundColor = "darkgray";
            morning.style.backgroundColor = "white";
            night.style.backgroundColor = "white";

            var btnCheck = document.getElementById('btnCheck');
            btnCheck.disabled = false;
        }

        function night_click() {
            var morning = document.getElementById('btnMorning');
            var noon = document.getElementById('btnNoon');
            var night = document.getElementById('btnNight');

            night.style.backgroundColor = "darkgray";
            noon.style.backgroundColor = "white";
            morning.style.backgroundColor = "white";

            var btnCheck = document.getElementById('btnCheck');
            btnCheck.disabled = false;
        }


        //確認訂位日期人數時段
        function btnCheck_click() {
            var ucDate = document.getElementById('calendarSelectDate');
            if (ucDate.textContent == "") {
                alert("日付を入力してください");
            }
            else {
                $("#ContentPlaceHolder1_ltlDate").text(ucDate.textContent);
                var hfDate = document.getElementById('ContentPlaceHolder1_HiddenField1');
                hfDate.value = ucDate.textContent;

                var morning = document.getElementById('btnMorning');
                var noon = document.getElementById('btnNoon');
                var night = document.getElementById('btnNight');
                var hfTime = document.getElementById('ContentPlaceHolder1_HiddenField2');

                if (morning.style.backgroundColor == "darkgray") {
                    $("#ContentPlaceHolder1_ltlTime").text("11:00");
                    hfTime.value = "11:00";
                }

                if (noon.style.backgroundColor == "darkgray") {
                    $("#ContentPlaceHolder1_ltlTime").text("14:30");
                    hfTime.value = "14:30";
                }

                if (night.style.backgroundColor == "darkgray") {
                    $("#ContentPlaceHolder1_ltlTime").text("18:00");
                    hfTime.value = "18:00";
                }

                var ucPeople = '<%= ddlNPR.ClientID %>';
                var selectedIndex = document.getElementById(ucPeople).selectedIndex;
                var selectedValue = document.getElementById(ucPeople).options[selectedIndex].value;
                $("#ContentPlaceHolder1_ltlPeople").text(selectedValue);

                var hfPeo = document.getElementById('ContentPlaceHolder1_HiddenField3');
                hfPeo.value = selectedValue;

                $(".calendarBlockLeft").slideUp(2000);
                $(".calendarBlockRight").slideUp(2000);

                document.getElementById("SMcalendarBlock").style.display = "block";
            }
        }


        function btnChange_click() {
            $("#SMcalendarBlock").slideUp(500);
            $(".calendarBlockLeft").slideDown(2000);
            $(".calendarBlockRight").slideDown(2000);
        }

    </script>

    <style>
        #buttomDiv {
            height: 150px;
        }

        /* Always set the map height explicitly to define the size of the div
       * element that contains the map. */
        /* #map {
            height: 100%;
        } */

        /* Optional: Makes the sample page fill the window. */
        html,
        body {
            height: 100%;
            margin: 0;
            padding: 0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- 放值的label --%>
    <asp:Label ID="lblDate" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:Label ID="lblTime" runat="server" Text="Label" Visible="false"></asp:Label>
    <asp:Label ID="lblPeo" runat="server" Text="Label" Visible="false"></asp:Label>

    <div id="header-space-reservation"></div>

    <div class="container bg-content">
        <div class="row" id="mainImage">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <img src="img/reservation/photo02.jpg" id="mainImg01">
                <%--<img src="https://live.staticflickr.com/65535/51085818632_2dd375a75c_k.jpg" id="mainImg02" />--%>
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" id="content">
            <div>
                <h1 class="titles">猫カフェ　Cat Baggage</h1>
                <hr class="style-one" />
                <div class="context">
                    <p>お客様と猫ちゃんが望む居心地の良い・癒し・アットホームな空間を提供するをコンセプトに多種多様なまだまだ初々しい猫ちゃんたちがお客様をお出迎え致します。</p>
                    <p>猫ちゃんとの時間をゆっくりと過ごしたい。一緒に遊んで癒されたい。猫ちゃんとの生活を体感したい。という方から、空いた時間のちょっとした休憩・おしゃべりの場としてもご利用出来るよう心掛けております。</p>
                </div>
            </div>
            <div class="TitleDiv">
                <h2 class="titles">Attention</h2>
                <hr class="style-one" />
            </div>
            <div class="context">
                <p>· 寝ている猫は起こさない、触らないでください。</p>
                <p>· 猫のおもちゃ、おやつなどの持ち込みはご遠慮願います。</p>
                <p>· 入店の際は必ず手洗いとアルコール消毒をしてください。</p>
                <p>· 入店したら履き物を脱いでスリッパに履き替えてください。</p>
                <p>· お客様が飼っている猫を連れてのご入室はできません。</p>
                <p>· フラッシュ撮影は猫の目に悪影響があるためご遠慮願います。</p>
                <p>· 店内は全室禁煙となっております。</p>
            </div>
        </div>
        <div class="row" id="info">
            <div class="TitleDiv">
                <h2 class="titles">Access</h2>
                <hr class="style-one" />
            </div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <div id="map"></div>
                <%--<script
                    src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBA9A_Ry9G67EMNHQHYwh3aAE9ubAkaLdU&callback=initMap&v=weekly&channel=2"
                    async></script>--%>
                <iframe width="600" height="350" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src=https://maps.google.com.tw/maps?f=q&hl=zh-TW&geocode=&q=屏東縣琉球郷信義路50號&z=16&output=embed&t=></iframe>
            </div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <div>
                    <div>
                        <div class="smTitles">住所</div>
                        <div class="smContent">
                            929 屏東縣琉球郷信義路50號
                        </div>
                    </div>
                    <div>
                        <div class="smTitles">電話番号</div>
                        <div class="smContent">0905-651494175</div>
                    </div>
                    <div>
                        <div class="smTitles">営業時間</div>
                        <div class="smContent">年中無休</div>
                    </div>
                </div>
            </div>
        </div>

        <div id="booking">
            <div class="TitleDiv">
                <h2 class="titles">Booking</h2>
                <hr class="style-one" />
            </div>
            <%-- 行事曆 --%>
            <div class="row calendarBlock" runat="server">
                <div id="SMcalendarBlock">
                    <h2>予約詳細</h2>
                    <%-- 放值的HiddenField --%>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField2" runat="server" Value="0" />
                    <asp:HiddenField ID="HiddenField3" runat="server" Value="0" />

                    <h5>日付</h5>
                    <asp:Label ID="ltlDate" runat="server">日付</asp:Label><br />
                    <h5>人数</h5>
                    <asp:Label ID="ltlPeople" runat="server">人数</asp:Label><br />
                    <h5>時間帯</h5>
                    <asp:Label ID="ltlTime" runat="server">時間帯</asp:Label><br />

                    <button onclick="btnChange_click(); return false;">予約内容変更</button>
                </div>
                <div class="calendarBlockLeft ">
                    <div class="calendarBlockLeftInner">
                        <div id="calendar"></div>
                    </div>
                </div>

                <%-- 右邊 --%>
                <div class="calendarBlockRight">
                    <div class="calendarBlockRightInner">
                        <ul>
                            <li class="calendarSelectTitle">日付</li>
                            <p id="calendarSelectDate"></p>
                            <br />
                            <li class="calendarSelectTitle">人数</li>
                            <div class="dropdown">
                                <asp:DropDownList ID="ddlNPR" runat="server" Width="120px" BackColor="#F6F1DB" ForeColor="#7d6754" Font-Names="Andalus" CssClass="ddl">
                                    <asp:ListItem Selected="True" Value="1"> 1 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="2"> 2 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="3"> 3 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="4"> 4 </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <li>時間帯</li>
                            <div>
                                <button id="btnMorning" class="btnTime" type="button" onclick="morning_click();">11:00</button><br />
                                <button id="btnNoon" class="btnTime " type="button" onclick="noon_click();return false;">14:30</button><br />
                                <button id="btnNight" class="btnTime " type="button" onclick="night_click();return false;">18:00</button>
                            </div>
                        </ul>
                        <div id="btnCheckDiv">
                            <button id="btnCheck" disabled="disabled" class="btnTime" onclick="btnCheck_click();return false;">確定</button>
                        </div>
                    </div>
                </div>
            </div>

            <%-- 餐點 --%>
            <div class="TitleDiv">
                <h2 class="titles">Menu Order</h2>
                <hr class="style-one" />
            </div>

            <asp:Label ID="lblOrItemID" runat="server" Visible="false"/>
            <asp:Label ID="lblOrItemName" runat="server" Visible="false"/>
            <asp:Label ID="lblOrItemAmount" runat="server" Visible="false"/>
            <asp:Label ID="lblOrItemPrice" runat="server" Visible="false" />

            <asp:ScriptManager ID="scriptmanager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="updatepanel1" runat="server">
                <ContentTemplate>
                    <asp:PlaceHolder ID="plcMenu" runat="server">
                        <div class="container">
                            <div class="row">
                                <div id="menuDiv">

                                    <!--coffee-->
                                    <asp:PlaceHolder ID="plcOrder" runat="server">
                                        <p>coffee:</p>
                                        <asp:DropDownList ID="ddlCoffee" runat="server" CssClass="menuDDL"></asp:DropDownList>
                                        數量：<asp:TextBox ID="txtCoffeeAmount" runat="server" CssClass="menuTextBox" TextMode="Number" min="1"></asp:TextBox>
                                        <asp:Button ID="btnAddCoffe" runat="server" Text="+" OnClick="btnAddCoffe_Click" /><br />

                                        <!--tea-->
                                        <p>Tea:</p>
                                        <asp:DropDownList ID="ddlTea" runat="server" CssClass="menuDDL">
                                        </asp:DropDownList>
                                        數量：<asp:TextBox ID="txtTeaAmount" runat="server" CssClass="menuTextBox" TextMode="Number" min="1"></asp:TextBox>
                                        <asp:Button ID="btnAddTea" runat="server" Text="+" OnClick="btnAddTea_Click" /><br />

                                        <!--dessert-->
                                        <p>Dessert:</p>
                                        <asp:DropDownList ID="ddlDessert" runat="server" CssClass="menuDDL">
                                        </asp:DropDownList>
                                        數量：<asp:TextBox ID="txtDessertAmount" runat="server" CssClass="menuTextBox" TextMode="Number" min="1"></asp:TextBox>
                                        <asp:Button ID="btnAddDessert" runat="server" Text="+" OnClick="btnAddDessert_Click" /><br />


                                        <!--others-->
                                        <p>Others:</p>
                                        <asp:DropDownList ID="ddlOthers" runat="server" CssClass="menuDDL">
                                        </asp:DropDownList>
                                        數量：<asp:TextBox ID="txtOthersAmount" runat="server" CssClass="menuTextBox" TextMode="Number" min="1"></asp:TextBox>
                                        <asp:Button ID="btnAddOthers" runat="server" Text="+" OnClick="btnAddOthers_Click" /><br />
                                    </asp:PlaceHolder>
                                    <br />
                                    <asp:Label ID="Label2" runat="server" Text="Label">選んだプラン：</asp:Label><br />
                                    <br />
                                    <asp:Label ID="lblUserOrder" runat="server"></asp:Label><br />
                                    <asp:Label ID="Label1" runat="server" Text="Label">総額：</asp:Label>
                                    <asp:Label ID="lblUserTotalPrice" runat="server">0</asp:Label>
                                    <br />
                                    <br />

                                    <div>
                                        <asp:Button runat="server" Text="予約を確定する" ID="btnConfirm" OnClick="btnConfirm_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>

                    <%-- 個人資訊 --%>
                    <asp:PlaceHolder ID="plcInfo" runat="server" Visible="false">
                        <div class="container">
                            <div class="row">
                                <div id="InfoDiv">
                                    <span style="color: red;">* </span>名前:<asp:TextBox ID="txtName" runat="server" CssClass="nes-input inpContent"></asp:TextBox><br />
                                    <h6>
                                        <asp:Label ID="lblName" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label>
                                    </h6>
                                    <span style="color: red;">* </span>性別:
                                    <asp:RadioButton ID="rdbtnM" runat="server" GroupName="Sex" Checked="false" Text="男" />&nbsp;
                                    <asp:RadioButton ID="rdbtnF" runat="server" GroupName="Sex" Checked="false" Text="女" />&nbsp;
                                    <asp:RadioButton ID="rdbtnO" runat="server" GroupName="Sex" Checked="false" Text="その他" /><br />
                                    <h6>
                                        <asp:Label ID="lblSex" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label>
                                    </h6>
                                    <span style="color: red;">* </span>電話番号:<asp:TextBox ID="txtPhone" runat="server" CssClass="nes-input inpContent"></asp:TextBox><br />
                                    <h6>
                                        <asp:Literal ID="ltlPhone2" runat="server">電話番号は10桁で入力してください。</asp:Literal><br />
                                        <asp:Label ID="lblPhone" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label><br />
                                        <asp:Label ID="lblPhone2Red" runat="server" Visible="false" ForeColor="Red">入力した電話番号に誤りがあります。</asp:Label>
                                    </h6>
                                    <span style="color: red;">* </span>メールアドレス:<asp:TextBox ID="txtMail" runat="server" CssClass="nes-input inpContent"></asp:TextBox><br />
                                    <h6>
                                        <asp:Literal ID="ltlGMail" runat="server">Gmailのみです。</asp:Literal><br />
                                        <asp:Label ID="lblMail" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label><br />
                                        <asp:Label ID="lblMail2Red" runat="server" Visible="false" ForeColor="Red">入力したメールに誤りがあります。</asp:Label>
                                    </h6>
                                    付注:<asp:TextBox ID="txtNote" runat="server" CssClass="nes-input inpContent"></asp:TextBox><br />

                                    <asp:Button ID="plcInfo_btnCheck" runat="server" Text="確定" OnClick="plcInfo_btnCheck_Click" />
                                </div>
                            </div>
                        </div>
                    </asp:PlaceHolder>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <%-- end of booking --%>
    </div>

    <div id="buttomDiv"></div>
</asp:Content>
