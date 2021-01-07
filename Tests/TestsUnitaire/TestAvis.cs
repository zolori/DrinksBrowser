using Metier;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;

namespace TestUnitaire
{
    [TestClass]
    public class TestAvis
    {
        /// <summary>
        /// Test simple des propertietes de ListAvis
        /// </summary>
        [TestMethod]
        public void TestPropriete()
        {
            Avis a1 = new Avis("Kevindu38", 5, "salut c'est michou", new DateTime(21 / 12 / 2012));

            // Test des exceptions
           

            Assert.AreEqual(a1.Pseudo, "Kevindu38");
            Assert.AreEqual(a1.Commentaire, "salut c'est michou");
            Assert.AreEqual(a1.Date, new DateTime(21/12/2012));
            Assert.AreEqual(a1.Note, 5);



            // Validons que tout explose bien
            // Pseudo
            bool flag = false;
            try { new Avis("", 4.5, "commentaire", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Avis(null, 4.5, "commentaire", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Avis("  ", 4.5, "commentaire", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            // Note
            flag = false;
            try { new Avis("avis", -1, "commentaire", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Avis("avis", 6, "commentaire", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);



            // Commentaire
            flag = false;
            try { new Avis("avis", 4.5, "", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Avis("avis", 4.5, null, DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Avis("avis", 4.5, "  ", DateTime.Now); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Test Equals
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            Avis a1 = new Avis("Kevindu38", 5, "salut c'est michou", new DateTime(21 / 12 / 2012));
            Avis a2 = new Avis("Kevindu39", 5, "salut c'est Jean", new DateTime(21 / 12 / 2010));
            Avis a3 = new Avis("Kevindu38", 5, "salut c'est michou", new DateTime(21 / 12 / 2012));

            // a1 et a3 identiques
            Assert.AreEqual(a1, a3);

            // a1 et a2 différents (pseudos)
            Assert.AreNotEqual(a1, a2);


        }
    }
}
