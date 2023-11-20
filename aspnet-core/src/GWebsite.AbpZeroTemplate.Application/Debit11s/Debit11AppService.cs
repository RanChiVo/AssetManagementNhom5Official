using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s;
using GWebsite.AbpZeroTemplate.Application.Share.Debit11s.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Debit11s
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Debit11)]
    public class Debit11AppService : GWebsiteAppServiceBase, IDebit11AppService
    {
        private readonly IRepository<Debit11> debit11Repository;

        public Debit11AppService(IRepository<Debit11> debit11Repository)
        {
            this.debit11Repository = debit11Repository;
        }

        #region Public Method

        public void CreateOrEditDebit11(Debit11Input debit11Input)
        {
            if (debit11Input.Id == 0)
            {
                Create(debit11Input);
            }
            else
            {
                Update(debit11Input);
            }
        }

        public void DeleteDebit11(int id)
        {
            var debit11Entity = debit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (debit11Entity != null)
            {
                debit11Entity.IsDelete = true;
                debit11Repository.Update(debit11Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Debit11Input GetDebit11ForEdit(int id)
        {
            var debit11Entity = debit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (debit11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Debit11Input>(debit11Entity);
        }

        public Debit11ForViewDto GetDebit11ForView(int id)
        {
            var debit11Entity = debit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (debit11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Debit11ForViewDto>(debit11Entity);
        }

        public PagedResultDto<Debit11Dto> GetDebit11s(Debit11Filter input)
        {
            var query = debit11Repository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<Debit11Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Debit11Dto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Debit11_Create)]
        private void Create(Debit11Input debit11Input)
        {
            var debit11Entity = ObjectMapper.Map<Debit11>(debit11Input);
            SetAuditInsert(debit11Entity);
            debit11Repository.Insert(debit11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Edit)]
        private void Update(Debit11Input debit11Input)
        {
            var debit11Entity = debit11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == debit11Input.Id);
            if (debit11Entity == null)
            {
            }
            ObjectMapper.Map(debit11Input, debit11Entity);
            SetAuditEdit(debit11Entity);
            debit11Repository.Update(debit11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
