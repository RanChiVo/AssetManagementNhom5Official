using Abp.Domain.Entities;
using System;
using System.Collections.Generic;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public partial class Price : Entity<int>
    {
        public Price()
        {
            VideoInstructionCategories = new HashSet<VideoInstructionCategory>();
        }
        
        public string Code { get; set; }
        public string ValueString { get; set; }
        public string ValueHtml { get; set; }
        public string Icon { get; set; }
        public string PackageName { get; set; }
        public string Description { get; set; }
        public string ValueString1 { get; set; }
        public string ValueString2 { get; set; }
        public string ValueString3 { get; set; }
        public double PriceValue { get; set; }
        public string Name { get; set; }
        public string Alias { get; set; }
        public string Image { get; set; }
        public string Link { get; set; }
        public int? CategoryId { get; set; }
        public double? Price1Month { get; set; }
        public double? Price3Month { get; set; }
        public double? Price6Month { get; set; }
        public double? Price12Month { get; set; }
        public double? Price24Month { get; set; }
        public string RecordStatus { get; set; }
        public string AuthStatus { get; set; }
        public string MakerId { get; set; }
        public DateTime? CreateDt { get; set; }
        public string CheckerId { get; set; }
        public DateTime? ApproveDt { get; set; }
        public string EditorId { get; set; }
        public DateTime? EditDt { get; set; }
        public string LinkAzure { get; set; }
        public string LinkBackupAzure { get; set; }
        public string ValueString4 { get; set; }
        public string ValueString5 { get; set; }
        public int Order { get; set; }
        public bool IsHot { get; set; }
        public string ImageHorizontal { get; set; }
        public string ImageFull { get; set; }
        public string ShortDecription { get; set; }
        public string LinkDocument { get; set; }
        public string Banner1ImageLink { get; set; }
        public string Banner2ImageLink { get; set; }
        public string Banner3ImageLink { get; set; }
        public string Banner4ImageLink { get; set; }

        public ICollection<VideoInstructionCategory> VideoInstructionCategories { get; set; }
    }
}
