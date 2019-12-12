using System;
using System.Collections.Generic;

namespace Labb4
{
    public class CountryRepository
    {
        public List<Country> Countries { get; set; }
        private JsonDeserializer<CountryRepository> json = new JsonDeserializer<CountryRepository>();

        public void Deserialize()
        {
            json.Deserialize("rawData.json");
            Countries = json.Type.Countries;
        }

        public List<Country> GetCountries()
        {
            Deserialize();
            return Countries;
        }
    }
}
