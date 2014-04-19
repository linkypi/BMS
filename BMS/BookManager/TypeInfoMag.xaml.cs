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

namespace BMS.BookManager
{
    /// <summary>
    /// TypeInfoMag.xaml 的交互逻辑
    /// </summary>
    public partial class TypeInfoMag : Page
    {
        List<API.TypeInfo> models = new List<API.TypeInfo>();
        private bool flag = false;
        private int pageindex;

        public TypeInfoMag()
        {
            InitializeComponent();
            flag = true;
            GridList.ItemsSource = models;
            this.SizeChanged += new SizeChangedEventHandler(TypeInfoMag_SizeChanged);
            Search();
        }

        void TypeInfoMag_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

            RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;
        }


        #region 查询

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }

        void Search()
        {
            if (!flag)
            {
                return;
            }
            API.SearchModel model = new API.SearchModel();
            model.Conditions = new Dictionary<string, object>();
            model.PageSize = page.PageSize;
            model.CurrentPage = page.PageIndex;

            if (!string.IsNullOrEmpty(sc_typeName.Text))
            {
                if (!Security.ValidateInput(sc_typeName.Text))
                {
                    Tool.PlayBackgAnimation(sc_typeName);
                    return;
                }
                model.Conditions.Add("BTypeName", sc_typeName.Text);
            }

            RequestHelper.RequestAsync(this.busy,(int)MethodType.SearchBType, new List<object>() { model }, new EventHandler<API.ExecuteCompletedEventArgs>(GetCompleted));
        }

        public void GetCompleted(object sender,API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            models.Clear();
            if (e.Result.ReturnValue)
            {
                API.SearchModel model = e.Result.Obj as API.SearchModel;
                if(model !=null)
                {
                    models.AddRange(model.Result as List<API.TypeInfo>);
                    this.page.PageSize = (int)pagesize.Value;
                    string[] data = new string[model.AllPages];
                    //PagedCollectionView pcv = new PagedCollectionView(data);

                    this.page.PageIndexChanged -= page_PageIndexChanged;
                    this.page.Source = data;
                    this.page.PageIndexChanged += page_PageIndexChanged;
                    this.page.PageIndex = pageindex;
                }
            }
            GridList.Rebind();
        }

        private void page_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {
            pageindex = e.NewPageIndex;
            Search();
        }

        private void pagesize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            Search();
        }

        private void GridList_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                return;
            }

            API.TypeInfo t = GridList.SelectedItem as API.TypeInfo;
            this.updtype.Text = t.BTypeName;
            this.updtype.Tag = t.TypeID;
        }

        #endregion 

        #region 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.type.Text))
            {
                Tool.PlayBackgAnimation(this.type);
                return;
            }
            if (MessageBox.Show("确定添加吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            RequestHelper.RequestAsync(this.busy, (int)MethodType.AddBType, new List<object>() { this.type.Text }, new EventHandler<API.ExecuteCompletedEventArgs>(AddCompleted));

        }

        public void AddCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                this.type.Text = string.Empty;
                updtype.Text = string.Empty;
                Search();
            }
        }

        #endregion 

        #region 修改

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                MessageBox.Show("请选择需要修改的图书类别！");
                return;
            }

            if (string.IsNullOrEmpty(this.updtype.Text))
            {
                Tool.PlayBackgAnimation(this.updtype);
                return;
            }

            API.TypeInfo t = GridList.SelectedItem as API.TypeInfo;
            API.TypeInfo ti = new API.TypeInfo();
            ti.TypeID = t.TypeID;
            ti.BTypeName = updtype.Text;

            RequestHelper.RequestAsync(this.busy, (int)MethodType.UpdateBType, new List<object>() { ti }, new EventHandler<API.ExecuteCompletedEventArgs>(AddCompleted));
        }

        #endregion

        #region 删除

        private void delete_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridList.SelectedItems == null)
            {
                MessageBox.Show("请选择需要删除的类别！");
                return;
            }

            List<int> list = new List<int>();
            foreach (var item in GridList.SelectedItems)
            {
                API.TypeInfo t = item as API.TypeInfo;
                list.Add(t.TypeID);
            }

            if (list.Count == 0)
            {
                return;
            }
            if (MessageBox.Show("确定删除选中项吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.DeleteBType, new List<object>() { list }, new EventHandler<API.ExecuteCompletedEventArgs>(DelCompleted));
        }

        public void DelCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                this.type.Text = string.Empty;
                updtype.Text = string.Empty;
                Search();
            }
        }

        #endregion
    }
}
