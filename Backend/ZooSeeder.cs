using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zoo.Entities;

namespace Zoo.Backend
{
    public class ZooSeeder
    {
        private readonly ZooContext _db;

        public ZooSeeder(ZooContext db)
        {
            _db = db;
        }

        public void Seed()
        {
            
            if(_db.Database.CanConnect())
            {
                if(_db.Animals.Any()) 
                {
                    var animals = GetAnimals();

                    _db.Animals.AddRange(animals);
                    _db.SaveChanges();
                }
            }
        }

        private IEnumerable<Animal> GetAnimals()
        {
            var caretakerJohn = new Caretaker()
            {
                FirstName = "John",
                LastName = "Wick"
            };

            var caretakerBob = new Caretaker()
            {
                FirstName = "Bob",
                LastName = "Robin"
            };


            var animals = new List<Animal>()
            {
                new Animal()
                {
                    Name = "Mruczek",
                    Species = Species.TIGER,
                    DateOfBirth = DateTime.Today,
                    Caretaker = caretakerJohn
                },
                new Animal()
                {
                    Name = "Grzywacz",
                    Species = Species.LION,
                    DateOfBirth = DateTime.Today,
                    Caretaker = caretakerJohn
                },
                new Animal()
                {
                    Name = "Lotnik",
                    Species = Species.PARROT,
                    DateOfBirth = DateTime.Today,
                    Caretaker = caretakerBob
                },
                new Animal()
                {
                    Name = "Futrzasty",
                    Species = Species.PANDA,
                    DateOfBirth = DateTime.Today,
                    Caretaker = caretakerBob
                },
                new Animal()
                {
                    Name = "Dolf",
                    Species = Species.DOLPHIN,
                    DateOfBirth = DateTime.Today,
                    Caretaker = caretakerBob
                }
            };
            return animals;
        }
    }
}
