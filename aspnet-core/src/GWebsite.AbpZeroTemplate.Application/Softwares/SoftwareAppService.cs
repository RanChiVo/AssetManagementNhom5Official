using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares;
using GWebsite.AbpZeroTemplate.Application.Share.Softwares.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using Microsoft.Win32;
using System.Management;
using System;

namespace GWebsite.AbpZeroTemplate.Web.Core.Softwares
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Software)]
    public class SoftwareAppService : GWebsiteAppServiceBase, ISoftwareAppService
    {
        private readonly IRepository<Software> softwareReponsitory;
        public SoftwareAppService(IRepository<Software> softwareReponsitory)
        {
            this.softwareReponsitory = softwareReponsitory;
        }

        #region Public Method
        public void CreateOrEditSoftware(SoftwareInput softwareInput)
        {
            if(softwareInput.Id==0)
            {
                Create(softwareInput);
            }
            else
            {
                Update(softwareInput);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Software_Delete)]
        public void DeleteSoftware(int id)
        {
            var softwareEntity = softwareReponsitory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if(softwareEntity!=null)
            {
                softwareEntity.IsDelete = true;
                softwareReponsitory.Update(softwareEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }
        public SoftwareInput GetSoftwareForEdit(int id)
        {
            var softwareEntity = softwareReponsitory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if(softwareEntity==null)
            {
                return null;
            }
            return ObjectMapper.Map<SoftwareInput>(softwareEntity);
        }

        public SoftwareForViewDto GetSoftwareForView(int id)
        {
            var softwareEntity = softwareReponsitory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if(softwareEntity==null)
            {
                return null;
            }
            return ObjectMapper.Map<SoftwareForViewDto>(softwareEntity);
        }
        public PagedResultDto<SoftwareDto> GetSoftwares(SoftwareFilter input)
        {
            GetListSoftware();
            var query = softwareReponsitory.GetAll().Where(x => !x.IsDelete);
            if (input.Name!=null)
            {
                query = query.Where(x => x.Cpuname.ToLower().Equals(input.Name));
            }
            var totalCount = query.Count();

            if(!string.IsNullOrWhiteSpace(input.Sorting))
            {
                query = query.OrderBy(input.Sorting);
            }

            var items = query.PageBy(input).ToList();

            return new PagedResultDto<SoftwareDto>(
                totalCount, items.Select(item => ObjectMapper.Map<SoftwareDto>(item)).ToList());
        }

        #endregion
        #region Private Method
        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Software_Create)]
        private void Create(SoftwareInput customerInput)
        {
            var customerEntity = ObjectMapper.Map<Software>(customerInput);
            SetAuditInsert(customerEntity);
            softwareReponsitory.Insert(customerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Software_Edit)]
        private void Update(SoftwareInput customerInput)
        {
            var customerEntity = softwareReponsitory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == customerInput.Id);
            if (customerEntity == null)
            {
            }
            ObjectMapper.Map(customerInput, customerEntity);
            SetAuditEdit(customerEntity);
            softwareReponsitory.Update(customerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private void GetListSoftware()
        {
            
            string uninstallKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            using (RegistryKey rk = Registry.LocalMachine.OpenSubKey(uninstallKey))
            {
                foreach (string skName in rk.GetSubKeyNames())
                {
                    SoftwareInput softwareInput = new SoftwareInput();
                    using (RegistryKey sk = rk.OpenSubKey(skName))
                    {
                        try
                        {

                            var displayName = sk.GetValue("DisplayName");
                            var vs = sk.GetValue("DisplayVersion");
                            var pushlish = sk.GetValue("Publisher");
                            var installdate = sk.GetValue("InstallDate");
                            var installLocation = sk.GetValue("InstallLocation");
                            var installsource = sk.GetValue("InstallSource");
                            var urlAbout = sk.GetValue("URLInfoAbout");
                            var urlUpdate = sk.GetValue("URLUpdateInfo");
                            if (displayName != null)
                            {
                                softwareInput.Displayname = displayName.ToString();
                                softwareInput.DisplayVersion = vs.ToString();
                                softwareInput.Publisher = pushlish.ToString();
                                softwareInput.Installdate = installdate.ToString();
                                softwareInput.InstallLocation = installLocation.ToString();
                                softwareInput.InstallSource = installsource.ToString();
                                softwareInput.URLInfoAbout = urlAbout.ToString();
                                softwareInput.URLUpdateInfo = urlUpdate.ToString();

                                var computerEntity = softwareReponsitory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Displayname == softwareInput.Displayname);
                                if (computerEntity == null)
                                {
                                    Create(softwareInput);
                                }
                                else
                                {
                                    Update(softwareInput);
                                }
                            }
                        }
                        catch (Exception ex)
                        { }
                    }
                }
            }
        }
        #endregion
    }
}
