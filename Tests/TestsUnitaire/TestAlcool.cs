using Metier;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static System.Console;

namespace TestUnitaire
{
    [TestClass]
    public class TestAlcool
    {
        /// <summary>
        /// Test simple des propertietes de Alcool
        /// </summary>
        [TestMethod]
        public void TestPropriete()
        {
            // Validons que tout explose bien

            // Nom
            bool flag = false;
            try { new Alcool("", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Alcool(null, "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Alcool("  ", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            // Description
            flag = false;
            try { new Alcool("wiwi", "oui", TypeAlcool.Cognac, "", 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Alcool("wiwi", "oui", TypeAlcool.Cognac, null, 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            flag = false;
            try { new Alcool("wiwi", "oui", TypeAlcool.Cognac, "  ", 30, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            // Prix
            flag = false;
            try { new Alcool("wiwi", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, -1); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);

            // Degre
            flag = false;
            try { new Alcool("wiwi", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", -1, 52); }
            catch (ArgumentException) { flag = true; }
            Assert.IsTrue(flag);
        }

        /// <summary>
        /// Test simple des propertietes de Alcool
        /// </summary>
        [TestMethod]
        public void TestEquals()
        {
            Alcool a1 = new Alcool("jcvd", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52);
            Alcool a2 = new Alcool("jcv2", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52);
            Alcool a3 = new Alcool("jcvd", "oui", TypeAlcool.Cognac, "V'la qu'il est bon", 30, 52);

            Assert.AreEqual(a1, a3);
            Assert.AreNotEqual(a1, a2);


        }
    }
}
