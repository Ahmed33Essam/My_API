using My_API.Models;

namespace My_API.DTO
{
    public class CateProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string>? Products { get; set; }
    }
}
