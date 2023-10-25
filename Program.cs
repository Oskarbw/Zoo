using System.Runtime.CompilerServices;
using Zoo.Backend;
using Zoo.Entities;

namespace Zoo
{
    public class Program
    {
        static void Main(string[] args)
        {   
            ZooContext _db = new ZooContext();
            ZooSeeder seeder = new ZooSeeder(_db);

            seeder.Seed();

            var animals = _db.Animals.ToList();
            foreach (var animal in animals)
            {
                Console.WriteLine(animal.Name);
            }

            Console.WriteLine("Hello, World!");
        }
    }
}