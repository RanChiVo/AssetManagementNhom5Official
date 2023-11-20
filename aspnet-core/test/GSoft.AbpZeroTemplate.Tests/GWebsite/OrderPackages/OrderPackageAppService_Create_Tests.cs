using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppService_Create_Tests : OrderPackageAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Create_OrderPackage_Client()
        {
            LoginAsHostAdmin();
            await CreateOrderPackageAndTestAsync(1, "name1", "phone1");
            await CreateOrderPackageAndTestAsync(2, "name2", "phone2");
        }

        private async Task CreateOrderPackageAndTestAsync(int idUser, string name, string phone)
        {
            //Act
            await _orderpackageAppService.CreateOrderPackageAsync(
                new CreateOrderPackageInput
                {
                    IdUser = idUser,
                    UserName = name,
                    PhoneNumber = phone
                });

            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created menu
                var createdOrderPackage = await context.OrderPackages.FirstOrDefaultAsync(x => x.IdUser == idUser && x.UserName == name);
                createdOrderPackage.ShouldNotBe(null);

                //Check some properties
                createdOrderPackage.UserName.ShouldBe(name);
                createdOrderPackage.PhoneNumber.ShouldBe(phone);
            });
        }
    }
}
