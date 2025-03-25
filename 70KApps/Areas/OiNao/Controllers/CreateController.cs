using _70KApps.Areas.OiNao.Models;
using _70KApps.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Graph;
using System.Net;

namespace _70KApps.Areas.OiNao.Controllers
{
    [Area("OiNao")]
    public class CreateController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public CreateController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult getContactForm(int? Id)
        {
            OiNaoContact contact = new OiNaoContact();
            if (Id.HasValue)
            {
                contact = _context.OiNaoContacts.Find(Id);
                contact.AssociatedAddresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(Id)).ToList();
                contact.AssociatedContactNumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(Id)).ToList();
                contact.AssociatedEmails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(Id)).ToList();
            }
            return PartialView("_ContactForm", contact);
        }


        public IActionResult postContactForm(OiNaoContact contact)
        {
            if (contact.ID.Equals(0))
            {
                contact.CreateDate = DateTime.Now;
                contact.CreatedBy = User.Identity.Name;
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                contact.reinitialize();
                _context.OiNaoContacts.Add(contact);
            }
            else
            {
                contact.UpdateDate = DateTime.Now;
                contact.UpdatedBy = User.Identity.Name;
                contact.reinitialize();
                _context.OiNaoContacts.Update(contact);
            }
            _context.SaveChanges();

            contact.AssociatedAddresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();
            contact.AssociatedContactNumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();
            contact.AssociatedEmails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(contact.ID)).ToList();

            return PartialView("_ContactForm", contact);
        }


        public IActionResult getEmailForm(int Id)
        {
            List<OiNaoEmail> emails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(Id)).ToList();
            return PartialView("_EmailForm", emails);
        }


        public IActionResult postEmailForm(OiNaoEmail email)
        {
            if (email.ID.Equals(0))
            {
                email.CreateDate = DateTime.Now;
                email.CreatedBy = User.Identity.Name;
                email.UpdateDate = DateTime.Now;
                email.UpdatedBy = User.Identity.Name;
                _context.OiNaoEmails.Add(email);
            }
            else
            {
                email.UpdateDate = DateTime.Now;
                email.UpdatedBy = User.Identity.Name;
                _context.OiNaoEmails.Update(email);
            }
            
            _context.SaveChanges();
            List<OiNaoEmail> emails = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(email.OiNaoContactID)).ToList();

            return PartialView("_EmailForm", emails);
        }


        public IActionResult getContactNumberForm(int id)
        {
            List<OiNaoContactNumber> cnumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(id)).ToList();
            return PartialView("_ContactNumberForm", cnumbers);
        }


        public IActionResult postContactNumberForm(OiNaoContactNumber cnumber)
        {
            if (cnumber.ID.Equals(0))
            {
                cnumber.CreateDate = DateTime.Now;
                cnumber.CreatedBy = User.Identity.Name;
                cnumber.UpdateDate = DateTime.Now;
                cnumber.UpdatedBy = User.Identity.Name;
                _context.OiNaoContactNumbers.Add(cnumber);
            }
            else
            {
                cnumber.UpdateDate = DateTime.Now;
                cnumber.UpdatedBy = User.Identity.Name;
                _context.OiNaoContactNumbers.Update(cnumber);
            }
            _context.SaveChanges();
            List<OiNaoContactNumber> cnumbers = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(cnumber.OiNaoContactID)).ToList();
            return PartialView("_ContactNumberForm", cnumbers);
        }


        public IActionResult getAddressForm(int Id)
        {
            List<OiNaoAddress> addresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(Id)).ToList();
            return PartialView("_AddressForm", addresses);
        }


        public IActionResult postAddressForm(OiNaoAddress address)
        {
            if (address.ID.Equals(0))
            {
                address.CreateDate = DateTime.Now;
                address.CreatedBy = User.Identity.Name;
                address.UpdateDate = DateTime.Now;
                address.UpdatedBy = User.Identity.Name;
                address.reinitialize();
                _context.OiNaoAddresses.Add(address);
            }
            else
            {
                address.UpdateDate = DateTime.Now;
                address.UpdatedBy = User.Identity.Name;
                address.reinitialize();
                _context.OiNaoAddresses.Update(address);
            }
            _context.SaveChanges();
            List<OiNaoAddress> addresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(address.OiNaoContactID)).ToList();
            return PartialView("_AddressForm", addresses);
        }


        public IActionResult getRelationshipForm()
        {
            List<OiNaoRelationship> relationships = new List<OiNaoRelationship>();
            return PartialView("_RelationshipForm", relationships);
        }


        public IActionResult postRelationshipForm(OiNaoRelationship relationship)
        {
            if (relationship.ID.Equals(0))
            {
                relationship.CreateDate = DateTime.Now;
                relationship.CreatedBy = User.Identity.Name;
                relationship.UpdateDate = DateTime.Now;
                relationship.UpdatedBy = User.Identity.Name;
                _context.OiNaoRelationships.Add(relationship);
            }
            else
            {
                relationship.UpdateDate = DateTime.Now;
                relationship.UpdatedBy = User.Identity.Name;
                _context.OiNaoRelationships.Update(relationship);
            }
            _context.SaveChanges();
            List<OiNaoRelationship> relationships = new List<OiNaoRelationship>();
            return PartialView("_RelationshipForm", relationships);
        }
    }
}
