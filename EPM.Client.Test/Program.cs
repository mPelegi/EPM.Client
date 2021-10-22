using System;
using System.Collections.Generic;
using System.Reflection;
using EPM.Client.BLL.Hardware;
using EPM.Client.BLL.Service;
using EPM.Client.BLL.Software;
using EPM.Client.Models;

namespace EPM.Client.Test
{
    class Program
    {
        static CpuDTO cpuModel { get; set; }
        static GpuDTO gpuModel { get; set; }
        static RamDTO ramModel { get; set; }
        static List<RamDTO> ramModels { get; set; }
        static MoboDTO moboModel { get; set; }
        static OsDTO osModel { get; set; }
        static List<DriveDTO> driveModels { get; set; }

        static void Main(string[] args)
        {
            //Processor();
            //GraphicCard();
            //Ram();
            //Mobo();
            //OS();
            //Drive();
            //SendDescription();
            //SendPerformance();
        }

        static void Processor()
        {
            CpuBLL cpu = new CpuBLL();

            cpuModel = cpu.GetDescription();
            PrintAttributes(cpuModel);
            cpuModel = cpu.GetPerformance();
            PrintAttributes(cpuModel);
        }

        static void GraphicCard()
        {
            GpuBLL gpu = new GpuBLL();

            gpuModel = gpu.GetDescription();
            PrintAttributes(gpuModel);
            gpuModel = gpu.GetPerformance();
            PrintAttributes(gpuModel);
        }

        static void Ram()
        {
            RamBLL ram = new RamBLL();

            ramModels = ram.GetDescription();
            ramModels.ForEach(x => PrintAttributes(x));
            ramModel = ram.GetPerformance();
            PrintAttributes(ramModel);
        }

        static void Mobo()
        {
            MoboBLL mobo = new MoboBLL();

            moboModel = mobo.GetDescription();
            PrintAttributes(moboModel);
        }

        static void OS()
        {
            OsBLL os = new OsBLL();

            osModel = os.GetDescription();
            PrintAttributes(osModel);
        }

        static void Drive()
        {
            DriveBLL drive = new DriveBLL();

            driveModels = drive.GetDescription();
            driveModels.ForEach(x => PrintAttributes(x));
            driveModels = drive.GetPerformance();
            driveModels.ForEach(x => PrintAttributes(x));
        }

        static void SendDescription()
        {
            ServiceBLL serviceBLL = new ServiceBLL();

            serviceBLL.Start();
        }

        static void SendPerformance()
        {
            ServiceBLL serviceBLL = new ServiceBLL();

            serviceBLL.StartMonitoring();
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
