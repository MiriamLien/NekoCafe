using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace NekoCafe
{
    public partial class Login : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this._mgrAccount.IsLogined())
            {
                this.plcLogout.Visible = true;
                this.plcLogin.Visible = false;

                Account account = this._mgrAccount.GetCurrentUser();

                this.txtMemberAccount.Text = account.Account1;
            }
            else
            {
                this.plcLogin.Visible = true;
                this.plcLogout.Visible = false;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text.Trim();
            string password = this.txtPassword.Text.Trim();

            if (this._mgrAccount.TryLogin(account, password))
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('アカウント又はパスワードが間違っています。');location.href='Login.aspx';", true);
            }
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
            Account account = this._mgrAccount.GetCurrentUser();
            var member = this._mgrMember.GetMember(account.AccountID);

            if (member.Level == 4 || member.Level == 10)
            {
                Response.Redirect("~/BackAdmin/adminHome.aspx");
            }
            else
            {
                Response.Redirect("~/Account_Info.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this._mgrAccount.Logout();
            this.plcLogin.Visible = true;
            this.plcLogout.Visible = false;
            this.txtAccount.Text = string.Empty;
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/NewAccount.aspx");
        }
    }
}