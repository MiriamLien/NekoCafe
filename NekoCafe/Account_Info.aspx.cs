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
    public partial class Account_Info : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();
        private ReservationManager _mgrReservation = new ReservationManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            int level = 0;
            if (this._mgrAccount.IsLogined())
            {
                Account account = this._mgrAccount.GetCurrentUser();
                MemberInfo memberInfo = this._mgrMember.GetMember(account.AccountID);

                this.ltlName.Text = memberInfo.Name;
                this.ltlSex.Text = memberInfo.Sex;
                this.ltlPhone.Text = memberInfo.Phone;
                this.ltlMail.Text = memberInfo.Mail;


                level = this._mgrMember.LevelSelector(account.AccountID);
                if (memberInfo.Level == 4)
                    level = 4;
                if (memberInfo.Level == 10)
                    level = 10;

                this.ltlLevel.Text = "Level: " + level;
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
            if (!IsPostBack)
            {
                Account account = this._mgrAccount.GetCurrentUser();
                MemberInfo memberInfo = this._mgrMember.GetMember(account.AccountID);
                List<MRModel> memberOrderList = this._mgrReservation.GetOrderListForAccountInfo(account.AccountID);
                this.rptROR.DataSource = memberOrderList;
                this.rptROR.DataBind();

                if(memberOrderList.Count == 0)
                {
                    this.plcNoRecord.Visible = true;
                }

                MemberInfoModel mberInfo = new MemberInfoModel()
                {
                    AccountID = account.AccountID,
                    Name = memberInfo.Name,
                    Sex = memberInfo.Sex,
                    Phone = memberInfo.Phone,
                    Mail = memberInfo.Mail,
                    Level = level
                };
                this._mgrMember.UpdateMember(mberInfo);
            }
        }
        protected void btnUpdatePwd_Click(object sender, EventArgs e)
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
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", $"alert('{error}。');location.href='Account_Info.aspx';", true);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this._mgrAccount.Logout();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            Account account = this._mgrAccount.GetCurrentUser();
            Account memberAccount = this._mgrAccount.GetAccount(account.Account1);


            if (string.IsNullOrWhiteSpace(this.txtName.Text.Trim()))
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更に失敗しました。 ユーザ名は必須です。');location.href='Account_Info.aspx';", true);
            else if (string.IsNullOrWhiteSpace(this.txtPhone.Text.Trim()))
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更に失敗しました。 電話番号は必須です。');location.href='Account_Info.aspx';", true);
            else if (string.IsNullOrWhiteSpace(this.txtMail.Text.Trim()))
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更に失敗しました。 メールアドレスは必須です。');location.href='Account_Info.aspx';", true);
            else
            {
                MemberInfoModel newInfo = new MemberInfoModel()
                {
                    AccountID = memberAccount.AccountID,
                    Name = this.txtName.Text.Trim(),
                    Phone = this.txtPhone.Text.Trim(),
                    Mail = this.txtMail.Text.Trim()
                };

                this._mgrMember.UpdateMember(newInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('会員情報の変更が完了しました。');location.href='Account_Info.aspx';", true);
                //Response.Redirect(Request.RawUrl);
            }
        }
    }
}