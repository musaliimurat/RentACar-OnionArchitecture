using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Interfaces.Services;
using RentACar.MVC.Models;
using RentACar.MVC.ViewModels;
using System.Diagnostics;

namespace RentACar.MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IBannerService _bannerService;
    private readonly ICarService _carService;
    private readonly IBlogService _blogService;

    public HomeController(ILogger<HomeController> logger, IBannerService bannerService, ICarService carService, IBlogService blogService)
    {
        _logger = logger;
        _bannerService = bannerService;
        _carService = carService;
        _blogService = blogService;
    }

    public async Task<IActionResult> Index()
    {
        var bannerValues = await _bannerService.GetAllBannerAsync();
        var featuredCars = await _carService.GetAllIsSliderCarsAsync();
        var newBlogs = await _blogService.GetAllBlogIsNewAsync();

        HomeVM vm = new()
        {
            GetBanner = bannerValues.Data.First(),
            GetAllFeaturedCars = featuredCars.Data,
            GetAllBlogIsNew = newBlogs.Data,
        };
        return View(vm);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
