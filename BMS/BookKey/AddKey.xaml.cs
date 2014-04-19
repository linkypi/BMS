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
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using BMS.Common;

namespace BMS.BookKey
{
    /// <summary>
    /// AddKey.xaml 的交互逻辑
    /// </summary>
    public partial class AddKey : Page
    {
        private bool flag = false;
        private int pageindex=0;

        public AddKey()
        {
            InitializeComponent();
            flag = true;
            API.TypeInfo t = new API.TypeInfo();
            t.TypeID = -1;
            t.BTypeName = "全部";

            flag = true;
            List<API.TypeInfo> list = Store.TypeInfos;
            list.Add(t);
            sc_type.ItemsSource = list;
            sc_type.SelectedIndex = list.Count - 1;
            this.GridList.ItemsSource = models;

            this.SizeChanged += new SizeChangedEventHandler(AddKey_SizeChanged);
            SearchBook();
        }

        private List<API.Book> models = new List<API.Book>();

        void AddKey_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

            RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;

            //DockPanel wp2 = this.FindName("panel2") as DockPanel;
            //wp2.Width = e.NewSize.Width;

            //RadDataPager rdp2 = this.FindName("page2") as RadDataPager;
            //RadNumericUpDown nud2 = this.FindName("pagesize2") as RadNumericUpDown;
            //rdp2.Width = e.NewSize.Width - nud2.Width;


        }

        #region  查询 

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

        private void GetCompleted(object sender, API.ExecuteCompletedEventArgs e)
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
        
        private void page_PageIndexChanged(object sender, Telerik.Windows.Controls.PageIndexChangedEventArgs e)
        {
            pageindex = e.NewPageIndex;
            SearchBook();
        }

        private void pagesize_ValueChanged(object sender, Telerik.Windows.Controls.RadRangeBaseValueChangedEventArgs e)
        {
            SearchBook();
        }
        private void search_Click(object sender, RoutedEventArgs e)
        {
            SearchBook();
        }

        #endregion 

        #region  获取关键字

        private void GridList_SelectionChanged(object sender, Telerik.Windows.Controls.SelectionChangeEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                return;
            }
            API.Book b = GridList.SelectedItem as API.Book;
            GridKey.Tag = b.BID;
            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetBKeyByBID, new List<object>() { b.BID }, new EventHandler<API.ExecuteCompletedEventArgs>(GetBKeyCompleted));
    
        }

        public void GetBKeyCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Result.ReturnValue)
            {
                GridKey.ItemsSource = e.Result.Obj as List<API.BookKey>;
                GridKey.Rebind();
            }
        }

        #endregion 

        #region 删除 关键字

        private void del_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridKey.SelectedItems == null)
            {
                MessageBox.Show("请选择需要删除的关键字！");
                return;
            }

            List<int> idlist = new List<int>();

            foreach (var item in GridKey.SelectedItems)
            {
                API.BookKey key = item as API.BookKey;
                idlist.Add(key.ID);
            }

            if (MessageBox.Show("确定删除吗？", "提示", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            RequestHelper.RequestAsync(this.busy, (int)MethodType.DeleteBKeys, new List<object>() { idlist},new EventHandler<API.ExecuteCompletedEventArgs>(Completed));
        }

        public void Completed (object sender,API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
               // SearchBook();
                int id = (int)GridKey.Tag;
                RequestHelper.RequestAsync(this.busy, (int)MethodType.GetBKeyByBID, new List<object>() { id }, new EventHandler<API.ExecuteCompletedEventArgs>(GetBKeyCompleted));
    
            }
        }

        #endregion

        #region 保存

        private void Save_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridList.SelectedItem == null)
            {
                MessageBox.Show("请选择需添加关键字的书籍！");
                return;
            }
            API.Book b = GridList.SelectedItem as API.Book;

            List<API.BookKey> models = GridScan.ItemsSource as List<API.BookKey>;
            foreach (var item in models)
            {
                item.BID = b.BID;
            }

            if(MessageBox.Show("确定为 "+b.BookName+"添加关键字吗？","",MessageBoxButton.OKCancel)==MessageBoxResult.Cancel)
            {
                return;
            }

            RequestHelper.RequestAsync(this.busy,(int)MethodType.AddBKeys, new List<object>() { models }, new EventHandler<API.ExecuteCompletedEventArgs>(SaveCompleted));
    
        }

        public void SaveCompleted (object sender,API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;

            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                if (GridList.SelectedItem == null)
                {
                    return;
                }
                API.Book b = GridList.SelectedItem as API.Book;
                GridKey.Tag = b.BID;
                RequestHelper.RequestAsync(this.busy, (int)MethodType.GetBKeyByBID, new List<object>() { b.BID }, new EventHandler<API.ExecuteCompletedEventArgs>(GetBKeyCompleted));
    
            }
        }

        #endregion 

        /// <summary>
        /// 添加关键字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click(object sender, RoutedEventArgs e)
        {
            //if (GridList.SelectedItem == null)
            //{
            //    MessageBox.Show("请选择需添加关键字的书籍！");
            //    return;
            //}

            if (string.IsNullOrEmpty(keys.Text))
            {
                Tool.PlayBackgAnimation(keys);
                return;
            }

            List<string> key = keys.Text.Split("\r\n".ToCharArray()).ToList();
            List<API.BookKey> BKS = new List<API.BookKey>();
           
            foreach (var item in key)
            {
                if (string.IsNullOrEmpty(item))
                {
                    continue;
                }
                API.BookKey bk = new API.BookKey();
                bk.BKey = item;
                BKS.Add(bk);
            }

            GridScan.ItemsSource = BKS;
            GridScan.Rebind();
            keys.Text = string.Empty;
        }

        /// <summary>
        /// 清空预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click_1(object sender, RoutedEventArgs e)
        {
            GridScan.ItemsSource = null;
            GridScan.Rebind();
        }

        /// <summary>
        /// 删除预览
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadButton_Click_2(object sender, RoutedEventArgs e)
        {
            if (GridScan.SelectedItems == null)
            {
                MessageBox.Show("请选择需删除的预览项！");
                return;
            }

            List<API.BookKey> list= GridScan.ItemsSource as List<API.BookKey>;
            foreach (var item in GridScan.SelectedItems)
            {
                API.BookKey bk = item as API.BookKey;
                foreach (var child in list)
                {
                    if (child == bk)
                    {
                        list.Remove(child);
                        break;
                    }
                }
            }

            GridScan.ItemsSource = list;
            GridScan.Rebind();
        }


    }

}
