using ChainOfResponsibilityProject.ChainOfResponsibility;
using ChainOfResponsibilityProject.DAL;
using ChainOfResponsibilityProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChainOfResponsibilityProject.Controllers
{
    public class DefaultController : Controller
    {
        private readonly Context _context;

        public DefaultController(Context context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CustomerProcessViewModel model)
        {
            Employee treasurer = new Treasurer(_context);
            Employee managerAsistant = new ManagerAsistant(_context);
            Employee manager = new Manager(_context);
            Employee areaDirector = new AreaDirector(_context);

            treasurer.SetNextApprover(managerAsistant);
            managerAsistant.SetNextApprover(manager);
            manager.SetNextApprover(areaDirector);

            treasurer.ProcessRequest(model);

            return View();
        }
    }
}
