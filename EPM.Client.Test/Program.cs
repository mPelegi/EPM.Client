using System;
using System.Collections.Generic;
using System.Reflection;
using EPM.Client.DataCollector.Hardware;
using EPM.Client.DataCollector.Software;
using EPM.Client.Models;

namespace EPM.Client.Test
{
    class Program
    {
        static CpuModel cpuModel { get; set; }
        static GpuModel gpuModel { get; set; }
        static RamModel ramModel { get; set; }
        static List<RamModel> ramModels { get; set; }
        static MoboModel moboModel { get; set; }
        static OSModel osModel { get; set; }
        static List<DriveModel> driveModels { get; set; }

        static void Main(string[] args)
        {
            Processor();
            GraphicCard();
            Ram();
            Mobo();
            OS();
            Drive();
        }

        static void Processor()
        {
            CPU cpu = new CPU();

            cpuModel = cpu.GetDescription();
            PrintAttributes(cpuModel);
            cpuModel = cpu.GetPerformance();
            PrintAttributes(cpuModel);
        }

        static void GraphicCard()
        {
            GPU gpu = new GPU();

            gpuModel = gpu.GetDescription();
            PrintAttributes(gpuModel);
            gpuModel = gpu.GetPerformance();
            PrintAttributes(gpuModel);
        }

        static void Ram()
        {
            RAM ram = new RAM();

            ramModels = ram.GetDescription();
            ramModels.ForEach(x => PrintAttributes(x));
            ramModel = ram.GetPerformance();
            PrintAttributes(ramModel);
        }

        static void Mobo()
        {
            MOBO mobo = new MOBO();

            moboModel = mobo.GetDescription();
            PrintAttributes(moboModel);
        }

        static void OS()
        {
            OS os = new OS();

            osModel = os.GetDescription();
            PrintAttributes(osModel);
        }

        static void Drive()
        {
            Drive drive = new Drive();

            driveModels = drive.GetDescription();
            driveModels.ForEach(x => PrintAttributes(x));
            driveModels = drive.GetPerformance();
            driveModels.ForEach(x => PrintAttributes(x));
        }

        static void PrintAttributes(object obj)
        {
            
            PropertyInfo[] pi = obj.GetType().GetProperties();
            Console.WriteLine("\n\n{0}", obj.ToString());
            foreach (PropertyInfo p in pi)
            {
                if (p.GetValue(obj) != null)
                {
                    Console.WriteLine(p.Name + " : " + Convert.ToString(p.GetValue(obj)));
                }
            }
        }
    }
}
