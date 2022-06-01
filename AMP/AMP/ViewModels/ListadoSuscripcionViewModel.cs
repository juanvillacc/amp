using AMP.Models;
using AMP.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    internal class ListadoSuscripcionViewModel : BaseViewModel
    {
        INavigation Navigation;
        public ListadoSuscripcionViewModel(INavigation navigation)
        {

            Navigation = navigation;
            SuscripcionService Service = new SuscripcionService();

            var lista = await Service.ObtenerSuscripciones();
            ListaSuscripcion =  lista;
        }

        private List<Suscripcion> _listaSucripcion;

        public List<Suscripcion> ListaSuscripcion
        {
            get { return _listaSucripcion; }
            set 
            {
                if (_listaSucripcion != value)
                {
                    OnPropertyChanged("ListaSuscripcion");
                    _listaSucripcion = value;
                }    
            }
        }



        

    }
}
