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
using BMS.Common;

namespace BMS.Sys
{
    /// <summary>
    /// AddRole.xaml 的交互逻辑
    /// </summary>
    public partial class AddRole : Page
    {
        public AddRole()
        {
            InitializeComponent();
            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetMenuInfoList, new List<object>() { }, new EventHandler<API.ExecuteCompletedEventArgs>(GetRemindCompleted));
       
        }

        #region 初始化

        private void GetRemindCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            RadTreeView1.Items.Clear();
            if (e.Error != null)
            {
                MessageBox.Show(System.Windows.Application.Current.MainWindow, " 服务器错误\n" + e.Error.Message);
                return;
            }
            if (e.Result.ReturnValue)
            {
                List<API.MenuInfo> arr = e.Result.Obj as List<API.MenuInfo>;
                if (arr == null) { return; }

                foreach (var item in arr)
                {
                    if (item.Parent == 0)
                    {
                        RadTreeViewItem rm = new RadTreeViewItem();
                        rm.Header = item.MenuName;
                        rm.Tag = item.MenuID;
                        if (item.Parent == 0)
                        {
                            rm = Find(item, rm);
                        }
                        RadTreeView1.Items.Add(rm);
                    }
                }

            }
        }


        /// <summary>
        /// 递归查找子菜单
        /// </summary>
        /// <param name="child"></param>
        /// <param name="remindList"></param>
        /// <param name="userMenuIDs"></param>
        /// <returns></returns>
        private RadTreeViewItem Find(API.MenuInfo child, RadTreeViewItem parent)
        {
            var mm = from a in Store.MenuInfos
                     where a.Parent == child.MenuID
                     select a;
            //若该菜单为叶子节点   则判断菜单是否是有提醒
            if (mm.Count() > 0)
            {
                foreach (var item in mm)
                {
                    RadTreeViewItem rm = new RadTreeViewItem();
                    rm.Header = item.MenuName;
                    rm.Tag = item.MenuID;
                    rm = Find(item, rm);
                    parent.Items.Add(rm);
                }
            }
            return parent;

        }

        #endregion

        #region 保存
        
        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(roleName.Text))
            {
                Tool.PlayBackgAnimation(roleName);
                return;
            }

            List<int> menuids = new List<int>();
            foreach (var item in RadTreeView1.Items)
            {
                  RadTreeViewItem rv = item as RadTreeViewItem;
                  if (rv.CheckState == System.Windows.Automation.ToggleState.Off)
                  {
                      continue;
                  }
                  if (rv.Items.Count == 0 && rv.CheckState == System.Windows.Automation.ToggleState.On)
                  {
                      menuids.Add(Convert.ToInt32(rv.Tag));
                  }
                  FindMenuID(rv,menuids);
            }

            if (menuids.Count == 0)
            {
                MessageBox.Show("请选择角色可操作的菜单！");
                return;
            }
            if (MessageBox.Show("确定保存吗？", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }

            API.RoleInfo role = new API.RoleInfo();
            role.Note = note.Text;
            role.RoleName = roleName.Text;


            RequestHelper.RequestAsync(this.busy, (int)MethodType.AddRole, new List<object>() { role,menuids}, new EventHandler<API.ExecuteCompletedEventArgs>(SaveCompleted));
       
        }

        private void SaveCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Error != null)
            {
                MessageBox.Show(System.Windows.Application.Current.MainWindow, " 服务器错误\n" + e.Error.Message);
                return;
            }

            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                note.Text = string.Empty;
                roleName.Text = string.Empty;
            }
        }

        private void FindMenuID(RadTreeViewItem parent,List<int> menuids)
        {
            foreach (var item in parent.Items)
            {
                RadTreeViewItem rv = item as RadTreeViewItem;
                if (rv.CheckState == System.Windows.Automation.ToggleState.Off)
                {
                    continue;
                }
                if (rv.Items.Count == 0 && rv.CheckState == System.Windows.Automation.ToggleState.On)
                {
                    menuids.Add(Convert.ToInt32(rv.Tag));
                }

                FindMenuID(rv, menuids);
            }
    
        }

        #endregion 

        //#region 获取提醒列表
        private void SelectAll_Click_1(object sender, RoutedEventArgs e)
        {
            foreach (var item in RadTreeView1.Items)
            {
                RadTreeViewItem rv = item as RadTreeViewItem;
                rv.CheckState = System.Windows.Automation.ToggleState.On;
            }
        }

        private void UnSelect(object sender, RoutedEventArgs e)
        {
             foreach (var item in RadTreeView1.Items)
            {
                RadTreeViewItem rv = item as RadTreeViewItem;
                rv.CheckState = System.Windows.Automation.ToggleState.Off;
            }
        }


        //#endregion
    }
}
