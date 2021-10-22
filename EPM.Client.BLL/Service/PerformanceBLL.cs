using EPM.Client.BLL.Hardware;
using EPM.Client.BLL.Software;
using EPM.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.BLL.Service
{
    public class PerformanceBLL
    {
        static PerformanceDTO performance;

        public PerformanceBLL()
        {
            performance = new PerformanceDTO();
        }

        public PerformanceDTO CreateReport()
        {
            performance.CPU = new CpuBLL().GetPerformance();
            performance.GPU = new GpuBLL().GetPerformance();
            performance.RAM = new RamBLL().GetPerformance();
            performance.Drives = new DriveBLL().GetPerformance();

            return performance;
        }
    }
}
