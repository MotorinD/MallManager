using MallManager.DAL.Entities;
using System.Collections.Generic;

namespace MallManager.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        List<TEntity> GetList();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Delete(int id);
    }
}
