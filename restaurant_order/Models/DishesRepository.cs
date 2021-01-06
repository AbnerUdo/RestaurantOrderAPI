using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restaurant_order.Models
{
    public class DishesRepository : IDishesRepository
    {
        private List<Dishes> dishes = new List<Dishes>();

        public IEnumerable<Dishes> GetAll()
        {
            return dishes;
        }

        public bool Add(string period, string dishTypes)
        {            
            bool addResult = false;
            string periodLowerCase = period.ToLower();

            string[] dishTypesSeparated = dishTypes.Split(',');

            if(periodLowerCase == "morning" || periodLowerCase == "night")
            {
                Populate(periodLowerCase, dishTypesSeparated);
                addResult = true;
                return addResult;
            }
            else
            {
                return addResult;
            }
        }

        private Dishes Populate(string period, string[] dishTypes)
        {
            Dishes dish = new Dishes();

            foreach (string dishType in dishTypes)
            {
                if (dishType == "1")
                {
                    dish.dishType = dishType;
                    dish.food = period == "morning" ? "eggs" : "steak";
                }
                else if (dishType == "2")
                {
                    dish.dishType = dishType;
                    dish.food = period == "morning" ? "toast" : "potato";
                }
                else if (dishType == "3")
                {
                    dish.dishType = dishType;
                    dish.food = period == "morning" ? "Coffee" : "wine";
                }
                else if (dishType == "4")
                {
                    if(period == "morning")
                    {
                        dish.dishType = "error";
                        dish.food = "error";
                    }
                    else
                    {
                        dish.dishType = dishType;
                        dish.food = "cake";
                    }                    
                }
            }

            return dish;
        }
    }
}