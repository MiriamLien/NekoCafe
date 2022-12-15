using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe.BackAdmin
{
    public partial class adminHome : System.Web.UI.Page
    {
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this._mgrAccount.IsLogined())
            {
                Account account = this._mgrAccount.GetCurrentUser();
                MemberInfo memberInfo = this._mgrMember.GetMember(account.AccountID);

                if (memberInfo.Level == 10)
                {
                    this.plcAdminHome2.Visible = false;

                }
                else if (memberInfo.Level == 4)
                {
                    this.plcAdminHome1.Visible = false;
                    this.plcAdminHome2.Visible = true;
                }
                else
                {
                    Response.Redirect("~/Account_Info.aspx");
                }
            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
    }
}