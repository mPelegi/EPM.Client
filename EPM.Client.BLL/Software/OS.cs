using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace EPM.Client.DataCollector.Software
{
    public class OS
    {
        private static string OperatingSystemQuery = "SELECT * FROM Win32_OperatingSystem";
        private ManagementObjectSearcher OperatingSystemSearcher = new ManagementObjectSearcher(OperatingSystemQuery);

        public OS()
        {

        }

        public OSModel GetDescription()
        {
            OSModel retorno = new OSModel();

            foreach (ManagementObject obj in OperatingSystemSearcher.Get())
            {
                retorno.Name = Convert.ToString(obj["Caption"]);
                retorno.Manufacturer = Convert.ToString(obj["Manufacturer"]);
                retorno.CSName = Convert.ToString(obj["CSName"]);
                retorno.RegisteredUser = Convert.ToString(obj["RegisteredUser"]);
            }

            return retorno;
        }
    }
}
