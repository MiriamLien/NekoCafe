using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe
{
    public partial class Main : System.Web.UI.MasterPage
    {
        private AccountManager _mgr = new AccountManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this._mgr.IsLogined())
            {
                this.plcLogin.Visible = false;
                this.plcLogout.Visible = true;
            }
            else
            {
                this.plcLogin.Visible = true;
                this.plcLogout.Visible = false;
                this._mgr.Logout();
            }
        }
    }
}