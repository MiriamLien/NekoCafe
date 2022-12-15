<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Account_Info.aspx.cs" Inherits="NekoCafe.Account_Info" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>マイページ</title>
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

        #accountpic {
            width: 200px;
            height: 200px;
        }

        .btnSize {
            width: 140px;
            margin-bottom: 10px;
        }

        .divspace {
            margin-bottom: 30px;
        }

        .bgc-hamburger2 {
            background-color: #edc9a5;
        }

        .div-hamburger {
            background-color: #f6f75f;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row nes-container is-rounded">
                <div class="col-12 ">
                    <h1 id="titleMemb" align="center">マイページ</h1>
                </div>
            </div>

            <div class="row nes-container is-rounded">
                <div class="col-lg-3 col-md-5 col-12 divspace">
                    <img src="img/Account_Info/cat.jpg" id="accountpic" />
                    <h4>会員情報 </h4>
                    <p>
                        <span class="badge bg-warning">
                            <asp:Literal ID="ltlLevel" runat="server" Text='<%#Eval("[Level]") %>'></asp:Literal>
                        </span>
                    </p>

                    <p>ユーザ名：<asp:Literal ID="ltlName" runat="server"></asp:Literal></p>
                    <p>性別：<asp:Literal ID="ltlSex" runat="server"></asp:Literal></p>
                    <p>電話番号：<asp:Literal ID="ltlPhone" runat="server"></asp:Literal></p>
                    <p>メールアドレス：<asp:Literal ID="ltlMail" runat="server"></asp:Literal></p>
                </div>
                <div class="col-lg-7 col-md-7 col-12 divspace">
                    <div>
                        <h4>会員レベルの機能</h4>
                        <div class="row">
                            <div class="col-12">
                                <p class="h6">会員レベルには「ダイニャーモンド会員」「ゴールニャー会員」「シルニャー会員」「レギュラー会員」があり</p>
                                <p class="h6">ダイニャーモンド会員（購入金額が合計4,000元以上のお客様）15％OFF</p>
                                <p class="h6">ゴールニャー会員（購入金額が合計2,500元以上のお客様）10％OFF</p>
                                <p class="h6">シルニャー会員（購入金額が合計1,500元以上のお客様）5％OFF</p>
                                <p class="h6">割引を使いたい場合、お支払い時にこの画面をご提示ください。</p>
                                <br />
                            </div>
                        </div>
                        <h3>予約履歴</h3>
                        <br />
                        <asp:PlaceHolder ID="plcNoRecord" runat="server" Visible="false">
                            <div class="row">
                                <div class="col-12">
                                    まだ予約記録がありません。
                                </div>
                            </div>
                        </asp:PlaceHolder>
                        <asp:Repeater ID="rptROR" runat="server">
                            <ItemTemplate>
                                <div class="row">
                                    <div class="col-12">
                                        注文番号:<asp:Literal ID="ltlOrderID" Text='<%#Eval("OrderID") %>' runat="server" /><br />
                                        <asp:Literal ID="ltlDateTime" Text='<%#Eval("Time") %>' runat="server" />&nbsp;
                                            消費金額：<asp:Literal ID="ltlSpending" Text='<%#Eval("Spending") %>' runat="server" />元
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                    </div>
                </div>
                <div class="col-lg-2 col-md-0 d-none d-lg-block">
                    <button type="button" class="nes-btn btnSize" data-bs-toggle="modal" data-bs-target="#ChangeAccInfoModal">会員情報変更</button>
                    <div class="modal" id="ChangeAccInfoModal" tabindex="-1">
                        <div class="modal-dialog">
                            <div class="modal-content nes-container">
                                <div class="modal-header">
                                    <h5 class="modal-title">会員情報変更</h5>
                                    <button type="button" class="nes-btn btn-close nes-pointer" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <p>ユーザ名：<asp:TextBox ID="txtName" runat="server" CssClass="nes-input"></asp:TextBox></p>
                                    <p>電話番号：<asp:TextBox ID="txtPhone" runat="server" CssClass="nes-input" TextMode="Phone"></asp:TextBox></p>
                                    <p>メールアドレス：<asp:TextBox ID="txtMail" runat="server" CssClass="nes-input" TextMode="Email"></asp:TextBox></p>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnUpdateInfo" runat="server" CssClass="nes-btn is-primary nes-pointer" Text="保存" OnClick="btnUpdateInfo_Click" />&nbsp;
                                    <button type="button" class="nes-btn nes-pointer" data-bs-dismiss="modal">キャンセル</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <button type="button" class="nes-btn btnSize" data-bs-toggle="modal" data-bs-target="#ChangePwdModal">パスワード変更</button>
                    <div class="modal" id="ChangePwdModal" tabindex="-1">
                        <div class="modal-dialog">
                            <div class="modal-content nes-container">
                                <div class="modal-header">
                                    <h5 class="modal-title">パスワード変更</h5>
                                    <button type="button" class="nes-btn btn-close nes-pointer" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body">
                                    <p>現在のパスワード：<asp:TextBox ID="txtOldPwd" runat="server" CssClass="nes-input" TextMode="Password"></asp:TextBox></p>
                                    <p>新しいパスワード：<asp:TextBox ID="txtNewPwd" runat="server" CssClass="nes-input" TextMode="Password"></asp:TextBox></p>
                                    <p>新しいパスワード確認：<asp:TextBox ID="txtNewPwdCheck" runat="server" CssClass="nes-input" TextMode="Password"></asp:TextBox></p>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnUpdatePwd" runat="server" CssClass="nes-btn is-primary nes-pointer" Text="保存" OnClick="btnUpdatePwd_Click" />&nbsp;
                                    <button type="button" class="nes-btn nes-pointer" data-bs-dismiss="modal">キャンセル</button>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:Button runat="server" ID="btnLogout" class="nes-btn nes-pointer btnSize" Text="ログアウト" OnClick="btnLogout_Click" />




                </div>
                <div class="col-auto d-md-block d-lg-none hamburger">
                    <nav class="navbar">
                        <button class="navbar-toggler navbar-dark bgc-hamburger2 collapsed" type="button"
                            data-bs-toggle="collapse" data-bs-target="#navbarToggleExternalContent"
                            aria-controls="navbarToggleExternalContent" aria-expanded="false"
                            aria-label="Toggle navigation">
                            <span class="navbar-toggler-icon"></span>
                        </button>
                    </nav>
                    <div class="navbar-collapse div-hamberger collapse" id="navbarToggleExternalContent">
                        <ul class="navbar-nav">
                            <li class="nav-item">
                                <button type="button" class="nes-btn btnSize" data-bs-toggle="modal" data-bs-target="#ChangeAccInfoModal">会員情報変更</button>
                            </li>
                            <li class="nav-item ">
                                <button type="button" class="nes-btn btnSize" data-bs-toggle="modal" data-bs-target="#ChangePwdModal">パスワード変更</button>
                            </li>
                            <li class="nav-item ">
                                <asp:Button runat="server" ID="btnLogout2" class="nes-btn nes-pointer btnSize" Text="ログアウト" OnClick="btnLogout_Click" />
                            </li>
                        </ul>
                    </div>
                </div>
            </div>


        </div>

    </form>
</body>
</html>
