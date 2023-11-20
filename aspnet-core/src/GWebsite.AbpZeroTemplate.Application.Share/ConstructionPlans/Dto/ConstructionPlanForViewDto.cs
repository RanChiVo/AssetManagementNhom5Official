using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto
{
    public class ConstructionPlanForViewDto
    {
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
        public int Nam { get; set; }
        public DateTime NgayHieuLuc { get; set; }
        public string KinhPhi { get; set; }
    }
}
