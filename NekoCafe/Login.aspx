<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="NekoCafe.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>ログイン</title>
    <link rel="stylesheet" href="css/bootstrap.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin />
    <link rel="stylesheet" href="https://fonts.googleapis.com/css2?family=DotGothic16&display=swap" />
    <!-- latest -->
    <link href="https://unpkg.com/nes.css@latest/css/nes.min.css" rel="stylesheet" />
    <script src="js/bootstrap.js"></script>
    <style>
        body {
            font-family: 'DotGothic16', cursive;
            background-color: rgb(250, 250, 146);
        }

        #titleLogin {
            margin-top: 30px;
            margin-bottom: 30px;
        }

        .loginContent {
            font-size: 23px;
        }

        .inpContent {
            font-size: 16px;
            margin-bottom: 20px;
        }

        #endContent {
            height: 20px;
        }
    </style>
    <script>
       
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container loginAllContent">
            <div class="row">
                <div class="col-2"></div>
                <div class="col-8">
                    <h1 id="titleLogin" style="text-align: center;">ログイン</h1>
                </div>
                <div class="col-2"></div>
            </div>
            <asp:PlaceHolder ID="plcLogin" runat="server">
                <div class="row">
                    <div class="col-2 col-lg-3"></div>
                    <div class="col-8 col-lg-6 loginContent">
                        <p>アカウント：</p>
                        <asp:TextBox ID="txtAccount" runat="server" CssClass="nes-input inpContent" /><br />
                        <p>パスワード：</p>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="nes-input inpContent" type="password"/><br />
                        <br />
                        <div class="row justify-content-evenly">
                            <div class="col-6" style="text-align: center;">
                                <asp:Button ID="btnLogin" runat="server" Text="ログイン" CssClass="nes-btn loginBtn" OnClick="btnLogin_Click"/>
                            </div>
                            <div class="col-6" style="text-align: center;">
                                <asp:Button ID="btnNew" runat="server" Text="新規登録" CssClass="nes-btn" OnClick="btnNew_Click"/>
                            </div>
                        </div>

                    </div>
                    <div class="col-2 col-lg-3"></div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plcLogout" runat="server">
                <div class="row">
                    <div class="col-2 col-lg-3"></div>
                    <div class="col-8 col-lg-6 loginContent">
                        <p>現在ログイン中：</p>
                        <asp:TextBox ID="txtMemberAccount" runat="server" CssClass="nes-input inpContent" Enabled="false" />
                        <br />
                        <div class="row justify-content-evenly">
                            <div class="col-6" style="text-align: center;">
                                <asp:Button ID="btnEnter" runat="server" Text="入る" CssClass="nes-btn loginBtn" OnClick="btnEnter_Click"/>
                            </div>
                            <div class="col-6" style="text-align: center;">
                                <asp:Button ID="btnLogout" runat="server" Text="ログアウト" CssClass="nes-btn loginBtn" OnClick="btnLogout_Click"/>
                            </div>
                        </div>
                    </div>
                    <div class="col-2 col-lg-3"></div>
                </div>
            </asp:PlaceHolder>
            <div id="endContent"></div>
        </div>
    </form>
</body>
</html>
