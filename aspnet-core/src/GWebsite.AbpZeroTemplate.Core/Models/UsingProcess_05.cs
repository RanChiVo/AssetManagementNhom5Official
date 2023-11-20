using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Abp.Domain.Entities;

namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class UsingProcess_05: FullAuditModel
    {
        public string AssetId { get; set; }
        public DateTime UseDate { get; set; }
        public string Unit { get; set; }
        public string User { get; set; }
        public string Content { get; set; }
    }
}
