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

namespace BMS.BookManager
{
    /// <summary>
    /// UpdateBook.xaml 的交互逻辑
    /// </summary>
    public partial class UpdateBook : Page
    {
        public UpdateBook()
        {
            InitializeComponent();
      
            API.TypeInfo t = new API.TypeInfo();
            t.TypeID = -1;
            t.BTypeName = "全部";

            flag = true;
            List<API.TypeInfo> list = Store.TypeInfos;
            list.Add(t);
            sc_type.ItemsSource = list;
            sc_type.SelectedIndex = list.Count - 1;
            type.ItemsSource = list;

            this.GridList.ItemsSource = models;

            this.SizeChanged += new SizeChangedEventHandler(Search_SizeChanged);
        }

        private List<API.Book> models = new List<API.Book>();
        private int pageindex;
        private bool flag = false;


        void Search_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            DockPanel wp = this.FindName("panel") as DockPanel;
            wp.Width = e.NewSize.Width;

             RadDataPager rdp = this.FindName("page") as RadDataPager;
            RadNumericUpDown nud = this.FindName("pagesize") as RadNumericUpDown;
            rdp.Width = e.NewSize.Width - nud.Width;

            outline.Width = txt.ActualWidth - txtblock.ActualWidth;
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


        public void GetCompleted(object sender, API.ExecuteCompletedEventArgs e)
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
            if (GridList.SelectedItem == null) 
            {
                return;
            }
            API.Book b = GridList.SelectedItem as API.Book;
            position.Text = b.SMPosition;
            serialNum.Text = b.SerialNum;
            pubDate.DateTimeText = b.PubDate.ToString("yyyy-MM-dd");
            publisher.Text = b.Publisher;
            price.Value  = b.BPrice;
            bookName.Text = b.BookName;
            bookName.Tag = b.BID;
            author.Text = b.BAuthor;
            type.SelectedValue = b.BTypeID;

            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetOutLine, new List<object>() { b.BID }, new EventHandler<API.ExecuteCompletedEventArgs>(GetDetailCompleted));
        }

        public void GetDetailCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Result.Obj != null)
            {
                string outline = e.Result.Obj.ToString();

                if (string.IsNullOrEmpty(outline))
                {
                    return;
                }
                int index = 1;

                List<int> indexList = new List<int>();
                int ind;
                do
                {
                    ind = outline.IndexOf(index.ToString());
                    if (ind >= 0)
                    {
                        indexList.Add(ind);
                    }
                    index++;
                }
                while (ind >= 0);

                if (indexList.Count != 0)
                {
                    indexList.Add(outline.Length - 1);
                }
                string temps = "";

                for (int i = 0; i < indexList.Count; i++)
                {
                    char[] tem = new char[100];
                    outline.CopyTo(indexList[i], tem, 0, indexList[i + 1] - indexList[i]);

                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append(tem);
                    temps += sb.Replace("\0", "").ToString() + "\n\r";
                    if (i == indexList.Count - 2)
                    {
                        break;
                    }
                }

                this.outline.Text = temps;
            }
        }


        private void GridList_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            API.Book bok = GridList.SelectedItem as API.Book;

            RadTabItem rb = new RadTabItem();

            rb.Header = bok.BookName;
            rb.Content = new BookDetail(bok);
            rb.IsSelected = true;

            Main.AddTabItem(rb);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Sumbit_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(bookName.Text))
            {
                Tool.PlayBackgAnimation(bookName);
                return;
            }
            if (string.IsNullOrEmpty(author.Text))
            {
                Tool.PlayBackgAnimation(author);
                return;
            }
            if (string.IsNullOrEmpty(outline.Text))
            {
                Tool.PlayBackgAnimation(outline);
                return;
            }
            if (string.IsNullOrEmpty(publisher.Text))
            {
                Tool.PlayBackgAnimation(publisher);
                return;
            }
            //if (string.IsNullOrEmpty(serialNum.Text))
            //{
            //    Tool.PlayBackgAnimation(serialNum);
            //    return;
            //}
            if (string.IsNullOrEmpty(position.Text))
            {
                Tool.PlayBackgAnimation(position);
                return;
            }
            if (string.IsNullOrEmpty(pubDate.DateTimeText))
            {
                Tool.PlayBackgAnimation(pubDate);
                return;
            }
            API.Book b = new API.Book();
            b.BID = Convert.ToInt32(bookName.Tag);
            b.BAuthor = author.Text.Trim();
            b.BookName = bookName.Text.Trim();
            b.BPrice = (double)price.Value;
            b.BTypeID =(int) type.SelectedValue;
            b.OutLine = this.outline.Text.Trim();
            b.PubDate =(DateTime) pubDate.SelectedDate;
            b.Publisher = publisher.Text;
            b.SerialNum = serialNum.Text;
            b.SMPosition = position.Text;

            RequestHelper.RequestAsync(this.busy, (int)MethodType.UpdateBook, new List<object>() { b }, new EventHandler<API.ExecuteCompletedEventArgs>(SaveCompleted));
        }

        public void SaveCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                Clear();
            }
        }

        private void Clear()
        {
            bookName.Tag = null;
            author.Text = string.Empty;
            bookName.Text = string.Empty;
            price.Value = 0;
            this.outline.Text = string.Empty;
            pubDate.DateTimeText = string.Empty;
            publisher.Text = string.Empty;
            serialNum.Text = string.Empty;
            position.Text = string.Empty;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadMenuItem_Click(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
            if (GridList.SelectedItems == null)
            {
                MessageBox.Show("请选择要删除的书籍!");
                return;
            }
            if (MessageBox.Show("确定删除选中的书籍吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }

            List<int> bids = new List<int>();
            foreach (var item in GridList.SelectedItems)
            {
                API.Book b = item as API.Book;
                bids.Add(b.BID);
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.DeleteBook, new List<object>() { bids }, new EventHandler<API.ExecuteCompletedEventArgs>(DeleteCompleted));
        }

        public void DeleteCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            MessageBox.Show(e.Result.Message);

            if (e.Result.ReturnValue)
            {
                SearchBook();
            }
            Clear();
        }
      
    }
}
