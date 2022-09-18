using ContactsPrj.Data;
using ContactsPrj.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using System.Threading.Tasks;

namespace ContactsPrj.Controllers
{
    public class ContactsController : Controller
    {
        private readonly ContactsPrjContext _context;

        public ContactsController(ContactsPrjContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNew([Bind("Id,Name,MobilePhone,JobTitle,BirthDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contact);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Contacts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contact.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var contact = await _context.Contact.FirstOrDefaultAsync(x => x.Id == id);
            if (contact == null)
            {
                return NotFound();
            }

            _context.Contact.Remove(contact);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Change([Bind("Id,Name,MobilePhone,JobTitle,BirthDate")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contact);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactExists(contact.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction(nameof(Index));
        }

        private bool ContactExists(int id)
        {
            return _context.Contact.Any(e => e.Id == id);
        }
    }
}