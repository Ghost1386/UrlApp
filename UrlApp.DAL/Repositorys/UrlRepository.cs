using UrlApp.DAL.Interfaces;
using UrlApp.Models;
using UrlApp.Models.Models;

namespace UrlApp.DAL.Repositorys;

public class UrlRepository : IUrlRepository
{
    private readonly ApplicationContext _applicationContext;

    public UrlRepository(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(Url url)
    {
        _applicationContext.Urls.Add(url);
        _applicationContext.SaveChanges();
    }

    public IEnumerable<Url> GetAll()
    {
        return _applicationContext.Urls;
    }
    
    public Url Get(string path)
    {
        var url = _applicationContext.Urls.FirstOrDefault(u => u.ShortenedUrl.Contains(path.Trim()));

        return url;
    }

    public Url Find(int id)
    {
        var url = _applicationContext.Urls.FirstOrDefault(u => u.Id == id);

        return url;
    }

    public void Edit(Url url)
    {
        _applicationContext.Urls.Update(url);
        _applicationContext.SaveChanges();
    }

    public void Delete(int id)
    {
        var url = Find(id);
        
        _applicationContext.Urls.Remove(url);
        _applicationContext.SaveChanges();
    }
}