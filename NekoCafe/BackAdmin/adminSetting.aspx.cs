using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace NekoCafe.BackAdmin
{
    public partial class adminSetting : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePwd_Click(object sender, EventArgs e)
        {
            bool isPwdRight = false;
            bool isNewPwdRight = false;
            string error = string.Empty;

            Account account = this._mgrAccount.GetCurrentUser();
            Account memberAccount = this._mgrAccount.GetAccount(account.Account1);

            if (string.IsNullOrWhiteSpace(this.txtNewPwd.Text.Trim()))
                error = "変更に失敗しました。 新しいパスワードは必須です。";
            else if (this.txtNewPwd.Text.Trim() != this.txtNewPwdCheck.Text.Trim())
                error = "変更に失敗しました。 パスワードと確認の入力内容が違います。";
            else if (this.txtNewPwd.Text.Trim() == this.txtOldPwd.Text.Trim())
                error = "変更に失敗しました。 現在のパスワードと新しいパスワードが同じです。";
            else
                isNewPwdRight = true;

            if (this.txtOldPwd.Text.Trim() != memberAccount.Password)
                error = "変更に失敗しました。 パスワードが存在しません。";
            else
                isPwdRight = true;

            bool result = isPwdRight && isNewPwdRight;

            if (result)
            {
                AccountModel member = new AccountModel()
                {
                    AccountID = memberAccount.AccountID,
                    Password = this.txtNewPwd.Text.Trim()
                };

                //執行更變密碼
                this._mgrAccount.UpdateAccount(member);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('パスワードの変更が完了しました。');location.href='Login.aspx';", true);
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('{error}。');location.href='adminSetting.aspx';", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BackAdmin/adminHome.aspx");
        }
    }
}