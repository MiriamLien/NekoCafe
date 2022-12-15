<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="Reservation2.aspx.cs" Inherits="NekoCafe.Reservation2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%-- 字體 --%>
    <link href="https://fonts.googleapis.com/css?family=Press+Start+2P" rel="stylesheet">
    <%-- 像素CSS --%>
    <link href="https://unpkg.com/nes.css/css/nes.css" rel="stylesheet" />
    <%-- bootstrap --%>
    <link rel="stylesheet" href="ccs/bootstrap.css">
    <script src="js/bootstrap.js"></script>
    <%-- jquery --%>
    <script src="js/jquery.js"></script>

    <%-- 套自己ㄉcss --%>
    <link rel="stylesheet" href="css/ReservationStyle.css">
    <link rel="stylesheet" href="css/Calendar.css">

    <%-- 行事曆的css --%>
    <link href="calendar/main.css" rel="stylesheet" />
    <script src="calendar/main.js"></script>

    <script>
<%--        //行事曆本身&選擇事件
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
                    var UcCheckDate = confirm('確定選取 ' + info.dateStr + ' 嗎？');

                    if (UcCheckDate) {
                        $('#calendarSelectDate').text(info.dateStr);
                        content2.hfDate.value == info.dateStr;
                    }
                    else
                        alert('請重新選擇訂位日期。');
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
        function btnTime_click() {
            var morning = document.getElementById('btnMorning');
            var noon = document.getElementById('btnNoon');
            var night = document.getElementById('btnNight');

            morning.onclick = function () {
                alert("morning");
                morning.style.backgroundColor = "red";
                noon.style.backgroundColor = "#ebe9b0";
                night.style.backgroundColor = "#ebe9b0";
            }
            noon.onclick = function () {
                alert("noon");
                noon.style.backgroundColor = "red";
                morning.style.backgroundColor = "#ebe9b0";
                night.style.backgroundColor = "#ebe9b0";
            }
            night.onclick = function () {
                alert("night");
                night.style.backgroundColor = "red";
                noon.style.backgroundColor = "#ebe9b0";
                morning.style.backgroundColor = "#ebe9b0";
            }

            var btnCheck = document.getElementById('btnCheck');
            btnCheck.disabled = false;
        }

        //確認訂位日期人數時段
        function btnCheck_click() {
            var bbb = $("#ContentPlaceHolder1_HiddenField1");
            bbb.value = "345-53454-3534";
            console.log(bbb.value);

            var ucDate = document.getElementById('calendarSelectDate');
            if (ucDate.textContent == "")
                alert("請選擇欲訂位日期");
            else {
                $("#ContentPlaceHolder1_ltlDate").text(ucDate.textContent);

                var morning = document.getElementById('btnMorning');
                var noon = document.getElementById('btnNoon');
                var night = document.getElementById('btnNight');

                if (morning.style.backgroundColor == "red") {
                    $("#ContentPlaceHolder1_ltlTime").text("11:30");
                    content2.hfTime.value == "11:30:00";
                }

                if (noon.style.backgroundColor == "red") {
                    $("#ContentPlaceHolder1_ltlTime").text("14:30");
                    content2.hfTime.value == "14:30:00";
                }

                if (night.style.backgroundColor == "red") {
                    $("#ContentPlaceHolder1_ltlTime").text("18:00");
                    content2.hfTime.value == "18:00:00";
                }



                var ucPeople = '<%= DropDownList1.ClientID %>';
                var selectedIndex = document.getElementById(ucPeople).selectedIndex;
                var selectedValue = document.getElementById(ucPeople).options[selectedIndex].value;
                $("#ContentPlaceHolder1_ltlPeople").text(selectedValue);
                content2.hfPeople.value == selectedValue;

                $(".calendarBlockLeft").slideUp(2000);
                $(".calendarBlockRight").slideUp(2000);

                document.getElementById("SMcalendarBlock").style.display = "block";
            }
        }

        function btnChange_click() {
            $("#SMcalendarBlock").slideUp(500);
            $(".calendarBlockLeft").slideDown(2000);
            $(".calendarBlockRight").slideDown(2000);
        }--%>

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:HiddenField ID="hfDate" runat="server" />
    <asp:HiddenField ID="hfTime" runat="server" />
    <asp:HiddenField ID="hfPeople" runat="server" />

    <div id="header-space-reservation"></div>

    <div class="container bg-content">
        <div class="row" id="mainImage">
            <div class="col-md-12 col-sm-12 col-xs-12">
                <img src="img/reservation/photo02.jpg" id="mainImg01">
                <img src="https://live.staticflickr.com/65535/51085818632_2dd375a75c_k.jpg" id="mainImg02" />
            </div>
        </div>
        <div class="col-md-12 col-sm-12 col-xs-12" id="content">
            <div>
                <h1 class="titles">名前はまだない珈琲店</h1>
                <hr class="style-one" />
                <div class="context">
                    <p>一些介紹一些介紹一些介紹一些介紹</p>
                    <p>一些介紹一些介紹一些介紹一些介紹</p>
                </div>
            </div>
            <div class="TitleDiv">
                <h2 class="titles">Notice</h2>
                <hr class="style-one" />
            </div>
            <div class="context">
                <p>当店は基本的に面倒な会員登録などはなくお気軽にドロップインでご利用頂けます。</p>
                <p>※月会員登録ご希望の場合のみ登録が必要になります。</p>
                <p>詳しいご利用方法はこちら⬇︎</p>
                <br />
                <p>①【後払いのお時間制】</p>
                <p>ご来店時受付にて入館登録のうえ、リストバンドをお受け取り頂き店内をご利用下さい。</p>
                <p>お帰りの際にご滞在頂いたお時間分のお代金をお支払い頂きます。</p>
                <br />
                <p>①【後払いのお時間制】</p>
                <p>ご来店時受付にて入館登録のうえ、リストバンドをお受け取り頂き店内をご利用下さい。</p>
                <p>お帰りの際にご滞在頂いたお時間分のお代金をお支払い頂きます。</p>
            </div>
        </div>
        <div class="row" id="info">
            <div class="TitleDiv">
                <h2 class="titles">Info</h2>
                <hr class="style-one" />
            </div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3641.162882779375!2d120.65988781482312!3d24.130917284403203!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x34693da96ea977cf%3A0xc1649f82e9860cfb!2z5YWt5pyI5Yid5LiAOOe1kOibi-aNsiB8IOWFqOeQg-WUr-S4gCB8IOWPsOS4reS8tOaJi-emrg!5e0!3m2!1szh-TW!2stw!4v1645079677801!5m2!1szh-TW!2stw" width="100%" height="350" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
            </div>
            <div class="col-md-6 col-sm-12 col-xs-12">
                <div>
                    <div>
                        <div class="smTitles">住所</div>
                        <div class="smContent">
                            新北市新店區雙城路175號之三
                        </div>
                    </div>
                    <div>
                        <div class="smTitles">電話番号</div>
                        <div class="smContent">0905-651494175號之三</div>
                    </div>
                    <div>
                        <div class="smTitles">営業時間</div>
                        <div class="smContent">年中無休</div>
                    </div>
                </div>
            </div>
        </div>
        <div id="booking">
            <asp:PlaceHolder ID="plcOrder" runat="server">
                <div class="container">
                    <div class="row">
                        <!--行事曆-->
                        <div>
                            <asp:Calendar ID="cldDate" runat="server"></asp:Calendar>
                        </div>
                        <!--訂位-->
                        <div class="col-4">
                            <div>
                                <asp:DropDownList ID="ddlTime" runat="server" Width="120px" CssClass="nes-select">
                                    <asp:ListItem Selected="True" Value="1"> 11:00 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="2"> 14:30 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="3"> 18:00 </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>
                                <asp:DropDownList ID="ddlPeople" runat="server" Width="120px" CssClass="nes-select">
                                    <asp:ListItem Selected="True" Value="1"> 1 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="2"> 2 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="3"> 3 </asp:ListItem>
                                    <asp:ListItem Selected="false" Value="4"> 4 </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Button ID="btnForOrder" runat="server" Text="確定" />
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="plcMenu" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Literal ID="ltlDate" runat="server">日期 </asp:Literal>
                            <asp:Literal ID="ltlTime" runat="server">時間 </asp:Literal>
                            <asp:Literal ID="ltlPeople" runat="server">人數</asp:Literal>
                            <asp:Button ID="btnChangeOrder" runat="server" Text="變更" />
                        </div>
                        <div>
                            MENU:
                            <asp:CheckBoxList ID="CheckBoxList1" runat="server" CssClass="nes-checkbox">
                                <asp:ListItem Selected="false" Value="1"> 1 </asp:ListItem>
                                <asp:ListItem Selected="false" Value="2"> 2 </asp:ListItem>
                                <asp:ListItem Selected="false" Value="3"> 3 </asp:ListItem>
                                <asp:ListItem Selected="false" Value="4"> 4 </asp:ListItem>
                            </asp:CheckBoxList>
                        </div>
                        <div>
                            <asp:Button ID="btnForMenu" runat="server" Text="確定" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>

            <asp:PlaceHolder ID="plcInfo" runat="server">
                <div class="container">
                    <div class="row">
                        <div class="col-12">
                            <asp:Literal ID="Literal1" runat="server">日期 </asp:Literal>
                            <asp:Literal ID="Literal2" runat="server">時間 </asp:Literal>
                            <asp:Literal ID="Literal3" runat="server">人數</asp:Literal>
                            <asp:Button ID="Button1" runat="server" Text="變更" />
                        </div>
                        <div>
                            <asp:Literal ID="Literal4" runat="server">菜單</asp:Literal>
                            <asp:Button ID="Button3" runat="server" Text="變更" />
                        </div>
                        <div>
                            姓名:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            性別:<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            電話:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                            信箱:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                            備註:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                            <asp:Button ID="Button2" runat="server" Text="確定" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>
</asp:Content>
