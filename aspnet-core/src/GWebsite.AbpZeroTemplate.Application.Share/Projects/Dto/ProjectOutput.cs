using Abp.Application.Services.Dto;
using Abp.Runtime.Validation;
using GSoft.AbpZeroTemplate.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GWebsite.AbpZeroTemplate.Application.Share.Projects.Dto
{
    public class ProjectOutput
    {
        public ProjectDto Project { get; set; }
        public List<ComboboxItemDto> Projects { get; set; }

        public ProjectOutput()
        {
            Projects = new List<ComboboxItemDto>();
        }
    }
}
