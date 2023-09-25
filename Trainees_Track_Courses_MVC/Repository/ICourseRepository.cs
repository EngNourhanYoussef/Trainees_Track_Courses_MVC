using Trainees_Track_Courses_MVC.Models;

namespace Trainees_Track_Courses_MVC.Repository
{
    public interface ICourseRepository
    {
        public List<Courses> GetCourses();

        public Courses GetCoursesById(int id);

        public void InsertCourse(Courses c);

        public void UpdateCourses(int id);

        public void DeleteCourse(int id);
    }
}
