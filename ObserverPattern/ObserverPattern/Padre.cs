using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Padre
    {
        private String nombre { get; set; }
        private Madre esposa { get; set; }
        private IList<Hijo> hijos { get; set; }

    }
}
