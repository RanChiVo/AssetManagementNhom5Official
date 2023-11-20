using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s;
using GWebsite.AbpZeroTemplate.Application.Share.Asset11s.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Linq;
using System.Linq.Dynamic.Core;

namespace GWebsite.AbpZeroTemplate.Web.Core.Asset11s
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11)]
    public class Asset11AppService : GWebsiteAppServiceBase, IAsset11AppService
    {
        private readonly IRepository<Asset11> asset11Repository;

        private readonly IRepository<Debit11> debit11Repository;
        private readonly IRepository<Credit11> credit11Repository;

        public Asset11AppService(IRepository<Asset11> asset11Repository, IRepository<Debit11> debit11Repository, IRepository<Credit11> credit11Repository)
        {
            this.asset11Repository = asset11Repository;
            this.debit11Repository = debit11Repository;
            this.credit11Repository = credit11Repository;
        }

        #region Public Method

        public void CreateOrEditAsset11(Asset11Input asset11Input)
        {
            if (asset11Input.Id == 0)
            {
                Create(asset11Input);
            }
            else
            {
                Update(asset11Input);
            }
        }

        public void DeleteAsset11(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity != null)
            {
                asset11Entity.IsDelete = true;
                asset11Repository.Update(asset11Entity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public Asset11Input GetAsset11ForEdit(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset11Input>(asset11Entity);
        }

        public Asset11ForViewDto GetAsset11ForView(int id)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (asset11Entity == null)
            {
                return null;
            }
            return ObjectMapper.Map<Asset11ForViewDto>(asset11Entity);
        }

        public PagedResultDto<Asset11Dto> GetAsset11s(Asset11Filter input)
        {
            var query = asset11Repository.GetAll().Where(x => !x.IsDelete);

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
            return new PagedResultDto<Asset11Dto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<Asset11Dto>(item)).ToList());
        }

        // hoach toan
        public void Accounting()
        {
            var listAsset = asset11Repository.GetAll().Where(x => !x.IsDelete && !x.IsAccounted);
            foreach (var asset in listAsset)
            {
                var debitAccountVar = new Debit11();
                var debitAccount = new Debit11();
                if (asset.Vat > 0)
                {
                    debitAccountVar = new Debit11();
                    debitAccountVar.AssetId = asset.AssetId;
                    debitAccountVar.AccountType = 331;
                    debitAccountVar.Price = (((double)asset.Vat / 100) * asset.Price) * asset.Quantity;
                    debitAccount.Price = Math.Round(debitAccount.Price, 3);
                    SetAuditInsert(debitAccountVar);
                    debit11Repository.Insert(debitAccountVar);

                    debitAccount.AssetId = asset.AssetId;
                    debitAccount.AccountType = asset.DebitAccount;
                    debitAccount.Price = asset.Price * asset.Quantity - debitAccountVar.Price;
                    SetAuditInsert(debitAccount);
                    debit11Repository.Insert(debitAccount);
                }
                else
                {
                    debitAccount.AssetId = asset.AssetId;
                    debitAccount.AccountType = asset.DebitAccount;
                    debitAccount.Price = asset.Price * asset.Quantity;
                    SetAuditInsert(debitAccount);
                    debit11Repository.Insert(debitAccount);
                }

                var creditAccount = new Credit11();
                creditAccount.AssetId = asset.AssetId;
                creditAccount.AccountType = asset.CreditAccount;
                creditAccount.Price = asset.Price * asset.Quantity;
                SetAuditInsert(creditAccount);
                credit11Repository.Insert(creditAccount);

                asset.IsAccounted = true;

                CurrentUnitOfWork.SaveChanges();
            }

        }

        // Khau hao
        public void Depreciating()
        {
            var listAsset = asset11Repository.GetAll().Where(x => !x.IsDelete && !x.IsDepreciated);
            foreach (var asset in listAsset)
            {
                if (asset.Time != 0)
                {
                    var debitAccount = new Debit11();
                    debitAccount.AssetId = asset.AssetId;
                    debitAccount.AccountType = 134;
                    debitAccount.Price = ((asset.Price / asset.Time) / 12) * asset.Quantity;
                    debitAccount.Price = Math.Round(debitAccount.Price, 3);
                    SetAuditInsert(debitAccount);
                    debit11Repository.Insert(debitAccount);

                    var creditAccount = new Credit11();
                    creditAccount.AssetId = asset.AssetId;
                    creditAccount.AccountType = 2141;
                    creditAccount.Price = debitAccount.Price;
                    SetAuditInsert(creditAccount);
                    credit11Repository.Insert(creditAccount);

                    asset.IsDepreciated = true;
                    CurrentUnitOfWork.SaveChanges();

                }
            }
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Create)]
        private void Create(Asset11Input asset11Input)
        {
            var asset11Entity = ObjectMapper.Map<Asset11>(asset11Input);
            SetAuditInsert(asset11Entity);
            asset11Repository.Insert(asset11Entity);
            CurrentUnitOfWork.SaveChanges();
        }


        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Asset11_Edit)]
        private void Update(Asset11Input asset11Input)
        {
            var asset11Entity = asset11Repository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == asset11Input.Id);
            if (asset11Entity == null)
            {
            }
            ObjectMapper.Map(asset11Input, asset11Entity);
            SetAuditEdit(asset11Entity);
            asset11Repository.Update(asset11Entity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
