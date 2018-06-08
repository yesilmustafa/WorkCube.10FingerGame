using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkCube._10FingerGame.Entity.Entities;

namespace WorkCube._10FingerGame.BLL.Repositories
{
    public class UserRepository:RepositoryBase<User>{
        public User UserCheck(string username, string password)
        {
           return ctx.Users.Where(x=> x.Name==username && x.Password==password).FirstOrDefault();
        }
    }
    public class SkorRepository:RepositoryBase<Skor>{ }
}
