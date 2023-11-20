using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GWebsite.AbpZeroTemplate.Application.Share.Videos.VideoInstructions.Dto
{
    public class UpdateVideoInstructionInput
    {
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        public int VideoInstructionCategoryId { get; set; }
        public string YoutubeId { get; set; }
        [Required]
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
    }
}
