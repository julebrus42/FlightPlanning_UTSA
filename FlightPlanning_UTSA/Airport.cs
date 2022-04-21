using System;
using System.Collections.Generic;
using System.Text;

namespace FlightPlanning_UTSA
{
    class Airport
    {
        public string ICAOCODE { get; }
        public int QNH { get; }
        public int temp { get; }
        public bool departure { get; }

        public Airport(string iCAOCODE, int temp, int QNH, bool landing)
        {
            this.ICAOCODE = iCAOCODE;
            this.QNH = QNH;
            this.temp = temp;
            this.departure = landing;
        }
    }
}
