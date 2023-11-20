using Abp.Application.Services.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppService_Get_By_Id_Tests : OrderPackageAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Get_By_Id_Test()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            await UpdateOrderPackageByIdAndTestAsync(1);
        }

        private async Task UpdateOrderPackageByIdAndTestAsync(int id)
        {
            var orderPackage = await _orderpackageAppService.GetOrderPackageByIdAsync(new EntityDto<int>() { Id = 1 });
            orderPackage.IdUser.ShouldBe(1);
            orderPackage.UserName.ShouldBe("username1");
        }
    }
}
