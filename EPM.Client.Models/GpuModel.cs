using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Models
{
    public class GpuModel
    {
        #region Description
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string DedicatedMemory { get; set; }
        #endregion

        #region Performance
        public double LoadPercentage { get; set; }
        #endregion
    }
}
