namespace GWebsite.AbpZeroTemplate.Core.Models
{
    public class Category : FullAuditModel
    {
        public string CategoryType { get; set; }
        public string CategoryId { get; set; }  // Note: Id của category sẽ được tạo theo type của category đó
                                                // Ex: Loại danh mục đơn vị tính (DVT), thì category sẽ có mã là DVTxxxxxx
        
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Description { get; set; }
    }
}
