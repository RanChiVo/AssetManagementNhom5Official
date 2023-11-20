using Abp.Application.Services.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppService_Delete_Tests : OrderPackageAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Delete_Order_Package()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            await DeleteOrderPackageAndTestAsync(1);
            await DeleteOrderPackageAndTestAsync(2);
            await DeleteOrderPackageAndTestAsync(3);
        }

        private async Task DeleteOrderPackageAndTestAsync(int id)
        {
            //Act
            await _orderpackageAppService.DeleteOrderPackageAsync(
                new EntityDto<int>()
                {
                    Id = id
                });

            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created update
                var deletedOrderPackage = await context.OrderPackages.FirstOrDefaultAsync(x => x.Id == id);
                deletedOrderPackage.RecordStatus.ShouldBe("0");
            });
        }
    }
}
