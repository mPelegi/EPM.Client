using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.Models.DTO
{
    public class PerformanceDTO
    {
        #region Hardwares
        public CpuDTO CPU { get; set; }
        public GpuDTO GPU { get; set; }
        public MoboDTO MotherBoard { get; set; }
        public RamDTO RAM { get; set; }
        public List<DriveDTO> Drives { get; set; }
        #endregion

        #region Softwares
        public OsDTO OperatingSystem { get; set; }
        #endregion
    }
}
