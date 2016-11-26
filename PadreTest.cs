using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using SoftwareDesign.Pr02.Invariantes;
using System;

namespace Observer.Test
{

    /// <summary>
    ///     Clase de prueba para la clase Padre
    ///</summary>
    [TestClass()]
    public class PadreTest
    {

        /// <summary>
        ///     Prueba básica para el constructor de la clase Padre.
        ///</summary>
        [TestMethod()]
        public void ConstructorTest()
        {
            Padre target = new Padre("Diego"); 
            string expected = "Diego"; 
            string actual;
            target.Nombre = expected;
            actual = target.Nombre;
            Assert.AreEqual(expected, actual,"El nombre del padre creado no es correcto");
            Assert.IsNull(target.Esposa, "Los padres por defecto no son solteros");
        }

        /// <summary>
        ///     Pueba destinada a verificar que al casar dos personas solteras se satisface 
        ///     el invariante sobre matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioDeSolterosTest()
        {
            Padre diego  = new Padre("Diego");
            Madre lucia  = new Madre("Lucia");
            diego.Esposa = lucia;
            Assert.AreEqual(diego, lucia.Esposo, "La madre no está casada con el padre.");
            Assert.AreEqual(diego.Esposa, lucia, "El padre no está casado con la madre.");
        }

        /// <summary>
        ///     Prueba destinada a verificar que al casarse un hombre casado con una mujer soltera,
        ///     la primera esposa del hombre queda soltera y la nueva pareja satisface el invariante 
        ///     de los matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioMujerSolteraHombreCasadoTest()
        {
            Padre alonso = new Padre("Fernando Alono");
            Madre raquel = new Madre("Raquel del Rosario");
            Madre dasha  = new Madre("Dasha Kapustina");
            alonso.Esposa = raquel;
            alonso.Esposa = dasha;
            Assert.AreEqual(alonso.Esposa, dasha, "Alonso no está casado con Dasha");
            Assert.AreEqual(dasha.Esposo, alonso, "Dasha no está casada con Alonso");
            Assert.IsNull(raquel.Esposo, "Raquel no está soltera");
        }

        /// <summary>
        ///     Prueba destinada a verificar que al casarse un hombre soltero con una mujer casada, 
        ///     el marido anterior de ésta queda soltero y la nueva pareja satisface el invariante 
        ///     de los matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioMujerCasadaHombreSolteroTest()
        {
            Madre isabel = new Madre("Isabel Presysler");
            Padre julio = new Padre("Julio Iglesias");
            Padre miguel = new Padre("Miguel Boyer");
            julio.Esposa  = isabel;
            miguel.Esposa = isabel;
            Assert.AreEqual(isabel.Esposo, miguel, "Isabel no está casada con Miguel");
            Assert.AreEqual(miguel.Esposa, isabel, "Miguel no está casado con Julian");
            Assert.IsNull(julio.Esposa, "Julio no está soltero");
        }

        /// <summary>
        ///     Prueba destinada a verificar que al casarse una madre casada con un padre casado, sus 
        ///     cónyuges previos quedan solteros y la nueva pareja satisface el invariante de los 
        ///     matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioMujerCasadaHombreCasadoTest()
        {
            Madre isabel = new Madre("Isabel Pantoja");
            Madre maite = new Madre("Maite Zaldivar");
            Padre julian = new Padre("Julian Munhoz");
            Padre diego = new Padre("Diego Gómez");
            julian.Esposa = maite;
            diego.Esposa  = isabel;
            julian.Esposa = isabel;

            Assert.AreEqual(isabel.Esposo, julian, "Julian no está casado con Isabel");
            Assert.AreEqual(julian.Esposa, isabel, "Isabel no está casada con Julian");
            Assert.IsNull(maite.Esposo, "Maite no está soltera");
            Assert.IsNull(diego.Esposa, "Julián no está soltera");
        }


        /// <summary>
        ///   Una prueba para verificar que los hijos son de ambos miembros de la pareja
        ///</summary>
        [TestMethod()]
        public void addHijoTest()
        {
            Madre isabel = new Madre("Isabel");
            Padre paquirri = new Padre("Paquirri");
            string nombreHijo = "DJ Kiko";
            Hijo kiko = new Hijo(nombreHijo);
            paquirri.addHijo(kiko);

            Assert.IsTrue(isabel.Hijos.Contains(kiko));
            Assert.IsTrue(paquirri.Hijos.Contains(kiko));
        }

    } // class
} // namespace
