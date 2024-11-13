using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        // Lista kontaktów
        public IActionResult Index()
        {
            return View(_contactService.GetAll());
        }

        // Zwraca formularz dodania kontaktu
        [HttpGet]
        public IActionResult Add()
        {
            var model = new ContactModel();
            model.Organizations = _contactService.GetAllOrganizations()
                .Select(e => new SelectListItem()
                {
                    Value = e.Id.ToString(),
                    Text = e.Name,
                    Selected = e.Id == 102
                }).ToList();
            return View(model);
        }

        // Obsługuje zapis danych kontaktu
        [HttpPost]
        public IActionResult Add(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Organizations = _contactService.GetAllOrganizations()
                    .Select(e => new SelectListItem()
                    {
                        Value = e.Id.ToString(),
                        Text = e.Name,
                        Selected = e.Id == model.Id
                    }).ToList();
                return View(model);
            }
            _contactService.Add(model);
            return RedirectToAction(nameof(Index));
        }

        // Obsługuje usunięcie kontaktu
        public IActionResult Delete(int id)
        {
            _contactService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        // Wyświetla szczegóły kontaktu
        public IActionResult Details(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); // Sprawdzenie, czy kontakt istnieje
            }
            return View(contact);
        }

        // GET: Wyświetla formularz edycji kontaktu
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contact = _contactService.GetById(id);
            if (contact == null)
            {
                return NotFound(); // Sprawdzenie, czy kontakt istnieje
            }
            return View(contact);
        }

        // POST: Obsługuje zapis edytowanych danych kontaktu
        [HttpPost]
        public IActionResult Edit(ContactModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Przekazujemy model z powrotem do widoku, jeśli są błędy
            }
            _contactService.Update(model);
            return RedirectToAction(nameof(Index));
        }
    }
}