using Abp.Domain.Entities;
using GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructionCategories.Dto
{
    public class VideoInstructionCategoryDto: Entity<int>
    {
        public int PriceId { get; set; }
        public string Name { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
    }
}
