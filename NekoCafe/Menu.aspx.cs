using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe
{
    public partial class Menu : System.Web.UI.Page
    {
        private ItemManager _mgrItem = new ItemManager();
        private BulletinManager _mgrBu = new BulletinManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            var coffelist = this._mgrItem.GetItemClassList(1);
            this.rptCoffee.DataSource = coffelist;
            this.rptCoffee.DataBind();

            var tealist = this._mgrItem.GetItemClassList(2);
            this.rptTea.DataSource = tealist;
            this.rptTea.DataBind();

            var dessertlist = this._mgrItem.GetItemClassList(3);
            this.rptDessert.DataSource = dessertlist;
            this.rptDessert.DataBind();

            var otherlist = this._mgrItem.GetItemClassList(4);
            this.rptOther.DataSource = otherlist;
            this.rptOther.DataBind();

            var osusume = this._mgrBu.GetBPList("おすすめ");
            this.rptOsu.DataSource = osusume;
            this.rptOsu.DataBind();
        }
    }
}