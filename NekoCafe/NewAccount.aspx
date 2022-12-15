<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewAccount.aspx.cs" Inherits="NekoCafe.NewAccount" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>新規登録</title>
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

        #titleNewAcc {
            margin-top: 30px;
            margin-bottom: 30px;
        }

        .NewAccContent {
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
</head>
<body>
    <form id="form1" runat="server">
        <div class="container loginAllContent">
            <div class="row">
                <div class="col-2"></div>
                <div class="col-8">
                    <h1 id="titleNewAcc" style="text-align: center;">新規登録</h1>
                </div>
                <div class="col-2"></div>
            </div>
            <asp:PlaceHolder ID="plcNewAcc" runat="server">
                <div class="row">
                    <div class="col-2 col-lg-3"></div>
                    <div class="col-8 col-lg-6 NewAccContent">
                        <p>アカウント：</p>
                        <asp:TextBox ID="txtAccount" runat="server" CssClass="nes-input inpContent" /><br />
                        <h6>
                            <asp:Label ID="lblSameAcc" runat="server" Visible="false" ForeColor="Red">このアカウントはすでに存在します。</asp:Label>
                        </h6>
                        <p>パスワード：</p>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="nes-input inpContent" type="password" /><br />
                        <p>パスワードの確認：</p>
                        <asp:TextBox ID="txtPasswordCheck" runat="server" CssClass="nes-input inpContent" type="password" /><br />
                        <h6>
                            <asp:Label ID="lblUnsamePwd" runat="server" Visible="false" ForeColor="Red">パスワードが一致していません。</asp:Label>
                            
                        </h6>
                        <div class="col-12 justify-content-end">
                            <asp:Button ID="btnAccCheck" runat="server" Text="確認" CssClass="nes-btn loginBtn" OnClick="btnAccCheck_Click" />
                        </div>
                    </div>
                    <div class="col-2 col-lg-3"></div>
                </div>
            </asp:PlaceHolder>
            <asp:PlaceHolder ID="plcNewMember" runat="server">
                <div class="row">
                    <div class="col-2 col-lg-3"></div>
                    <div class="col-8 col-lg-6 loginContent">
                        <p><span style="color: red;">* </span>名前：</p>
                        <asp:TextBox ID="txtName" runat="server" CssClass="nes-input inpContent" /><br />
                        <h6>
                            <asp:Label ID="lblName" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label>
                        </h6>
                        <p><span style="color: red;">* </span>性別：</p>
                        <asp:RadioButton ID="rdbMale" runat="server" GroupName="Sex" Checked="false"/><span> 男 </span>&nbsp;
                        <asp:RadioButton ID="rdbFemale" runat="server" GroupName="Sex" Checked="false"/><span> 女 </span>&nbsp;
                        <asp:RadioButton ID="rdbOther" runat="server" GroupName="Sex" Checked="false"/><span> その他 </span>
                        <br />
                        <h6>
                            <asp:Label ID="lblSex" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label>
                        </h6>
                        <p><span style="color: red;">* </span>電話番号：</p>
                        <asp:TextBox ID="txtPhone" runat="server" CssClass="nes-input inpContent" TextMode="Phone" /><br />
                        <h6>
                            <asp:Literal ID="ltlPhone2" runat="server">電話番号は10桁で入力してください。</asp:Literal><br />
                            <asp:Label ID="lblPhone" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label><br />
                            <asp:Label ID="lblPhone2Red" runat="server" Visible="false" ForeColor="Red">入力した電話番号に誤りがあります。</asp:Label>
                        </h6>
                        <p><span style="color: red;">* </span>メール：</p>
                        <asp:TextBox ID="txtMail" runat="server" CssClass="nes-input inpContent" TextMode="Email" /><br />
                        <h6>
                            <asp:Literal ID="ltlGMail" runat="server">Gmailのみです。</asp:Literal><br />
                            <asp:Label ID="lblMail" runat="server" Visible="false" ForeColor="Red">この項目は必須です。</asp:Label><br />
                            <asp:Label ID="lblMail2Red" runat="server" Visible="false" ForeColor="Red">入力したメールに誤りがあります。</asp:Label>
                        </h6>
                        <div class="col-12 justify-content-end">
                            <asp:Button ID="btnMemberInfoCheck" runat="server" Text="確認" CssClass="nes-btn loginBtn" OnClick="btnMemberInfoCheck_Click" />
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
