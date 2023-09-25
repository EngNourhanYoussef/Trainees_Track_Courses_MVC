using Trainees_Track_Courses_MVC.Models;

namespace Trainees_Track_Courses_MVC.Repository
{
    public interface ITraineesRepository
    {

        public List<Trainees> GetTrainees();

        public Trainees GetTraineesById(int id);

        public void InsertTrainees(Trainees t);

        public void UpdateTrainees(int id);

        public void DeleteTrainees(int id);
    }
}
