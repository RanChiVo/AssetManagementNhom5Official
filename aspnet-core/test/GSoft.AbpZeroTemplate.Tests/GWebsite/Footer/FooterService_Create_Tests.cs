using System.Linq;
using System.Threading.Tasks;
using Abp.Collections.Extensions;
using Abp.UI;
using Microsoft.EntityFrameworkCore;
using GSoft.AbpZeroTemplate.Authorization.Roles;
using GSoft.AbpZeroTemplate.Authorization.Users.Dto;
using GSoft.AbpZeroTemplate.MultiTenancy;
using Shouldly;
using Xunit;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.Footer
{
    public class FooterService_Create_Tests : FooterServiceTestBase
    {
        [MultiTenantFact]
        public async Task Should_Create_Footer_For_Host()
        {
            LoginAsHostAdmin();

            await CreateSlideAndTestAsync("jnsh2000@testdomain.com");
            await CreateSlideAndTestAsync("adams_d@gmail.com");
        }

        private async Task CreateSlideAndTestAsync(string content)
        {//_slideService.CreateSlideAsync(CreateSlideEntity(content));

            
            //Assert
            await UsingDbContextAsync(async context =>
            {
                //Get created user
                var createdUser = await context.Slides.FirstOrDefaultAsync(u => u.Content == content);
                createdUser.ShouldNotBe(null);

                //Check some properties
                createdUser.Content.ShouldBe(content);
            });
        }
    }
}
