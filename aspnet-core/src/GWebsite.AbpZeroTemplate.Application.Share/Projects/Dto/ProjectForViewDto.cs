using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    /// <summary>
    /// <model cref="Project"></model>
    /// </summary>
    public class ProjectForViewDto
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDayCreate { get; set; }
    }
}
