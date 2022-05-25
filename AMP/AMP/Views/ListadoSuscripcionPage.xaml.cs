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
    public partial class ListadoSuscripcionPage : ContentPage
    {
        public ListadoSuscripcionPage()
        {
            InitializeComponent();
            this.BindingContext = new ListadoSuscripcionViewModel(Navigation);
        }
    }
}