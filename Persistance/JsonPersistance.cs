using System;
using System.Collections.Generic;
using System.Text;
using Metier;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Persistance
{
    public class JsonPersistance : IPersistance
    {
        public JsonPersistance(string c)
        {
            Directory.SetCurrentDirectory(c);
        }

        public JsonPersistance()
        {
        }

        public IEnumerable<Alcool> ChargerAlcools(String c)
        {
            IEnumerable<Alcool> alcools = new List<Alcool>();
            Stream fs = File.OpenRead(c);
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<Alcool>));
            alcools = ser.ReadObject(fs) as IEnumerable<Alcool>;
            fs.Close();
            return alcools;
        }

        public bool SauvegarderAlcools(String c, IEnumerable<Alcool> alcools)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<Alcool>));
            Stream fs = File.Create(c);
            ser.WriteObject(fs, alcools);
            fs.Close();

            return true;
        }
    }

}
