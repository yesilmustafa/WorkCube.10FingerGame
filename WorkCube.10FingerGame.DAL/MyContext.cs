using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkCube._10FingerGame.Entity.Entities;

namespace WorkCube._10FingerGame.DAL
{
    public class MyContext:DbContext
    {
        public MyContext():base("name=mycon"){}

        public DbSet<User> Users { get; set; }
        public DbSet<Skor> Skors { get; set; }

    }
}
