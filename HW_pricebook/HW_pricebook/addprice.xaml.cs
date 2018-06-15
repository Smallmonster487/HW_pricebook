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
    /// price.xaml 的互動邏輯
    /// </summary>
    
    

    public partial class addprice : UserControl
    {

        public string Daytimes
        {
            get
            {
                return DayTime.Text;
            }
            set
            {
                DayTime.Text = value;
            }

        }
        public string ItemName
        {
            get
            {
                return TaskName.Text;
            }
            set
            {
                TaskName.Text = value;
            }

        }
        public string ItemPrice
        {
            get
            {
                return TaskPrice.Text;
            }
            set
            {
                TaskPrice.Text = value;
            }

        }
        public addprice()
        {
            InitializeComponent();
        }
        // 自訂刪除事件
        public event EventHandler DeleteItem;

        // 項目名稱鍵盤按下事件
        private void TaskNamePreviewKeyDown(object sender, KeyEventArgs e)
        {
            // 任務空白，而且按下 Backspace 鍵時，引發 DeleteItem 事件
            if (TaskName.Text == "" && e.Key == Key.Back)
            {
                DeleteItem(this, null);
            }
        }
        public int itemPriceValue
        {
            get
            {
                //嘗試解析價格
                try
                {
                    return int.Parse(TaskPrice.Text);
                }
                //失敗後要求用家輸入數字
                catch
                {
                    MessageBox.Show("請輸入數字");
                    return 0;
                }
            }
            set
            {
                TaskPrice.Text = value.ToString();
            }
        }
       

    }
    
}
