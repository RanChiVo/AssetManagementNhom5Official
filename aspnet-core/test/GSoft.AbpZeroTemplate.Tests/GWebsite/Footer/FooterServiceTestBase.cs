using GWebsite.AbpZeroTemplate.Application.Share.Templates;
using GWebsite.AbpZeroTemplate.Core.Models;

namespace GSoft.AbpZeroTemplate.Tests.GWebsite.Footer
{
    public abstract class FooterServiceTestBase : AppTestBase
    {
        protected readonly ISlidesAppService _slideService;

        protected FooterServiceTestBase()
        {
            _slideService = Resolve<ISlidesAppService>();
        }

        protected void CreateTestFooter()
        {
            //Note: There is a default "admin" user also

            UsingDbContext(
                context =>
                {
                    context.Slides.Add(CreateSlideEntity("jnsh2000@testdomain.com"));
                    context.Slides.Add(CreateSlideEntity("adams_d@gmail.com"));
                    context.Slides.Add(CreateSlideEntity("ArthurDent@yahoo.com"));
                });
        }

        protected Slide CreateSlideEntity(string content)
        {
            var footer = new Slide
            {
                Content = content
            };

            return footer;
        }
    }
}