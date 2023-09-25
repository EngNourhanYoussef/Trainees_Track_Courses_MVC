using Microsoft.EntityFrameworkCore;
using Trainees_Track_Courses_MVC.Models;

namespace Trainees_Track_Courses_MVC.Repository
{
    public class TrackRepo : ITrackRepository
    {

        public TraineesDBContext Context { get; set; }
        public TrackRepo(TraineesDBContext traineesDBContext) {

             Context = traineesDBContext;
        }

        public List<Tracks> GetTracks()
        {
            return  Context.Track.ToList();
        }

        public Tracks GetTrackById(int id)
        {
            return Context.Track.FirstOrDefault(t => t.TrcID == id);
        }

        public void InsertTrack(Tracks t)
        {
            if (t != null)
            {
                Context.Track.Add(t);
                Context.SaveChanges();
            }
        }

        public void UpdateTrack(int id)
        {
            Tracks t = Context.Track.Find(id);

            if (t != null)
            {
                Context.SaveChanges();
            }
        }

        public void DeleteTrack(int id)
        {
            
            Context.Track.Remove(Context.Track.Find(id));
            Context.SaveChanges();
        }

     
    }
}
