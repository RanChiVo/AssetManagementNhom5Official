using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSoft.AbpZeroTemplate.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.DisposalPlanDetails.Dto
{
    public class DisposalPlanDetailFilter: PagedAndSortedInputDto
    {
        public string MaKeHoach { get; set; }
    }
}
