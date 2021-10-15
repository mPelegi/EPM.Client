using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Text;

namespace EPM.Client.DataCollector.Hardware
{
    public class CPU
    {
        private static string ProcessorQuery = "SELECT * FROM Win32_Processor";
        private ManagementObjectSearcher ProcessorSearcher = new ManagementObjectSearcher(ProcessorQuery);
        private static PerformanceCounter PerformanceCounter = new PerformanceCounter("Processor Information", "% Processor Performance", "_Total");
        private static PerformanceCounter LoadCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

        public CPU()
        {
            CpuClockPercentage();
            CpuLoadPercentage();
        }

        public CpuModel GetDescription()
        {
            CpuModel retorno = new CpuModel();

            foreach (ManagementObject obj in ProcessorSearcher.Get())
            {
                retorno.Name = Convert.ToString(obj["Name"]);
                retorno.Manufacturer = Convert.ToString(obj["Manufacturer"]);
                retorno.NumberOfPhysicalCores = Convert.ToString(obj["NumberOfCores"]);
                retorno.NumberOfLogicalCores = Convert.ToString(obj["NumberOfLogicalProcessors"]);
            }

            return retorno;
        }

        public CpuModel GetPerformance()
        {
            CpuModel retorno = new CpuModel();

            foreach (ManagementObject obj in ProcessorSearcher.Get())
            {
                retorno.MaxClockSpeed = Convert.ToDouble(obj["MaxClockSpeed"]) / 1000;
                retorno.ActualClockSpeed = retorno.MaxClockSpeed * CpuClockPercentage() / 100;
                retorno.LoadPercentage = CpuLoadPercentage();
            }

            return retorno;
        }

        private double CpuClockPercentage()
        {
            return (double)PerformanceCounter.NextValue();
        }

        private double CpuLoadPercentage()
        {
            return (double)LoadCounter.NextValue();
        }
    }
}
