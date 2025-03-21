using _70KApps.Areas.OiNao.Models;
using _70KApps.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;

namespace _70KApps.Areas.OiNao.Controllers
{
    public class CreateController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public CreateController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        [HttpGet]
        public IActionResult getContactForm(int? contactId)
        {
            OiNaoContact contact = new OiNaoContact();
            if (contactId.HasValue)
            {
                contact = _context.OiNaoContacts.Find(contactId);
                contact.AssociatedAddresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(contactId)).ToList();
                contact.AssociatedContactNumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(contactId)).ToList();
                contact.AssociatedEmails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(contactId)).ToList();
                contact.AssociatedContacts = _context.OiNaoRelationships.Where(x => x.OiNaoContactA.Equals(contactId)).ToList();
            }
            return PartialView("_ContactForm", contact);
        }

        [HttpPost]
        public IActionResult postContactForm(OiNaoContact contact)
        {
            if (contact.ID.Equals(null))
            {
                contact.CreateDate = DateTime.Now;
                contact.CreatedBy = User.Identity.Name;
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                _context.OiNaoContacts.Add(contact);
            }
            else
            {
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                _context.OiNaoContacts.Update(contact);
            }
            _context.SaveChanges();

            contact.AssociatedAddresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();
            contact.AssociatedContactNumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();
            contact.AssociatedEmails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();
            contact.AssociatedContacts = _context.OiNaoRelationships.Where(x => x.OiNaoContactA.Equals(contact.ID)).ToList();

            return PartialView("_ContactForm", contact);
        }

        [HttpGet]
        public IActionResult getEmailForm()
        {
            OiNaoEmail email = new OiNaoEmail();
            return PartialView("_EmailForm", email);
        }

        [HttpPost]
        public IActionResult postEmailForm(OiNaoEmail email)
        {
            _context.OiNaoEmails.Add(email);
            _context.SaveChanges();
            return PartialView("_EmailForm", email);
        }

        [HttpGet]
        public IActionResult getContactNumberForm()
        {
            OiNaoContactNumber cnumber = new OiNaoContactNumber();
            return PartialView("_ContactNumberForm", cnumber);
        }

        [HttpPost]
        public IActionResult postContactNumberForm(OiNaoContactNumber cnumber)
        {
            _context.OiNaoContactNumbers.Add(cnumber);
            _context.SaveChanges();
            return PartialView("_EmailForm", cnumber);
        }

        [HttpGet]
        public IActionResult getAddressForm()
        {
            OiNaoAddress address = new OiNaoAddress();
            return PartialView("_AddressForm", address);
        }

        [HttpPost]
        public IActionResult postAddressForm(OiNaoAddress address)
        {
            _context.OiNaoAddresses.Add(address);
            _context.SaveChanges();
            return PartialView("AddressForm", address);
        }

        [HttpGet]
        public IActionResult getRelationshipForm()
        {
            OiNaoRelationship relationship = new OiNaoRelationship();
            return PartialView("_RelationshipForm", relationship);
        }

        [HttpPost]
        public IActionResult postRelationshipForm(OiNaoRelationship relationship)
        {
            _context.OiNaoRelationships.Add(relationship);
            _context.SaveChanges();
            return PartialView("_RelationshipForm", relationship);
        }
    }
}
