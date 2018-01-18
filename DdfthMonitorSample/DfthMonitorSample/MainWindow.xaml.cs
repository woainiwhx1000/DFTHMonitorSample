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
using DFTHMonitor.dll;
using DFTHMonitor.widget;
using System.Windows.Forms;
namespace DfthMonitorSample
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void StartMeasure(object sender, RoutedEventArgs e)
        {
            string userName = UserName.Text;
            if (userName.Equals(""))
            {
                MessageDialog.ShowMessage("提示信息", "用户姓名不能为空");
                return;
            }
            string userAge = UserAge.Text;
            int age = 0;
            try
            {
                age = int.Parse(userAge);
                if(age <= 0 || age >= 120)
                {
                    MessageDialog.ShowMessage("提示信息", "年龄输入不合法");
                    return;
                }
            }
            catch (Exception)
            {
                MessageDialog.ShowMessage("提示信息", "年龄输入不合法");
                return;
            }
            string filePath = ECGFile.Text;
            if(filePath.Equals(""))
            {
                MessageDialog.ShowMessage("提示信息", "文件路径为空");
                return;
            }
            string userGender = Male.IsChecked  == true ? "男" : "女";
            DfthMonitorOutter outter = new DfthMonitorOutter();
            outter.StartMeasure(userName, age, userGender, filePath,result: MeausreResult);
        }

        private bool MeausreResult(string result,string user)
        {
            Console.WriteLine(result);
            return false;
        }

        private void Scan(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fhd = new OpenFileDialog();
            fhd.DefaultExt = "ecg";
            fhd.Filter = "心电文件 (*.ecg)|*ecg";
            DialogResult result = fhd.ShowDialog();
            if(result == System.Windows.Forms.DialogResult.OK)
            {
                StoreFile.Text = fhd.FileName;
            }
        }

        private void Look(object sender, RoutedEventArgs e)
        {
            string userName = UserName.Text;
            if (userName.Equals(""))
            {
                MessageDialog.ShowMessage("提示信息", "用户姓名不能为空");
                return;
            }
            string userAge = UserAge.Text;
            int age = 0;
            try
            {
                age = int.Parse(userAge);
                if (age <= 0 || age >= 120)
                {
                    MessageDialog.ShowMessage("提示信息", "年龄输入不合法");
                    return;
                }
            }
            catch (Exception)
            {
                MessageDialog.ShowMessage("提示信息", "年龄输入不合法");
                return;
            }
            string filePath = StoreFile.Text;
            if (filePath.Equals(""))
            {
                MessageDialog.ShowMessage("提示信息", "文件路径为空");
                return;
            }
            string userGender = Male.IsChecked == true ? "男" : "女";
            DfthMonitorOutter outter = new DfthMonitorOutter();
            outter.PlayBackByFilePath(userName, age, userGender, filePath);
        }
    }
}
