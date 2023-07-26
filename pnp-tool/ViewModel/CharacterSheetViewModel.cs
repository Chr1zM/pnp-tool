﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using Microsoft.Xaml.Behaviors.Core;
using pnp_tool.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
        public ObservableCollection<string> Strengths { get; }
        public ObservableCollection<string> Weaknesses { get; }


        /* Character Inventory */
        public ObservableCollection<string> Inventory { get; }

        /* Character Profile Image */
        public string CharacterImage
        {
            get => characterSheet.CharacterImage;
            set { characterSheet.CharacterImage = value; RaisePropertyChanged(); }
        }

        public CharacterSheetViewModel()
        {
            characterSheet = new CharacterSheet();

            Strengths = new ObservableCollection<string>(characterSheet.Strengths);
            Strengths.CollectionChanged += Strengths_CollectionChanged;

            Weaknesses = new ObservableCollection<string>(characterSheet.Weaknesses);
            Weaknesses.CollectionChanged += Weaknesses_CollectionChanged;

            Inventory = new ObservableCollection<string>(characterSheet.Inventory);
            Inventory.CollectionChanged += Inventory_CollectionChanged;

            AddStrengthCommand = new RelayCommand<string>(AddStrength);
            RemoveStrengthCommand = new RelayCommand<string>(RemoveStrength);

            AddWeaknessCommand = new RelayCommand<string>(AddWeakness);
            RemoveWeaknessCommand = new RelayCommand<string>(RemoveWeakness);

            AddItemCommand = new RelayCommand<string>(AddItem);
            RemoveItemCommand = new RelayCommand<string>(RemoveItem);

            SelectCharacterImageCommand = new ActionCommand(SelectCharacterImage);
            RemoveCharacterImageCommand = new ActionCommand(RemoveCharacterImage);
        }

        private void Strengths_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    characterSheet.Strengths.Add((string)e.NewItems[0]); break;
                case NotifyCollectionChangedAction.Remove:
                    characterSheet.Strengths.Remove((string)e.OldItems[0]); break;
                default: break;
            }
        }
        private void Weaknesses_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    characterSheet.Weaknesses.Add((string)e.NewItems[0]); break;
                case NotifyCollectionChangedAction.Remove:
                    characterSheet.Weaknesses.Remove((string)e.OldItems[0]); break;
                default: break;
            }
        }

        private void Inventory_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    characterSheet.Inventory.Add((string)e.NewItems[0]); break;
                case NotifyCollectionChangedAction.Remove:
                    characterSheet.Inventory.Remove((string)e.OldItems[0]); break;
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
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                CharacterImage = openFileDialog.FileName;
            }
        }
        private void RemoveCharacterImage() => CharacterImage = null;

    }
}
