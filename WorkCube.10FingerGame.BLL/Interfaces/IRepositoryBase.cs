using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkCube._10FingerGame.BLL.Interfaces
{
    public interface IRepositoryBase<T> where T:class, new()
    {
        List<T> GetAll();
        T GetSingle(int entityID);
        T Insert(T entity);
        void Update();
        void Delete(int entityID);
    }
}
