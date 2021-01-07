using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metier
{
    public interface IPersistance
    {
        IEnumerable<Alcool> ChargerAlcools(String s);
        bool SauvegarderAlcools(String s, IEnumerable<Alcool> ListAlcool);
    }
}

