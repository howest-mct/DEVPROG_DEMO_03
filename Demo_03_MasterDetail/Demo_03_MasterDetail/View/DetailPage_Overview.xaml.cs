using Demo_03_MasterDetail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_03_MasterDetail.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage_Overview : ContentPage
    {
        public DetailPage_Overview()
        {
            InitializeComponent();

            FilterBeerList("all beers");          
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public void FilterBeerList(string filter)
        {
            this.Title = filter;    //set the title of this page

            switch(filter)
            {
                //no filter:
                case null:
                case "all beers":
                    lvwBeers.ItemsSource = Beer.GetBeers();
                    break;

                //alcohol free:
                case "alcohol free":
                    lvwBeers.ItemsSource = Beer.GetBeersFiltered(true);
                    break;

                //without alcohol free:
                case "alcoholic":
                    lvwBeers.ItemsSource = Beer.GetBeersFiltered(false);
                    break;
            }
              
        }

        private void lvwBeers_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Beer beer = lvwBeers.SelectedItem as Beer;
            if (beer == null) return;   //no beer was selected; ignore

            Navigation.PushAsync(new BeerDetailPage(beer));

            lvwBeers.SelectedItem = null;   //remove selected beer, so none is selected if you come back
        }
    }
}