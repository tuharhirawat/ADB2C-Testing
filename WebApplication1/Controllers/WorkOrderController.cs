//using Microsoft.AspNetCore.Mvc;

//namespace WebApplication1.Controllers
//{
//    public class WorkOrderController : Controller
//    {
//        public IActionResult Index()
//        {
//            return View();
//        }
//    }
//}
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class WorkOrderController : Controller
    {
        private readonly AppDbContext _context;

        public WorkOrderController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var workOrders = await _context.WorkOrderMasters
                .Include(w => w.WorkOrderDetails)
                .ToListAsync();
            return View(workOrders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(WorkOrderMaster workOrder)
        {
            if (ModelState.IsValid)
            {
                _context.WorkOrderMasters.Add(workOrder);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(workOrder);
        }
    }
}
