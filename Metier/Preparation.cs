using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    class Preparation
    {
        public string Etape { get; set; }
        private string etape;

        public override string ToString()
        {
            return $"{Etape}";
        }

    }
}
