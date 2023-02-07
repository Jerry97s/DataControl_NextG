using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF.Control
{
    public enum Page_IDX
    {
        HOME = 0,
        Search_EF = 1,
        Search_REG = 2,
        Setting = 3,
    }
    class Controls
    {
        

        public void Page_Control(Page_IDX Pages)
        {

            switch(Pages)
            {
                case Page_IDX.HOME:

                    break;
                case Page_IDX.Search_EF:
                    break;
                case Page_IDX.Search_REG:
                    break;
                case Page_IDX.Setting:
                    break;
                default:
                    break;
            }
        }
    }
}
