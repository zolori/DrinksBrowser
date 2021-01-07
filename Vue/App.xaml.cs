using Metier;
using Persistance;
using System.IO;
using System.Windows;

namespace Vue
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly string CHEMIN_JSON = Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\..\\Solution Items\\");

        public Manager LeManager = new Manager(new JsonPersistance(CHEMIN_JSON));
    }
}
