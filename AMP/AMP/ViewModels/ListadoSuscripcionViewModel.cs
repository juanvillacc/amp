using AMP.Models;
using AMP.Services;
using AMP.Utilities;
using AMP.Views;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    internal class ListadoSuscripcionViewModel : BaseViewModel
    {
        INavigation Navigation;
        SuscripcionService Service = new SuscripcionService();
        public ICommand commandAgregar { get; set; }
        public ICommand commandSeleccionar { get; set; }

        public ListadoSuscripcionViewModel(INavigation navigation)
        {
            Navigation = navigation;
            commandAgregar = new Command(execute: async () =>
            {
                Constantes.SuscripcionSeleccionada = new Suscripcion();
                await AbrirDetalle();
            });

            commandSeleccionar = new Command(execute: async (id) =>
            {
                Constantes.SuscripcionSeleccionada = (Suscripcion)id;
                await AbrirDetalle();
            });
        }

        private async Task AbrirDetalle()
        {
            await Navigation.PushAsync(new DetalleSuscripcionPage());
        }

        private List<Suscripcion> _listaSucripcion;

        public List<Suscripcion> ListaSuscripcion
        {
            get { return _listaSucripcion; }
            set 
            {
                if (_listaSucripcion != value)
                {
                    _listaSucripcion = value;
                    OnPropertyChanged("ListaSuscripcion");
                }    
            }
        }

        public async void CargarSuscripciones()
        {
            var lista = await Service.ObtenerSuscripciones();
            ListaSuscripcion = lista;
        }
        private Suscripcion _suscripcionSeleccionada;

        public Suscripcion SuscripcionSeleccionada
        {
            get { return _suscripcionSeleccionada; }
            set {
                if (value != null)
                {
                    commandSeleccionar.Execute(value);
                }
            }
        }
    }
}
