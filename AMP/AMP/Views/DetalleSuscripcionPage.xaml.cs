using AMP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AMP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetalleSuscripcionPage : ContentPage
    {
        DetalleSuscripcionViewModel viewModel;
        public DetalleSuscripcionPage()
        {
            InitializeComponent();
            viewModel = new DetalleSuscripcionViewModel(Navigation);
            this.BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ObtenerCiudades();
        }
    }
}