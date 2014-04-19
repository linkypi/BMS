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
using Telerik.Windows.Controls;
using System.Collections.ObjectModel;
using BMS.Common;
using System.Threading;


namespace BMS
{
    /// <summary>
    /// Main.xaml 的交互逻辑
    /// </summary>
    public partial class Main : Window
    {
        public delegate void AddEventHalder(RadTabItem rb);
        private static double oldHeight = 0;
        public static event  AddEventHalder AddRTItem;
        public void DragWindow(object sender, MouseButtonEventArgs args)
        {
            this.DragMove();
        }

        public Main()
        {
            InitializeComponent();
            this.CurrentUser.Text = Store.CurrentUser.UserName;
          
            AddRTItem += new AddEventHalder(Main_AddRTItem);
            foreach (var item in Store.MenuInfos)
            {
                if (item.Parent == 0)
                {
                    RadMenuItem rm = new RadMenuItem();
                    rm.Header = item.MenuName;
                    rm.Tag = item.ClassName;
                    rm.Click += new Telerik.Windows.RadRoutedEventHandler(RadMenuItem_Click);
                    if (item.Parent == 0)
                    {
                        rm = Find(item, rm);
                    }
                    menu.Items.Add(rm);
                }
            }
            //注册RadTabItem关闭事件
            EventManager.RegisterClassHandler( typeof(RadTabItem), RoutedEventHelper.CloseTabEvent, new RoutedEventHandler(OnCloseClicked));
            this.Activated += new EventHandler(Main_Activated);
           
            
            this.Width = 1100;
            this.Height = 700;
            this.ResizeMode = ResizeMode.CanResize;
        }

        void Main_Activated(object sender, EventArgs e)
        {
            oldHeight = this.Height;
        }

    

        void Main_AddRTItem(RadTabItem rb)
        {
            bool has = false;
            foreach (var item in tabcontrols.Items)
            {
                RadTabItem child = item as RadTabItem;
                if (child.Header == rb.Header)
                {
                    has = true;
                    break;
                }
            }
            if (!has)
            {
                tabcontrols.Items.Add(rb);
            }
        }

        public static void AddTabItem(RadTabItem rb)
        {
            AddRTItem(rb);
        }

        /// <summary>
        /// 递归查找子菜单
        /// </summary>
        /// <param name="child"></param>
        /// <param name="remindList"></param>
        /// <param name="userMenuIDs"></param>
        /// <returns></returns>
        private RadMenuItem Find(API.MenuInfo child, RadMenuItem parent)
        {
            var mm = from a in Store.MenuInfos
                     where a.Parent == child.MenuID
                     select a;
            //若该菜单为叶子节点   则判断菜单是否是有提醒
            if (mm.Count() > 0)
            {
                foreach (var item in mm)
                {
                    RadMenuItem rm = new RadMenuItem();
                    rm.Click += new Telerik.Windows.RadRoutedEventHandler(RadMenuItem_Click);
                    rm.Header = item.MenuName;
                    rm.Tag = item.ClassName;
                    rm.Background = new SolidColorBrush(Colors.LightBlue);
                    rm = Find(item, rm);
                    
                    parent.Items.Add(rm);
                }
            }
            return parent;

        }
        
        /// <summary>
        /// 点击菜单栏弹出指定页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            RadMenuItem mn = sender as RadMenuItem;

            if (mn.Tag == null)
            {
                return;
            }
            //去除重复项
            foreach (var item in tabcontrols.Items)
            {
                RadTabItem child = item as RadTabItem;
                if (child.Header == mn.Header)
                {
                    return;
                }
            }
        
            RadTabItem rb = new RadTabItem();
            
            rb.Header = mn.Header;
            Frame newframe = new Frame();
            newframe.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            newframe.JournalOwnership = System.Windows.Navigation.JournalOwnership.OwnsJournal;
            newframe.BorderThickness = new Thickness(1);
            newframe.Source = new Uri(mn.Tag.ToString(), UriKind.Relative);
            rb.Content = newframe;
            rb.IsSelected = true;

            tabcontrols.Items.Add(rb);
        }


        public void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            var tabItem = sender as RadTabItem;
            tabcontrols.Items.Remove(tabItem);
        }


        /// <summary>
        /// 退出系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Louout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            this.Close();
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SetPassWord_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = System.Windows.WindowState.Normal;
            //this.Width = 1100;
            //this.Height = 600;
        }

    }
}
