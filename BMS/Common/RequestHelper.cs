using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Telerik.Windows.Controls;
using System.Windows.Navigation;
using System.Reflection;


namespace BMS.Common
{
   public class RequestHelper
    {
       /// <summary>
       /// 同步请求
       /// </summary>
       /// <param name="busy"></param>
       /// <param name="methodid"></param>
       /// <param name="args"></param>
       /// <returns></returns>
        public static API.Result Request(RadBusyIndicator busy, int methodid, List<object> args)
        {
            if (busy == null)
            {
                busy = new RadBusyIndicator();
            }
            busy.IsBusy = true;

            if (args == null)
            {
                args = new List<object>();
            }
            if (methodid != 1)
            {
                if (!Store.IsLogin)
                {
                    NavigationWindow window = new NavigationWindow();
                    window.Source = new Uri("Login.xaml", UriKind.Relative);
                    window.Show();
                }
                args.Insert(0, Store.CurrentUser == null ? new API.UserInfo() : Store.CurrentUser);
            }

            API.BMSServiceClient client = new API.BMSServiceClient();

            client.Open();
            API.Result ret = client.Execute(methodid, args);
            client.Close();
            busy.IsBusy = false;
            return ret;
        }

       /// <summary>
       /// 发起异步请求
       /// </summary>
       /// <param name="busy"></param>
       /// <param name="methodid"></param>
       /// <param name="args"></param>
       /// <param name="CompletedEvent"></param>
        public static void RequestAsync(RadBusyIndicator busy, int methodid, List<object> args, EventHandler<API.ExecuteCompletedEventArgs> CompletedEvent)
        {
            if (busy == null)
            {
                busy = new RadBusyIndicator();
            }
            busy.IsBusy = true;

            if (args == null)
            {
                args = new List<object>();
            }
            if (methodid != 1)
            {
                if (!Store.IsLogin)
                {
                    NavigationWindow window = new NavigationWindow();
                    window.Source = new Uri("Login.xaml", UriKind.Relative);
                    window.Show();
                }
                args.Insert(0, Store.CurrentUser == null ? new API.UserInfo() : Store.CurrentUser);
            }

            API.BMSServiceClient client = new API.BMSServiceClient();
            //清除所有代理  防止回调完成时执行其他Completed事件
            var c1Type = client.GetType();
            var field = c1Type.GetField("ExecuteCompleted", BindingFlags.NonPublic | BindingFlags.Instance);
            MulticastDelegate multicastDelegate = field.GetValue(client) as MulticastDelegate;
            if (multicastDelegate != null)
            {
                Delegate[] dels = multicastDelegate.GetInvocationList();
                foreach (var listener in dels)
                {
                    client.ExecuteCompleted -= listener as EventHandler<API.ExecuteCompletedEventArgs>;
                    //Do what you got to do to ensure the listener is not a zombie
                }
            }
            client.ExecuteCompleted += CompletedEvent;
            client.ExecuteAsync(methodid, args);
        }
    }
}
