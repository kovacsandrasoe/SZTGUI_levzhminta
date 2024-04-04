using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SZTGUI_levzhminta
{
    public class Food
    {
        public Food(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public Food()
        {
            
        }

        public string Name { get; set; }

        public int Price { get; set; }

        public Food GetCopy()
        {
            return new Food(Name, Price);
        }

    }
}
