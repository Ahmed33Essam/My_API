using My_API.Models;

namespace My_API.Repositorys
{
    public class ProductRepo : IProduct
    {
        private readonly Context context;

        public ProductRepo(Context _context)
        {
            context = _context;
        }

        public void Add(Product product)
        {
            context.Products.Add(product);
        }

        public Product GetByID(int id)
        {
            return context.Products.Find(id);
        }

        public List<Product> ShowAll()
        {
            return context.Products.ToList();
        }

        public void Update(Product product)
        {
            context.Update(product);
        }

        public void Delete(int id)
        {
            context.Remove(id);
        }

        public void Save()
        {
            context.SaveChanges();
        }

    }
}
