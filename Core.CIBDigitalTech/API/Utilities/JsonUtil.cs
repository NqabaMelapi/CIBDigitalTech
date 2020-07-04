using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Core.CIBDigitalTech.API.Utilities
{
    public class JsonUtil
    {
        public static bool CheckChildNode(string jsonString, string roodNode,string childNode)
        {
            var node = JObject.Parse(jsonString)[roodNode]
                .Children<JProperty>()
                .Where(jp => jp.Name.StartsWith(childNode))
                .Select(jp => (JArray)jp.Value)
                .ToList();

            return node.Any();
        }

        public static string GetChildNode(string jsonString, string roodNode, string childNode)
        {
            var node = JObject.Parse(jsonString)[roodNode]
                .Children<JProperty>()
                .Where(jp => jp.Name.StartsWith(childNode))
                .Select(jp => (JArray)jp.Value)
                .ToList();

            return node.ToString();
        }
    }
}
