using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkCube._10FingerGame.BLL.Interfaces;
using WorkCube._10FingerGame.DAL;

namespace WorkCube._10FingerGame.BLL.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected MyContext ctx = new MyContext();
        public void Delete(int entityID)
        {
            var entity = ctx.Set<T>().Find(entityID);
            ctx.Set<T>().Remove(entity);
            ctx.SaveChanges();

        }

        public List<T> GetAll()
        {
            return ctx.Set<T>().ToList<T>();
        }

        public T GetSingle(int entityID)
        {
            var entity = ctx.Set<T>().Find(entityID);
            return entity;
        }

        public T Insert(T entity)
        {
            var user = ctx.Set<T>().Add(entity);
            ctx.SaveChanges();
            return user;
        }

        public void Update()
        {
            ctx.SaveChanges();
        }
    }
}
