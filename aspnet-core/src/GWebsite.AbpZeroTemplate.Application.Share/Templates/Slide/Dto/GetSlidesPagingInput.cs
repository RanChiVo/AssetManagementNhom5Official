namespace GWebsite.AbpZeroTemplate.Application.Share.Templates.Slider.Dto
{
    public class GetSlidesPagingInput : GetSlidesInput
    {
        public int MaxResultCount { get; set; }

        public int SkipCount { get; set; }

        public string Sorting { get; set; }
    }
}
