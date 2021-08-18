using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace 配置检测引擎
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
                return;
            if (args[0] == "/?")
            {
                Console.WriteLine("\n用法：    Detect [-p] [-z] [-n] [-w] [-c] [-b] [-j] [-x] [-m]\n\n");

                Console.WriteLine("\n选项：    -p      输出处理器信息\n" +
                                    "          -z      输出主板信息\n" +
                                    "          -n      输出内存信息\n" +
                                    "          -w      输出网卡信息\n" +
                                    "          -c      输出磁盘信息\n" +
                                    "          -b      输出BIOS信息\n" +
                                    "          -j      输出监视器信息\n" +
                                    "          -x      输出显卡信息\n" +
                                    "          -m      输出系统信息");
                return;
            }

            ManagementClass a = new ManagementClass("Win32_Processor");//处理器信息
            ManagementClass b = new ManagementClass("Win32_BaseBoard");//主板信息
            ManagementClass c = new ManagementClass("Win32_PhysicalMemory");//内存信息
            ManagementClass d = new ManagementClass("Win32_NetworkAdapter");//网卡信息
            ManagementClass e = new ManagementClass("Win32_DiskDrive");//磁盘信息
            ManagementClass f = new ManagementClass("Win32_BIOS");//BIOS信息
            ManagementClass g = new ManagementClass("Win32_DesktopMonitor");//监视器信息
            ManagementClass h1 = new ManagementClass("Win32_DisplayConfiguration");//显卡信息 1
            ManagementClass h2 = new ManagementClass("Win32_VideoController");//显卡信息 2
            ManagementClass j = new ManagementClass("Win32_OperatingSystem");//系统信息

            if (args[0] == "Detect" && args .Length > 1)
            {
                string str = "";
                for(int i = 0;i < args.Length;i ++)
                    str += args[i];

                if (str.Contains ("-p"))
                {
                    //处理器
                    foreach (ManagementObject o in a.GetInstances())
                    {
                        Console.WriteLine("CPU名称：" + o["name"] + "<-");
                        Console.WriteLine("CPU编号：" + o["ProcessorId"] + "<-");
                        Console.WriteLine("CPU版本：" + o["Version"] + "<-");
                        Console.WriteLine("CPU位宽：" + o["AddressWidth"] + "<-");
                        Console.WriteLine("CPU主频：" + o["CurrentClockSpeed"] + "<-");
                        Console.WriteLine("CPU外频：" + o["ExtClock"] + "<-");
                        Console.WriteLine("CPU接口：" + o["SocketDesignation"] + "<-");
                        Console.WriteLine("CPU制造商：" + o["Manufacturer"] + "<-");
                        Console.WriteLine("CPU核心数：" + o["NumberOfCores"] + "<-");
                        Console.WriteLine("CPU线程数：" + o["NumberOfLogicalProcessors"] + "<-");
                        Console.WriteLine("CPU L2缓存：" + o["L2CacheSize"] + "<-");
                        Console.WriteLine("CPU L3缓存：" + o["L3CacheSize"] + "<-");
                        Console.WriteLine("CPU电压：" + o["CurrentVoltage"] + "<-");
                        Console.WriteLine("虚拟化支持：" + o["VirtualizationFirmwareEnabled"] + "<-");
                        Console.WriteLine("Hyper-V支持：" + o["VMMonitorModeExtensions"] + "<-");
                    }
                }

                if (str.Contains("-z"))
                {
                    //主板
                    foreach (ManagementObject o in b.GetInstances())
                    {
                        Console.WriteLine("主板型号：" + o["Product"] + "<-");
                        Console.WriteLine("主板制造商：" + o["Manufacturer"] + "<-");
                        Console.WriteLine("主机板：" + o["HostingBoard"] + "<-");
                        Console.WriteLine("热拔插支持：" + o["HotSwappable"] + "<-");
                    }
                }

                if (str.Contains("-n"))
                {
                    //内存
                    foreach (ManagementObject o in c.GetInstances())
                    {
                        Console.WriteLine("内存编号：" + o["DeviceLocator"] + "<-");
                        Console.WriteLine("内存类型：" + o["Description"] + "<-");
                        Console.WriteLine("内存位宽：" + o["DataWidth"] + "<-");
                        Console.WriteLine("内存标签：" + o["BankLabel"] + "<-");
                        Console.WriteLine("内存容量：" + o["Capacity"] + "<-");
                        Console.WriteLine("内存频率：" + o["Speed"] + "<-");
                        Console.WriteLine("生产厂商：" + o["Manufacturer"] + "<-");
                        Console.WriteLine("热拔插支持：" + o["HotSwappable"] + "<-");
                    }
                }

                if(str.Contains ("-w"))
                {
                    //网卡
                    foreach (ManagementObject o in d.GetInstances())
                    {
                        if (!o["Manufacturer"].ToString().Contains("Microsoft"))
                        {
                            Console.WriteLine("网卡编号：" + o["DeviceID"] + "<-");
                            Console.WriteLine("网卡名称：" + o["Name"] + "<-");
                            Console.WriteLine("网卡类型：" + o["AdapterType"] + "<-");
                            Console.WriteLine("物理设备：" + o["PhysicalAdapter"] + "<-");
                            Console.WriteLine("电源管理：" + o["PowerManagementSupported"] + "<-");
                            Console.WriteLine("产品名称：" + o["ProductName"] + "<-");
                            Console.WriteLine("网卡带宽：" + o["Speed"] + "<-");
                            Console.WriteLine("生产厂商：" + o["Manufacturer"] + "<-");
                            Console.WriteLine("设备描述：" + o["Description"] + "<-");
                            Console.WriteLine("MAC地址：" + o["MACAddress"] + "<-");
                        }
                    }
                }

                if(str.Contains ("-c"))
                {
                    //磁盘
                    foreach (ManagementObject o in e.GetInstances())
                    {
                        Console.WriteLine("磁盘名称：" + o["Name"] + "<-");
                        Console.WriteLine("磁盘型号：" + o["Model"] + "<-");
                        Console.WriteLine("磁盘状态：" + o["Status"] + "<-");
                        Console.WriteLine("生产厂商：" + o["Manufacturer"] + "<-");
                        Console.WriteLine("磁盘大小：" + o["Size"] + "<-");
                        Console.WriteLine("磁盘描述：" + o["Description"] + "<-");
                        Console.WriteLine("柱面总数：" + o["TotalCylinders"] + "<-");
                        Console.WriteLine("磁头总数：" + o["TotalHeads"] + "<-");
                        Console.WriteLine("扇区总数：" + o["TotalSectors"] + "<-");
                        Console.WriteLine("序列号：" + o["SerialNumber"] + "<-");
                    }
                }

                if(str.Contains ("-b"))
                {
                    //BIOS
                    foreach (ManagementObject o in f.GetInstances())
                    {
                        Console.WriteLine("BIOS名称：" + o["Name"] + "<-");
                        Console.WriteLine("生产厂商：" + o["Manufacturer"] + "<-");
                        Console.WriteLine("主要BIOS：" + o["PrimaryBIOS"] + "<-");
                        Console.WriteLine("BIOS版本：" + o["Version"] + "<-");
                    }
                }

                if(str.Contains ("-j"))
                {
                    //监视器
                    foreach (ManagementObject o in g.GetInstances())
                    {
                        Console.WriteLine("监视器名称：" + o["Name"] + "<-");
                        Console.WriteLine("监视器类型：" + o["MonitorType"] + "<-");
                        Console.WriteLine("生产厂商：" + o["MonitorManufacturer"] + "<-");
                        Console.WriteLine("监视器编号：" + o["DeviceID"] + " <-");
                        Console.WriteLine("监视器高度：" + o["ScreenHeight"] + "<-");
                        Console.WriteLine("监视器宽度：" + o["ScreenWidth"] + "<-");
                        Console.WriteLine("电源管理支持：" + o["PowerManagementSupported"] + "<-");
                    }
                }

                if(str.Contains ("-x"))
                {
                    //显卡
                    foreach (ManagementObject o in h1.GetInstances())
                    {
                        Console.WriteLine("设备名称：" + o["DeviceName"] + "<-");
                        foreach (ManagementObject o2 in h2.GetInstances())
                        {
                            Console.WriteLine("芯片厂商：" + o2["AdapterCompatibility"] + "<-");
                            Console.WriteLine("出厂日期：" + o2["DriverDate"] + "<-");
                            Console.WriteLine("内存大小：" + o2["AdapterRAM"] + "<-");
                            Console.WriteLine("驱动程序：" + o2["InstalledDisplayDrivers"] + "<-");
                            Console.WriteLine("驱动版本：" + o2["DriverVersion"] + "<-");
                            Console.WriteLine("DAC类型：" + o2["AdapterDACType"] + "<-");
                            Console.WriteLine("最大刷新率：" + o2["MaxRefreshRate"] + "<-");
                            Console.WriteLine("最小刷新率：" + o2["MinRefreshRate"] + "<-");
                            Console.WriteLine("当前显示模式：" + o2["VideoModeDescription"] + "<-");
                        }
                    }
                }

                if(str.Contains ("-m"))
                {
                    //操作系统
                    foreach (ManagementObject o in j.GetInstances())
                    {
                        Console.WriteLine("系统名称：" + o["Caption"] + "<-");
                        foreach (ManagementObject o2 in j.GetInstances())
                        {
                            Console.WriteLine("计算机名称：" + o2["CSName"] + "<-");
                        }
                        Console.WriteLine("系统版本：" + o["Version"] + "<-");
                        Console.WriteLine("系统位宽：" + o["OSArchitecture"] + "<-");
                        Console.WriteLine("注册用户：" + o["RegisteredUser"] + "<-");
                        Console.WriteLine("安装日期：" + o["InstallDate"] + "<-");
                        Console.WriteLine("序列号：" + o["SerialNumber"] + "<-");
                    }
                }
                return;
            }
            else
            {
                Console.WriteLine("参数不正确!!!");
                return;
            }
            //foreach (var property in j.Properties)
            //{
            //    Console.WriteLine(property.Name + "：");
            //    foreach (ManagementObject o in j.GetInstances())
            //    {
            //        Console.WriteLine(o[property.Name] + "\n------------------");
            //        //break;
            //    }
            //}

            //Console.ReadKey();
        }
    }
}
