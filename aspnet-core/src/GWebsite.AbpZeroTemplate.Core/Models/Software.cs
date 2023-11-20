using System;
namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Software:FullAuditModel
    {
       public string Cpuname { get; set; }
       public string Displayname { get; set; }
       public string DisplayVersion { get; set; }
       public string Publisher { get; set; }
       public string Installdate { get; set; }
       public string InstallLocation { get; set; }
       public string InstallSource { get; set; }
       public string URLInfoAbout { get; set; }
       public string URLUpdateInfo { get; set; }
    }
}
