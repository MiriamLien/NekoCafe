using NekoCafe.CatCafe.ORM;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Linq;

namespace NekoCafe
{
    public partial class ReservationPage : System.Web.UI.Page
    {
        private ReservationManager _mgrReservation = new ReservationManager();
        private OrderItemManager _mgrOrderItem = new OrderItemManager();
        private AccountManager _mgrAccount = new AccountManager();
        private MemberManager _mgrMember = new MemberManager();
        private OrderManager _mgrOrder = new OrderManager();
        private ItemManager _mgrItem = new ItemManager();
        private List<OIModel> _memberOrder = new List<OIModel>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this._memberOrder.Clear();

                //咖啡下拉選單
                var coffelist = this._mgrItem.GetItemAndPriceList(1);
                this.ddlCoffee.DataSource = coffelist;
                this.ddlCoffee.DataValueField = "ItemID";
                this.ddlCoffee.DataTextField = "NamePrice";
                this.ddlCoffee.DataBind();

                //茶類下拉選單
                var tealist = this._mgrItem.GetItemAndPriceList(2);
                this.ddlTea.DataSource = tealist;
                this.ddlTea.DataValueField = "ItemID";
                this.ddlTea.DataTextField = "NamePrice";
                this.ddlTea.DataBind();

                //點心下拉選單
                var dessertlist = this._mgrItem.GetItemAndPriceList(3);
                this.ddlDessert.DataSource = dessertlist;
                this.ddlDessert.DataValueField = "ItemID";
                this.ddlDessert.DataTextField = "NamePrice";
                this.ddlDessert.DataBind();

