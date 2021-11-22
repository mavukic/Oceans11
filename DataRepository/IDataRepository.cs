﻿using System.Collections.Generic;

namespace Oceans11.DataRepository
{
    public interface IDataRepository<TEntity, TDto>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        TDto GetDto(long id);
        void Add(TEntity entity);
        
        void Update(TEntity entityToUpdate, TEntity entity);
        void Delete(TEntity entity);
    }
}
