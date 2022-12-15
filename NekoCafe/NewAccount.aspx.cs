using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace NekoCafe
{
    public partial class NewAccount : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.plcNewAcc.Visible = true;
                this.plcNewMember.Visible = false;
                this.lblSameAcc.Visible = false;

                //重置資料
                this.txtAccount.Text = string.Empty;
                this.txtPassword.Text = string.Empty;
                this.txtPasswordCheck.Text = string.Empty;
                this.txtName.Text = string.Empty;
                this.txtPhone.Text = string.Empty;
                this.txtMail.Text = string.Empty;
                this.rdbMale.Checked = false;
                this.rdbFemale.Checked = false;
                this.rdbOther.Checked = false;
            }
        }

        protected void btnAccCheck_Click(object sender, EventArgs e)
        {
            this.lblSameAcc.Visible = false;
            this.lblUnsamePwd.Visible = false;

            bool isAccRight = false; 
            bool isPwdRight = false;
            bool isPwdCRight = false;
                
            isAccRight = !string.IsNullOrWhiteSpace(this.txtAccount.Text);
            isPwdRight = !string.IsNullOrWhiteSpace(this.txtPassword.Text);
            isPwdCRight = !string.IsNullOrWhiteSpace(this.txtPasswordCheck.Text);

            bool result = (isAccRight && isPwdRight && isPwdCRight);
            if (!result)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('アカウントとパスワードを入力してください。');location.href='NewAccount.aspx';", true);
                return;
            }

            if (this._mgrAccount.GetAccount(this.txtAccount.Text) != null)
                this.lblSameAcc.Visible = true;
            else if (this.txtPassword.Text != this.txtPasswordCheck.Text)
                this.lblUnsamePwd.Visible = true;
            else
            {
                this.plcNewAcc.Visible = false;
                this.lblSameAcc.Visible = false;
                this.lblUnsamePwd.Visible = false;
                this.plcNewMember.Visible = true;
            }
        }

        protected void btnMemberInfoCheck_Click(object sender, EventArgs e)
        {
            this.lblName.Visible = false;
            this.lblSex.Visible = false;
            this.lblPhone.Visible = false;
            this.lblMail.Visible = false;

            bool isNameRight = false;
            bool isSexRight = false;
            bool isPhoneRight = false;
            bool isMailRight = false;

            if (string.IsNullOrWhiteSpace(this.txtName.Text))
                this.lblName.Visible = true;
            else
            {
                this.lblName.Visible = false;
                isNameRight = true;
            }

            string sex = string.Empty;
            if (this.rdbMale.Checked || this.rdbFemale.Checked || this.rdbOther.Checked)
            {
                if (this.rdbMale.Checked)
                    sex = "男";
                else if (this.rdbFemale.Checked)
                    sex = "女";
                else
                    sex = "その他";
                
                isSexRight = true;
                this.lblSex.Visible = false;
            }
            else
                this.lblSex.Visible = true;

            bool telCheck = Regex.IsMatch(this.txtPhone.Text.Trim(), @"^09[0-9]{8}$");

            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
                this.lblPhone.Visible = true;
            else if (telCheck)
            {
                this.lblPhone.Visible = false;
                isPhoneRight = true;
                this.lblPhone2Red.Visible = false;
            }
            else
            {
                this.lblPhone2Red.Visible = true;
                this.lblPhone.Visible = false;
            }

            bool mailCheck = Regex.IsMatch(this.txtMail.Text.Trim(), @"@gmail.com$");

            if (string.IsNullOrWhiteSpace(this.txtMail.Text))
                this.lblMail.Visible = true;
            else if (mailCheck)
            {
                this.lblMail.Visible = false;
                this.lblMail2Red.Visible = false;
                isMailRight = true;
            }
            else
            {
                this.lblMail2Red.Visible = true;
                this.lblMail.Visible = false;
            }


            //上述條件皆達成，才寫入資料庫
            bool result = (isNameRight && isSexRight && isPhoneRight && isMailRight);

            AccountModel member = new AccountModel()
            {
                Account = this.txtAccount.Text.Trim(),
                Password = this.txtPassword.Text.Trim()
            };

            MemberInfoModel memberInfo = new MemberInfoModel()
            {
                Name = this.txtName.Text.Trim(),
                Sex = sex,
                Phone = this.txtPhone.Text.Trim(),
                Mail = this.txtMail.Text.Trim()
            };

            if (result)
            {
                this._mgrAccount.CreateAccount(member);
                Account newAcc = this._mgrAccount.GetAccount(member.Account);
                int newID = newAcc.AccountID;
                this._mgrMember.CreateMember(newID,memberInfo);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('アカウント作成が完了しました。');location.href='Login.aspx';", true);
                //Response.Redirect("~/Login.aspx");
            } 
        }
    }
}