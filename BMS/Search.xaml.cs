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
using BMS.BookManager;

namespace BMS
{
    /// <summary>
    /// Search.xaml 的交互逻辑
    /// </summary>
    public partial class Search : Page
    {
        private List<API.Book> models = new List<API.Book>();
        private int pageindex;
        private bool flag = false;

        public Search()
        {
            InitializeComponent();
            API.TypeInfo type = new API.TypeInfo();
            type.TypeID = -1;
            type.BTypeName = "全部";

            flag = true;
            List<API.TypeInfo> list =  Store.TypeInfos;
            list.Add(type);
            sc_type.ItemsSource = list;
            sc_type.SelectedIndex = list.Count - 1;

            this.GridList.ItemsSource = models;

            this.SizeChanged += new SizeChangedEventHandler(Search_SizeChanged);

            SearchBook();
        }

        void Search_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

             RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;
        }


        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchBook();
        }

        private void SearchBook()
        {
            if (!flag)
            {
                return;
            }
            API.SearchModel model = new API.SearchModel();
            model.Conditions = new Dictionary<string, object>();
            model.PageSize = page.PageSize;
            model.CurrentPage = page.PageIndex;

            if (!string.IsNullOrEmpty(sc_author.Text))
            {
                if (!Security.ValidateInput(sc_author.Text))
                {
                    Tool.PlayBackgAnimation(sc_author);
                    return;
                }
                model.Conditions.Add("BAuthor", sc_author.Text);
            }

            if (!string.IsNullOrEmpty(sc_bookName.Text))
            {
                if (!Security.ValidateInput(sc_bookName.Text))
                {
                    Tool.PlayBackgAnimation(sc_bookName);
                    return;
                }
                model.Conditions.Add("BookName", sc_bookName.Text);
            }

            if (!string.IsNullOrEmpty(sc_publisher.Text))
            {
                if (!Security.ValidateInput(sc_publisher.Text))
                {
                    Tool.PlayBackgAnimation(sc_publisher);
                    return;
                }
                model.Conditions.Add("Publisher", sc_publisher.Text);
            }

            if (!string.IsNullOrEmpty(sc_bkey.Text))
            {
                if (!Security.ValidateInput(sc_bkey.Text))
                {
                    Tool.PlayBackgAnimation(sc_bkey);
                    return;
                }
                model.Conditions.Add("BKey", sc_bkey.Text);
            }

            if ((int)sc_type.SelectedValue != -1)
            {
                model.Conditions.Add("BTypeID", sc_type.SelectedValue);
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.SearchBook, new List<object>() { model }, new EventHandler<API.ExecuteCompletedEventArgs>(GetCompleted));
   
        }

        private void page_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {
            pageindex = e.NewPageIndex;
            SearchBook();
        }

        private void pagesize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            SearchBook();
        }


        public void GetCompleted(object sender,API.ExecuteCompletedEventArgs e )
        {
            this.busy.IsBusy = false;
            models.Clear();
            API.Result res = e.Result;
            if (res.ReturnValue)
            {
                API.SearchModel smodel = res.Obj as API.SearchModel;
                List<API.Book> list = smodel.Result as List<API.Book>;
                if (list != null)
                {
                    var books = (from a in list
                                 orderby a.PubDate descending
                                 select a).ToList();
                    models.AddRange(books);
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

        private void GridList_SelectionChanged(object sender, SelectionChangeEventArgs e)
        {
          
        }

        private void GridList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            API.Book bok = GridList.SelectedItem as API.Book;

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
