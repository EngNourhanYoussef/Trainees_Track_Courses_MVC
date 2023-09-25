using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.Repository;

namespace Trainees_Track_Courses_MVC.Controllers
{
    //[Authorize]
    //[Route("Trainee")]
    public class TraineesController : Controller
    {

        public ITrackRepository trackRepository { get; set; }
        public ITraineesRepository traineesRepository { get; set; }

        public ICourseRepository courseRepository { get; set; }
        
        public TraineesController( ITraineesRepository traineesRepository, ITrackRepository trackRepository, ICourseRepository courseRepository)
        {

            this.traineesRepository = traineesRepository;
            this.trackRepository = trackRepository;

            this.courseRepository = courseRepository;
        }



        
        // GET: TraineesController
        public ActionResult Index()
        {
           
            return View(traineesRepository.GetTrainees());
        }

        [Route("Trainee/{id:min(1):int}")]
        // GET: TraineesController/Details/5
        public ActionResult Details(int id)
        {
            return View(traineesRepository.GetTraineesById(id));
        }

        // GET: TraineesController/Create

        [AllowAnonymous]
        
        public ActionResult Create()
        {
            ViewBag.Allcourse = courseRepository.GetCourses();

            ViewBag.AllTrack = trackRepository.GetTracks();
            return View();
        }

        // POST: TraineesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Trainees trainees)
        {

            if (ModelState.IsValid)
            {
                traineesRepository.InsertTrainees(trainees);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: TraineesController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Allcourse = courseRepository.GetCourses();

            ViewBag.AllTrack = trackRepository.GetTracks();
            return View();
        }

        // POST: TraineesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id , Trainees t)
        {

            if (ModelState.IsValid)
            {
                traineesRepository.UpdateTrainees(id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: TraineesController/Delete/5
        public ActionResult Delete(int id)
        {
            traineesRepository.DeleteTrainees(id);

            return RedirectToAction(nameof(Index));
        }

      
    }
}
