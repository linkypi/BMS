using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BMS.Common
{
    public  class Security
    {
        #region 安全

        /// <summary>
        /// MD5　32位加密
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string GetMD5_32(string pwd)
        {
            string temp = "";
            MD5 md5 = MD5.Create();//实例化一个md5对像
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] s = md5.ComputeHash(Encoding.UTF8.GetBytes(pwd));
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < s.Length; i++)
            {
                // 将得到的字符串使用十六进制类型格式。格式后的字符是小写的字母，
                //如果使用大写（X）则格式后的字符是大写字符
                temp = temp + s[i].ToString("X2");//确保有2位的16进制数  这样数组长度为16的结果才会有32个字节
            }
            return temp;
        }

        /// <summary>
        /// Verify a hash against a string.
        /// </summary>
        /// <param name="input">未加密的字符串</param>
        /// <param name="hash">md5字符串</param>
        /// <returns></returns>
        public static bool verifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMD5_32(input);

            // Create a StringComparer an comare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 验证用户输入  防止SQL注入
        /// </summary>
        /// <param name="str">用户输入字符串</param>
        /// <returns>验证成功返回true 否则false</returns>
        public static bool ValidateInput(string str)
        {
            if (str.Contains("-") || str.Contains(";") || str.Contains("'") || str.Contains("/") || str.Contains("Xp_"))
                return false;
            return true;
        }

        /// <summary>
        /// 处理网页中的HTML代码，并消除危险字符
        /// </summary>        
        public static string HTMLEncode(string fString)
        {
            if (fString != string.Empty)
            {
                ///替换尖括号
                fString = fString.Replace("<", "&lt;");
                fString = fString.Replace(">", "&rt;");
                ///替换引号
                fString = fString.Replace(((char)34).ToString(), "&quot;");
                fString = fString.Replace(((char)39).ToString(), "&#39;");
                ///替换空格
                fString = fString.Replace(((char)13).ToString(), "&nbsp;");
                ///替换换行
                fString = fString.Replace("\r\n", "<br/>");
                ///替换换行符
                fString = fString.Replace(((char)10).ToString(), "<br/>");
                ///替换tab
                fString = fString.Replace("\t", "&nbsp;&nbsp;&nbsp;&nbsp;");
            }
            return fString;
        }

        /// <summary>
        /// 为字符串中的非英文字符编码
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string ToHexString(string s)
        {
            char[] chars = s.ToCharArray();
            StringBuilder builder = new StringBuilder();
            for (int index = 0; index < chars.Length; index++)
            {
                bool needToEncode = NeedToEncode(chars[index]);
                if (needToEncode)
                {
                    string encodedString = ToHexString(chars[index].ToString());//TODO:是不否会出问题？
                    builder.Append(encodedString);
                }
                else
                {
                    builder.Append(chars[index]);
                }
            }
            return builder.ToString();
        }

        /// <summary>
        ///指定 一个字符是否应该被编码
        /// </summary>
        /// <param name="chr"></param>
        /// <returns></returns>
        private static bool NeedToEncode(char chr)
        {
            string reservedChars = "$-_.+!*'(),@=&";

            if (chr > 127)
                return true;
            if (char.IsLetterOrDigit(chr) || reservedChars.IndexOf(chr) >= 0)
                return false;

            return true;
        }
        #endregion

    }
}
