using OdeToFoodCore.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFoodCore.Data
{
    public  interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updateRestaurant);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant Delete(int id);
        int GetCountOfRestaurants();
        int Commit();
    }

}
