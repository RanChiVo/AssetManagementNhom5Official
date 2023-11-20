using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using GWebsite.AbpZeroTemplate.Application;
using GWebsite.AbpZeroTemplate.Application.Share.Computers;
using GWebsite.AbpZeroTemplate.Application.Share.Computers.Dto;
using GWebsite.AbpZeroTemplate.Core.Authorization;
using GWebsite.AbpZeroTemplate.Core.Models;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Management;
using System.Net;

namespace GWebsite.AbpZeroTemplate.Web.Core.Computer
{
    [AbpAuthorize(GWebsitePermissions.Pages_Administration_Computer)]
    public class ComputerAppService : GWebsiteAppServiceBase, IComputerAppService
    {
        private readonly IRepository<GWebsite.AbpZeroTemplate.Core.Models.Computer> computerRespostory;

        public ComputerAppService(IRepository<GWebsite.AbpZeroTemplate.Core.Models.Computer> computerRespostory)
        {
            this.computerRespostory = computerRespostory;
        }
        #region Public Method
        public void CreateOrEditComputer(ComputerInput computerInput)
        {          
            if (computerInput.Id == 0)
            {
                Create(computerInput);
            }
            else
            {
                Update(computerInput);
            }
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Computer_Delete)]
        public void DeleteComputer(int id)
        {
            var computerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (computerEntity != null)
            {
                computerEntity.IsDelete = true;
                computerRespostory.Update(computerEntity);
                CurrentUnitOfWork.SaveChanges();
            }
        }

        public ComputerInput GetComputerForEdit(int id)
        {
            var computerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (computerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ComputerInput>(computerEntity);
        }

        public ComputerForViewDto GetComputerForView(int id)
        {
            var computerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == id);
            if (computerEntity == null)
            {
                return null;
            }
            return ObjectMapper.Map<ComputerForViewDto>(computerEntity);
        }

        public PagedResultDto<ComputerDto> GetComputer(ComputerFilter input)
        {
            GWebsite.AbpZeroTemplate.Core.Models.Computer pc = GetCurrentPC();
            var computerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Cpuname == pc.Cpuname);
            if (computerEntity == null)
            {
                var pcEntity = pc;
                SetAuditInsert(pcEntity);
                computerRespostory.Insert(pcEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            else
            {
                var customerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == computerEntity.Id);
                if (customerEntity == null)
                {
                }
                ObjectMapper.Map(pc, customerEntity);
                SetAuditEdit(customerEntity);
                computerRespostory.Update(customerEntity);
                CurrentUnitOfWork.SaveChanges();
            }
            var query = computerRespostory.GetAll().Where(x => !x.IsDelete);    
            // filter by value
            if (input.Name != null)
            {
                query = query.Where(x => x.Cpuname.ToLower().Equals(input.Name));
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
            return new PagedResultDto<ComputerDto>(
                totalCount,
                items.Select(item => ObjectMapper.Map<ComputerDto>(item)).ToList());
        }


        #endregion

        #region Private Method

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Computer_Create)]
        private void Create(ComputerInput customerInput)
        {
            var computerEntity = ObjectMapper.Map<GWebsite.AbpZeroTemplate.Core.Models.Computer>(customerInput);
            SetAuditInsert(computerEntity);
            computerRespostory.Insert(computerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        [AbpAuthorize(GWebsitePermissions.Pages_Administration_Computer_Edit)]
        private void Update(ComputerInput customerInput)
        {
            var customerEntity = computerRespostory.GetAll().Where(x => !x.IsDelete).SingleOrDefault(x => x.Id == customerInput.Id);
            if (customerEntity == null)
            {
            }
            ObjectMapper.Map(customerInput, customerEntity);
            SetAuditEdit(customerEntity);
            computerRespostory.Update(customerEntity);
            CurrentUnitOfWork.SaveChanges();
        }

        private string DeviceInformation(string manager1, string Name11)
        {
            string ret = "";
            try
            {
                //CPU
                ManagementClass ManagementClass1 = new ManagementClass(manager1);
                //Create a ManagementObjectCollection to loop through
                ManagementObjectCollection ManagemenobjCol = ManagementClass1.GetInstances();
                //Get the properties in the class
                PropertyDataCollection properties = ManagementClass1.Properties;
                foreach (ManagementObject obj in ManagemenobjCol)
                {
                    foreach (PropertyData property in properties)
                    {
                        try
                        {
                            if (property.Name == Name11)
                            {
                                ret = obj.Properties[property.Name].Value.ToString();
                            }
                        }
                        catch
                        {
                            //Add codes to manage more informations
                        }
                    }
                }
            }
            catch
            {
                //Win 32 Classes Which are not defined on client system
                ret = ":D";
            }
            return ret;
        }

        private string DeviceInformation2(string manager1, string Name11)
        {
            string ret = "";
            try
            {
                //CPU
                ManagementClass ManagementClass1 = new ManagementClass(manager1);
                //Create a ManagementObjectCollection to loop through
                ManagementObjectCollection ManagemenobjCol = ManagementClass1.GetInstances();
                //Get the properties in the class
                PropertyDataCollection properties = ManagementClass1.Properties;
                foreach (ManagementObject obj in ManagemenobjCol)
                {
                    foreach (PropertyData property in properties)
                    {
                        try
                        {
                            if (property.Name == Name11)
                            {
                                ret += obj.Properties[property.Name].Value.ToString() + "|";
                            }
                        }
                        catch
                        {
                            //Add codes to manage more informations
                        }
                    }
                }
            }
            catch
            {
                //Win 32 Classes Which are not defined on client system
                ret = ":D";
            }
            return ret;
        }

        private GWebsite.AbpZeroTemplate.Core.Models.Computer GetCurrentPC()
        {
            
                GWebsite.AbpZeroTemplate.Core.Models.Computer pc = new GWebsite.AbpZeroTemplate.Core.Models.Computer();
                pc.Domain1 = System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
                pc.DNSHostName = Dns.GetHostName();
                pc.Cpuname = DeviceInformation("Win32_Processor", "Name");
                pc.Manufacturer = DeviceInformation("Win32_ComputerSystem", "Manufacturer");
                pc.Model = DeviceInformation("Win32_ComputerSystem", "Model");
                pc.UserName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
                pc.Ram1Manufacturer = DeviceInformation2("Win32_PhysicalMemory", "Manufacturer");
                pc.Ram1PartNumber = DeviceInformation2("Win32_PhysicalMemory", "PartNumber");
                pc.Ram1Total = DeviceInformation2("Win32_PhysicalMemory", "Capacity");
                pc.MonitorType = DeviceInformation("Win32_DesktopMonitor", "Caption");
                pc.HDD1Type = DeviceInformation2("Win32_DiskDrive", "Caption");

                pc.HDD1Size = DeviceInformation2("Win32_DiskDrive", "Size");

                pc.OS = DeviceInformation("Win32_OperatingSystem", "Caption");
                pc.OSA = DeviceInformation("Win32_OperatingSystem", "OSArchitecture");

                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
                foreach (System.Net.IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    {
                        pc.LocalIp = ip.ToString();
                        break;
                    }
                }
                return pc;
            
        }


        #endregion

    }
}