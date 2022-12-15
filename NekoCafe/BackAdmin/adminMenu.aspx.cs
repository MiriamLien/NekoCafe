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
    public partial class adminMenu : System.Web.UI.Page
    {
        private ItemManager _mgrItem = new ItemManager();
        public string alertMessage { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string txt = string.Empty;
                var itemList = this._mgrItem.GetItemList(txt);
                this.rptMenu.DataSource = itemList;
                this.rptMenu.DataBind();

                this.plcAdd.Visible = false;
                this.plcUpdate.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearch.Text;
            var itemSearchList = this._mgrItem.GetItemList(txt);
            this.rptMenu.DataSource = itemSearchList;
            this.rptMenu.DataBind();
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            string txt = string.Empty;
            var itemList = this._mgrItem.GetItemList(txt);
            this.rptMenu.DataSource = itemList;
            this.rptMenu.DataBind();

            this.plcAdd.Visible = false;
            this.plcUpdate.Visible = false;
        }

        protected void btnAddMenu_Click(object sender, EventArgs e)
        {
            this.plcAdd.Visible = true;
            this.plcUpdate.Visible = false;
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);

            var item = this._mgrItem.GetItem(id);
            this.txtCode.Text = item.ItemID.ToString();
            this.txtItemName.Text = item.Name.ToString();
            this.txtPrice.Text = item.Price.ToString();

            this.plcUpdate.Visible = true;
            this.plcAdd.Visible = false;
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrItem.DeleteItem(id);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminMenu.aspx';", true);

            //this.Response.Redirect(Request.RawUrl);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtCode.Text);
            var item = this._mgrItem.GetItem(id);

            try
            {
                string itemName = this.txtItemName.Text;
                int price = Convert.ToInt32(this.txtPrice.Text);
                ItemModel updateMenu = new ItemModel()
                {
                    ItemClassID = item.ItemClassID,
                    ItemID = item.ItemID,
                    Name = itemName,
                    Price = price
                };

                this._mgrItem.UpdateItem(updateMenu);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminMenu.aspx';", true);
                this.plcUpdate.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminMenu.aspx';", true);
            }

            //this.Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plcUpdate.Visible = false;
            this.plcAdd.Visible = false;
        }

        protected void btnAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                int itemClassID = Convert.ToInt32(this.ddlItemClassID.SelectedValue);
                string itemName = this.addItemName.Text;
                int price = Convert.ToInt32(this.addPrice.Text);
                ItemModel addMenu = new ItemModel()
                {
                    ItemClassID = itemClassID,
                    Name = itemName,
                    Price = price
                };

                this._mgrItem.CreateItem(addMenu);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了。');location.href='adminMenu.aspx';", true);

                this.plcAdd.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminMenu.aspx';", true);
            }
            //this.Response.Redirect(Request.RawUrl);
        }

        protected void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.plcAdd.Visible = false;
            this.plcUpdate.Visible = false;
        }
    }
}