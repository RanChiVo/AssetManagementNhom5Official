using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages.Dto;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppService_Get_Tests : OrderPackageAppServiceTestBase
    {
        [MultiTenantFact]
        public async Task Get_All_Order_Package_Test()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            var OrderPackages = await _orderpackageAppService.GetOrderPackagesAsync();
            OrderPackages.Items.Count.ShouldBe(5);
        }

        private async Task Get_Order_Package_Page_0_Test()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            var OrderPackagesPaging = await _orderpackageAppService.GetOrderPackagesAsync(new GetOrderPackageInput()
            {
                MaxResultCount = 3,
                SkipCount = 0
            });
            OrderPackagesPaging.TotalCount.ShouldBe(5);
            OrderPackagesPaging.Items.Count.ShouldBe(3);
            OrderPackagesPaging.Items[0].UserName.ShouldBe("username1");
            OrderPackagesPaging.Items[0].IdUser.ShouldBe(1);
            OrderPackagesPaging.Items[2].UserName.ShouldBe("username3");
            OrderPackagesPaging.Items[2].IdUser.ShouldBe(3);
        }

        private async Task Get_Order_Package_Page_2_Test()
        {
            LoginAsHostAdmin();
            CreateOrderPackageData();
            var OrderPackagesPaging = await _orderpackageAppService.GetOrderPackagesAsync(new GetOrderPackageInput()
            {
                MaxResultCount = 3,
                SkipCount = 1
            });
            OrderPackagesPaging.TotalCount.ShouldBe(5);
            OrderPackagesPaging.Items.Count.ShouldBe(2);
            OrderPackagesPaging.Items[0].UserName.ShouldBe("username4");
            OrderPackagesPaging.Items[0].IdUser.ShouldBe(4);
            OrderPackagesPaging.Items[1].UserName.ShouldBe("username5");
            OrderPackagesPaging.Items[1].IdUser.ShouldBe(5);
        }
    }
}
