using Metier;
using StubAlcool;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestStub
{
    class TestStub
    {

        static void Main(string[] args)
        {

            string CHEMIN_JSON = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Solution Items\\");

            Manager Man = new Manager(new Stub(CHEMIN_JSON));


            foreach (Alcool a in Man.AlcoolsAffiche)
            {
                a.UpdateNote();
                Console.WriteLine("//////////////");
                Console.WriteLine("//////////////");
                Console.WriteLine("          ");
                Console.WriteLine(a.Nom);
                Console.WriteLine(a.Note);

                if (a.ListAvis != null)
                {
                    foreach(Avis b in a.ListAvis)
                    {
                        Console.WriteLine(b.Pseudo);
                        Console.WriteLine(b.Commentaire);
                        Console.WriteLine("      ");
                    }
                }
            }

            




        }   

    }
}
