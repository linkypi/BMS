using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BMS.DbHelper
{
    public static class Log
    {
        /// <summary>
        /// 记录错误日志至文本文件
        /// 默认日志路径：/Content/System/ErrorLog
        /// </summary>
        /// <param name="errpath">出错路径</param>
        /// <param name="ex">记录的内容</param>
        public static void CreateErrorLog(string exception)
        {
            //目录路径
            string m_directory = AppDomain.CurrentDomain.BaseDirectory + "//System//ErrorLog//";  /// "~//Content//System//ErrorLog//"; //System.Web.HttpContext.Current.Server.MapPath("~//Content//System//ErrorLog//");

            //日志路径
            string m_fileName = "~//Content//System//ErrorLog.txt"; //System.Web.HttpContext.Current.Server.MapPath("~//Content//System//ErrorLog.txt");
            //以日期为文件文件名
            string fileNameWithDate = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString() + ".txt";
            //创建目录

            if (!Directory.Exists(m_directory))
                Directory.CreateDirectory(m_directory);
            FileStream fs = File.Open(m_directory + fileNameWithDate, FileMode.Append, FileAccess.Write, FileShare.Write);


            ////写入文件
            string WriteWorld = "\r\n*****************************       " +
                    DateTime.Now.ToString() +
                    "       **********************************\r\n";

            WriteWorld += exception + "\r\n\r\n";

            byte[] byt = Encoding.UTF8.GetBytes(WriteWorld);
            fs.Write(byt, 0, byt.Length);
            fs.Flush();
            fs.Close();
            fs.Dispose();
        }
    }
}
