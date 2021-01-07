using Metier;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace StubAlcool
{
    public class Stub : IPersistance
    {
        public Stub(string c)
        {
            Directory.SetCurrentDirectory(c);
        }

        public List<Alcool> listAlcool = new List<Alcool>();

        public IEnumerable<Alcool> ChargerAlcools(String s)
        {
            Alcool a1 = new Alcool("whiskyTestStub", "Images/Label 5 CB.jpg", TypeAlcool.Whisky, "descritpion1", 45, 25);

            listAlcool.Add(a1);

            a1.AjouterAvis(new Avis("test", 5, "Tres bon alcool je recommande", DateTime.Now));
            a1.AjouterAvis(new Avis("test", 1, "Je n'aime pas du tout", DateTime.Now)); //Ne doit pas apparaitre => même pseudo qu'au dessus
            a1.AjouterAvis(new Avis("test2", 4, "Un delice", DateTime.Now));
            a1.AjouterAvis(new Avis("test3", 3, "Bof", DateTime.Now));

            listAlcool.Add(a1);

            Alcool a2 = new Alcool("GinTestStub", "Images/gordons_gin.png", TypeAlcool.Gin, "descritpion2", 43, 23);

            listAlcool.Add(a2);

            listAlcool.Add(new Alcool("RicardTEstStub", "Images/Ricard.png", TypeAlcool.Pastis, "descritpion3", 40, 20,
                new Avis("TestConstructeur", 5, "Tres bon pour l'aperitif", DateTime.Now)));

            return listAlcool;
        }

        public bool SauvegarderAlcools(String s, IEnumerable<Alcool> alcools)
        {
            throw new NotImplementedException();
        }

    }

}
