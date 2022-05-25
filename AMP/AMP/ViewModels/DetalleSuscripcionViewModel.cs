using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    internal class DetalleSuscripcionViewModel : BaseViewModel
    {
        private int _id_usuario_suscripcion;

        public int id_usuario_suscripcion
        {
            get { return _id_usuario_suscripcion; }
            set {
                if (_id_usuario_suscripcion != value)
                {
                    OnPropertyChanged("id_usuario_suscripcion");
                    _id_usuario_suscripcion = value;
                }
                           
            }
        }


        private string _documento;

        public string documento
        {
            get { return _documento; }
            set
            {
                if (_documento != value)
                {
                    OnPropertyChanged("documento");
                    _documento = value;
                }


            }
        }

        private string _nombres;

        public string nombres
        {
            get { return _nombres; }
            set
            {
                if (_nombres != value)
                {
                    OnPropertyChanged("nombres");
                    _nombres = value;
                }
            }
        }

        private bool _estado;

        public bool estado
        {
            get { return _estado; }
            set
            {

                if (_estado != value)
                {
                    OnPropertyChanged("estado");
                    _estado = value;
                }


            }
        }

        public ICommand Guardar { get; set; }
        public ICommand Borrar { get; set; }
        public ICommand Cancelar { get; set; }


        INavigation Navigation;
        public DetalleSuscripcionViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Guardar = new Command(
                 execute: () =>
                 {
                     Cerrar();
                 }, 
                 canExecute: () =>
                 {
                     return !String.IsNullOrEmpty(documento) && !String.IsNullOrEmpty(nombres);
                 });

            Borrar = new Command(
                execute: () =>
                {
                    Cerrar();
                },
                canExecute: () =>
                {
                    return id_usuario_suscripcion > 0;
                });

            Cancelar = new Command(
                execute: () =>
                {
                    Cerrar();
                });
        }

        public async void Cerrar()
        {
            await Navigation.PopAsync();
        }

    }
}
