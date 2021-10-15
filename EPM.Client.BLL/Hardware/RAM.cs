using EPM.Client.Helpers;
using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.Management;
using System.Text;

namespace EPM.Client.DataCollector.Hardware
{
    public class RAM
    {
        private static string MemoryQuery = "SELECT * FROM Win32_PhysicalMemory";
        private static string OperatingSystemQuery = "SELECT * FROM Win32_OperatingSystem";
        private ManagementObjectSearcher MemorySearcher = new ManagementObjectSearcher(MemoryQuery);
        private ManagementObjectSearcher OperatingSystemSearcher = new ManagementObjectSearcher(OperatingSystemQuery);

        public RAM()
        {

        }

        public List<RamModel> GetDescription()
        {
            List<RamModel> retorno = new List<RamModel>();

            foreach (ManagementObject obj in MemorySearcher.Get())
            {
                RamModel ramAux = new RamModel();

                ramAux.PartNumber = Convert.ToString(obj["PartNumber"]);
                ramAux.ClockSpeed = Convert.ToString(obj["ConfiguredClockSpeed"]);
                ramAux.Manufacturer = Convert.ToString(obj["Manufacturer"]);
                ramAux.Capacity = SizeConverter.ToConvert((ulong)obj["Capacity"]);
                ramAux.Tag = Convert.ToString(obj["Tag"]);

                retorno.Add(ramAux);
            }

            return retorno;
        }

        public RamModel GetPerformance()
        {
            RamModel retorno = new RamModel();

            foreach (ManagementObject obj in OperatingSystemSearcher.Get())
            {
                retorno.FreeMemory = SizeConverter.KilobyteToGigabyte((ulong)obj["FreePhysicalMemory"]);
                retorno.TotalMemory = SizeConverter.KilobyteToGigabyte((ulong)obj["TotalVisibleMemorySize"]);
            }


            return retorno;
        }
    }
}
