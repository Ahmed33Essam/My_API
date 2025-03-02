using My_API.Models;

namespace My_API.Repositorys
{
    public interface IProduct
    {
        public List<Product> ShowAll();
        public Product GetByID(int id);
        public void Add(Product product);
        public void Update(Product product);
        public void Delete(int id);
        public void Save();
    }
}
