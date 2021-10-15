using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Models
{
    public class CpuModel
    {
        #region Description
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string NumberOfPhysicalCores { get; set; }
        public string NumberOfLogicalCores { get; set; }
        #endregion

        #region Performance
        public double MaxClockSpeed { get; set; }
        public double ActualClockSpeed { get; set; }
        public double LoadPercentage { get; set; }
        #endregion


    }
}
