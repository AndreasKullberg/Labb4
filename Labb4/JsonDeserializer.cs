using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;

namespace Labb4
{
    public class JsonDeserializer<T>
    {
     
        public T Type { get; private set; }

        public void Deserialize(string json)
        {
            var assembly = typeof(T).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream($"{assembly.GetName().Name}.{json}");
            using (var reader = new StreamReader(stream))
            {
                Type = JsonConvert.DeserializeObject<T>(reader.ReadToEnd());
            }
        }
    }
}
