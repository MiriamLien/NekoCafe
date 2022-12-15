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
    public partial class adminCats : System.Web.UI.Page
    {
        private CatBreedManager _mgrCatBreed = new CatBreedManager();
        private CatStateManager _mgrCatState = new CatStateManager();
        private CatManager _mgrCat = new CatManager();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.plcCats1.Visible = true;
                this.plcCats2.Visible = false;
                this.plcCats3.Visible = false;
                this.plcCat.Visible = true;
                this.plcCatState.Visible = false;
                this.plcOthers.Visible = false;
                this.plcAddCat.Visible = false;
                this.plcAddState.Visible = false;
                this.plcAddBreed.Visible = false;
                this.plcUpdateCat.Visible = false;
                this.plcUpdateCatState.Visible = false;

                string txt = string.Empty;
                var catList = this._mgrCat.GetCatList(txt);
                this.rptCats1.DataSource = catList;
                this.rptCats1.DataBind();
            }
        }

        protected void btnNekoChange_Click(object sender, EventArgs e)
        {
            this.plcCats1.Visible = true;
            this.plcCats2.Visible = false;
            this.plcCats3.Visible = false;
            this.plcCat.Visible = true;
            this.plcCatState.Visible = false;
            this.plcOthers.Visible = false;

            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;


            string txt = string.Empty;
            var catList = this._mgrCat.GetCatList(txt);
            this.rptCats1.DataSource = catList;
            this.rptCats1.DataBind();
        }

        protected void btnStatusChange_Click(object sender, EventArgs e)
        {
            this.plcCats1.Visible = false;
            this.plcCats2.Visible = true;
            this.plcCats3.Visible = false;
            this.plcCat.Visible = false;
            this.plcCatState.Visible = true;
            this.plcOthers.Visible = false;

            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;

            string txt = string.Empty;
            var catStatusList = this._mgrCatState.GetCatStatusList(txt);
            this.rptCats2.DataSource = catStatusList;
            this.rptCats2.DataBind();
        }

        protected void btnOthersChange_Click(object sender, EventArgs e)
        {
            this.plcCats1.Visible = false;
            this.plcCats2.Visible = false;
            this.plcCats3.Visible = true;
            this.plcCat.Visible = false;
            this.plcCatState.Visible = false;
            this.plcOthers.Visible = true;

            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;

            string txt = string.Empty;
            var catBreedList = this._mgrCatBreed.GetCatBreedList(txt);
            this.rptCats3.DataSource = catBreedList;
            this.rptCats3.DataBind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearch.Text;
            var catStatusList = this._mgrCatState.GetCatStatusList(txt);
            this.rptCats2.DataSource = catStatusList;
            this.rptCats2.DataBind();
        }

        #region 新增資料
        protected void btnAddNeko_Click(object sender, EventArgs e)
        {
            this.plcAddCat.Visible = true;

            var breedlist = this._mgrCatBreed.GetCatBreedList("");
            this.ddlBreedID.DataSource = breedlist;
            this.ddlBreedID.DataValueField = "CatBreedID";
            this.ddlBreedID.DataTextField = "Breed";
            this.ddlBreedID.DataBind();

            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;
            this.plcUpdateCat.Visible = false;
            this.plcUpdateCatState.Visible = false;
        }

        protected void btnAddStatus_Click(object sender, EventArgs e)
        {
            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = true;

            var catIDlist = this._mgrCat.GetCatList("");
            this.ddlCatID_as.DataSource = catIDlist;
            this.ddlCatID_as.DataValueField = "CatID";
            this.ddlCatID_as.DataTextField = "CatName";
            this.ddlCatID_as.DataBind();

            this.plcAddBreed.Visible = false;
            this.plcUpdateCat.Visible = false;
            this.plcUpdateCatState.Visible = false;
        }
        protected void btnAddOthers_Click(object sender, EventArgs e)
        {
            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = true;
            this.plcUpdateCat.Visible = false;
            this.plcUpdateCatState.Visible = false;
        }

        protected void btnAddCat_Click(object sender, EventArgs e)
        {
            try
            {
                string name = this.txtName_ac.Text.Trim();
                int breedID = Convert.ToInt32(this.ddlBreedID.SelectedValue.Trim());
                bool isMale = this.rbtMale_ac.Checked;
                string sex;
                if (isMale)
                    sex = "男の子";
                else
                    sex = "女の子";
                DateTime birth = Convert.ToDateTime(this.txtBirth_ac.Text.Trim()).Date;
                string content = this.txtContent_ac.Text.Trim();

                if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(sex) && !string.IsNullOrWhiteSpace(content))
                {
                    CatModel cat = new CatModel()
                    {
                        CatName = name,
                        CatBreedID = breedID,
                        Sex = sex,
                        Birth = birth,
                        Contents = content
                    };
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了。');location.href='adminCats.aspx';", true);


                    this._mgrCat.CreateCat(cat);
                    this.plcAddCat.Visible = false;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容が間違っています。');location.href='adminCats.aspx';", true);
            }
            finally
            {
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnAddState_Click(object sender, EventArgs e)
        {
            try
            {
                int catID = Convert.ToInt32(this.ddlCatID_as.SelectedValue.Trim());

                DateTime date = Convert.ToDateTime(this.txtDate_as.Text.Trim());
                DateTime time = Convert.ToDateTime(this.txtTime_as.Text.Trim());
                DateTime datetime = date.Date.Add(time.TimeOfDay);

                bool isWork = this.rbtWork_as.Checked;


                CatStateModel catState = new CatStateModel()
                {
                    CatID = catID,
                    Date = datetime,
                    Work = isWork
                };

                this._mgrCatState.CreateCatState(catState);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了。');location.href='adminCats.aspx';", true);
                this.plcAddState.Visible = false;
            }

            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容が間違っています。');location.href='adminCats.aspx';", true);
            }
            finally
            {
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnAddBreed_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了')", true);
            try
            {
                string breed = this.txtBreed_ab.Text.Trim();

                if (!string.IsNullOrWhiteSpace(breed))
                {
                    CatBreedModel catBreed = new CatBreedModel()
                    {
                        Breed = breed
                    };

                    this._mgrCatBreed.CreateCatBreed(catBreed);
                    
                    this.plcAddBreed.Visible = false;
                }
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容が間違っています。');location.href='adminCats.aspx';", true);
            }
            finally
            {
                //Response.Redirect(Request.RawUrl);
            }
        }


        protected void btnCancalAddCat_Click(object sender, EventArgs e)
        {
            this.plcAddCat.Visible = false;
        }

        protected void btnCancelAddState_Click(object sender, EventArgs e)
        {
            this.plcAddState.Visible = false;
        }
        protected void btnCancelAddBreed_Click(object sender, EventArgs e)
        {
            this.plcAddBreed.Visible = false;
        }

        #endregion

        #region 刪除資料
        protected void btnDelete1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrCatState.DeleteCatState(id);
            this._mgrCat.DeleteCat(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminCats.aspx';", true);
            //Response.Redirect(Request.RawUrl);
        }

        protected void btnDelete2_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var catState = this._mgrCatState.GetCatState(id);
            CatStateModel catStateModel = new CatStateModel()
            {
                CatStateID = catState.CatStateID,
                CatID = catState.CatID,
                Date = catState.Date,
                Work = catState.Work
            };
            this._mgrCatState.DeleteCatState(catStateModel);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminCats.aspx';", true);
            //Response.Redirect(Request.RawUrl);
        }

        protected void btnDelete3_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var catBreed = this._mgrCatBreed.GetCatBreed(id);
            CatBreedModel breed = new CatBreedModel()
            {
                CatBreedID = catBreed.CatBreedID,
                Breed = catBreed.Breed
            };
            this._mgrCatBreed.DeleteCatBreed(breed);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminCats.aspx';", true);
            //Response.Redirect(Request.RawUrl);
        }
        #endregion

        #region 更新資料
        protected void btnUpdate1_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var cat = this._mgrCat.GetCat(id);

            this.txtID_uc.Text = cat.CatID.ToString();
            this.txtName_uc.Text = cat.CatName.ToString();
            this.txtSex_uc.Text = cat.Sex.ToString();
            this.txtBreedID_uc.Text = cat.CatBreedID.ToString();
            this.txtBirth_uc.Text = cat.Birth.Date.ToString();
            this.txtContent_uc.Text = cat.Contents.ToString();

            this.plcUpdateCat.Visible = true;
            this.plcUpdateCatState.Visible = false;
            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;
        }

        protected void btnUpdate2_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            var catState = this._mgrCatState.GetCatState(id);
            var cat = this._mgrCat.GetCat(catState.CatID);

            this.txtCatStateID_us.Text = catState.CatStateID.ToString();
            this.txtCatID_us.Text = catState.CatID.ToString();
            this.txtName_us.Text = cat.CatName.ToString();
            this.txtTime_us.Text = catState.Date.ToString();
            if (catState.Work)
                this.rbtWork_us.Checked = true;
            else
                this.rbtRest_us.Checked = true;

            this.plcUpdateCatState.Visible = true;
            this.plcUpdateCat.Visible = false;
            this.plcAddCat.Visible = false;
            this.plcAddState.Visible = false;
            this.plcAddBreed.Visible = false;
        }

        protected void btnUpdateCat_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtID_uc.Text);
            var cat = this._mgrCat.GetCat(id);

            try
            {
                string name = this.txtName_uc.Text.Trim();
                string content = this.txtContent_uc.Text.Trim();

                if (name != null && content != null)
                {
                    CatModel updateCat = new CatModel()
                    {
                        CatID = cat.CatID,
                        CatName = name,
                        CatBreedID = cat.CatBreedID,
                        Sex = cat.Sex,
                        Birth = cat.Birth.Date,
                        Contents = content
                    };

                    this._mgrCat.UpdateCat(updateCat);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminCats.aspx';", true);
                this.plcUpdateCatState.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容が間違っています。');location.href='adminCats.aspx';", true);
            }
            finally
            {
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnCancelUpdateCat_Click(object sender, EventArgs e)
        {
            this.plcUpdateCat.Visible = false;
        }

        protected void btnUpdateState_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtCatStateID_us.Text);
            var catState = this._mgrCatState.GetCatState(id);

            try
            {
                bool isWork = this.rbtWork_us.Checked;
                DateTime date = Convert.ToDateTime(this.txtTime_us.Text);

                if (date != null)
                {
                    CatStateModel updateCatState = new CatStateModel()
                    {
                        CatStateID = catState.CatStateID,
                        CatID = catState.CatID,
                        Date = date,
                        Work = isWork
                    };

                    this._mgrCatState.UpdateCatState(updateCatState);
                }
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminCats.aspx';", true);
                this.plcUpdateCatState.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('内容が間違っています。');location.href='adminCats.aspx';", true);
            }
            finally
            {
                //Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnCancelUpdateState_Click(object sender, EventArgs e)
        {
            this.plcUpdateCatState.Visible = false;
        }
        #endregion
    }
}