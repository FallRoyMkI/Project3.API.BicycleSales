namespace BicycleSales.API.Models.Tag.Request
{
    public class TagUpdateRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
    }
}
