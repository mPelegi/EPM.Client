using EPM.Client.Helpers;
using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;

namespace EPM.Client.BLL.Hardware
{
    public class CpuBLL
    {
        private static string ProcessorQuery = "SELECT * FROM Win32_Processor";
        private ManagementObjectSearcher ProcessorSearcher = new ManagementObjectSearcher(ProcessorQuery);
        private static PerformanceCounter PerformanceCounter = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");
        private static PerformanceCounter LoadCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public CpuBLL()
        {
            CpuClockPercentage();
            CpuLoadPercentage();
        }

        public CpuDTO GetDescription()
        {
            CpuDTO retorno = new CpuDTO();

            foreach (ManagementObject obj in ProcessorSearcher.Get())
            {
                retorno.Name = Convert.ToString(obj["Name"]);
                retorno.Manufacturer = Convert.ToString(obj["Manufacturer"]);
                retorno.NumberOfPhysicalCores = Convert.ToString(obj["NumberOfCores"]);
                retorno.NumberOfLogicalCores = Convert.ToString(obj["NumberOfLogicalProcessors"]);
            }

            return retorno;
        }

        public CpuDTO GetPerformance()
        {
            CpuDTO retorno = new CpuDTO();

            foreach (ManagementObject obj in ProcessorSearcher.Get())
            {
                retorno.MaxClockSpeedMHz = Convert.ToDecimal(obj["MaxClockSpeed"]);
                retorno.MaxClockSpeedGHz = UnitConverter.MHzToGHz((uint)obj["MaxClockSpeed"]);
                retorno.ActualClockSpeedMHz = retorno.MaxClockSpeedMHz * CpuClockPercentage() / 100;
                retorno.ActualClockSpeedGHz = retorno.MaxClockSpeedGHz * CpuClockPercentage() / 100;
                retorno.LoadPercentage = Math.Round(CpuLoadPercentage(), 2);
            }

            return retorno;
        }

        private decimal CpuClockPercentage()
        {
            return (decimal)PerformanceCounter.NextValue();
        }

        private decimal CpuLoadPercentage()
        {
            return (decimal)LoadCounter.NextValue();
        }
    }
}
