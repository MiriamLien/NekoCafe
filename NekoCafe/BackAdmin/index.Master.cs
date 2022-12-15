using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe.BackAdmin
{
    public partial class index : System.Web.UI.MasterPage
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
                }
                else if(memberInfo.Level == 4)
                {
                    this.linkPermissions.Visible = false;
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

        protected void logout_ServerClick(object sender, EventArgs e)
        {
            this._mgrAccount.Logout();
            Response.Redirect("~/Login.aspx");
        }
    }
}