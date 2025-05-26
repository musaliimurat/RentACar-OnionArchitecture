using Microsoft.AspNetCore.Mvc;
using RentACar.Application.DTOs.Concrete.ContactDto;
using RentACar.Application.Interfaces.Services;
using System.Threading.Tasks;

namespace RentACar.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.MyTitle = "Contact";
            ViewBag.Description = "Contact Us";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ContactCreateDto contactCreateDto)
        {
            var result = await _contactService.CreateContactAsync(contactCreateDto);
            if (result.Success)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
