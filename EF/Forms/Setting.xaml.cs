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
using System.Windows.Threading;

namespace EF.Forms
{
    /// <summary>
    /// Setting.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Setting : Window
    {
        public Setting()
        {
            InitializeComponent();
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            //WindowStartupLocation wsl = new WindowStartupLocation();
            //wsl = new Point(10, 10);

            btnClose.Click += btnClick_Setting;

        }

        private void btnClick_Setting(object sender, RoutedEventArgs e)
        {
            Dispatcher.Invoke(DispatcherPriority.Normal
                , new Action(delegate
                {
                    switch(((Button)sender).Name)
                    {
                        case "btnClose":
                            Close();
                            break;
                        default:
                            break;
                    }
                    
                }));
        }

        delegate void FHideWindow();

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)

        {

            e.Cancel = true;

            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new

            FHideWindow(_HideThisWindow));

        }



        void _HideThisWindow()

        {

            this.Hide();

        }
    }
}
