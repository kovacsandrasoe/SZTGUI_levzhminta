using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_levzhminta
{
    public class FoodViewModel
    {
        public ObservableCollection<Food> Foods { get; set; }

        public ObservableCollection<Food> Basket { get; set; }

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

            Basket = new ObservableCollection<Food>()
        }
    }
}
