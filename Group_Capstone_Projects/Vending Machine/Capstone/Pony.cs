using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone
{
    public class Pony : Animal
    {
        public override string Yell { get; } = "Neigh, Neigh, Yay!\n";
        public Pony(string name) : base(name)
        {

        }
    }
}
