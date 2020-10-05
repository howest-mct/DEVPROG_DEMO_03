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
    public partial class BeerDetailPage : ContentPage
    {
        public BeerDetailPage(Beer beer)
        {
            InitializeComponent();

            ShowDetails(beer);
        }

        private void ShowDetails(Beer beer)
        {
            lblName.Text = "Name: " + beer.Name;
            lblBrewery.Text = "Brewery: " + beer.Brewery;
            lblAlcohol.Text = "Alcohol: " + beer.Alcohol + "%"; 
        }
    }
}