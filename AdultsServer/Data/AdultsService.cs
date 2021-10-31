using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using AdultsServer.Models;


namespace AdultsServer.Data
{
    public class AdultsService : IAdultsService
    {
       
        public IList<Adult> Adults { get; }
        
        private readonly string adultsFile = "C:\\Users\\ionge\\Desktop\\VIA UNIVERSITY\\3sem\\DNP1\\DNP1\\AdultsServer\\adults.json";

        public AdultsService()
        {
            Adults = File.Exists(adultsFile) ? ReadData<Adult>() : new List<Adult>();
            WritePersonsToFile();
        }

        private IList<T> ReadData<T>()
        {
            using (var jsonReader = File.OpenText(adultsFile))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }
        
        public async Task<Adult> AddAdultsAsync(Adult adult)
        {
            int max = Adults.Max(adult1 => adult1.Id);
            adult.Id = (++max);
            Adults.Add(adult);
            WritePersonsToFile();
            return adult;
        }

        public async Task<IList<Adult>> GetAdultsAsync()
        {
          //  IList<Adult> amp = new List<Adult>(Adults);
            return Adults;
        }

        public async Task RemoveAdultAsync(int AdultId)
        {
            Adult toRemove = Adults.First(t => t.Id == AdultId);
            Adults.Remove(toRemove);
            WritePersonsToFile();
        }

        private void WritePersonsToFile()
        {
            string PersonAsJson = JsonSerializer.Serialize(Adults);
            File.WriteAllText(adultsFile, PersonAsJson);
        }


    }
}