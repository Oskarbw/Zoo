using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo.Entities
{
    public class Animal
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Species Species { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Caretaker Caretaker { get; set; }
        public Guid CaretakerId { get; set; }
    }
}
