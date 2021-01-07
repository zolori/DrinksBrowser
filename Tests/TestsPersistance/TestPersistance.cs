using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using Metier;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Persistance;

namespace TestsPersistance
{
    [TestClass]
    public class TestPersitance
    {
        private static readonly string CHEMIN_JSON = Directory.GetCurrentDirectory();
        private Alcool a1;
        private Alcool a2;

        [TestInitialize]
        public void TestInitialize()
        {
            a1 = new Alcool("a1", "truc.jpg", TypeAlcool.Whisky, "Cet alcool est un whisky ecossais!", 45, 256)
            {
                ListAvis = new ObservableCollection<Avis>()
                {
                    new Avis("toto", 4.2, "Trop bon", new DateTime(2019, 06, 01, 18, 34, 45)),
                    new Avis("titi", 2.1, "Bof ...", new DateTime(2019, 06, 07, 18, 34, 45)),
                }
            };

            a2 = new Alcool("a2", "truc.jpg", TypeAlcool.Whisky, "Cet alcool est un whisky americain!", 50, 276)
            {
                ListAvis = new ObservableCollection<Avis>()
                {
                    new Avis("tata", 4.8, "Excellent!", new DateTime(2019, 06, 02, 18, 34, 45)),
                    new Avis("tutu", 1.1, "Pas top", new DateTime(2019, 06, 04, 18, 34, 45))
                }
            };
        }

        [TestMethod]
        public void TestSauvegarde()
        {
            JsonPersistance p = new JsonPersistance(CHEMIN_JSON);
            Assert.IsTrue(p.SauvegarderAlcools("test_persistance.json", new List<Alcool>() { a1, a2 }));
        }

        [TestMethod]
        public void TestChargement()
        {
            JsonPersistance p = new JsonPersistance(CHEMIN_JSON);
            IEnumerable<Alcool> alcools = p.ChargerAlcools("test_persistance.json");

            // Test que le chargement ne retourne pas null
            Assert.IsNotNull(alcools);
            // Test qu'il y a bien 2 alcools charges
            Assert.IsTrue(alcools.Count() == 2);
            // Test qu'un des alcools est 'a1'
            Assert.IsTrue(alcools.Where(a => a.Nom == a1.Nom).Count() == 1);
            // Test qu'un des alcools est 'a2'
            Assert.IsTrue(alcools.Where(a => a.Nom == a2.Nom).Count() == 1);

            // Test les proprietes de a1
            Alcool a1_ = alcools.Where(a => a.Nom == a1.Nom).First();
            Assert.IsTrue(a1_.Nom == a1.Nom);
            Assert.IsTrue(a1_.Degre == a1.Degre);
            Assert.IsTrue(a1_.Prix == a1.Prix);
            Assert.IsTrue(a1_.Image == a1.Image);
            Assert.IsTrue(a1_.Type == a1.Type);

            // Test les proprietes de a2
            Alcool a2_ = alcools.Where(a => a.Nom == a2.Nom).First();
            Assert.IsTrue(a2_.Nom == a2.Nom);
            Assert.IsTrue(a2_.Degre == a2.Degre);
            Assert.IsTrue(a2_.Prix == a2.Prix);
            Assert.IsTrue(a2_.Image == a2.Image);
            Assert.IsTrue(a2_.Type == a2.Type);

            // Test les avis de a1
            Assert.IsTrue(a1_.ListAvis.Count == 2);
            // Test qu'un des avis est de 'toto'
            Assert.IsTrue(a1_.ListAvis.Where(a => a.Pseudo == "toto").Count()==1);
            // Test qu'un des avis est de 'tata'
            Assert.IsTrue(a1_.ListAvis.Where(a => a.Pseudo == "titi").Count() == 1);
            // Test les proprietes de l'avis de toto
            Avis detoto = a1_.ListAvis.Where(a => a.Pseudo == "toto").First();
            Assert.IsTrue(detoto.Note == 4.2);
            Assert.IsTrue(detoto.Date.Equals(new DateTime(2019, 06, 01, 18, 34, 45)));
            Assert.IsTrue(detoto.Commentaire == "Trop bon");
            // Test les proprietes de l'avis de tata
            Avis detiti = a1_.ListAvis.Where(a => a.Pseudo == "titi").First();
            Assert.IsTrue(detiti.Note == 2.1);
            Assert.IsTrue(detiti.Date.Equals(new DateTime(2019, 06, 07, 18, 34, 45)));
            Assert.IsTrue(detiti.Commentaire == "Bof ...");

            // Test les avis de a2
            Assert.IsTrue(a2_.ListAvis.Count == 2);
            // Test qu'un des avis est de 'tata'
            Assert.IsTrue(a2_.ListAvis.Where(a => a.Pseudo == "tata").Count() == 1);
            // Test qu'un des avis est de 'tutu'
            Assert.IsTrue(a2_.ListAvis.Where(a => a.Pseudo == "tutu").Count() == 1);
            // Test les proprietes de l'avis de tata
            Avis detata = a2_.ListAvis.Where(a => a.Pseudo == "tata").First();
            Assert.IsTrue(detata.Note == 4.8);
            Assert.IsTrue(detata.Date.Equals(new DateTime(2019, 06, 02, 18, 34, 45)));
            Assert.IsTrue(detata.Commentaire == "Excellent!");
            // Test les proprietes de l'avis de tutu
            Avis detutu = a2_.ListAvis.Where(a => a.Pseudo == "tutu").First();
            Assert.IsTrue(detutu.Note == 1.1);
            Assert.IsTrue(detutu.Date.Equals(new DateTime(2019, 06, 04, 18, 34, 45)));
            Assert.IsTrue(detutu.Commentaire == "Pas top");
        }
    }
}
