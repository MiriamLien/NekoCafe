<%@ Page Title="" Language="C#" MasterPageFile="~/Main.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="NekoCafe.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container bgc-content">
        <div id="header-space-home" class="row"></div>
        <div id="index-content" class="container-fluid">
            <div class="row bgc-content2">
                <div class="col-md-3 offset-md-9">
                    <img id="hand-img" src="img/home/paw.png" />
                </div>
                <div class="col-lg-4 col-sm-12 ">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label ID="lblConcept" runat="server" Text="コンセプト" CssClass="h3"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Repeater ID="rptConceptContent" runat="server">
                                <ItemTemplate>
                                    <asp:Label ID="lblConceptContent" runat="server" Text='<%#Eval("Content") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ul>
                    <div>&nbsp;</div>
                </div>
                <div class="col-lg-4 col-sm-12 ">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label ID="lblCost" runat="server" Text="料金プラン" CssClass="h3"></asp:Label>
                        </li>
                        <li class="list-group-item">
                            <asp:Repeater ID="rptCostContent" runat="server">
                                <ItemTemplate>
                                    <asp:Label ID="lblCostContent" runat="server" Text='<%#Eval("Content") %>'></asp:Label>
                                    <br />
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ul>
                    <div>&nbsp;</div>
                </div>
                <div class="col-lg-4 col-sm-12 ">
                    <ul class="list-group list-group-flush">
                        <li class="list-group-item">
                            <asp:Label ID="lblNotice" runat="server" Text="入店時の注意事項" CssClass="h3"></asp:Label>
                        </li>
                        <asp:Repeater ID="rptNoticeContent" runat="server">
                            <ItemTemplate>
                                <li class="list-group-item">
                                    <asp:Label ID="lblNoticeContent" runat="server" Text='<%#Eval("Content") %>'></asp:Label>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div style="height:130px"</div>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
