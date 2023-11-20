using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class VideoInstruction : Entity<int>
    {
        public int VideoInstructionCategoryId { get; set; }
        public string YoutubeId { get; set; }
        public string Title { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
        public string Slug { get; set; }

        public VideoInstructionCategory VideoInstructionCategory { get; set; }
    }
}
