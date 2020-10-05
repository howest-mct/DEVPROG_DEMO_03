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
    public partial class ModalPage : ContentPage
    {
        public ModalPage()
        {
            InitializeComponent();

            btnGoBack.IsEnabled = false; //will onlly be enabled if accept button is clicked
        }

        protected override void OnAppearing()
        {
            Debug.WriteLine("-> Modal page appears");
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            Debug.WriteLine("-> Modal page disappears");
        }

        //bool telling if the user can go back yet
        //  (you might eg. only set this to true if user hit accept button)
        bool canGoBack = false;

        private void Accept_Clicked(object sender, EventArgs e)
        {
            canGoBack = true;   //enable hardware button to go back
            btnGoBack.IsEnabled = true; //enable back button in GUI
        }

        //this is executed when the device's back button is pressed 
        //since this is a modal page, we want to prevent this button from working
        protected override bool OnBackButtonPressed()
        {
            if (canGoBack) //check if user can go back yet
                return base.OnBackButtonPressed();  //return to previous page
            else
                return true;    //prevent returning to previous page
        }

        private void btnGoBack_Clicked(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}