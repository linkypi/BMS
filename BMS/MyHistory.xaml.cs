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
using BMS.Common;
using Telerik.Windows.Controls;

namespace BMS
{
    /// <summary>
    /// MyHistory.xaml 的交互逻辑
    /// </summary>
    public partial class MyHistory : Page
    {
        private List<API.BorowInfo> models  =new List<API.BorowInfo>();
        private bool flag = false;
        public MyHistory()
        {
            InitializeComponent();
            GridList.ItemsSource = models;
            Search();
            flag = true;
            this.SizeChanged+=new SizeChangedEventHandler(MyHistory_SizeChanged);
        }

        private int pageindex = 0;
        void MyHistory_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

            RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;
        }


        private void Search()
        {
            if (!flag)
            { return; }
            API.SearchModel model = new API.SearchModel();
            model.CurrentPage = page.PageIndex;
            model.PageSize = (int)pagesize.Value;
            model.Conditions = new Dictionary<string, object>();
            model.Conditions.Add("UserID", Store.CurrentUser.UserID);
            ComboBoxItem cb = isBorow.SelectedItem as ComboBoxItem;
            if (cb.Content.ToString() == "已还")
            {
                model.Conditions.Add("IsReturn",1);
            }
            else if (cb.Content.ToString() == "未还")
            {
                 model.Conditions.Add("IsReturn",0);
            }
            RequestHelper.RequestAsync(this.busy, MethodType.SearchBHist, new List<object>() { model}, new EventHandler<API.ExecuteCompletedEventArgs>(GetCompleted));
        }

        public void GetCompleted (object sender,API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            models.Clear();
            API.Result res = e.Result;
            if (res.ReturnValue)
            {
                API.SearchModel smodel = res.Obj as API.SearchModel;
                List<API.BorowInfo> list = smodel.Result as List<API.BorowInfo>;
                if (list != null)
                {
                    foreach (var item in list)
                    {
                        if (string.IsNullOrEmpty(item.Borower))
                        {
                            item.Borower = item.UserName;

                        }
                    }
                    models.AddRange(list);
                    GridList.Rebind();
                }

                this.page.PageSize = (int)pagesize.Value;
                string[] data = new string[smodel.AllPages];
                //PagedCollectionView pcv = new PagedCollectionView(data);

                this.page.PageIndexChanged -= page_PageIndexChanged;
                this.page.Source = data;
                this.page.PageIndexChanged += page_PageIndexChanged;
                this.page.PageIndex = pageindex;
            }
        }

            
        private void GridList_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
       

        }

        private void page_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {
            pageindex = e.NewPageIndex;
            Search();
        }

        private void pagesize_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            Search();
        }

        private void search_Click(object sender, RoutedEventArgs e)
        {
            Search();
        }
    }
}
