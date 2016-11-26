using System;
using System.Collections.Generic;



namespace ObserverPattern
{
    public class Madre : PersonaObservable, ObservadorPersona
    {
        private String nombre;
        private Padre esposo;
        public IList<Hijo> hijos;
        public int id { get; }
        private static int contadorId = 0;

        public Madre(String nombre)
        {
            this.nombre = nombre;
            hijos = new List<Hijo>();
            id = contadorId;
            contadorId++;
        }

        public void addHijo(Hijo h)
        {
            hijos.Add(h);
            if (!esposo.Hijos.Contains(h))
            {
                esposo.Hijos.Add(h);
            }
        }

        public void esposoCambiado(Padre p)
        {
            Esposo = p;
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

        public Padre Esposo
        {
            get
            {
                return esposo;
            }
            set
            {
                Padre old = esposo;
                if (value != null)
                {
                    if (!observables.Contains(value))
                    {
                        this.addObserver(value);
                    }

                    if (esposo != null)
                    {
                        if (value.id != esposo.id)
                        {
                            if (old != null)
                            {
                                this.removeObserver(old);
                                old.Esposa = null;
                            }
                            esposo = value;
                            base.notifyMadre(this);

                        }
                    }
                    else
                    {
                        esposo = value;
                        base.notifyMadre(this);
                    }

                }
                else
                {
                    if (observables.Contains(value))
                    {
                        this.removeObserver(value);
                       
                    }

                    if (esposo != null)
                    {
                        this.removeObserver(esposo);
                        esposo = null;
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
            
        }
    }
}
