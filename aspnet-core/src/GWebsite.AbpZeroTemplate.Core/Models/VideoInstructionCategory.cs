using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class VideoInstructionCategory : Entity<int>
    {
        public VideoInstructionCategory()
        {
            VideoInstructions = new HashSet<VideoInstruction>();
        }
        
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

        public Price Price { get; set; }
        public ICollection<VideoInstruction> VideoInstructions { get; set; }
    }
}
