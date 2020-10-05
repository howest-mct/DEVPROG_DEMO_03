using Demo_03_TabbedPage.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_03_TabbedPage.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BreweryOverview : ContentPage
    {
        public BreweryOverview()
        {
            InitializeComponent();

            LoadBreweries();
        }

        private void LoadBreweries()
        {
            lvwBreweries.ItemsSource = Beer.GetBreweries();
        }
    }
}