using Trainees_Track_Courses_MVC.Models;
namespace Trainees_Track_Courses_MVC.Repository
    
{
    public interface ITrackRepository
    {

        public List<Tracks> GetTracks();

        public Tracks GetTrackById(int id);

        public void InsertTrack( Tracks t);

        public void UpdateTrack(int id);

        public void DeleteTrack(int id);
    }
}
