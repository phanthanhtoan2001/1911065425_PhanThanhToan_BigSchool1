using System;
using System.Linq;
using System.Web.Mvc;

using System.Data.Entity;

using Microsoft.AspNet.Identity;
using _1911065425_PhanThanhToan_BigSchool.Models;
using _1911065425_PhanThanhToan_BigSchool.Models.ViewModels;
using Microsoft.Exchange.WebServices.Data;

namespace _1911065425_PhanThanhToan_BigSchool.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _dbContext;
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourses = _dbContext.Courses.Include(c => c.Lecturer).Include(c => c.Category).Where(c => c.DateTime > DateTime.Now);

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = upcommingCourses,
                ShowAction = User.Identity.IsAuthenticated
            };


            return View(viewModel);
        }
       public ActionResult Search(string searchString)
        {
            var khoahoc = _dbContext.Courses.Include(b => b.Category);
           
            if (!String.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
               khoahoc = khoahoc.Where(b => b.Category.Name.Contains(searchString));
            }

            return View(khoahoc.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}