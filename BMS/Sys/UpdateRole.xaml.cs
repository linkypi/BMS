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
    /// UpdateRole.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateRole : Page
    {
        public UpdateRole()
        {
            InitializeComponent();
            GridList.ItemsSource = models;
            this.SizeChanged += new SizeChangedEventHandler(UpdateRole_SizeChanged);
            flag = true;
            SearchRole();
             foreach (var item in Store.MenuInfos)
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


        private int pageindex = 0;
        bool flag = false;
        List<API.RoleInfo> models = new List<API.RoleInfo>();

        void UpdateRole_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

            RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;
        }

        #region  查询

        private void SearchRole()
        {
            if (!flag)
            {
                return;
            }
            API.SearchModel model = new API.SearchModel();
            model.Conditions = new Dictionary<string, object>();
            model.PageSize = page.PageSize;
            model.CurrentPage = page.PageIndex;

            if (!string.IsNullOrEmpty(note.Text))
            {
                if (!Security.ValidateInput(note.Text))
                {
                    Tool.PlayBackgAnimation(note);
                    return;
                }
                model.Conditions.Add("Note", note.Text);
            }

            if (!string.IsNullOrEmpty(roleName.Text))
            {
                if (!Security.ValidateInput(roleName.Text))
                {
                    Tool.PlayBackgAnimation(roleName);
                    return;
                }
                model.Conditions.Add("RoleName", roleName.Text);
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.SearchRoles, new List<object>() { model }, new EventHandler<API.ExecuteCompletedEventArgs>(GetCompleted));

        }

        private void page_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {
            pageindex = e.NewPageIndex;
            SearchRole();
        }

        private void pagesize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            SearchRole();
        }


        public void GetCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Error != null)
            {
                MessageBox.Show(System.Windows.Application.Current.MainWindow, " 服务器错误\n" + e.Error.Message);
                return;
            }
            models.Clear();
            API.Result res = e.Result;
            if (res.ReturnValue)
            {
                API.SearchModel smodel = res.Obj as API.SearchModel;
                List<API.RoleInfo> list = smodel.Result as List<API.RoleInfo>;
                models.AddRange(list);
                GridList.Rebind();

                this.page.PageSize = (int)pagesize.Value;
                string[] data = new string[smodel.AllPages];
                this.page.PageIndexChanged -= page_PageIndexChanged;
                this.page.Source = data;
                this.page.PageIndexChanged += page_PageIndexChanged;
                this.page.PageIndex = pageindex;
            }
        }


        #endregion

        #region  详情

        private void GridList_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                return;
            }

            API.RoleInfo role = GridList.SelectedItem as API.RoleInfo;
            this.updnote.Text = role.Note;
            this.updroleName.Text = role.RoleName;
            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetRoleMenus, new List<object>() { role.RoleID }, new EventHandler<API.ExecuteCompletedEventArgs>(GetRoleMenusCompleted));
        }
        public void GetRoleMenusCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            //if (e.Error != null)
            //{
            //    MessageBox.Show(System.Windows.Application.Current.MainWindow, " 服务器错误\n" + e.Error.Message);
            //    return;
            //}
            RadTreeView1.Items.Clear();
            if (e.Result.ReturnValue)
            {
                List<API.RoleMenuInfo> list = e.Result.Obj as List<API.RoleMenuInfo>;

                List<int> menus = new List<int>();
                foreach (var item in list)
                {
                    menus.Add(item.MenuID);
                }
               
                InitRemindMenu(menus);
            }
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <param name="remindList"></param>
        /// <param name="menus">用户定制的菜单编号集合</param>
        private void InitRemindMenu( List<int> menus)
        {
            var menu = from a in Store.MenuInfos
                       where a.Parent == 0
                       select a;
            foreach (var item in menu)
            {
                RadTreeViewItem p = Find(item , menus);
                if (p != null)
                {
                    p.Header = item.MenuName;
                    p.DataContext = item;
                    p.Tag = item.MenuID;
                    RadTreeView1.Items.Add(p);
                }
            }
        }


        private RadTreeViewItem Find(API.MenuInfo child, List<int> menus)
        {
            var mm = from a in Store.MenuInfos
                     where a.Parent == child.MenuID
                     select a;
            //若该菜单为叶子节点   则判断菜单是否是有提醒
            if (mm.Count() == 0)
            {
                RadTreeViewItem rad = new RadTreeViewItem();
                rad.Header = child.MenuName;
                rad.DataContext = child;
                rad.Tag = child.MenuID;
                if (menus.Contains(child.MenuID))
                {
                    rad.IsChecked = true;
                    rad.CheckState = System.Windows.Automation.ToggleState.On;
                }
                else
                {
                    rad.IsChecked = false;
                    rad.CheckState = System.Windows.Automation.ToggleState.Off;
                }
                      
                return rad;
            }

            RadTreeViewItem parent = new RadTreeViewItem();


            //若该菜单不是叶子节点   则继续循环查找
            foreach (var item in mm)
            {
                RadTreeViewItem obj = Find(item, menus);

                if (obj != null)
                {
                    obj.Header = item.MenuName;
                    obj.DataContext = item;
                    obj.Tag = item.MenuID;
                    parent.Items.Add(obj);
                }
            }

            //查找该父节点中的状态
            int checkedCount = 0;
            System.Windows.Automation.ToggleState state = System.Windows.Automation.ToggleState.Off;
            foreach (var item in parent.Items)
            {
                RadTreeViewItem xxd = item as RadTreeViewItem;
                if (xxd.CheckState == System.Windows.Automation.ToggleState.Indeterminate)
                {
                    state = System.Windows.Automation.ToggleState.Indeterminate;
                    break;
                }
                if (xxd.IsChecked == true)
                {
                    checkedCount++;
                }
            }

            if (state == System.Windows.Automation.ToggleState.Indeterminate)
            {
                parent.CheckState = System.Windows.Automation.ToggleState.Indeterminate;
            }
            else
            {
                if (checkedCount == 0)
                {
                    parent.IsChecked = false;
                    parent.CheckState = System.Windows.Automation.ToggleState.Off;
                }
                else if (checkedCount == parent.Items.Count)
                {
                    parent.IsChecked = true;
                    parent.CheckState = System.Windows.Automation.ToggleState.On;
                }
                else
                {
                    parent.CheckState = System.Windows.Automation.ToggleState.Indeterminate;
                }
            }
            if (parent.Items.Count == 0)
            {
                return null;
            }
            return parent;

        }

        #endregion 

        #region  保存

        private void Save_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                MessageBox.Show("请选择需要修改的角色！");
                return;
            }
            if (string.IsNullOrEmpty(updroleName.Text))
            {
                Tool.PlayBackgAnimation(updroleName);
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
                FindMenuID(rv, menuids);
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

            API.RoleInfo old = GridList.SelectedItem as API.RoleInfo;
            API.RoleInfo role = new API.RoleInfo();
            role.Note = updnote.Text;
            role.RoleName = updroleName.Text;
            role.RoleID = old.RoleID;

            RequestHelper.RequestAsync(this.busy, (int)MethodType.UpdateRole, new List<object>() { role, menuids }, new EventHandler<API.ExecuteCompletedEventArgs>(SaveCompleted));
       
        }


        private void FindMenuID(RadTreeViewItem parent, List<int> menuids)
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

        public void SaveCompleted(object sender, API.ExecuteCompletedEventArgs e)
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
                roleName.Text = string.Empty;
                note.Text = string.Empty;
                SearchRole();
            }
        }

        #endregion 

        #region 删除

        private void Del_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                MessageBox.Show("请选择需要删除的角色！");
                return;
            }
            if (MessageBox.Show("确定删除该角色吗？", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            API.RoleInfo role = GridList.SelectedItem as API.RoleInfo;
            RequestHelper.RequestAsync(this.busy, (int)MethodType.DeleteRole, new List<object>() {role.RoleID },new EventHandler<API.ExecuteCompletedEventArgs>(DelCompleted));
        }

        public void DelCompleted(object sender, API.ExecuteCompletedEventArgs e)
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
                SearchRole();
            }
        }

        #endregion 

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

        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchRole();
        }

    }
}
