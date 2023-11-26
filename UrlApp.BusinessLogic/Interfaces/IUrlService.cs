using UrlApp.Common.DTOs;
using UrlApp.Models.Models;

namespace UrlApp.BusinessLogic.Interfaces;

public interface IUrlService
{
    void Create(CreateUrlDto createUrlDto, string scheme, string host);

    List<GetUrlDto> GetAll();
    
    string Get(string path);

    Url Find(int id);

    void Edit(Url url, string scheme, string host);

    void Delete(int id);
}