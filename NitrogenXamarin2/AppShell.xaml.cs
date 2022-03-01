using NitrogenXamarin2.ViewModels;
using NitrogenXamarin2.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace NitrogenXamarin2
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
