using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;


namespace EF.Forms
{
    /// <summary>
    /// MsgBox.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MsgBox : Window
    {
        System.Timers.Timer pTimer = null;
        int nShowTime = 10;
        int nNowTime = 0;
        string sOrginMsg = "";
        int sOrginType = 0;

        public DialogResult eDefaultRs =  System.Windows.Forms.DialogResult.None;

        public MsgBox()
        {
            InitializeComponent();
            pTimer = new System.Timers.Timer();
            pTimer.Interval = 1000;
            pTimer.Elapsed += new System.Timers.ElapsedEventHandler(ShowTimer);

            btnLeft.Click += btnClick;
            btnRight.Click += btnClick;
        }

        public void OnLoad(object sender, RoutedEventArgs e)
        {
            //WindowStartupLocation wsl = new WindowStartupLocation();
            //wsl = new Point(10, 10);

            eDefaultRs = System.Windows.Forms.DialogResult.None;

        }

        private void ShowTimer(object sender, EventArgs e)
        {
            //SecTmr_Work();
            Dispatcher.Invoke(DispatcherPriority.Normal
                , new Action(delegate
                {
                    SecTmr_Work();
                }));
        }
        private void SecTmr_Work()
        {
            nNowTime++;
            if (nShowTime > nNowTime)
            {
                lblMsg_Detail.Content = sOrginMsg;
                lblMsg_Timer.Content = "(" + (nShowTime - nNowTime).ToString() + ")";
            }
            else
            {
                if (eDefaultRs != System.Windows.Forms.DialogResult.Yes)
                    Clear();
            }
        }

        public void Clear(bool bClose = false)
        {
            nShowTime = 0;
            pTimer.Stop();
            if(bClose)
            {
                pTimer.Dispose();
                pTimer = null;
            }
            Close();
        }

        /// <summary>
        /// MsgBox Set
        /// </summary>
        /// <param name="sMsg"></param>
        /// <param name="btn"></param>
        /// <param name="nTime"></param>
        /// <param name="MsgType">
        /// 9999 => 종료
        /// </param>
        public void SetMsg(string sMsg, MessageBoxButtons btn = MessageBoxButtons.YesNo, int nTime = 10, int MsgType = 0)
        {
            //string sSetMsg = "";
            sOrginMsg = sMsg;
            sOrginType = MsgType;
                //pTimer.Stop();
                nNowTime = 0;
            if (nTime > 0)
            {
                nShowTime = nTime;
                string timeTxt = $"({nShowTime.ToString()})";
                //lblMsg.Content = sOrginMsg + "\r\n" + timeTxt;
                lblMsg_Detail.Content = sOrginMsg;
                lblMsg_Timer.Content = "(" + (nShowTime - nNowTime).ToString() + ")";
            }

            //eDefaultRs = eDefaultRes;

            if (btn == MessageBoxButtons.YesNo)
            {
                btnLeft.Content = "예";
                btnRight.Content = "아니오";

            }

            pTimer.Start();

        }

        private void btnClick(object sender, RoutedEventArgs e)
        {
            bool bClose = false;
            switch (((System.Windows.Controls.Button)sender).Name)
            {
                case "btnLeft":
                    eDefaultRs = System.Windows.Forms.DialogResult.Yes;
                    bClose = true;
                    break;
                case "btnRight":
                    eDefaultRs = System.Windows.Forms.DialogResult.No;
                    break;
                default:
                    break;
            }
            Clear(bClose);


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
