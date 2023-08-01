using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace pnp_tool.Model
{
    public class CharacterSheet
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public int MaxHP { get; set; }
        public int CurrentHP { get; set; }
        public int MaxMana { get; set; }
        public int CurrentMana { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }
        public int Courage { get; set; }
        public List<string> Strengths { get; set; }
        public List<string> Weaknesses { get; set; }
        public List<string> Inventory { get; set; }
        public byte[] CharacterImageBytes { get; set; }

        public BitmapImage GetCharacterImage()
        {
            if (CharacterImageBytes != null && CharacterImageBytes.Length > 0)
            {
                BitmapImage characterImage = new BitmapImage();
                using (MemoryStream ms = new MemoryStream(CharacterImageBytes))
                {
                    characterImage.BeginInit();
                    characterImage.CacheOption = BitmapCacheOption.OnLoad;
                    characterImage.StreamSource = ms;
                    characterImage.EndInit();
                }
                return characterImage;
            }
            return null;
        }

        public CharacterSheet()
        {
            Name = string.Empty;
            Class = string.Empty;
            Race = string.Empty;
            MaxHP = 30;
            CurrentHP = 30;
            MaxMana = 10;
            CurrentMana = 10;

            Strength = 5;
            Dexterity = 5;
            Intelligence = 5;
            Wisdom = 5;
            Charisma = 5;
            Courage = 5;

            Strengths = new List<string>();
            Weaknesses = new List<string>();
            Inventory = new List<string>();

            CharacterImageBytes = null;
        }
    }
}
