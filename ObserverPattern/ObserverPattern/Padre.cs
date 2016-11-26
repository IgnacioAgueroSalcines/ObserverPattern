using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    public class Padre : PersonaObservable, ObservadorPersona
    {
        private String nombre;
        private Madre esposa;
        private IList<Hijo> hijos;
        public int id { get; }
        private static int contadorId=0;

        public Padre(String nombre)
        {
            this.nombre = nombre;
            hijos = new List<Hijo>();
            id = contadorId;
            contadorId++;
        }

        public void addHijo(Hijo h)
        {
            hijos.Add(h);
            if (!esposa.Hijos.Contains(h))
            {
                esposa.Hijos.Add(h);

            }
        }

        public String Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }
        
        public Madre Esposa
        {
            get
            {
                return esposa;
            }
            set{
                Madre old = esposa;

                //si el valor no es nulo, se observa la esposa y la esposa observa padre
                if (value != null)
                {
                    
                    if (!observables.Contains(value))
                    {
                        this.addObserver(value);
                        
                    }

                    if (esposa != null)
                    {
                        if (value.id != esposa.id)
                        {
                            //antigua esposa deja de observar y de ser observada
                            if (old != null)
                            {
                                this.removeObserver(old);
                                old.Esposo = null;
                            }
                            esposa = value;
                            base.notifyPadre(this);

                        }
                    }
                    else
                    {
                        esposa = value;
                        base.notifyPadre(this);
                    }

                }
                else//valor nulo, se divorcian
                {
                    if (esposa != null)
                    {
                        this.removeObserver(esposa);
                        esposa = null;
                    }
                }

                
               
                
                
                
            }
            
        }

        public IList<Hijo> Hijos
        {
            get
            {
                return hijos;
            }
        }

        public void esposaCambiada(Madre m)
        {
            Esposa = m;
        }

        public void esposoCambiado(Padre p)
        {
        }
    }
}
