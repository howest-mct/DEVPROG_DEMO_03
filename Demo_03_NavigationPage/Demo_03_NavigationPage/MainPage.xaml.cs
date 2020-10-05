using Demo_03_NavigationPage.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Demo_03_NavigationPage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("-> Main page appears");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine("-> Main page disappears");
        }

        private void OnModelessNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ModelessPage());
        }

        private void OnModalNav_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new ModalPage());
        }
    }
}
