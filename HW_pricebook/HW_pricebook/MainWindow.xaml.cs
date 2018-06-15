using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HW_pricebook
{
    /// <summary>
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            addprice item = new addprice();

            TaskList.Children.Add(item);
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {

            int AddPrice = 0;

            //按enter時會計算
            if (e.Key == Key.Return)
            {

                foreach (addprice item in TaskList.Children)
                {

                    AddPrice += item.itemPriceValue;
                }

                //顯示總價
                totalPrice.Text = AddPrice.ToString();
            }
        }

        private void Window_Closed(object sender, EventArgs e)
        {

            //設置一個字串
            string data = "";

            // 轉換項目
            foreach (addprice item in TaskList.Children)
            {

                //每一種資料區隔加入字串
                data += item.Daytimes + "|" + item.ItemName + "|" + item.ItemPrice + "\r\n";

            }
            //存檔
            System.IO.File.WriteAllText(@"D:\data.txt", data);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 開啟檔案
            string[] lines = System.IO.File.ReadAllLines(@"D:\data.txt");

            // 分析
            foreach (string line in lines)
            {
                // 隔開
                string[] parts = line.Split('|');

                //建立元件
                addprice item = new addprice();

                //讀取
                item.Daytimes = parts[0];
                item.ItemName = parts[1];
                item.ItemPrice = parts[2];

                //增加項目
                TaskList.Children.Add(item);
            }
        }

        private void AddButten_MouseDown(object sender, MouseButtonEventArgs e)
        {
            int AddPrice = 0;

            foreach (addprice item in TaskList.Children)
                {

                    AddPrice += item.itemPriceValue;
                }

              //顯示總價
              totalPrice.Text = AddPrice.ToString();
           
        }
    }
}
