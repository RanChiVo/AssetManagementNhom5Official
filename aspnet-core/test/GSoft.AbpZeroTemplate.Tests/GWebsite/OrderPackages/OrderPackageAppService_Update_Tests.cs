using Abp.Application.Services.Dto;
using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppService_Update_Tests : OrderPackageAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Update_Order_Package()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            await UpdateOrderPackageAndTestAsync(1, 1, "namee1", "phonee1", "emaill1@gmail.com");
            await UpdateOrderPackageAndTestAsync(1, 2, "namee2", "phonee2", "emaill2@gmail.com");
        }

        private async Task UpdateOrderPackageAndTestAsync(int id, int idUser, string name, string phone, string email)
        {
            //Act
            await _orderpackageAppService.UpdateOrderPackageAsync(
                new UpdateOrderPackageInput
                {
                    Id = id,
                    IdUser = idUser,
                    UserName = name,
                    PhoneNumber = phone,
                    Email = email
                });

            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created update
                var updatedOrderPackage = await context.OrderPackages.FirstOrDefaultAsync(x => x.Id == id);
                updatedOrderPackage.ShouldNotBe(null);

                //Check some properties
                updatedOrderPackage.UserName.ShouldBe(name);
                updatedOrderPackage.PhoneNumber.ShouldBe(phone);
                updatedOrderPackage.Email.ShouldBe(email);
            });
        }

    }
}
