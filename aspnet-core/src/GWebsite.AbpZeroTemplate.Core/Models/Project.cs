using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Project : FullAuditModel
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDayCreate { get; set; }
    }
}
