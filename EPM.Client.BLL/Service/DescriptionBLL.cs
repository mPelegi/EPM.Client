using EPM.Client.BLL.Hardware;
using EPM.Client.BLL.Software;
using EPM.Client.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace EPM.Client.BLL.Service
{
    public class DescriptionBLL
    {
        static DescriptionDTO description;

        public DescriptionBLL()
        {
            description = new DescriptionDTO();
        }

        public DescriptionDTO CreateReport()
        {
            description.CPU = new CpuBLL().GetDescription();
            description.GPU = new GpuBLL().GetDescription();
            description.MotherBoard = new MoboBLL().GetDescription();
            description.RAMs = new RamBLL().GetDescription();
            description.Drives = new DriveBLL().GetDescription();
            description.OperatingSystem = new OsBLL().GetDescription();

            return description;
        }
    }
}
