using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace NekoCafe.Helpers
{
    public class Logger
    {
        private const string _savePath = "D:\\CSharpClass\\Project_NekoCafe\\Log\\Log.log";

        /// <summary>
        /// 記錄錯誤
        /// </summary>
        /// <param name="moduleName"></param>
        /// <param name="ex"></param>
        public static void WriteLog(string moduleName, Exception ex)
        {
            //-----
            //yyyy/MM/dd HH:mm:ss
            //  Module Name
            //Error Content
            //-----

            string content =
$@"-----
{DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")}
    {moduleName}
    {ex.ToString()}
-----
";
            File.AppendAllText(Logger._savePath, content);
        }

        //創建檔案
        static void CreateFile()
        {
            if (!File.Exists("D:\\CSharpClass\\Project_NekoCafe\\Log\\Log.log"))
            {
                //File.Create會傳回FileStream值,導致檔案運作
                FileStream shutdown = File.Create("D:\\CSharpClass\\Project_NekoCafe\\Log\\Log.log");
                //將FileStream關閉,才能進行檔案刪除
                shutdown.Close();
            }
        }
    }
}