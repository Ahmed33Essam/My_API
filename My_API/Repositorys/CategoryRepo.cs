using Microsoft.EntityFrameworkCore;
using My_API.Models;

namespace My_API.Repositorys
{
    public class CategoryRepo : ICategory
    {
        private readonly Context context;

        public CategoryRepo(Context context)
        {
            this.context = context;
        }

        public List<Category> ShowAll()
        {
            return context.Categories.ToList();
        }
        public List<string> ShowById(int id)
        {
            List<string> list = context.Products.Where(p => p.CategoryId == id).Select(p => p.Name).ToList();
            return list;
        }
        public string GetName(int id)
        {
            return context.Categories.Where(c => c.Id == id).FirstOrDefault().Name;
        }
    }
}
