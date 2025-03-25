using _70KApps.Areas.OiNao.Models;
using _70KApps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _70KApps.Areas.OiNao.Controllers
{
    [Area("OiNao")]
    public class DeleteController : Controller
    {
        private readonly ILogger<DeleteController> _logger;
        private readonly ApplicationDbContext _context;

        public DeleteController(ILogger<DeleteController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public string deleteContact(int id)
        {
            OiNaoContact thisContact = _context.OiNaoContacts.Find(id);
            
            List<OiNaoAddress> matchedAddresses = _context.OiNaoAddresses.Where(x => x.OiNaoContactID.Equals(id)).ToList();
            List<OiNaoEmail> matchedEmail = _context.OiNaoEmails.Where(x => x.OiNaoContactID.Equals(id)).ToList();
            List<OiNaoContactNumber> matchedContact = _context.OiNaoContactNumbers.Where(x => x.OiNaoContactID.Equals(id)).ToList();

            if (matchedAddresses.Any())
            {
                _context.OiNaoAddresses.RemoveRange(matchedAddresses);
            }

            if (matchedEmail.Any())
            {
                _context.OiNaoEmails.RemoveRange(matchedEmail);
            }

            if (matchedContact.Any())
            {
                _context.OiNaoContactNumbers.RemoveRange(matchedContact);
            }

            _context.SaveChanges();
            _context.OiNaoContacts.Remove(thisContact);
            _context.SaveChanges();

            return "Contact Deleted";
        }


    }
}
