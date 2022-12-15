using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace NekoCafe.BackAdmin
{
    public partial class adminPermissions : System.Web.UI.Page
    {
        private PermissionsManager _mgrPermissions = new PermissionsManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtSearch.Text = string.Empty;
                var PermissionsList = this._mgrPermissions.GetPermissionsList();
                this.rptPermissions.DataSource = PermissionsList;
                this.rptPermissions.DataBind();

                this.plcUpdate.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearch.Text;
            var permissionsList = this._mgrPermissions.GetPermissionsList(txt);
            this.rptPermissions.DataSource = permissionsList;
            this.rptPermissions.DataBind();
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            this.txtSearch.Text = string.Empty;
            var PermissionsList = this._mgrPermissions.GetPermissionsList();
            this.rptPermissions.DataSource = PermissionsList;
            this.rptPermissions.DataBind();
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);

            var permissions = this._mgrPermissions.GetPermissions(id);
            this.txtID.Text = permissions.AccountID.ToString();
            this.txtAccount.Text = permissions.Account.ToString();
            this.ddlLevel.SelectedValue = permissions.Level.ToString();

            this.plcUpdate.Visible = true;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtID.Text);
            var item = this._mgrPermissions.GetPermissions(id);

            try
            {
                string account = this.txtAccount.Text;
                int level = Convert.ToInt32(this.ddlLevel.SelectedValue);
                ALModel updatePermissions = new ALModel()
                {
                    AccountID = item.AccountID,
                    Account = account,
                    Level = level
                };

                this._mgrPermissions.UpdatePermissions(updatePermissions);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminPermissions.aspx';", true);
                this.plcUpdate.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminPermissions.aspx';", true);
            }

            //this.Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plcUpdate.Visible = false;
        }
    }
}