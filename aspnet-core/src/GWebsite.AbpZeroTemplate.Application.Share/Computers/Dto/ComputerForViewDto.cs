using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;
namespace GWebsite.AbpZeroTemplate.Application.Share.Computers.Dto
{
    public class ComputerForViewDto
    {
        public string Domain1 { get; set; }
        public string DNSHostName { get; set; }
        public string Cpuname { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string UserName { get; set; }
        public string Ram1Manufacturer { get; set; }
        public string Ram1PartNumber { get; set; }
        public string Ram1Total { get; set; }
        public string Ram2Manufacturer { get; set; }
        public string Ram2PartNumber { get; set; }
        public string Ram2Total { get; set; }
        public string MonitorType { get; set; }
        public string HDD1Type { get; set; }
        public string HDD1Size { get; set; }
        public string HDD2Type { get; set; }
        public string HDD2Size { get; set; }
        public string OS { get; set; }
        public string OSA { get; set; }
        public string LocalIp { get; set; }
    }
}
