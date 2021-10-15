using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Models
{
    public class DriveModel
    {
        #region Description
        public string Model { get; set; }
        public string InterfaceType { get; set; }
        public string MediaType { get; set; }
        public string Partitions { get; set; }
        public string Status { get; set; }
        #endregion

        #region Performance
        public string LogicalDisk { get; set; }
        public string TotalSize { get; set; }
        public string AvailableSize { get; set; }
        #endregion
    }
}
