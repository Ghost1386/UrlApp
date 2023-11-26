using UrlApp.Models.Models;

namespace UrlApp.DAL.Interfaces;

public interface IUrlRepository
{
    void Create(Url url);

    IEnumerable<Url> GetAll();

    Url Get(string path);

    Url Find(int id);

    void Edit(Url url);

    void Delete(int id);
}