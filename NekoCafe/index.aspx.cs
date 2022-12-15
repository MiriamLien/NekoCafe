using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe
{
    public partial class index : System.Web.UI.Page
    {
        BulletinManager _mgrBulletin = new BulletinManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            var concept = this._mgrBulletin.GetBulletin(this.lblConcept.Text);
            var conceptlist = this._mgrBulletin.AnalyzeContent_newLine(concept);
            this.rptConceptContent.DataSource = conceptlist ;
            this.rptConceptContent.DataBind();

            var cost = this._mgrBulletin.GetBulletin(this.lblCost.Text);
            var costlist = this._mgrBulletin.AnalyzeContent_newLine(cost);
            this.rptCostContent.DataSource = costlist;
            this.rptCostContent.DataBind();

            var notice = this._mgrBulletin.GetBulletin(this.lblNotice.Text);
            var noticelist = this._mgrBulletin.AnalyzeContent_newLine(notice);
            this.rptNoticeContent.DataSource = noticelist;
            this.rptNoticeContent.DataBind();
        }
    }
}