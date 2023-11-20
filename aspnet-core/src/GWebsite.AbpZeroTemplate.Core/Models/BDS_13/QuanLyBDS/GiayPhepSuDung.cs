using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
   public class GiayPhepSuDung : FullAuditModel
    {
        public string Name { set; get; }
        public DateTime ThoiHan { set; get; }


    }
}
