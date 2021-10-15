using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Models
{
    public class RamModel
    {
        #region Description
        public string PartNumber { get; set; }
        public string ClockSpeed { get; set; }
        public string Manufacturer { get; set; }
        public string Capacity { get; set; }
        public string Tag { get; set; }
        #endregion

        #region Performance
        public double FreeMemory { get; set; }
        public double TotalMemory { get; set; }
        #endregion
    }
}
