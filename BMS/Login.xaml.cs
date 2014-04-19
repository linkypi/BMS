using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Windows.Media.Animation;
using BMS.Common;
using BMS;
using System.Reflection;


namespace BMS
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            this.Width = 400;
            this.Height = 250;
            this.username.Focus();
        }
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            this.DragMove();
        }

        public void CloseWindow(object sender, RoutedEventArgs args)
        {
            this.Close();
        }

        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            LoginTo();
           
        }

        private void LoginTo()
        {
            if (string.IsNullOrEmpty(username.Text))
            {
                Tool.PlayBackgAnimation(username);
                return;
            }

            IntPtr p = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.pwd.SecurePassword);

            // 使用.NET内部算法把IntPtr指向处的字符集合转换成字符串  
            string password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
            if (string.IsNullOrEmpty(password))
            {
                Tool.PlayBackgAnimation(pwd);
                return;
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetUser, new List<object> { username.Text.Trim() },
                new EventHandler<API.ExecuteCompletedEventArgs>(LoginCompleted));
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void LoginCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Result.ReturnValue)
            {

                API.UserInfo user = e.Result.Obj as API.UserInfo;

                IntPtr p = System.Runtime.InteropServices.Marshal.SecureStringToBSTR(this.pwd.SecurePassword);
                // 使用.NET内部算法把IntPtr指向处的字符集合转换成字符串  
                string password = System.Runtime.InteropServices.Marshal.PtrToStringBSTR(p);
                if (user.Pwd == Security.GetMD5_32(password))
                {
                    Store.CurrentUser = user;
                    Store.IsLogin = true;
                    Store.CurrentRole = e.Result.Arr[0] as API.RoleInfo;

                    API.Result result = RequestHelper.Request(this.busy, (int)MethodType.GetTypeInfoList, new List<object>() { });
                    if (result.ReturnValue)
                    {
                        List<BMS.API.TypeInfo> list = result.Obj as List<BMS.API.TypeInfo>;
                        Store.TypeInfos.AddRange(list);
                    }

                    API.Result result2 = RequestHelper.Request(this.busy, (int)MethodType.GetMenuInfoList, new List<object>() { });
                    if (result2.ReturnValue)
                    {
                        List<BMS.API.MenuInfo> list = result2.Obj as List<BMS.API.MenuInfo>;
                        Store.MenuInfos.AddRange(list);
                    }

                    //获取所有用户
                    API.Result result3 = RequestHelper.Request(this.busy, (int)MethodType.GetAllUsers, new List<object>() { });
                    if (result3.ReturnValue)
                    {
                        List<BMS.API.UserInfo> list = result3.Obj as List<BMS.API.UserInfo>;
                        Store.UserInfos.AddRange(list);
                    }

                    //NavigationWindow window = new NavigationWindow();
                    //window.Source = new Uri("Main.xaml", UriKind.Relative);
                    //window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    //window.Show();
                    Main m = new Main();
                    m.Show();
                    this.Close();
                }
                else
                {
                    errorMsg.Text = "密码错误!";
                    Tool.PlayForegAnimation(errorMsg);
                }
            }
            else
            {
                errorMsg.Text = e.Result.Message;
                Tool.PlayForegAnimation(errorMsg);
            }
        }

        private void pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                LoginTo();
            }
        }

    }
}