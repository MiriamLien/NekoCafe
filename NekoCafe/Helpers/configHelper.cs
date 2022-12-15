﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace NekoCafe.Helpers
{
    public class ConfigHelper
    {
        private const string _mainDBName = "MainDB";

        /// <summary>
        /// 讀取設定檔中的連線字串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            return GetConnectionString(_mainDBName);
        }

        public static string GetConnectionString(string name)
        {
            string connString = ConfigurationManager.ConnectionStrings[name].ConnectionString;
            return connString;
        }
    }
}