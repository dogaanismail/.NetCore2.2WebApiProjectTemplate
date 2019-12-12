namespace CompanyName.Entities.Entities
{
    public class Article : BaseEntity
    {
        public string Text { get; set; }
        public int? PostType { get; set; }
    }
}
