using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace restaurant_order.Models
{
    public class DishesRepository : IDishesRepository
    {
        private List<Dish> dishes = new List<Dish>();

        public IEnumerable<Dish> GetAll()
        {
            return dishes;
        }

        public bool Add(string order)
        {                        
            string period = Regex.Replace(order.Split()[0], @"[^0-9a-zA-Z\ ]+", "").ToLower();

            string dishTypes = order.Substring(order.IndexOf(",") + 1);

            string[] dishTypesSeparated = dishTypes.Split(',');

            if(period == "morning" || period == "night")
            {
                dishes.Add(Populate(period, dishTypesSeparated));
                return true;
            }
            else
            {
                return false;
            }
        }

        private Dish Populate(string period, string[] dishTypes)
        {
            Dish dish = new Dish();

            foreach (string dishType in dishTypes)
            {
                if (dishType == "1")
                {
                    //dish.dishType = dishType;
                    dish.food += period == "morning" ? "eggs" : "steak";
                }
                else if (dishType == "2")
                {
                    //dish.dishType = dishType;
                    dish.food += period == "morning" ? "toast" : "potato";
                }
                else if (dishType == "3")
                {
                    //dish.dishType = dishType;
                    dish.food += period == "morning" ? "Coffee" : "wine";
                }
                else if (dishType == "4")
                {
                    if(period == "morning")
                    {
                        //dish.dishType = "error";
                        dish.food += "error";
                    }
                    else
                    {
                        //dish.dishType = dishType;
                        dish.food += "cake";
                    }                    
                }
            }

            return dish;
        }
    }
}