                //其他下拉選單
                var otherlist = this._mgrItem.GetItemAndPriceList(4);
                this.ddlOthers.DataSource = otherlist;
                this.ddlOthers.DataValueField = "ItemID";
                this.ddlOthers.DataTextField = "NamePrice";
                this.ddlOthers.DataBind();
            }
        }

        protected void btnAddCoffe_Click(object sender, EventArgs e)
        {
            var amuntCheck = String.IsNullOrWhiteSpace(this.txtCoffeeAmount.Text);

            //檢查數量有沒有寫
            if (!amuntCheck)
            {
                OIModel oilist = new OIModel();

                oilist.ItemID = Convert.ToInt32(this.ddlCoffee.SelectedValue);
                var item = this._mgrItem.GetItem(oilist.ItemID);
                oilist.Name = item.Name;
                oilist.Amount = Convert.ToInt32(this.txtCoffeeAmount.Text);
                oilist.Price = item.Price * oilist.Amount;

                this.lblOrItemID.Text += oilist.ItemID.ToString() + "&";
                this.lblOrItemName.Text += oilist.Name.ToString() + "&";
                this.lblOrItemAmount.Text += oilist.Amount.ToString() + "&";
                this.lblOrItemPrice.Text += oilist.Price.ToString() + "&";

                //this._memberOrder.Add(oilist);

                //string str = string.Empty;
                //int totalPrice = 0;
                //foreach (var item2 in this._memberOrder)
                //{
                string str = oilist.Name + "   x" + oilist.Amount + "   合計" + oilist.Price + "\n\r";
                int totalPrice = oilist.Price;
                //}
                this.lblUserOrder.Text += (str + "<br />");
                int ttprice = Convert.ToInt32(this.lblUserTotalPrice.Text);
                this.lblUserTotalPrice.Text = (ttprice + totalPrice).ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数なし。')", true);
            }
        }

        protected void btnAddTea_Click(object sender, EventArgs e)
        {
            var amuntCheck = String.IsNullOrWhiteSpace(this.txtTeaAmount.Text);

            if (!amuntCheck)
            {
                OIModel oilist = new OIModel();

                oilist.ItemID = Convert.ToInt32(this.ddlTea.SelectedValue);
                var item = this._mgrItem.GetItem(oilist.ItemID);
                oilist.Name = item.Name;
                oilist.Amount = Convert.ToInt32(this.txtTeaAmount.Text);
                oilist.Price = item.Price * oilist.Amount;

                this.lblOrItemID.Text += oilist.ItemID.ToString() + "&";
                this.lblOrItemName.Text += oilist.Name.ToString() + "&";
                this.lblOrItemAmount.Text += oilist.Amount.ToString() + "&";
                this.lblOrItemPrice.Text += oilist.Price.ToString() + "&";

                //this._memberOrder.Add(oilist);

                //string str = string.Empty;
                //int totalPrice = 0;
                //foreach (var item2 in this._memberOrder)
                //{
                string str = oilist.Name + "   x" + oilist.Amount + "   合計" + oilist.Price + "\n\r";
                int totalPrice = oilist.Price;
                //}
                this.lblUserOrder.Text += (str + "<br />");
                int ttprice = Convert.ToInt32(this.lblUserTotalPrice.Text);
                this.lblUserTotalPrice.Text = (ttprice + totalPrice).ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数なし。')", true);
            }
        }

        protected void btnAddDessert_Click(object sender, EventArgs e)
        {
            var amuntCheck = String.IsNullOrWhiteSpace(this.txtDessertAmount.Text);

            if (!amuntCheck)
            {
                OIModel oilist = new OIModel();

                oilist.ItemID = Convert.ToInt32(this.ddlDessert.SelectedValue);
                var item = this._mgrItem.GetItem(oilist.ItemID);
                oilist.Name = item.Name;
                oilist.Amount = Convert.ToInt32(this.txtDessertAmount.Text);
                oilist.Price = item.Price * oilist.Amount;

                this.lblOrItemID.Text += oilist.ItemID.ToString() + "&";
                this.lblOrItemName.Text += oilist.Name.ToString() + "&";
                this.lblOrItemAmount.Text += oilist.Amount.ToString() + "&";
                this.lblOrItemPrice.Text += oilist.Price.ToString() + "&";

                this._memberOrder.Add(oilist);

                //this._memberOrder.Add(oilist);

                //string str = string.Empty;
                //int totalPrice = 0;
                //foreach (var item2 in this._memberOrder)
                //{
                string str = oilist.Name + "   x" + oilist.Amount + "   合計" + oilist.Price + "\n\r";
                int totalPrice = oilist.Price;
                //}
                this.lblUserOrder.Text += (str + "<br />");
                int ttprice = Convert.ToInt32(this.lblUserTotalPrice.Text);
                this.lblUserTotalPrice.Text = (ttprice + totalPrice).ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数なし。')", true);
            }
        }

        protected void btnAddOthers_Click(object sender, EventArgs e)
        {
            var amuntCheck = String.IsNullOrWhiteSpace(this.txtOthersAmount.Text);

            if (!amuntCheck)
            {
                OIModel oilist = new OIModel();

                oilist.ItemID = Convert.ToInt32(this.ddlOthers.SelectedValue);
                var item = this._mgrItem.GetItem(oilist.ItemID);
                oilist.Name = item.Name;
                oilist.Amount = Convert.ToInt32(this.txtOthersAmount.Text);
                oilist.Price = item.Price * oilist.Amount;

                this.lblOrItemID.Text += oilist.ItemID.ToString() + "&";
                this.lblOrItemName.Text += oilist.Name.ToString() + "&";
                this.lblOrItemAmount.Text += oilist.Amount.ToString() + "&";
                this.lblOrItemPrice.Text += oilist.Price.ToString() + "&";

                this._memberOrder.Add(oilist);

                //this._memberOrder.Add(oilist);

                //string str = string.Empty;
                //int totalPrice = 0;
                //foreach (var item2 in this._memberOrder)
                //{
                string str = oilist.Name + "   x" + oilist.Amount + "   合計" + oilist.Price + "\n\r";
                int totalPrice = oilist.Price;
                //}
                this.lblUserOrder.Text += (str + "<br />");
                int ttprice = Convert.ToInt32(this.lblUserTotalPrice.Text);
                this.lblUserTotalPrice.Text = (ttprice + totalPrice).ToString();
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('数なし。')", true);
            }
        }

        //確認按鈕 > 送資料庫
        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            this.lblDate.Text = this.HiddenField1.Value;
            this.lblTime.Text = this.HiddenField2.Value;
            this.lblPeo.Text = this.HiddenField3.Value;

            //檢查有沒有選日期人數時段
            try
            {
                if (this.lblDate.Text != "0" && this.lblTime.Text != "0" && this.lblPeo.Text != "0")
                {
                    if (this._mgrAccount.IsLogined())
                    {
                        Account account = this._mgrAccount.GetCurrentUser();
                        MemberInfo memberInfo = this._mgrMember.GetMember(account.AccountID);

                        //取得訂單
                        OrderModel order = new OrderModel()
                        {
                            AccountID = account.AccountID,
                            Date = DateTime.Parse(this.lblDate.Text),
                            Time = DateTime.Parse(this.lblTime.Text),
                            NPR = int.Parse(this.lblPeo.Text)
                        };

                        this._mgrOrder.CreateOrder(order);
                        var newOrder = this._mgrOrder.GetOrderID(account.AccountID);

                        OrderItemModel ordermodel = new OrderItemModel();

                        string[] itemID = this._mgrOrderItem.AnalyzeText(this.lblOrItemID.Text);
                        string[] amount = this._mgrOrderItem.AnalyzeText(this.lblOrItemAmount.Text);
                        string[] price = this._mgrOrderItem.AnalyzeText(this.lblOrItemPrice.Text);
                        List<OrderItem> orderItems = new List<OrderItem>();
                        orderItems = this._mgrOrderItem.BuildOIList(itemID, amount, price);

                        foreach (var item in orderItems)
                        {
                            ordermodel.OrderID = newOrder.OrderID;
                            ordermodel.ItemID = item.ItemID;
                            ordermodel.Amount = item.Amount;
                            ordermodel.Price = item.Price;

                            this._mgrOrderItem.CreateOrderItem(ordermodel);
                        }

                        ReservationModel newReservation = new ReservationModel()
                        {
                            OrderID = newOrder.OrderID,
                            Name = memberInfo.Name,
                            Sex = memberInfo.Sex,
                            Phone = memberInfo.Phone,
                            Mail = memberInfo.Mail,
                            Note = null
                        };

                        this._mgrReservation.CreateReservation(newReservation.OrderID, newReservation);

                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('予約完了。');location.href='Index.aspx';", true);
                    }
                    else
                    {
                        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('連絡先を入力してください。')", true);

                        this.plcInfo.Visible = true;
                        this.plcOrder.Visible = false;
                        this.btnConfirm.Visible = false;
                    }
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ご希望の時間帯を選択してください。')", true);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //確認按鈕 > 非會員 填寫個人資訊
        protected void plcInfo_btnCheck_Click(object sender, EventArgs e)
        {
            string sex = string.Empty;
            if (this.rdbtnF.Checked == true || this.rdbtnM.Checked == true || this.rdbtnO.Checked == true)
            {
                if (this.rdbtnF.Checked == true)
                    sex = "M";
                else if (this.rdbtnM.Checked == true)
                    sex = "F";
                else
                    sex = "Other";
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('未入力項目があります。')", true);
            }

            bool isPhoneRight = false;
            bool isMailRight = false;
            bool isNameRight = false;
            bool isSexRight = false;

            bool telCheck = Regex.IsMatch(this.txtPhone.Text.Trim(), @"^09[0-9]{8}$");
            bool mailCheck = Regex.IsMatch(this.txtMail.Text.Trim(), @"@gmail.com$");

            //name
            if (string.IsNullOrWhiteSpace(this.txtName.Text))
                this.lblName.Visible = true;
            else
            {
                isNameRight = true;
                this.lblName.Visible = false;
            }

            //sex
            if (string.IsNullOrWhiteSpace(sex))
                this.lblSex.Visible = true;
            else
            {
                isSexRight = true;
                this.lblSex.Visible = false;
            }

            //phone
            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
                this.lblPhone.Visible = true;
            else if (telCheck)
            {
                this.lblPhone.Visible = false;
                isPhoneRight = true;
                this.lblPhone2Red.Visible = false;
            }
            else
            {
                this.lblPhone2Red.Visible = true;
                this.lblPhone.Visible = false;
            }

            //mail
            if (string.IsNullOrWhiteSpace(this.txtMail.Text))
                this.lblMail.Visible = true;
            else if (mailCheck)
            {
                this.lblMail.Visible = false;
                this.lblMail2Red.Visible = false;
                isMailRight = true;
            }
            else
            {
                this.lblMail2Red.Visible = true;
                this.lblMail.Visible = false;
            }

            if (isNameRight && isSexRight && isPhoneRight && isMailRight)
            {
                //取得訂單
                OrderModel order = new OrderModel()
                {
                    Date = DateTime.Parse(this.lblDate.Text),
                    Time = DateTime.Parse(this.lblTime.Text),
                    NPR = int.Parse(this.lblPeo.Text)
                };

                this._mgrOrder.CreateOrder(order);

                var newOrder = this._mgrOrder.GetOrder();

                //點餐
                OrderItemModel orderItemModel = new OrderItemModel();

                foreach (var item in _memberOrder)
                {
                    orderItemModel.OrderID = newOrder.OrderID;
                    orderItemModel.ItemID = item.ItemID;
                    orderItemModel.Amount = item.Amount;
                    orderItemModel.Price = item.Price;

                    this._mgrOrderItem.CreateOrderItem(orderItemModel);
                }

                //聯絡資訊
                ReservationModel newReservation = new ReservationModel()
                {
                    OrderID = newOrder.OrderID,
                    Name = this.txtName.Text.Trim(),
                    Sex = sex,
                    Phone = this.txtPhone.Text.Trim(),
                    Mail = this.txtMail.Text.Trim(),
                    Note = this.txtNote.Text.Trim()
                };

                this._mgrReservation.CreateReservation(newReservation.OrderID, newReservation);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('予約完了。');location.href='Index.aspx';", true);
            }
            else
            {
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('未入力項目があります。')", true);
            }
        }
    }
}