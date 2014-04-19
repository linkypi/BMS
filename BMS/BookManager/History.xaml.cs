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
    /// History.xaml 的交互逻辑
    /// </summary>
    public partial class History : Page
    {
        private List<API.BorowInfo> models  =new List<API.BorowInfo>();
        private bool flag = false;
        public History()
        {
            InitializeComponent();
            GridList.ItemsSource = models;

            //API.UserInfo type = new API.UserInfo();
            //type.UserID = -1;
            //type.UserName = "全部";

            //List<API.UserInfo> list = new List<API.UserInfo>();
            //list.Add(type);
            //list.AddRange(Store.UserInfos);
            //user.ItemsSource = list;
            //user.SelectedIndex = 0;

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

            if (!string.IsNullOrEmpty(user.Text))
            {
                model.Conditions.Add("Borower", user.Text);
            
            }
           
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

        private void GridList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            API.BorowInfo b = GridList.SelectedItem as API.BorowInfo;

            API.Book bok = new  API.Book();
            bok.BAuthor = b.BAuthor;
            bok.BID = b.BID;
            bok.BookName = b.BookName;
            bok.BPrice = b.BPrice;
            bok.BTypeID = b.BTypeID;
            bok.BTypeName = b.BTypeName;
            bok.IsBorow = !b.IsReturn;
            bok.PubDate = b.PubDate;
            bok.Publisher = b.Publisher;
            bok.SerialNum = b.SerialNum;
            bok.SMPosition = b.SMPosition;
           
            RadTabItem rb = new RadTabItem();

            rb.Header = bok.BookName;//"图书简介"
            //Frame newframe = new Frame();
            //newframe.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            //newframe.JournalOwnership = System.Windows.Navigation.JournalOwnership.OwnsJournal;
            //newframe.BorderThickness = new Thickness(1);
            //newframe.Source = new Uri("BookDetail.xaml", UriKind.Relative);

            BookDetail bd = new BookDetail(bok);

            rb.Content = bd;
            rb.IsSelected = true;

            Main.AddTabItem(rb);
        }
    }
}
