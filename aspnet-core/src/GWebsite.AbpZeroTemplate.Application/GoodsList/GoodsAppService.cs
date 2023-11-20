using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList;
using GWebsite.AbpZeroTemplate.Application.Share.GoodsList.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq.Dynamic.Core;
using Microsoft.EntityFrameworkCore;

namespace GWebsite.AbpZeroTemplate.Web.Core.Goodss
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Goods)]
    public class GoodsAppService : GWebsiteAppServiceBase, IGoodsAppService
    {
        private readonly IRepository<Goods> goodsRepository;
        private readonly IRepository<Project> projectRepository;

        public GoodsAppService(IRepository<Goods> goodsRepository, IRepository<Project> projectRepository)
        {
            this.goodsRepository = goodsRepository;
            this.projectRepository = projectRepository;
        }

        #region Public Method

        public void CreateOrEditGoods(GoodsInput goodsInput)
        {
            if (goodsInput.Id == 0)
            {
                Create(goodsInput);
            }
            else
            {
                Update(goodsInput);
            }
        }

        public void DeleteGoods(int id)
        {
            var goodsEntity = goodsRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsEntity != null)
            {
                goodsEntity.IsDelete = true;
                goodsRepository.Update(goodsEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public GoodsInput GetGoodsForEdit(int id)
        {
            var goodsEntity = goodsRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<GoodsInput>(goodsEntity);
        }

        public GoodsForViewDto GetGoodsForView(int id)
        {
            var goodsEntity = goodsRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (goodsEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<GoodsForViewDto>(goodsEntity);
        }

        public PagedResultDto<GoodsDto> GetGoods(GoodsFilter input)
        {
            var query = goodsRepository.GetAll().Where(x => !x.IsDelete);

            // filter by value
            if (input.GoodsCode != null)
            {
                query = query.Where(x => x.GoodsCode.ToLower().Equals(input.GoodsCode));
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
            return new PagedResultDto<GoodsDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<GoodsDto>(item)).ToList());
        }

        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Goods_Create)]
        private void Create(GoodsInput goodsInput)
        {
            var goodsEntity = ObjectMapper.Map<Goods>(goodsInput);
            SetAuditInsert(goodsEntity);
            goodsRepository.Insert(goodsEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Goods_Edit)]
        private void Update(GoodsInput goodsInput)
        {
            var goodsEntity = goodsRepository.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == goodsInput.Id);
            if (goodsEntity == null)
            {
            }
            ObjectMapper.Map(goodsInput, goodsEntity);
            SetAuditEdit(goodsEntity);
            goodsRepository.Update(goodsEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        #endregion
    }
}
