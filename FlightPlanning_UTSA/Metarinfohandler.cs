using System;
using System.Collections.Generic;
using System.Text;

namespace FlightPlanning_UTSA
{
    class Metarinfohandler
    {
        public List<int> HandleMetarInfo(string MetarInfo)
        {
            List<int> info = new List<int>();

            String[] liste = MetarInfo.Split('=');

            int number = Convert.ToInt32(liste.Length);

            int lastString = number - 1;

            string METARINFO = liste[lastString];

            String[] METARINFO_list = METARINFO.Split(' ');

            foreach (String value in METARINFO_list)
            {

                if (value.Contains('/'))
                {
                    String[] temp = value.Split('/');
                    int tempNumber = Convert.ToInt32(temp[0]);
                    info.Add(tempNumber);
                }
                if (value.Contains('Q'))
                {
                    String[] QNH = value.Split('Q');
                    int QNHNumber = Convert.ToInt32(QNH[1]);
                    info.Add(QNHNumber);
                }
            }
            return info;
        }
    }
}
