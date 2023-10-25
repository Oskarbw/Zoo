using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Interfaces;
using Zoo.Entities;
using Zoo.Backend;


namespace Zoo.Services
{
    public class CaretakerService : ICRUD<Caretaker>
    {

        private readonly ZooContext _db;

        public CaretakerService(ZooContext db)
        {
            _db = db;
        }
        public void Create(Caretaker entity)
        {
            _db.Caretakers.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var query = from caretaker in _db.Caretakers
                        where caretaker.Id == id select caretaker;
            var result = query.FirstOrDefault();
            _db.Caretakers.Remove(result);
            _db.SaveChanges();
        }

        public Caretaker Read(Guid id)
        {
            var query = from caretaker in _db.Caretakers
                        where caretaker.Id == id
                        select caretaker;
            return query.FirstOrDefault();
        }

        public void Update(Guid id, Caretaker entity)
        {
            var query = from caretaker in _db.Caretakers
                        where caretaker.Id == id
                        select caretaker;
            var result = query.FirstOrDefault();
            if(result != null)
            {
                result.FirstName = entity.FirstName;
                result.LastName = entity.LastName;
                _db.SaveChanges();
            }
        }
    }
}
