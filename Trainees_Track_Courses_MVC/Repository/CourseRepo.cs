using Trainees_Track_Courses_MVC.Models;

namespace Trainees_Track_Courses_MVC.Repository
{
    public class CourseRepo : ICourseRepository
    {
        public TraineesDBContext  Context { get; set; }

        public CourseRepo(TraineesDBContext traineesDB ) 
        { 
            Context = traineesDB;
        
        }
        public void DeleteCourse(int id)
        {
            Context.Course.Remove(Context.Course.Find(id));
            Context.SaveChanges();
            
        }

        public List<Courses> GetCourses()
        {
            return Context.Course.ToList();
        }

        public Courses GetCoursesById(int id)
        {
            return Context.Course.Find(id);
        }

        public void InsertCourse(Courses c)
        {
            if( c != null)
            {
                Context.Course.Add(c);
                Context.SaveChanges();

            }
        }

        public void UpdateCourses(int id)
        {
            Courses course = Context.Course.Find(id);

            if( course != null ) 
            {
                Context.SaveChanges();
            
            }
        }
    }
}
