using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public abstract class PersonaObservable
    {

        public List<ObservadorPersona> observables= new List<ObservadorPersona>();

        public void addObserver(ObservadorPersona o)
        {
            observables.Add(o);
        }
        public void removeObserver(ObservadorPersona o)
        {
            observables.Remove(o);
        }
        public void notifyPadre(Padre p)
        {
            for (int i = 0; i < observables.Count; i++)
            {
                observables[i].esposoCambiado(p);
            }
        }
        public void notifyMadre(Madre m)
        {
            for(int i = 0; i < observables.Count; i++)
            {
                observables[i].esposaCambiada(m);
            }
            
        }

    }
}
