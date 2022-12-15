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
    public partial class adminAccount : System.Web.UI.Page
    {
        private ReservationManager _mgrReser = new ReservationManager();
        private OrderItemManager _mgrOrderItem = new OrderItemManager(); 
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();
        private OrderManager _mgrOrder = new OrderManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.txtSearch.Text = string.Empty;
                var accountList = this._mgrAccount.GetAccountList(this.txtSearch.Text);
                this.rptAccount.DataSource = accountList;
                this.rptAccount.DataBind();

                this.plcAccUpdate.Visible = false;
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            this.rptAccount.Visible = true;
            this.rptMember.Visible = false;

            string txt = this.txtSearch.Text;
            var accountList = this._mgrAccount.GetAccountList(txt);
            this.rptAccount.DataSource = accountList;
            this.rptAccount.DataBind();
        }

        protected void btnMember_Click(object sender, EventArgs e)
        {
            this.rptMember.Visible = true;
            this.rptAccount.Visible = false;

            var memberlist = this._mgrAccount.GetMemberORAdminList(false);
            this.rptMember.DataSource = memberlist;
            this.rptMember.DataBind();
        }

        protected void btnStaff_Click(object sender, EventArgs e)
        {
            this.rptMember.Visible = true;
            this.rptAccount.Visible = false;

            var memberlist = this._mgrAccount.GetMemberORAdminList(true);
            this.rptMember.DataSource = memberlist;
            this.rptMember.DataBind();
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            this.rptAccount.Visible = true;
            this.rptMember.Visible = false;

            this.txtSearch.Text = string.Empty;
            var accountList = this._mgrAccount.GetAccountList(this.txtSearch.Text);
            this.rptAccount.DataSource = accountList;
            this.rptAccount.DataBind();
        }

        protected void btnAccUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var acc = this._mgrAccount.GetAccount(id);
            this.txtID.Text = acc.AccountID.ToString();
            this.txtAcc.Text = acc.Account1.ToString();
            this.txtPass.Text = acc.Password.ToString();
            this.txtDate.Text = acc.CreateDate.ToString();

            this.plcAccUpdate.Visible = true;
        }

        protected void btnAccDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var orID = this._mgrOrder.GetOrderIDList(id);

            foreach (var item in orID)
            {
                int a = item.OrderID;
                this._mgrOrderItem.DeleteOrder(a);
                this._mgrReser.DeleteReservation(a);
                this._mgrOrder.DeleteOrder(a);
            }

            this._mgrMember.DeleteMember(id);
            this._mgrAccount.DeleteAccount(id);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminAccount.aspx';", true);
        }

        protected void btnMemUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var acc = this._mgrAccount.GetAccount(id);
            this.txtID.Text = acc.AccountID.ToString();
            this.txtAcc.Text = acc.Account1.ToString();
            this.txtPass.Text = acc.Password.ToString();
            this.txtDate.Text = acc.CreateDate.ToString();

            this.plcAccUpdate.Visible = true;
        }

        protected void btnMemDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrAccount.DeleteAccount(id);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminAccount.aspx';", true);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtID.Text);
            var acc = this._mgrAccount.GetAccount(id);

            try
            {
                string account = this.txtAcc.Text;
                string password = this.txtPass.Text;
                AccountModel updateAccount = new AccountModel()
                {
                    AccountID = acc.AccountID,
                    Account = account,
                    CreateDate = acc.CreateDate,
                    Password = password,
                };

                this._mgrAccount.UpdateAccount(updateAccount);
                this._mgrAccount.UpdatePassword(updateAccount);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminAccount.aspx';", true);
                this.plcAccUpdate.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminAccount.aspx';", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plcAccUpdate.Visible = false;
        }
    }
}