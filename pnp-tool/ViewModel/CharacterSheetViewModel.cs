using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using pnp_tool.Model;
using pnp_tool.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace pnp_tool.ViewModel
{
    public class CharacterSheetViewModel : ViewModelBase
    {
        private CharacterSheet characterSheet { get; set; }

        public ICommand SelectCharacterImageCommand { get; }

        public ICommand RemoveCharacterImageCommand { get; }

        public ICommand AddStrengthCommand { get; }

        public ICommand RemoveStrengthCommand { get; }

        public ICommand AddWeaknessCommand { get; }

        public ICommand RemoveWeaknessCommand { get; }

        public ICommand AddItemCommand { get; }

        public ICommand RemoveItemCommand { get; }

        public ICommand ExportCharacterSheetCommand { get; }

        public ICommand ImportCharacterSheetCommand { get; }

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
            set
            {
                if (value > MaxHP) value = MaxHP;

                characterSheet.CurrentHP = value;
                RaisePropertyChanged();
            }
        }
        public int MaxHP
        {
            get => characterSheet.MaxHP;
            set
            {
                if (value < CurrentHP) CurrentHP = value;

                characterSheet.MaxHP = value;
                RaisePropertyChanged();
            }
        }

        public int CurrentMana
        {
            get => characterSheet.CurrentMana;
            set
            {
                if (value > MaxMana) value = MaxMana;

                characterSheet.CurrentMana = value;
                RaisePropertyChanged();
            }
        }
        public int MaxMana
        {
            get => characterSheet.MaxMana;
            set
            {
                if (value < CurrentMana) CurrentMana = value;

                characterSheet.MaxMana = value;
                RaisePropertyChanged();
            }
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
        public ObservableCollection<string> Strengths { get; }

        public ObservableCollection<string> Weaknesses { get; }


        /* Character Inventory */
        public ObservableCollection<string> Inventory { get; }

        /* Character Profile Image */
        public byte[] CharacterImageBytes
        {
            get => characterSheet.CharacterImageBytes;
            set { characterSheet.CharacterImageBytes = value; RaisePropertyChanged(); }
        }



        public CharacterSheetViewModel()
        {
            characterSheet = new CharacterSheet();

            Strengths = new ObservableCollection<string>(characterSheet.Strengths);
            Strengths.CollectionChanged += (_, e) => Strengths_CollectionChanged(e);

            Weaknesses = new ObservableCollection<string>(characterSheet.Weaknesses);
            Weaknesses.CollectionChanged += (_, e) => Weaknesses_CollectionChanged(e);

            Inventory = new ObservableCollection<string>(characterSheet.Inventory);
            Inventory.CollectionChanged += (_, e) => Inventory_CollectionChanged(e);

            AddStrengthCommand = new RelayCommand<string>(AddStrength);
            RemoveStrengthCommand = new RelayCommand<string>(RemoveStrength);

            AddWeaknessCommand = new RelayCommand<string>(AddWeakness);
            RemoveWeaknessCommand = new RelayCommand<string>(RemoveWeakness);

            AddItemCommand = new RelayCommand<string>(AddItem);
            RemoveItemCommand = new RelayCommand<string>(RemoveItem);

            SelectCharacterImageCommand = new ActionCommand(SelectCharacterImage);
            RemoveCharacterImageCommand = new ActionCommand(RemoveCharacterImage);

            ExportCharacterSheetCommand = new ActionCommand(ExportCharacterSheet);
            ImportCharacterSheetCommand = new ActionCommand(ImportCharacterSheet);
        }

        private void Strengths_CollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (string newStrength in e.NewItems)
                        characterSheet.Strengths.Add(newStrength);

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (string removedStrength in e.OldItems)
                        characterSheet.Strengths.Remove(removedStrength);

                    break;
                default: break;
            }
        }
        private void Weaknesses_CollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (string newWeakness in e.NewItems)
                        characterSheet.Weaknesses.Add(newWeakness);

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (string removedWeakness in e.OldItems)
                        characterSheet.Weaknesses.Remove(removedWeakness);

                    break;
                default: break;
            }
        }

        private void Inventory_CollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (string newItem in e.NewItems)
                        characterSheet.Inventory.Add(newItem);

                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (string oldItem in e.OldItems)
                        characterSheet.Inventory.Remove(oldItem);

                    break;
                default: break;
            }
        }

        private void AddStrength(string strength) => Strengths.Add(strength);

        private void RemoveStrength(string strength) => Strengths.Remove(strength);

        private void AddWeakness(string weakness) => Weaknesses.Add(weakness);

        private void RemoveWeakness(string weakness) => Weaknesses.Remove(weakness);

        private void AddItem(string item) => Inventory.Add(item);

        private void RemoveItem(string item) => Inventory.Remove(item);

        private void SelectCharacterImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                byte[] imageBytes = File.ReadAllBytes(openFileDialog.FileName);
                CharacterImageBytes = imageBytes;

            }
        }

        private void RemoveCharacterImage() => CharacterImageBytes = null;

        private void ExportCharacterSheet()
        {
            var saveFileDialog = new SaveFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                DefaultExt = "json",
                Title = "Export Character Sheet"
            };

            if (saveFileDialog.ShowDialog() == true)
            {
                string filePath = saveFileDialog.FileName;
                CharacterSheetSerializationService.SaveToFile(filePath, characterSheet);
            }
        }
        private void ImportCharacterSheet()
        {
            var openFileDialog = new OpenFileDialog
            {
                Filter = "JSON Files (*.json)|*.json",
                Title = "Import Character Sheet"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                CharacterSheet importedCharacterSheet = CharacterSheetSerializationService.LoadFromFile(filePath);
                UpdateCharacterSheetProperties(importedCharacterSheet);
            }
        }

        private void UpdateCharacterSheetProperties(CharacterSheet updatedCharacterSheet)
        {
            Name = updatedCharacterSheet.Name;
            Class = updatedCharacterSheet.Class;
            Race = updatedCharacterSheet.Race;
            MaxHP = updatedCharacterSheet.MaxHP;
            CurrentHP = updatedCharacterSheet.CurrentHP;
            MaxMana = updatedCharacterSheet.MaxMana;
            CurrentMana = updatedCharacterSheet.CurrentMana;

            Strength = updatedCharacterSheet.Strength;
            Dexterity = updatedCharacterSheet.Dexterity;
            Intelligence = updatedCharacterSheet.Intelligence;
            Wisdom = updatedCharacterSheet.Wisdom;
            Charisma = updatedCharacterSheet.Charisma;
            Courage = updatedCharacterSheet.Courage;

            Strengths.Clear();
            updatedCharacterSheet.Strengths.ForEach(Strengths.Add);

            Weaknesses.Clear();
            updatedCharacterSheet.Weaknesses.ForEach(Weaknesses.Add);

            Inventory.Clear();
            updatedCharacterSheet.Inventory.ForEach(Inventory.Add);

            CharacterImageBytes = updatedCharacterSheet.CharacterImageBytes;
        }
    }
}
