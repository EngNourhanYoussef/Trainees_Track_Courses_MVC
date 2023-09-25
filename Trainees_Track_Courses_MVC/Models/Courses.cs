using System.ComponentModel.DataAnnotations;

namespace Trainees_Track_Courses_MVC.Models
{
    public class Courses
    {
        //- ID
        //- Topic
        //- Grade

        [Key]
        public int CrsID { get; set; }
        public string Topic { get; set;}
        public string Grade { get; set;}

        public List<Trainees> trainees { get; set; }
    }
}
