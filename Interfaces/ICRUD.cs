using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Entities;
using Zoo.Backend;

namespace Zoo.Interfaces
{
    public interface ICRUD<T> 
    {
        public void Create(T entity);
        public T Read(Guid id);
        public void Update(Guid id, T entity);
        public void Delete(Guid id);
        
    }
}
