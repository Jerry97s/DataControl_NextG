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
using System.Windows.Shapes;
using System.Windows.Navigation;
using System.Windows.Threading;

namespace EF.Forms
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {
        List<Lsv_Param> lstLsvParam = null;
        MsgBox Window_MsgBox = null;
        Setting Window_Setting = null;
        Search_REG Window_Search_REG = null;
        Search_IO Window_Search_IO = null;
        public Main()
        {
            InitializeComponent();

            lstLsvParam = new List<Lsv_Param>();
            lstLsvParam.Add(new Lsv_Param() { sNowTime = "", sDiv1 = "", sDiv2 = "", sDetail = "" });
            lsvIOStr.ItemsSource = lstLsvParam;
           
        }


        private void OnLoad(object sender, RoutedEventArgs e)
        {
            Load_Form();

            btnSearchIO.MouseLeftButtonDown += btnClick_Main;
            btnSearchREG.MouseLeftButtonDown += btnClick_Main;
            btnSetting.MouseLeftButtonDown += btnClick_Main;
            btnClose.MouseLeftButtonDown += btnClick_Main;

        }
        private void Load_Form()
        {
            Window_MsgBox = new MsgBox();
            Window_Setting = new Setting();
            Window_Search_REG = new Search_REG();
            Window_Search_IO = new Search_IO();

            Window_MsgBox.Owner = Application.Current.MainWindow;
            Window_Setting.Owner = Application.Current.MainWindow;
            Window_Search_REG.Owner = Application.Current.MainWindow;
            Window_Search_IO.Owner = Application.Current.MainWindow;
        }

        private void btnClick_Main(object sender, MouseButtonEventArgs e)
        {
           Dispatcher.Invoke(DispatcherPriority.Normal
                , new Action(delegate
                {
                    switch (((Image)sender).Name)
                    {
                        case "btnSearchIO":
                            Window_Search_IO.ShowDialog();
                            break;
                        case "btnSearchREG":
                            Window_Search_REG.ShowDialog();
                            break;
                        case "btnSetting":
                            Window_Setting.ShowDialog();
                            break;
                        case "btnClose":
                            Window_MsgBox.SetMsg("종료하시겠습니까?", System.Windows.Forms.MessageBoxButtons.YesNo, 5, 9999);
                            
                            Window_MsgBox.ShowDialog();
                            if (Window_MsgBox.eDefaultRs == System.Windows.Forms.DialogResult.Yes)
                            {
                                FormClosing();
                            }
                            break;
                        default:
                            break;
                    }
                }));
        }


        private void FormClosing()
        {
            App.Current.Shutdown();
        }

        private void lsvEFStr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }
    }
    public class Lsv_Param
    {
        public string sNowTime { get; set; }
        public string sDiv1 { get; set; }
        public string sDiv2 { get; set; }
        public string sDetail { get; set; }
    }
}
