using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurant_order.Models
{
    public interface IDishesRepository
    {
        IEnumerable<Dishes> GetAll();
        bool Add(string period, string dishTypes);
    }
}
