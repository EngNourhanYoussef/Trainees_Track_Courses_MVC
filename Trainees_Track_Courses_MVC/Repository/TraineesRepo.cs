using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using Trainees_Track_Courses_MVC.Models;

namespace Trainees_Track_Courses_MVC.Repository
{
    public class TraineesRepo : ITraineesRepository
    {

        public TraineesDBContext Context { get; set; }
        public TraineesRepo(TraineesDBContext traineesDB) 
        {
            Context = traineesDB;
        
        }
      

        public List<Trainees> GetTrainees()
        {
            return Context.Trainee.Include(t => t.tracks).Include(t=> t.courses).ToList();

        }

        public Trainees GetTraineesById(int id)
        {
            return Context.Trainee.Include(t => t.tracks).Include(t => t.courses).FirstOrDefault(t => t.TrnID == id);
        }

        public void InsertTrainees(Trainees t)
        {
            

            if (t != null)
            {
                //SelectList DeptList = new SelectList(Context.Trainee.ToList(), "TrnID", "TrnName");
                Context.Trainee.Add(t);
                Context.SaveChanges();
            }
        }

        public void UpdateTrainees(int id)
        {
            Trainees t = Context.Trainee.Find(id);
            Context.SaveChanges();
        }


        public void DeleteTrainees(int id)
        {
            Context.Trainee.Remove(Context.Trainee.Find(id));
            Context.SaveChanges();

        }
    }
}
