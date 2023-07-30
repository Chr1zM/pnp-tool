using pnp_tool.Model;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace pnp_tool.Service
{
    public static class CharacterSheetSerializationService
    {
        public static string Serialize(CharacterSheet characterSheet)
        {
            return JsonConvert.SerializeObject(characterSheet, Formatting.Indented);
        }

        public static CharacterSheet Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<CharacterSheet>(json);
        }

        public static void SaveToFile(string filePath, CharacterSheet characterSheet)
        {
            var json = Serialize(characterSheet);
            File.WriteAllText(filePath, json);
        }

        public static CharacterSheet LoadFromFile(string filePath)
        {
            var json = File.ReadAllText(filePath);
            return Deserialize(json);
        }


    }
}
