using NekoCafe.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace NekoCafe
{
    public partial class Event : System.Web.UI.Page
    {
        BulletinManager _mgrBulletin = new BulletinManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.plcEvent.Visible = false;
                var news = this._mgrBulletin.GetBulletinList("news-");
                news = this._mgrBulletin.RemoveNewsInTitle(news);
                this.rptEventbtn.DataSource = news;
                this.rptEventbtn.DataBind();
            }

        }

        public void ImageChange()
        {

        }

        protected void btnEvent_Command(object sender, CommandEventArgs e)
        {
            string title = e.CommandName;
            this.lblTitle.Text = title;
            title = "news-" + title;
            var news = this._mgrBulletin.GetBulletinList(title);
            var newsContent = this._mgrBulletin.AnalyzeContent_newLine(news);
            var article = this._mgrBulletin.AnalyzeContent_img(newsContent);
            this.rptEventContent.DataSource = article;
            this.rptEventContent.DataBind();
            this.plcEvent.Visible = true;
        }
    }
}