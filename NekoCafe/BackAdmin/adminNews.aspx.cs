using NekoCafe.Helpers;
using NekoCafe.Managers;
using NekoCafe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;

namespace NekoCafe.BackAdmin
{
    public partial class adminNews : System.Web.UI.Page
    {
        private NewsFromBulletinManager _mgrNews = new NewsFromBulletinManager();
        private BulletinManager _mgrBulletin = new BulletinManager();
        private PictureManager _mgrPic = new PictureManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this._filePath.Clear();
                this.txtSearchNews.Text = string.Empty;
                this.txtSearchPic.Text = string.Empty;
                var NewsList = this._mgrBulletin.GetBulletinList(this.txtSearchNews.Text);
                this.rptNews.DataSource = NewsList;
                this.rptNews.DataBind();
                this.plcBtnForNews.Visible = true;
                this.plcBtnForPic.Visible = false;
                this.plcAddNews.Visible = false;
                this.plcAddPic.Visible = false;
                this.plcUpdateNews.Visible = false;
                this.plcPic.Visible = false;
            }
        }
        protected void btnNews_Click(object sender, EventArgs e)
        {
            this.plcBtnForNews.Visible = true;
            this.plcBtnForPic.Visible = false;
            this.plcNews.Visible = true;
            this.plcPic.Visible = false;
            this.plcAddNews.Visible = false;
            this.plcAddPic.Visible = false;
            this.plcUpdateNews.Visible = false;
        }

        protected void btnPic_Click(object sender, EventArgs e)
        {
            string txt = string.Empty;
            var picList = this._mgrPic.GetPictureList(txt);
            this.rptPic.DataSource = picList;
            this.rptPic.DataBind();

            this.lblUnsuccess.Visible = false;
            this.plcBtnForNews.Visible = false;
            this.plcBtnForPic.Visible = true;
            this.plcNews.Visible = false;
            this.plcPic.Visible = true;
            this.plcAddNews.Visible = false;
            this.plcAddPic.Visible = false;
            this.plcUpdateNews.Visible = false;
        }

        protected void btnAddNews_Click(object sender, EventArgs e)
        {
            this.plcAddNews.Visible = true;
            this.plcUpdateNews.Visible = false;
        }

        protected void btnSearchNews_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearchNews.Text;
            var NewsList = this._mgrBulletin.GetBulletinList(txt);
            this.rptNews.DataSource = NewsList;
            this.rptNews.DataBind();
        }

        protected void btnAddPic_Click(object sender, EventArgs e)
        {
            this.plcAddPic.Visible = true;
        }

        protected void btnSearchPic_Click(object sender, EventArgs e)
        {
            string txt = this.txtSearchPic.Text;
            var PicList = this._mgrPic.GetPictureList(txt);
            this.rptPic.DataSource = PicList;
            this.rptPic.DataBind();
        }

        protected void btnUpdate_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);

            var item = this._mgrBulletin.GetBulletin(id);
            this.txtBulletinID.Text = item.BulletinID.ToString();
            this.txtBulletinDate.Text = item.CreateDate.ToString();
            this.txtTitle.Text = item.Title.ToString();
            this.txtContents.Text = item.Content.ToString();

            this.plcAddNews.Visible = false;
            this.plcUpdateNews.Visible = true;
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrBulletin.DeleteBulletin(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminNews.aspx';", true);
        }

        protected void btnAddSave_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime createDate = Convert.ToDateTime(this.addBulletinDate.Text.Trim());
                string title = this.addTitle.Text.Trim();
                string contents = this.addContents.Text;
                int? picID;
                if (this.addPicID.Text.Trim() == string.Empty)
                    picID = null;
                else
                    picID = Convert.ToInt32(this.addPicID.Text.Trim());

                if (createDate != null && title != null)
                {
                    BulletinModel addBulletin = new BulletinModel()
                    {
                        CreateDate = createDate,
                        Title = title,
                        Content = contents,
                        PicID = picID
                    };

                    this._mgrBulletin.CreateBulletin(addBulletin);
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了。');location.href='adminNews.aspx';", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminNews.aspx';", true);
                }
                this.plcAddNews.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminNews.aspx';", true);
            }
        }

        protected void btnAddCancel_Click(object sender, EventArgs e)
        {
            this.plcAddNews.Visible = false;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(this.txtBulletinID.Text);
            var item = this._mgrBulletin.GetBulletin(id);

            try
            {
                string title = this.txtTitle.Text;
                string contents = this.txtContents.Text;
                int? picID;
                if (this.addPicID.Text.Trim() == string.Empty)
                    picID = null;
                else
                    picID = Convert.ToInt32(this.addPicID.Text.Trim());

                BulletinModel updateNews = new BulletinModel()
                {
                    BulletinID = item.BulletinID,
                    CreateDate = item.CreateDate,
                    Title = title,
                    Content = contents,
                    PicID = item.PicID
                };

                this._mgrBulletin.UpdateBulletin(updateNews);

                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('変更完了。');location.href='adminNews.aspx';", true);
                this.plcUpdateNews.Visible = false;
            }
            catch (Exception)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('入力した内容に誤りがあります。');location.href='adminNews.aspx';", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            this.plcUpdateNews.Visible = false;
        }

        protected void btnAddPicToArticle1_Click(object sender, EventArgs e)
        {
            bool isChecked = true;
            if (this.fuPic1.HasFile)
            {
                List<string> msgList;
                if (!ValidFileUpload(this.fuPic1, out msgList))
                {
                    lblMsg1.Text = string.Join("</br>", msgList);
                    isChecked = false;
                }
                if (!isChecked)
                {
                    this.lblUnsuccess.Visible = true;
                    return;
                }

                string fileName = this.fuPic1.FileName;
                string saveFolderPath = this.GetSavePath();
                string newFileName = GetNewFileName(fileName);
                string newFilePath = System.IO.Path.Combine(saveFolderPath, newFileName);
                this.fuPic1.SaveAs(newFilePath);

                string newFilePath2 = "~\\FileDownload\\" + newFileName;
                this.addContents.Text += "@img" + newFilePath2 + "@img\r\n";

                this.lblMsg1.Text = string.Empty;
                this.lblUnsuccess.Visible = false;
            }
        }

        protected void btnCancelPic_Click(object sender, EventArgs e)
        {
            this.plcAddPic.Visible = false;
        }

        protected void btnAddOnlyPic_Click(object sender, EventArgs e)
        {
            bool isChecked = true;
            List<string> msgList;
            if (!ValidFileUpload(this.fuPic, out msgList))
            {
                lblMsg.Text = string.Join("</br>", msgList);
                isChecked = false;
            }
            if (!isChecked)
            {
                return;
            }
            string fileName = this.fuPic.FileName;
            string saveFolderPath = this.GetSavePath();
            string newFileName = GetNewFileName(fileName);
            string newFilePath = System.IO.Path.Combine(saveFolderPath, newFileName);
            this.fuPic.SaveAs(newFilePath);
            var pic = new PictureModel()
            {
                PicRoute = "~\\FileDownload\\" + newFileName
            };
            this._mgrPic.CreatePicture(pic);

            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('追加完了。');location.href='adminNews.aspx';", true);
            this.lblUnsuccess.Visible = false;
        }

        protected void btnDeletePic_Command(object sender, CommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandName);
            this._mgrPic.DeletePicture(id);
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('削除しました。');location.href='adminNews.aspx';", true);
        }

        #region 圖片上傳方法
        private string GetSavePath()
        {
            string folder = "~/FileDownload";
            //string folderPath = Server.MapPath(folder);
            string folderPath = HostingEnvironment.MapPath(folder);
            return folderPath;
        }

        private string GetNewFileName(string fileName)
        {
            System.Threading.Thread.Sleep(3);
            Random random = new Random((int)DateTime.Now.Ticks);
            //使用當下時間
            string newFileName_Time = DateTime.Now.ToString("yyyyMMddHHmmssFFFFFF") + "_" + random.Next(10000).ToString("0000") + System.IO.Path.GetExtension(fileName);
            return newFileName_Time;
        }

        private bool ValidFileUpload(System.Web.UI.WebControls.FileUpload fileUpload, out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            string fileName = fileUpload.FileName;

            //檢查檔案副檔名是否符合規範
            if (!FileHelper.ValidFileExtension(fileName))
            {
                string fileExts = string.Join(", ", FileHelper.ImageFileExtArr);
                msgList.Add("ファイル形式は " + fileExts + " のみです。");
            }

            //檢查檔案大小是否符合規範
            byte[] fileContent = fileUpload.FileBytes;
            if (!FileHelper.ValidFileLength(fileContent))
            {
                msgList.Add("ファイルサイズは最大 " + FileHelper.UploadMB + " MBです。");
            }

            errorMsgList = msgList;
            if (errorMsgList.Count > 0)
                return false;
            else
                return true;
        }


        #endregion
    }
}