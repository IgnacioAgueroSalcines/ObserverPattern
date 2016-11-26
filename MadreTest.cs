using SoftwareDesign.Pr02.Invariantes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Observer.Test
{
    
    /// <summary>
    /// Clase de prueba para la clase Madre del gestor de matrimonios de Narnia
    ///</summary>
    [TestClass()]
    public class MadreTest
    {

        /// <summary>
        ///     Prueba para verificar el correcto funcionamiento del constructor de la clase
        /// </summary>
        [TestMethod()]
        public void MadreConstructorTest()
        {
            Madre target = new Madre("Lucía");
            string expected = "Lucía";
            string actual;
            target.Nombre = expected;
            actual = target.Nombre;
            Assert.AreEqual(expected, actual, "El nombre no está correctamente asignado");
            Assert.AreEqual(target.Esposo, null, "Cada madre está soltera por defecto");
        }

        /// <summary>
        ///     Pueba destinada a verificar que al casar dos personas solteras se satisface 
        ///     el invariante sobre matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioDeSolterosTest()
        {
            Madre target = new Madre("Lucía");
            Padre expected = new Padre("Diego");
            Padre actual;
            target.Esposo = expected;
            actual = target.Esposo;
            Assert.AreEqual(expected, actual, "La madre no está casada con el padre");
            Assert.AreEqual(expected.Esposa, target, "El padre no está casado con la madre");
        }

        /// <summary>
        ///     Prueba destinada a verificar que al casarse el esposo de una madre con otra
        ///     madre, se satisface el invariante sobre matrimonios y además la primera madre 
        ///     queda divorciada
        ///</summary>
        [TestMethod()]
        public void MatrimonioMujerSolteraHombreCasadoTest()
        {
            Madre isabel = new Madre("Isabel Pantoja");
            Madre maite = new Madre("Maite Zaldivar");
            Padre julian = new Padre("Julian Munhoz");
            maite.Esposo = julian;
            isabel.Esposo = julian;
            Assert.AreEqual(isabel.Esposo, julian, "Julian no está casado con Isabel");
            Assert.AreEqual(julian.Esposa, isabel, "Isabel no está casada con Julian");
            Assert.IsNull(maite.Esposo, "Maite no está soltera");
        }

        /// <summary>
        ///     Prueba destinada a verificar que al casarse una madre casada con un padre soltero
        ///     el primer padre de la madre queda soltero y la nueva pareja satisface el 
        ///     invariante de matrimonios
        ///</summary>
        [TestMethod()]
        public void MatrimonioMujerCasadaHombreSolteroTest()
        {
            Madre isabel = new Madre("Isabel Presysler");
            Padre julio = new Padre("Julio Iglesias");
            Padre miguel = new Padre("Miguel Boyer");
            isabel.Esposo = julio;
            isabel.Esposo = miguel;
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
            maite.Esposo  = julian;
            isabel.Esposo = diego;
            isabel.Esposo = julian;

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
            Madre isabel   = new Madre("Isabel");
            Padre paquirri = new Padre("Paquirri");
            string nombreHijo   = "DJ Kiko";
            Hijo kiko = new Hijo(nombreHijo);
            isabel.addHijo(kiko);

            Assert.IsTrue(isabel.Hijos.Contains(kiko));
            Assert.IsTrue(paquirri.Hijos.Contains(kiko));

        } 
  
    } // class

} // namespace
