using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Vehicle : FullAuditModel
    {

        public string IdVehicle { set; get; }
        public string Name { get; set; }
        public string Number { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string IdTypeCar { get; set; }
        public string IdModel { get; set; }
        public string Model { get; set; }
        public string MachineNumber { get; set; }
        public string Color { get; set; }
        public string HostName { get; set; }
        public string NameEngine { get; set; }
        public string SoKmDaDi { get; set; }
        public string DinhMucNhienLieu { get; set; }

    }

}

