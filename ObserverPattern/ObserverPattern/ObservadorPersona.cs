using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public interface ObservadorPersona
    {
         void esposaCambiada(Madre m);
         void esposoCambiado(Padre p);
    }
}
