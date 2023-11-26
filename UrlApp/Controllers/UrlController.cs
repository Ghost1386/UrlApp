using Microsoft.AspNetCore.Mvc;
using UrlApp.BusinessLogic.Interfaces;
using UrlApp.Common.DTOs;
using UrlApp.Models.Models;

namespace UrlApp.Controllers;

public class UrlController : Controller
{
    private readonly IUrlService _urlService;

    public UrlController(IUrlService urlService)
    {
        _urlService = urlService;
    }
    
    public IActionResult Index()
    {
        try
        {
            var getUrlDtos = _urlService.GetAll();
        
            return View(getUrlDtos);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(CreateUrlDto createUrlDto)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _urlService.Create(createUrlDto, HttpContext.Request.Scheme, HttpContext.Request.Host.ToString());
        
                return RedirectToAction("Index");
            }

            return BadRequest();
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    public IActionResult Get()
    {
        try
        {
            var url = _urlService.Get(HttpContext.Request.Path.ToUriComponent().Trim('/'));
        
            return Redirect(url);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    public IActionResult Edit(int id)
    {
        try
        {
            if (id == null)
            {
                return NotFound();
            }

            var url = _urlService.Find(id);
        
            if (url == null)
            {
                return NotFound();
            }
        
            return View(url);
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    [HttpPost]
    public IActionResult Edit(int id, Url url)
    {
        try
        {
            if (id != url.Id)
            {
                return NotFound();
            }
            
            _urlService.Edit(url, HttpContext.Request.Scheme, HttpContext.Request.Host.ToString());
            
            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
    
    public IActionResult Delete(int id)
    {
        try
        {
            if (id == null)
            {
                return NotFound();
            }
        
            _urlService.Delete(id);

            return RedirectToAction(nameof(Index));
        }
        catch (Exception e)
        {
            return NotFound(e.Message);
        }
    }
}