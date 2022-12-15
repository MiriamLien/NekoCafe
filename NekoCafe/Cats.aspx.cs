using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe
{
    public partial class Cats : System.Web.UI.Page
    {
        private CatManager _mgrCat = new CatManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.plcOC2.Visible = false;
                this.plcDC.Visible = false;
                this.plcBC.Visible = false;
                this.plcDMC.Visible = false;
                this.plcWC.Visible = false;
                this.plcWC2.Visible = false;
                this.plcOC.Visible = false;
                this.plcSC.Visible = false;

                this.rptCat1.DataSource = this._mgrCat.GetCCList(1);
                this.rptCat1.DataBind();
                this.rptCat2.DataSource = this._mgrCat.GetCCList(2);
                this.rptCat2.DataBind();
                this.rptCat3.DataSource = this._mgrCat.GetCCList(3);
                this.rptCat3.DataBind();
                this.rptCat4.DataSource = this._mgrCat.GetCCList(4);
                this.rptCat4.DataBind();
                this.rptCat5.DataSource = this._mgrCat.GetCCList(5);
                this.rptCat5.DataBind();
                this.rptCat6.DataSource = this._mgrCat.GetCCList(6);
                this.rptCat6.DataBind();
                this.rptCat7.DataSource = this._mgrCat.GetCCList(7);
                this.rptCat7.DataBind();
                this.rptCat8.DataSource = this._mgrCat.GetCCList(8);
                this.rptCat8.DataBind();
            }
        }

        protected void btnOC2_Click(object sender, ImageClickEventArgs e)
        {
            this.plcOC2.Visible = true;
            this.plcDC.Visible = false;
            this.plcBC.Visible = false;
            this.plcDMC.Visible = false;
        }

        protected void btnDC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcOC2.Visible = false;
            this.plcDC.Visible = true;
            this.plcBC.Visible = false;
            this.plcDMC.Visible = false;
        }

        protected void btnBC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcOC2.Visible = false;
            this.plcDC.Visible = false;
            this.plcBC.Visible = true;
            this.plcDMC.Visible = false;
        }

        protected void btnDMC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcOC2.Visible = false;
            this.plcDC.Visible = false;
            this.plcBC.Visible = false;
            this.plcDMC.Visible = true;
        }

        protected void btnWC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcWC.Visible = true;
            this.plcWC2.Visible = false;
            this.plcOC.Visible = false;
            this.plcSC.Visible = false;
        }

        protected void btnWC2_Click(object sender, ImageClickEventArgs e)
        {
            this.plcWC.Visible = false;
            this.plcWC2.Visible = true;
            this.plcOC.Visible = false;
            this.plcSC.Visible = false;
        }

        protected void btnOC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcWC.Visible = false;
            this.plcWC2.Visible = false;
            this.plcOC.Visible = true;
            this.plcSC.Visible = false;
        }

        protected void btnSC_Click(object sender, ImageClickEventArgs e)
        {
            this.plcWC.Visible = false;
            this.plcWC2.Visible = false;
            this.plcOC.Visible = false;
            this.plcSC.Visible = true;
        }
    }
}