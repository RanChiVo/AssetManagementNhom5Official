using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;
namespace GWebsite.AbpZeroTemplate.Application.Share.ConstructionPlans.Dto
{
    public class ConstructionPlanFilter : PagedAndSortedInputDto
    {
        public string KhuVuc { get; set; }
        public string PhongBan { get; set; }
        public string MaKeHoach { get; set; }
        public string TinhTrang { get; set; }
    }
}
