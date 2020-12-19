using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileGuide.Models
{
    public class Restaurant
    {
        [JsonProperty("restaurant_id")]
        public string restaurant_id { get; set; }

        [JsonProperty("restaurant_name")]
        public string RestaurantName { get; set; }

        [JsonProperty("restaurant_image")]
        public string RestaurantImage { get; set; }
        public string table_id { get; set; }
        public string table_name { get; set; }
        public string branch_name { get; set; }
        public string nexturl { get; set; }
        public List<TableMenuList> table_menu_list { get; set; }
    }

    public class TableMenuList
    {
        [JsonProperty("menu_category")]
        public string MenuCategory { get; set; }
        public string menu_category_id { get; set; }
        public string menu_category_image { get; set; }
        public string nexturl { get; set; }
        public List<CategoryDish> category_dishes { get; set; }
    }

    public class CategoryDish
    {
        public string dish_id { get; set; }
        
        [JsonProperty("dish_name")]
        public string DishName { get; set; }
        
        public double dish_price { get; set; }
        public string dish_image { get; set; }
        public string dish_currency { get; set; }
        public double dish_calories { get; set; }
        public string dish_description { get; set; }
        public bool dish_Availability { get; set; }
        public int dish_Type { get; set; }
        public int dish_Count { get; set; }
        public string nexturl { get; set; }
        public List<AddonCat> addonCat { get; set; }
        public string UpdatedCalories 
        {
            get
            {
                return dish_calories.ToString() + " Calories";
            }
            set { }
        }

        public string CombinedPrice
        {
            get 
            {
                var price = dish_price.ToString();
                if (string.IsNullOrEmpty(dish_currency) && string.IsNullOrEmpty(price))
                    return "NA";
                else if (string.IsNullOrEmpty(dish_currency))
                    return price;
                else if (string.IsNullOrEmpty(price))
                    return dish_currency;
                else
                    return dish_currency + "  " + price;
            }
            set { }
        }

        public bool isAddon
        {
            get => addonCat != null && addonCat.Count > 0 ? true : false;
        }
    }

    public class AddonCat
    {
        public string addon_category { get; set; }
        public string addon_category_id { get; set; }
        public int addon_selection { get; set; }
        public string nexturl { get; set; }
        public List<Addon> addons { get; set; }
    }

    public class Addon
    {
        public string dish_id { get; set; }
        public string dish_name { get; set; }
        public double dish_price { get; set; }
        public string dish_image { get; set; }
        public string dish_currency { get; set; }
        public double dish_calories { get; set; }
        public string dish_description { get; set; }
        public bool dish_Availability { get; set; }
        public int dish_Type { get; set; }
    }
}
