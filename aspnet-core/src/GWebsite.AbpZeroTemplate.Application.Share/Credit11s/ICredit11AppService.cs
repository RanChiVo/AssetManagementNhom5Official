using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Credit11s
{
    public interface ICredit11AppService
    {
        void CreateOrEditCredit11(Credit11Input credit11Input);
        Credit11Input GetCredit11ForEdit(int id);
        void DeleteCredit11(int id);
        PagedResultDto<Credit11Dto> GetCredit11s(Credit11Filter input);
        Credit11ForViewDto GetCredit11ForView(int id);
    }
}
