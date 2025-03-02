using My_API.Models;

namespace My_API.Repositorys
{
    public interface ICategory
    {
        public List<Category> ShowAll();
        public List<string> ShowById(int id);
        public string GetName(int id);
    }
}
