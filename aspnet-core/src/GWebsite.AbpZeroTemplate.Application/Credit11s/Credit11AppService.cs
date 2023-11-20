using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s;
using GWebsite.AbpZeroTemplate.Application.Share.Credit11s.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Credit11s
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Credit11)]
    public class Credit11AppService : GWebsiteAppServiceBase, ICredit11AppService
    {
        private readonly IRepository<Credit11> credit11Repository;

        public Credit11AppService(IRepository<Credit11> credit11Repository)
        {
            this.credit11Repository = credit11Repository;
        }

        #region Public Method

        public void CreateOrEditCredit11(Credit11Input credit11Input)
        {
            if (credit11Input.Id == 0)
            {
                Create(credit11Input);
            }
            else
            {
                Update(credit11Input);
            }
        }

        public void DeleteCredit11(int id)
        {
            var credit11Entity = credit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (credit11Entity != null)
            {
                credit11Entity.IsDelete = true;
                credit11Repository.Update(credit11Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Credit11Input GetCredit11ForEdit(int id)
        {
            var credit11Entity = credit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (credit11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Credit11Input>(credit11Entity);
        }

        public Credit11ForViewDto GetCredit11ForView(int id)
        {
            var credit11Entity = credit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (credit11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Credit11ForViewDto>(credit11Entity);
        }

        public PagedResultDto<Credit11Dto> GetCredit11s(Credit11Filter input)
        {
            var query = credit11Repository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.AssetId != null)
            {
                query = query.Where(x => x.AssetId.ToLower().Equals(input.AssetId));
            }

            var totalCount = query.Count();

            // sorting
            if (!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            // paging
            var items = query.PageBy(input).ToList();

            // result
            return new PagedResultDto<Credit11Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Credit11Dto>(item)).ToList());
        }

        public void test()
        {

        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Credit11_Create)]
        private void Create(Credit11Input credit11Input)
        {
            var credit11Entity = ObjectMapper.Map<Credit11>(credit11Input);
            SetAuditInsert(credit11Entity);
            credit11Repository.Insert(credit11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Edit)]
        private void Update(Credit11Input credit11Input)
        {
            var credit11Entity = credit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == credit11Input.Id);
            if (credit11Entity == null)
            {
            }
            ObjectMapper.Map(credit11Input, credit11Entity);
            SetAuditEdit(credit11Entity);
            credit11Repository.Update(credit11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
