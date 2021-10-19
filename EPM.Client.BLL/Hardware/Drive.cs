using EPM.Client.Helpers;
using EPM.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Management;
using System.Text;

namespace EPM.Client.DataCollector.Hardware
{
    public class Drive
    {
        private static string DiskDriveQuery = "SELECT * FROM Win32_DiskDrive";
        private ManagementObjectSearcher DiskDriveSearcher = new ManagementObjectSearcher(DiskDriveQuery);
        private DriveInfo[] AllDrives = DriveInfo.GetDrives();

        public Drive()
        {
            
        }

        public List<DriveModel> GetDescription()
        {
            List<DriveModel> retorno = new List<DriveModel>();

            string deviceID = null;
            string drivePartition = null;
            foreach (ManagementObject obj in DiskDriveSearcher.Get())
            {
                DriveModel drive = new DriveModel();

                drive.Model = Convert.ToString(obj["Model"]);
                drive.InterfaceType = Convert.ToString(obj["InterfaceType"]);
                drive.MediaType = Convert.ToString(obj["MediaType"]);
                drive.Partitions = Convert.ToString(obj["Partitions"]);
                drive.Status = Convert.ToString(obj["Status"]);

                deviceID = Convert.ToString(obj["DeviceID"]).Replace(@"\", "\\");
                drivePartition = "ASSOCIATORS OF {Win32_DiskDrive.DeviceID='" + deviceID + "'} WHERE AssocClass = Win32_DiskDriveToDiskPartition";

                using (ManagementObjectSearcher partitionSearch = new ManagementObjectSearcher(drivePartition))
                {
                    foreach (ManagementObject part in partitionSearch.Get())
                    {
                        drivePartition = "ASSOCIATORS OF {Win32_DiskPartition.DeviceID='" + part["DeviceID"] + "'} WHERE AssocClass = Win32_LogicalDiskToPartition";
                        using (ManagementObjectSearcher logicalpartitionsearch = new ManagementObjectSearcher(drivePartition))
                        {
                            foreach (ManagementObject logicalpartition in logicalpartitionsearch.Get())
                            {
                                drive.LogicalDisk = Convert.ToString(logicalpartition["DeviceID"]);
                            }
                        }
                    }
                }

                retorno.Add(drive);
            }

            return retorno;
        }

        public List<DriveModel> GetPerformance()
        {
            List<DriveModel> retorno = new List<DriveModel>();

            foreach (DriveInfo d in AllDrives)
            {
                DriveModel drive = new DriveModel();

                drive.LogicalDisk = d.Name.Replace(@"\", "");

                if (d.IsReady == true)
                {
                    drive.AvailableSizeMB = SizeConverter.ByteToMegabyte((ulong)d.TotalFreeSpace);
                    drive.TotalSizeMB = SizeConverter.ByteToMegabyte((ulong)d.TotalSize);
                    drive.AvailableSizeGB = SizeConverter.ByteToGigabyte((ulong)d.TotalFreeSpace);
                    drive.TotalSizeGB = SizeConverter.ByteToGigabyte((ulong)d.TotalSize);
                }

                retorno.Add(drive);
            }

            return retorno;
        }
    }
}
