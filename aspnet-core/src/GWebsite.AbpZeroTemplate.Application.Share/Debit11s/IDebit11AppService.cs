using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto;

namespace GWebsite.AbpZeroTemplate.Application.Share.Debit11s
{
    public interface IDebit11AppService
    {
        void CreateOrEditDebit11(Debit11Input debit11Input);
        Debit11Input GetDebit11ForEdit(int id);
        void DeleteDebit11(int id);
        PagedResultDto<Debit11Dto> GetDebit11s(Debit11Filter input);
        Debit11ForViewDto GetDebit11ForView(int id);
    }
}
