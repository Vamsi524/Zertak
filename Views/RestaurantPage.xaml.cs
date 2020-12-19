using MobileGuide.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MobileGuide.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RestaurantPage : ContentPage, INotifyPropertyChanged
    {
        public List<Restaurant> rest;
        public RestaurantPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            rest = await App.RestService.FetchFoodMenu();
            restaurantsListView.ItemsSource = rest;
            base.OnAppearing();
        }

        async void Handle_SelectedRestaurant(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var obj = (Restaurant)e.SelectedItem;
            NavigationPage.SetHasBackButton(this, true);
            NavigationPage.SetHasNavigationBar(this, true);
            await Navigation.PushAsync(new RestaurantItemPage(obj));
        }
    }
}