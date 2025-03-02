using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace My_API.Models
{
    public class Product
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public int Price { set; get; }
        public string? Description { set; get; }

        [ForeignKey("Category")]
        public int CategoryId { set; get; }
        [JsonIgnore]
        public Category? Category { set; get; }
    }
}
