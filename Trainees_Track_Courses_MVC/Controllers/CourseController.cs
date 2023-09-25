using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.Repository;

namespace Trainees_Track_Courses_MVC.Controllers
{
    public class CourseController : Controller
    {

        public ICourseRepository courseRepository { get; set; }

        public CourseController(ICourseRepository courseRepository)
        {
            this.courseRepository = courseRepository;

        }
        // GET: CourseController
        public ActionResult Index()
        {
            return View(courseRepository.GetCourses());
        }

        // GET: CourseController/Details/5
        public ActionResult Details(int id)
        {
            
            return View(courseRepository.GetCoursesById(id));
        }

        // GET: CourseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CourseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Courses c)
        {
           if(ModelState.IsValid)
            {
                courseRepository.InsertCourse(c);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CourseController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CourseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Courses courses)
        {
            if(ModelState.IsValid)
            {
                courseRepository.UpdateCourses(id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CourseController/Delete/5
        public ActionResult Delete(int id)
        {
            courseRepository.DeleteCourse(id);
            return RedirectToAction("index");
        }

        
    }
}
