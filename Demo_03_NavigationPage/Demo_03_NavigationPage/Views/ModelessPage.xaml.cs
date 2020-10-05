using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Demo_03_NavigationPage.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModelessPage : ContentPage
    {
        public ModelessPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("-> Modeless page appears");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine("-> Modeless page disappears");
        }
    }
}