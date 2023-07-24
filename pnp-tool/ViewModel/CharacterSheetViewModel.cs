using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using pnp_tool.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pnp_tool.ViewModel
{
    public class CharacterSheetViewModel : ViewModelBase
    {
        private CharacterSheet characterSheet { get; set; }

        /* Character Personality */
        public string Name
        {
            get => characterSheet.Name;
            set { characterSheet.Name = value; RaisePropertyChanged(); }
        }

        public string Class
        {
            get => characterSheet.Class;
            set { characterSheet.Class = value; RaisePropertyChanged(); }
        }

        public string Race
        {
            get => characterSheet.Race;
            set { characterSheet.Race = value; RaisePropertyChanged(); }
        }

        public int CurrentHP
        {
            get => characterSheet.CurrentHP;
            set { characterSheet.CurrentHP = value; RaisePropertyChanged(); }
        }
        public int MaxHP
        {
            get => characterSheet.MaxHP;
            set { characterSheet.MaxHP = value; RaisePropertyChanged(); }
        }
        public int CurrentMana
        {
            get => characterSheet.CurrentMana;
            set { characterSheet.CurrentMana = value; RaisePropertyChanged(); }
        }
        public int MaxMana
        {
            get => characterSheet.MaxMana;
            set { characterSheet.MaxMana = value; RaisePropertyChanged(); }
        }

        /* Character Attributes */
        public int Strength
        {
            get => characterSheet.Strength;
            set { characterSheet.Strength = value; RaisePropertyChanged(); }
        }
        public int Dexterity
        {
            get => characterSheet.Dexterity;
            set { characterSheet.Dexterity = value; RaisePropertyChanged(); }
        }
        public int Intelligence
        {
            get => characterSheet.Intelligence;
            set { characterSheet.Intelligence = value; RaisePropertyChanged(); }
        }
        public int Wisdom
        {
            get => characterSheet.Wisdom;
            set { characterSheet.Wisdom = value; RaisePropertyChanged(); }
        }
        public int Charisma
        {
            get => characterSheet.Charisma;
            set { characterSheet.Charisma = value; RaisePropertyChanged(); }
        }
        public int Courage
        {
            get => characterSheet.Courage;
            set { characterSheet.Courage = value; RaisePropertyChanged(); }
        }

        /* Character Strengths and Weaknesses */


        /* Character Inventory */


        public CharacterSheetViewModel()
        {
            characterSheet = new CharacterSheet();
        }
    }
}
