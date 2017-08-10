using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace SplitViewResearch
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void hamburgerButton_Clicked(object sender, EventArgs e)
        {
            NavigationDrawer.ToggleDrawer();
        }
    }
}
