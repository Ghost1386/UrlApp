using UrlApp.BusinessLogic.Interfaces;
using UrlApp.Common.DTOs;
using UrlApp.DAL.Interfaces;
using UrlApp.Models.Models;

namespace UrlApp.BusinessLogic.Services;

public class UrlService : IUrlService
{
    private readonly IGeneratorService _generatorService;
    private readonly IUrlRepository _urlRepository;

    public UrlService(IGeneratorService generatorService, IUrlRepository urlRepository)
    {
        _generatorService = generatorService;
        _urlRepository = urlRepository;
    }

    public void Create(CreateUrlDto createUrlDto, string scheme, string host)
    {
        var url = new Url
        {
            LongUrl = createUrlDto.LongUrl,
            ShortenedUrl = $"{scheme}://{host}/{_generatorService.GenerateShortUrl()}",
            DateOfCreation = DateTime.UtcNow.Date,
            NumberOfTransitions = 0
        };
        
        _urlRepository.Create(url);
    }

    public List<GetUrlDto> GetAll()
    {
        var urls = _urlRepository.GetAll().ToList();

        var getUrlDtos = urls.Select(url => new GetUrlDto
        {
            Id = url.Id,
            LongUrl = url.LongUrl,
            ShortenedUrl = url.ShortenedUrl,
            DateOfCreation = url.DateOfCreation,
            NumberOfTransitions = url.NumberOfTransitions
        }).ToList();

        return getUrlDtos;
    }

    public string Get(string path)
    {
        var url = _urlRepository.Get(path);

        url.NumberOfTransitions += 1;
        
        _urlRepository.Edit(url);

        return url.LongUrl;
    }

    public Url Find(int id)
    {
        var url = _urlRepository.Find(id);

        return url;
    }

    public void Edit(Url newUrl, string scheme, string host)
    {
        _urlRepository.Edit(newUrl);
    }

    public void Delete(int id)
    {
        _urlRepository.Delete(id);
    }
}