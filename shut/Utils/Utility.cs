using System;
using System.Collections.Generic;
using System.Text;

namespace ShutShut.Utils
{
    class Utility
    {

        public int determineDelta(DateTime d1, DateTime d2)
        {
            int ret = 0;

            //determino i secondi attuali di differenza
            if (d1 >= d2)
            {
                ret = (int)(d1 - d2).TotalSeconds;
            }
            else
            {
                ret = (int)(d2 - d1).TotalSeconds;
            }

            return ret;
        }

    }
}
