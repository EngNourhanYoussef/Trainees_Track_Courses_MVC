using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trainees_Track_Courses_MVC.Models;
using Trainees_Track_Courses_MVC.Repository;

namespace Trainees_Track_Courses_MVC.Controllers
{
    [Authorize]
    [Route("tracks")]
    [Route("admin/tracks")]
    public class TrackController : Controller
    {
        public ITrackRepository trackRepository { get; set; }

        public TrackController(ITrackRepository trackRepository)
        {
            this.trackRepository = trackRepository;

        }

        // GET: tracks
        [HttpGet]
        public ActionResult Index()
        {
            return View(trackRepository.GetTracks());
        }

        // GET: tracks/details/5
        [HttpGet("details/{id:int}")]
        public ActionResult Details(int id)
        {
            return View(trackRepository.GetTrackById(id));
        }

        // GET: tracks/create
        [HttpGet("create")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: tracks/create
        [HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                trackRepository.InsertTrack(tracks);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: tracks/edit/5
        [HttpGet("edit/{id:int}")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: tracks/edit/5
        [HttpPost("edit/{id:int}")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Tracks tracks)
        {
            if (ModelState.IsValid)
            {
                trackRepository.UpdateTrack(id);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: tracks/delete/5
        [HttpGet("delete/{id:int}")]
        public ActionResult Delete(int id)
        {
            trackRepository.DeleteTrack(id);
            return RedirectToAction("index");
        }
    }
}
