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

namespace EF.Forms
{
    /// <summary>
    /// Main.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Main : Window
    {
        List<Lsv_Param> lstLsvParam = null;
        MsgBox MsgBox = new MsgBox();
        public Main()
        {
            InitializeComponent();

            lstLsvParam = new List<Lsv_Param>();
            lstLsvParam.Add(new Lsv_Param() { sNowTime = "", sDiv1 = "", sDiv2 = "", sDetail = "" });
            lsvIOStr.ItemsSource = lstLsvParam;
        }


        private void OnLoad(object sender, RoutedEventArgs e)
        {
            
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void lsvServerStr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lsvIOStr_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSearchIO_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Search_EF Search_EF = new Search_EF();
            Search_EF.ShowDialog();
        }

        private void btnSearchREG_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Search_REG Search_REG = new Search_REG();
            Search_REG.ShowDialog();
        }

        private void btnSetting_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Setting Set = new Setting();
            Set.ShowDialog();
        }

        private void btnClose_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //Point pParentPoint = this.Parent.
            //MsgBox.WindowStartupLocation = WindowStartupLocation.Manual;
            //MsgBox.LocationChanged
            //MsgBox.Poi
            MsgBox.SetMsg("종료하시겠습니까?", System.Windows.Forms.MessageBoxButtons.YesNo, 5, 9999);
            MsgBox.ShowDialog();
            if (MsgBox.eDefaultRs == System.Windows.Forms.DialogResult.Yes)
            {
                FormClosing();
            }
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
