using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.CIBDigitalTech.Utilities
{
    public class StringToJson
    {
        public  bool GetSubBreedFromList(string jsonString, string subBreed)
        {
            
           
            var breed = JObject.Parse(jsonString)["message"]
                .Children<JProperty>()
                .Where(jp => jp.Name.StartsWith(subBreed))
                .Select(jp => (JArray)jp.Value)
                .ToList();

            return breed.Any();
        }
    }
}
