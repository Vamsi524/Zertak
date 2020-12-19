using MobileGuide.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;

namespace MobileGuide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantItemPage : ContentPage
    {
        public List<TableMenuList> menuList;
        public List<CategoryDish> presentDishesList;
        public RestaurantItemPage()
        {
            InitializeComponent();
        }

        public RestaurantItemPage(Restaurant restaurant)
        {
            InitializeComponent();
            Title = restaurant.RestaurantName;
            menuList = restaurant.table_menu_list;
            MenuCategoryListview.ItemsSource= menuList;
            MenuCategoryListview.SelectedItem = menuList.FirstOrDefault();
        }

        async void Handle_SelectedCategory(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {

        }

        private void MenuCategoryListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var obj = e.CurrentSelection;
            var info = obj.FirstOrDefault() as TableMenuList;
            presentDishesList = info.category_dishes;
            DishesListView.ItemsSource = info.category_dishes;
        }

        private void IncreaseButton_Clicked(object sender, EventArgs e)
        {
            if (sender is View v && v.BindingContext is CategoryDish item)
            {
                if (item.dish_Count < 10)
                    item.dish_Count += 1;
                OnPropertyChanged();
            }
        }

        private void DecreaseButton_Clicked(object sender, EventArgs e)
        {
            if (sender is View v && v.BindingContext is CategoryDish item)
            {
                if(item.dish_Count > 0)
                    item.dish_Count -= 1;
            }
        }
    }
}