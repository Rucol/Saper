using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Sapper5
{
    public class Wyniki
    {
        public const string Path = @".\Wyniki.json";
        private ObservableCollection<WynikModel> models;
        public Wyniki()
        {
            var data = Deserializacja();
            if(data == null) data = new ObservableCollection<WynikModel>();

            models = data;
            models.CollectionChanged += (sender, e) => { Serializacja(); };
        }
        private void Serializacja()
        {
           var result = JsonConvert.SerializeObject(models);
           File.WriteAllText(Path, result);
            
        }
        public ObservableCollection<WynikModel> Deserializacja()
        {
            try
            {
                var data = File.ReadAllText(Path);
                return JsonConvert.DeserializeObject<ObservableCollection<WynikModel>>(data);
            }
            catch
            {
                return null;
            }
        }
        public void Add(WynikModel modelwynik)
        {
           models.Add(modelwynik);
        }
        
    }
    public class WynikModel
    {
        public string Name { get; set; }
        public int Wynik { get; set; }
    }
}
