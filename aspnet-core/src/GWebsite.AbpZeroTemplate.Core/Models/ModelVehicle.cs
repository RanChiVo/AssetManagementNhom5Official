﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class ModelVehicle : FullAuditModel
    {
        public string IdModel { get; set; }
        public string NameModel { get; set; }
    }
}
