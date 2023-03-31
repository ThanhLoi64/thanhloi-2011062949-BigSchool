using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using thanhloi_2011062949.Models;
using thanhloi_2011062949.ViewModels;

namespace thanhloi_2011062949.Controllers
{
    public class CoursesController : Controller
    {
        // GET: Courses
        private readonly ApplicationDbContext _dbContext;
        public CoursesController()
        {
            _dbContext = new ApplicationDbContext();
        }
        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CoursesViewModel
            {
                Categories = _dbContext.Categories.ToList()
            };
            return View(viewModel);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoursesViewModel ViewModel)
        {
            if(!ModelState.IsValid)
            {
                ViewModel.Categories = _dbContext.Categories.ToList();
                return View("Create", ViewModel);
            }
            var course = new Course
            {
                LecturerId = User.Identity.GetUserId(),
                DateTime = ViewModel.GetDateTime(),
                CategoryId = ViewModel.Category,
                Place = ViewModel.Place
            };
            _dbContext.Courses.Add(course);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
        [Authorize]
        public ActionResult Attending()
        {
            var userId = User.Identity.GetUserId();

            var courses = _dbContext.Attendances
                .Where(a => a.AttendeeId == userId)
                .Select(a => a.Course)
                .Include(l => l.Lecturer)
                .Include(l => l.Category)
                .ToList();

            var viewModel = new CoursesViewModel
            {
                UpcommingCourses = (IQueryable<Course>)courses,
                ShowAction = User.Identity.IsAuthenticated
            };

            return View(viewModel);
        }
    }
}