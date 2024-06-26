﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SZTGUI_levzhminta
{
    public class FoodViewModel : ObservableObject
    {
        public ObservableCollection<Food> Foods { get; set; }

        public ObservableCollection<Food> Basket { get; set; }

        private Food selectedFood;
        public Food SelectedFood
        {
            get
            {
                return selectedFood;
            }
            set
            {
                selectedFood = value;
                OnPropertyChanged();
                (AddCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Food selectedBasket;

        public Food SelectedBasket
        {
            get
            {
                return selectedBasket;
            }
            set
            {
                selectedBasket = value; 
                OnPropertyChanged();
                (DeleteCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        public ICommand AddCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand ExportCommand { get; set; }
        public int SumPrice
        {
            get
            {
                return Basket.Sum(x => x.Price);
            }
        }


        public FoodViewModel()
        {
            Foods = new ObservableCollection<Food>()
            {
                new Food("paprika", 500),
                new Food("hagyma", 400),
                new Food("zsír", 100),
                new Food("marhahús", 3500),
                new Food("burgonya", 1500),
            };

            Basket = new ObservableCollection<Food>();

            AddCommand = new RelayCommand(() =>
            {
                Basket.Add(SelectedFood.GetCopy());
                OnPropertyChanged(nameof(SumPrice));
            }, () => SelectedFood != null);

            DeleteCommand = new RelayCommand(() =>
            {
                Basket.Remove(SelectedBasket);
                OnPropertyChanged(nameof(SumPrice));
            }, () => SelectedBasket != null);

            ExportCommand = new RelayCommand(() =>
            {
                string jsonText = JsonConvert.SerializeObject(Basket, Formatting.Indented);
                File.WriteAllText("basket.json", jsonText);
            });
        }
    }
}
