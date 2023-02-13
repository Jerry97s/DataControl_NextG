using EF.Forms;
using iNervCore.DATA;
using iNervCore.UTIL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EF
{
    /// <summary>
    /// App.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class App : Application
    {
        private void Load(object sender, StartupEventArgs args)
        {
            

            CheckDir();

            LoadSetting();

            Main main = new Main();
            main.Show();
        }
        private void CheckDir()
        {
            CFunc.CheckDir(CData.sSetDir);
            CFunc.CheckDir(CData.sDataDir);
        }


        private void LoadSetting()
        {
            CFunc.LoadConfig();

            //pDB.LoadSet_Device();
            //pDB.Load_Opt1();
            //pDB.Load_Opt2();
            ////CData.garOpt1.Add(1);

            //int i = 0;
            //if (CData.garOpt1.Count < CData.garOpt1_Name.Length)
            //{
            //    i = CData.garOpt1.Count;
            //    for (; i < CData.garOpt1_Name.Length; ++i)
            //    {
            //        CData.garOpt1.Add(0);
            //        pDB.Insert_Opt1(i + 1, 0);
            //    }
            //}
            //if (CData.garOpt2.Count < CData.garOpt2_Name.Length)
            //{
            //    i = CData.garOpt2.Count;
            //    for (; i < CData.garOpt2_Name.Length; ++i)
            //    {
            //        CData.garOpt2.Add(CData.garOpt2_Default[i]);
            //        pDB.Insert_Opt2(i + 1, CData.garOpt2[i]);
            //    }
            //}
        }
    }
}
