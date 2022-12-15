using NekoCafe.CatCafe.ORM;
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
    public partial class adminReservation : System.Web.UI.Page
    {
        private OrderManager _mgrOrder = new OrderManager();
        private ReservationManager _mgrReservation = new ReservationManager();
        private OrderItemManager _mgrOrderItem = new OrderItemManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var reserList = this._mgrOrder.GetMonthORList(true);

                this.rptReservation.DataSource = reserList;
                this.rptReservation.DataBind();

                this.plcUpdate.Visible = false;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string date = this.txtSearch.Text;
            List<ORModel> list = new List<ORModel>();
            list = this._mgrOrder.GetORList(date);

            this.rptReservation.DataSource = list;
            this.rptReservation.DataBind();
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);

            var order = this._mgrOrder.GetOrder(id);
            this.txtOID.Text = order.OrderID.ToString();
            this.txtTime.Text = order.Time.ToString();
            this.txtNPR.Text = order.NPR.ToString();

            var reservation = this._mgrReservation.GetReservation(id);
            this.txtNote.Text = reservation.Note;

            this.plcUpdate.Visible = true;

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtOID.Text);
            var order = this._mgrOrder.GetOrder(id);
            var reservation = this._mgrReservation.GetReservation(id);

            try
            {
                DateTime date = Convert.ToDateTime(this.txtTime.Text.Trim()).Date;
                DateTime time = Convert.ToDateTime(this.txtTime.Text.Trim());
                int npr = Convert.ToInt32(this.txtNPR.Text.Trim());
                string note = this.txtNote.Text;

                if (date != null && time != null)
                {
                    OrderModel updateOrder = new OrderModel()
                    {
                        OrderID = order.OrderID,
                        Date = date,
                        Time = time,
                        NPR = npr,
                    };
                    ReservationModel updateReservation = new ReservationModel()
                    {
                        OrderID = reservation.OrderID,
                        Name = reservation.Name,
                        Sex = reservation.Sex,
                        Phone = reservation.Phone,
                        Mail = reservation.Mail,
                        Note = note
                    };

                    this._mgrOrder.UpdateOrder(updateOrder);
                    this._mgrReservation.UpdateReservation(updateReservation);

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminReservation.aspx';", true);
                }
                this.plcUpdate.Visible = false;
                //this.Response.Redirect(Request.RawUrl);
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminReservation.aspx';", true);
            }
        }
        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrOrderItem.DeleteOrder(id);
            this._mgrReservation.DeleteReservation(id);
            this._mgrOrder.DeleteOrder(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminReservation.aspx';", true);
            //this.Response.Redirect(Request.RawUrl);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plcUpdate.Visible = false;
        }

        protected void btnAll_Click(object sender, EventArgs e)
        {
            string txt = string.Empty;
            var reserList = this._mgrOrder.GetORList(txt);

            this.rptReservation.DataSource = reserList;
            this.rptReservation.DataBind();

            this.plcUpdate.Visible = false;
            this.plcReserv.Visible = true;
            this.plcHisReserv.Visible = false;
        }

        protected void btnHistoryReserv_Click(object sender, EventArgs e)
        {
            var reserList = this._mgrOrder.GetMonthORList(false);

            this.rptReservation.DataSource = reserList;
            this.rptReservation.DataBind();

            this.plcUpdate.Visible = false;
            this.plcReserv.Visible = true;
        }

        protected void btnThisMonReserv_Click(object sender, EventArgs e)
        {
            var reserList = this._mgrOrder.GetMonthORList(true);

            this.rptReservation.DataSource = reserList;
            this.rptReservation.DataBind();

            this.plcUpdate.Visible = false;
            this.plcReserv.Visible = true;
        }
    }
}