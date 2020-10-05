using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Demo_03_Readacsv.Models;


namespace Demo_03_Readacsv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            LoadAllBeers();
        }



        /// <summary>
        /// Uses the static GetBeers method of the Beer class to:
        /// - get a list of beers (from csv file)
        /// - show the beers in the listview
        /// </summary>
        private void LoadAllBeers()
        {
            //call static method GetBeers of Beer class
            List<Beer> allBeers = Beer.GetBeers();

            //print all beers to output window using PrintBeers method
            lvwBeers.ItemsSource = allBeers;
        }
    }
}
