using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo_03_MasterDetail
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();

            lvwFilters.ItemsSource = new List<string> { "all beers", "alcohol free", "alcoholic" };
        }

        private void LvwFilters_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
           
            string filter = lvwFilters.SelectedItem as string;

            if (filter == null)
                return; //nothing is selected; ignore

            detailPage.FilterBeerList(filter);  //filter details based on masterpage

            IsPresented = false;    //HIDE the menu
        }
    }
}
