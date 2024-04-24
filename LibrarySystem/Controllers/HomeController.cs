using LibrarySystem.DataContext;
using LibrarySystem.DataModels;
using LibrarySystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LibrarySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var req1=new List<TableViewModel>();
            foreach(var item in _context.Books)
            {
                var re=new TableViewModel { id = item.Id,author=item.Author,name=item.BookName,borrower=item.BorrowerName,city=item.City,dateofissue= (DateOnly)item.DateOfIssue,genre=item.Genere };
           req1.Add(re);
            }
            return View(new LibraryViewModel { Table=req1});
      }
        [HttpPost]
      public IActionResult Index(TableViewModel model)
        {

            var req = new Book { BookName = model.name, Author = model.author, City = model.city, Genere = model.genre, DateOfIssue = model.dateofissue ,BorrowerName=model.borrower};
            _context.Books.Add(req);
            _context.SaveChanges();
            var req1 = new Borrower { City = model.city };
            _context.Borrowers.Add(req1);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
      public IActionResult Delete(int id)
        {
            var req=_context.Books.FirstOrDefault(M=>M.Id==id);
            _context.Books.Remove(req);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
      

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
