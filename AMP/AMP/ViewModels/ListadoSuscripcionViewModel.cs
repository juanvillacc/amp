using AMP.Models;
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
