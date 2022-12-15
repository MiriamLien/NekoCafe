<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/BackAdmin/index.Master" AutoEventWireup="true" CodeBehind="adminNews.aspx.cs" Inherits="NekoCafe.BackAdmin.adminNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="adminMain2">
        <h3>お知らせ・記事一覧</h3>
        <asp:Button ID="btnNews" runat="server" Text="お知らせ・記事一覧" OnClick="btnNews_Click"/>
        <asp:Button ID="btnPic" runat="server" Text="画像一覧" OnClick="btnPic_Click"/><br />
        <div style="height:8px"></div>
        <asp:PlaceHolder ID="plcBtnForNews" runat="server">
            <asp:Button runat="server" ID="btnAddNews" Text="お知らせ追加" OnClick="btnAddNews_Click" />
            &emsp; &emsp;
            <asp:TextBox runat="server" ID="txtSearchNews"></asp:TextBox>
            &nbsp;
            <asp:Button runat="server" ID="btnSearchNews" Text="検索" OnClick="btnSearchNews_Click" />
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcBtnForPic" runat="server">
            <asp:Button runat="server" ID="btnAddPic" Text="画像を追加" OnClick="btnAddPic_Click" />
            &emsp; &emsp;
            <asp:TextBox runat="server" ID="txtSearchPic"></asp:TextBox>
            &nbsp;
            <asp:Button runat="server" ID="btnSearchPic" Text="検索" OnClick="btnSearchPic_Click"/>
        </asp:PlaceHolder>
        <div style="height:8px"></div>
        <asp:PlaceHolder ID="plcAddPic" runat="server">
            <h4>画像を追加</h4>
            <div>
                <p>
                    画像：<asp:FileUpload ID="fuPic" runat="server" />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>&emsp; 
                </p>
                <div>
                    <asp:Button ID="btnAddOnlyPic" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddOnlyPic_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancelPic" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancelPic_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcAddNews" runat="server">
            <div>
                <h4>お知らせ追加</h4>
                <div>
                    <p>
                        画像パス：<asp:FileUpload ID="fuPic1" runat="server" />
                        <asp:Label ID="lblMsg1" runat="server"></asp:Label>&emsp; 
                        <asp:Button ID="btnAddPicToArticle1" runat="server" Text="+" OnClick="btnAddPicToArticle1_Click" />
                    </p>
                    <%--<p>
                        画像パス：<asp:FileUpload ID="fuPic2" runat="server" />
                        <asp:Label ID="lblMsg2" runat="server"></asp:Label>&emsp; 
                        <asp:Button ID="btnAddPicToArticle2" runat="server" Text="+" OnClick="btnAddPicToArticle2_Click" />
                    </p>
                    <p>
                        画像パス：<asp:FileUpload ID="fuPic3" runat="server" />
                        <asp:Label ID="lblMsg3" runat="server"></asp:Label>&emsp; 
                        <asp:Button ID="btnAddPicToArticle3" runat="server" Text="+" OnClick="btnAddPicToArticle3_Click" />
                    </p>--%>
                    <p><asp:Label ID="lblUnsuccess" runat="server" Text="アップロードに失敗しました。" Visible="false"></asp:Label></p>
                    <p>作成日：<asp:TextBox ID="addBulletinDate" runat="server" TextMode="DateTime"></asp:TextBox></p>
                    <p>タイトル：<asp:TextBox ID="addTitle" runat="server"></asp:TextBox><br />
                        &nbsp;&nbsp;&nbsp;(お知らせ追加したい場合 前にnews-を入カください ex:news-Title)</p>
                    <p>コンテンツ：<asp:TextBox ID="addContents" runat="server" TextMode="MultiLine" Width="750px"></asp:TextBox><br />
                        &nbsp;&nbsp;&nbsp;(コンテンツに画像を入れたいの場合、所定のフォーマットでご記入下さい：@imgファイルパス@img。)
                    </p>
                    <p><asp:TextBox ID="addPicID" runat="server" TextMode="Number" Visible="false"></asp:TextBox></p>
                    <p></p>
                </div>
                <div>
                    <asp:Button ID="btnAddSave" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnAddSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnAddCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnAddCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcUpdateNews" runat="server">
            <div>
                <h4>お知らせ変更</h4>
                <div>
                    <p>ID：<asp:TextBox ID="txtBulletinID" runat="server" TextMode="Number" Enabled="false"></asp:TextBox></p>
                    <p>作成日：<asp:TextBox ID="txtBulletinDate" runat="server" TextMode="DateTime" Enabled="false"></asp:TextBox></p>
                    <p>タイトル：<asp:TextBox ID="txtTitle" runat="server"></asp:TextBox></p>
                    <p>コンテンツ：<asp:TextBox ID="txtContents" runat="server" TextMode="MultiLine" Width="750px"></asp:TextBox></p>
                    <p>PicID：<asp:TextBox ID="txtPicID" runat="server" TextMode="Number"></asp:TextBox></p>
                </div>
                <div>
                    <asp:Button ID="btnSave" runat="server" CssClass="nes-pointer" Text="保存" OnClick="btnSave_Click" />
                    &nbsp;
                    <asp:Button ID="btnCancel" runat="server" CssClass="nes-pointer" Text="キャンセル" OnClick="btnCancel_Click" />
                </div>
            </div>
        </asp:PlaceHolder>
        <p></p>
        <asp:PlaceHolder ID="plcNews" runat="server">
            <table border="1">
                <tr align="center">
                    <th>ID</th>
                    <th>作成日</th>
                    <th>タイトル</th>
                    <th>コンテンツ</th>
                    <th></th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptNews">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="60px"><%# Eval("BulletinID") %></td>
                            <td width="100px"><%# Eval("CreateDate") %> </td>
                            <td width="150px"><%# Eval("Title") %> </td>
                            <td width="450px" align="left"><%# Eval("Content") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnUpdate" data-bs-toggle="modal" data-bs-target="#UpdateModal" CommandName='<%# Eval("BulletinID") %>' runat="server" Text="変更" OnCommand="btnUpdate_Command" /></td>
                            <td width="60px">
                                <asp:Button ID="btnDelete" CommandName='<%# Eval("BulletinID") %>' runat="server" Text="削除" OnCommand="btnDelete_Command" OnClientClick="return confirm('削除してもよろしいですか？')"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="plcPic" runat="server">
            <table border="1">
                <tr align="center">
                    <th>ID</th>
                    <th>画像パス</th>
                    <th></th>
                </tr>
                <asp:Repeater runat="server" ID="rptPic">
                    <ItemTemplate>
                        <tr align="center">
                            <td width="60px"><%# Eval("PicID") %></td>
                            <td width="500px"><%# Eval("PicRoute") %> </td>
                            <td width="60px">
                                <asp:Button ID="btnDeletePic" CommandName='<%# Eval("PicID") %>' runat="server" Text="削除" OnCommand="btnDeletePic_Command" OnClientClick="return confirm('削除してもよろしいですか？')"/></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </table>
        </asp:PlaceHolder>
    </div>
</asp:Content>
