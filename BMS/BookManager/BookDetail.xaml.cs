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

namespace BMS.BookManager
{
    /// <summary>
    /// BookDetail.xaml 的交互逻辑
    /// </summary>
    public partial class BookDetail : UserControl
    {
        public BookDetail()
        {
            InitializeComponent();
        }

        public BookDetail(API.Book book)
        {
            InitializeComponent();

            users.ItemsSource = Store.UserInfos;
            users.DisplayMemberPath = "UserName";
            users.SelectedValuePath = "UserID";
            users.SelectedIndex = 0;

            bookName.Text = book.BookName;
            bookName.Tag = book;
            author.Text = book.BAuthor;
            position.Text = book.SMPosition;
            serialNum.Text = book.SerialNum;
            price.Text = book.BPrice.ToString();
            publisher.Text = book.Publisher;
            pubDate.Text = book.PubDate.ToString("yyyy-MM-dd");

            borow.IsEnabled = true;
            Return.IsEnabled = true;
            if (book.IsBorow)
            {
                borow.IsEnabled = false;
                state.Text = "已借";
                state.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                Return.IsEnabled = false;
                state.Text = "可借";
                state.Foreground = new SolidColorBrush(Colors.Green);
            }
            var t = from a in Store.TypeInfos
                    where a.TypeID == book.BTypeID
                    select a;
            if (t.Count() != 0)
            {
                type.Text = t.First().BTypeName;
            }
            RequestHelper.RequestAsync(this.busy, (int)MethodType.GetOutLine, new List<object>() { book.BID }, new EventHandler<API.ExecuteCompletedEventArgs>(GetDetailCompleted));
        }

        public void GetDetailCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;
            if (e.Result.Obj != null)
            {
                string outline = e.Result.Obj.ToString();

                if (string.IsNullOrEmpty(outline))
                {
                    this.outline.Text = "无";
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

                indexList.Add(outline.Length - 1);
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

        #region  借书

        private void borow_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定借阅该书吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            API.Book b = bookName.Tag as API.Book;

            bool flag = false;
            object usr = users.Txt.Text;

            if (users.SelectedValue != null)
            {
                usr = users.SelectedValue;
                flag = true;
            }

            RequestHelper.RequestAsync(this.busy, (int)MethodType.Borow, new List<object>() { flag, usr, new List<int>() { b.BID } }, new EventHandler<API.ExecuteCompletedEventArgs>(BorowCompleted));
        }

        public void BorowCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;

            MessageBox.Show(e.Result.Message);
            if (e.Result.ReturnValue)
            {
                this.Return.IsEnabled = true;
                this.borow.IsEnabled = false;
                state.Text = "已借";
                state.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        #endregion

        #region   还书

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("确定归还该书吗？", "", MessageBoxButton.OKCancel) == MessageBoxResult.Cancel)
            {
                return;
            }
            API.Book b = bookName.Tag as API.Book;

            RequestHelper.RequestAsync(this.busy, (int)MethodType.Return, new List<object>() { users.Txt.Text, new List<int>() { b.BID } }, new EventHandler<API.ExecuteCompletedEventArgs>(ReturnCompleted));
        }

        public void ReturnCompleted(object sender, API.ExecuteCompletedEventArgs e)
        {
            this.busy.IsBusy = false;

            MessageBox.Show(e.Result.Message);

            if (e.Result.ReturnValue)
            {
                this.Return.IsEnabled = false;
                this.borow.IsEnabled = true;
                state.Text = "可借";
                state.Foreground = new SolidColorBrush(Colors.Green);
            }

        }

        #endregion
    }
}
