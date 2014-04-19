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
    /// AddBook.xaml 的交互逻辑
    /// </summary>
    public partial class AddBook : Page
    {
        public AddBook()
        {
            InitializeComponent();
            type.ItemsSource = Store.TypeInfos;
            this.type.SelectedIndex = 0;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(position.Text))
            {
                Tool.PlayBackgAnimation(position);
                return;
            }

            if (string.IsNullOrEmpty(serialNum.Text))
            {
                Tool.PlayBackgAnimation(serialNum); return;
            }

            if (string.IsNullOrEmpty(bookName.Text))
            {
                Tool.PlayBackgAnimation(bookName); return;
            }

            if (string.IsNullOrEmpty(author.Text))
            {
                Tool.PlayBackgAnimation(author); return;
            }

            if (type.SelectedIndex==-1)
            {
                Tool.PlayBackgAnimation(type); return;
            }

            if(price.Value==0)
            {
                Tool.PlayBackgAnimation(price); return;
            }

            if (string.IsNullOrEmpty(publisher.Text))
            {
                Tool.PlayBackgAnimation(publisher); return;
            }

            if (string.IsNullOrEmpty(pubDate.DateTimeText) || pubDate.SelectedDate==null)
            {
                Tool.PlayBackgAnimation(pubDate); return;
            }


            API.Book b = new API.Book();
            b.BAuthor = author.Text.Trim();
            b.BookName = bookName.Text.Trim();
            b.OutLine = outline.Text.Trim();
            b.SMPosition = position.Text.Trim();
            b.BPrice =(double) price.Value;
            b.Publisher = publisher.Text;
            b.PubDate = (DateTime)pubDate.SelectedDate;
            b.BTypeID = (int)type.SelectedValue;
            b.SerialNum = serialNum.Text;
          
            API.Result ret = RequestHelper.Request(this.busy, (int)MethodType.AddBook, new List<object>() { b});
            MessageBox.Show(ret.Message);
            if (ret.ReturnValue)
            {
                Clear();
            }
        }

        private void Clear()
        {
            this.bookName.Text = string.Empty;
            this.serialNum.Text = string.Empty;
            this.pubDate.DateTimeText = string.Empty;
            this.publisher.Text = string.Empty;
            this.position.Text = string.Empty;
            this.author.Text = string.Empty;
            this.outline.Text = string.Empty;
            this.price.Value = 0;
        }
    }
}
