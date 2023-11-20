using GWebsite.AbpZeroTemplate.Application.Share.OrderPackages;
using GWebsite.AbpZeroTemplate.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.OrderPackages
{
    public class OrderPackageAppServiceTestBase : AppTestBase
    {
        protected readonly IOrderPackagesAppService _orderpackageAppService;

        protected OrderPackageAppServiceTestBase()
        {
            _orderpackageAppService = Resolve<IOrderPackagesAppService>();
        }

        protected void CreateOrderPackageData()
        {
            UsingDbContext(
               context =>
               {
                   context.OrderPackages.Add(CreateOrderPackageTest(1, "username1", "phonenumber1", "email1@gmail.com"));
                   context.OrderPackages.Add(CreateOrderPackageTest(2, "username2", "phonenumber2", "email2@gmail.com"));
                   context.OrderPackages.Add(CreateOrderPackageTest(3, "username3", "phonenumber3", "email3@gmail.com"));
                   context.OrderPackages.Add(CreateOrderPackageTest(4, "username4", "phonenumber4", "email4@gmail.com"));
                   context.OrderPackages.Add(CreateOrderPackageTest(5, "username5", "phonenumber5", "email5@gmail.com"));
               });
        }

        private OrderPackage CreateOrderPackageTest(int idUser, string userName, string phoneNumber, string email)
        {
            return new OrderPackage()
            {
                IdUser = idUser,
                UserName = userName,
                PhoneNumber = phoneNumber,
                Email = email
            };
        }
    }
}
