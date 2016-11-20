using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Madre
    {
        private String nombre { get; set; }
        private Padre esposo { get; set; }
        private IList<Hijo> hijos { get; set; }
    }
}
