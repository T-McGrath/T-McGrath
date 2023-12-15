using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture.Farming
{
    public class Tractor : ISingable
    {
        public string Name { get; }

        public string Sound { get; }

        public Tractor()
        {
            Name = "Tractor";
            Sound = "vroom";
        }
    }
}
