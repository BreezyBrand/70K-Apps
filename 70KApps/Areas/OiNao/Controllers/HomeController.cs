using _70KApps.Areas.OiNao.Models;
using _70KApps.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _70KApps.Areas.OiNao.Controllers
{
    [Area("OiNao")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<OiNaoContact> contacts = _context.OiNaoContacts                                                    
                                                    .Include(n => n.AssociatedAddresses)
                                                    .Include(n => n.AssociatedContactNumbers)
                                                    .Include(n => n.AssociatedEmails)
                                                    .ToList();

            return View();
        }

        public IActionResult ResetContactTable()
        {
            List<OiNaoContact> contacts = _context.OiNaoContacts
                                                    .Include(n => n.AssociatedAddresses)
                                                    .Include(n => n.AssociatedContactNumbers)
                                                    .Include(n => n.AssociatedEmails)
                                                    .ToList();

            return PartialView("_contactTable", contacts);
        }
    }
}
