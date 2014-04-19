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
using System.Reflection;

namespace BMS.MyControl
{
    /// <summary>
    /// MyComboBox.xaml 的交互逻辑
    /// </summary>
    public partial class MyComboBox : UserControl
    {
        public MyComboBox()
        {
            InitializeComponent();
            listBox.Visibility = Visibility.Hidden;
            listBox.MaxHeight = 150;
            listBox.SelectionChanged += new SelectionChangedEventHandler(listBox_SelectionChanged);
        }

        void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PropertyInfo pi = CurrentType.GetProperty(displayMemberPath);
            string value = pi.GetValue((sender as ListBox).SelectedItem, null).ToString();
            this.Txt.Text = value;
            listBox.Visibility = Visibility.Hidden;
        }
        private Type CurrentType = null;

        private System.Collections.IEnumerable itemsSource = null;

        public System.Collections.IEnumerable ItemsSource
        {
            get { return itemsSource; }
            set
            {
                itemsSource = value;
                listBox.ItemsSource = itemsSource;
                foreach (var item in itemsSource)
                {
                    CurrentType = item.GetType();
                    break;
                }
            }
        }

        private string selectedValuePath;

        public string SelectedValuePath
        {
            set
            {
                selectedValuePath = value;
                listBox.SelectedValuePath = selectedValuePath;
            }
        }

        private string displayMemberPath;

        public string DisplayMemberPath
        {
            set
            {
                displayMemberPath = value;
                listBox.DisplayMemberPath = displayMemberPath;
            }
        }

        public object SelectedValue
        {
            get { return listBox.SelectedValue; }
        }

        public object SelectedItem
        {
            get { return listBox.SelectedItem; }
        }

        public int SelectedIndex
        {
            get { return listBox.SelectedIndex; }
            set { listBox.SelectedIndex = value; }
        }

        private void dropDown_Click(object sender, RoutedEventArgs e)
        {
            if (listBox.Visibility == Visibility.Visible)
            {
                listBox.Visibility = Visibility.Hidden;
                return;
            }
            listBox.Visibility = Visibility.Visible;
        }


    }
}
