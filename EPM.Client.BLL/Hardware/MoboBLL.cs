using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace EPM.Client.BLL.Hardware
{
    public class MoboBLL
    {
        private static string MotherboardQuery = "SELECT * FROM Win32_ComputerSystem";
        private ManagementObjectSearcher MotherboardSearcher = new ManagementObjectSearcher(MotherboardQuery);

        public MoboBLL()
        {

        }

        public MoboDTO GetDescription()
        {
            MoboDTO retorno = new MoboDTO();

            foreach (ManagementObject obj in MotherboardSearcher.Get())
            {
                retorno.Name = Convert.ToString(obj["Model"]);
                retorno.Manufacturer = Convert.ToString(obj["Manufacturer"]);
            }

            return retorno;
        }
    }
}
