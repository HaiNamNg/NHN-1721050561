using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace NHN1721050561.Models
{
    public class BaiTapDBcontext: DbContext
    {
        public BaiTapDBcontext() : base("BaiTapDBcontext")
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecture> Lectures { get; set; }
      

       
    }
}
//DESKTOP-GIPHEE4\SQLEXPRESS