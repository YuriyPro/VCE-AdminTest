using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TestVSE_Server.Clases
{
    public class Inicialization : CreateDatabaseIfNotExists<MyContext>
    {

        protected override void Seed(MyContext context)
        {
           
            Status status = new Status()
            {
                Name = "Adminu"
            };
            context.Status.Add(status);
            context.SaveChanges();
            Status status2 = new Status()
            {
                Name = "Teachers"
            };
            context.Status.Add(status2);
            context.SaveChanges();
            Status status3 = new Status()
            {
                Name = "Students"
            };
            context.Status.Add(status3);
            context.SaveChanges();

            User person = new User()
            {
                Name = "admin",
                Password =Additional.CreateMD5Hash("admin"),
                StatusId = context.Status.Where(x=>x.Name== "Adminu").Select(x=>x.Id).SingleOrDefault()

            };
            context.Users.Add(person);
            context.SaveChanges();
            //base.Seed(context);
          
        }

    }
}
