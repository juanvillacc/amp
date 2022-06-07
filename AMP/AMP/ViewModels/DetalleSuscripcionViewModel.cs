using AMP.Models;
using AMP.Services;
using AMP.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    internal class DetalleSuscripcionViewModel : BaseViewModel
    {
        private int _id_usuario_suscripcion;
        INavigation Navigation;

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
                    _documento = value;
                    OnPropertyChanged("documento");
                    ((Command)Guardar).ChangeCanExecute();
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
                    _nombres = value;
                    OnPropertyChanged("nombres");
                    ((Command)Guardar).ChangeCanExecute();
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
        SuscripcionService suscripcionService = new SuscripcionService();
        public DetalleSuscripcionViewModel(INavigation navigation)
        {
            Navigation = navigation;
            Guardar = new Command(
                 execute:async () =>
                 {
                     var suscripcion = new Suscripcion()
                     {
                         estado = this.estado,
                         nombres =  this.nombres,
                         documento = this.documento,
                         id_usuario_suscripcion = this.id_usuario_suscripcion,
                         id_ciudad = CiudadSeleccionada.id_ciudad
                     };
                     await suscripcionService.GuardarSuscripcion(suscripcion);
                     Cerrar();
                 }, 
                 canExecute: () =>
                 {
                     return !String.IsNullOrEmpty(documento) && !String.IsNullOrEmpty(nombres);
                 });

            Borrar = new Command(
                execute: async () =>
                {
                    await suscripcionService.EliminarSuscripcion(this.id_usuario_suscripcion);
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
            CargarDatos();
        }

        public async void Cerrar()
        {
            await Navigation.PopAsync();
        }
        private void CargarDatos()
        {
            var suscripcion = Constantes.SuscripcionSeleccionada;
            this.id_usuario_suscripcion = suscripcion.id_usuario_suscripcion;
            this.nombres = suscripcion.nombres;
            this.documento = suscripcion.documento;
            this.estado = suscripcion.estado;
            //this.CiudadSeleccionada = suscripcion.id_ciudad;
        }

        private List<Ciudad> _listaCiudades;
        public List<Ciudad> ListaCiudades
        {
            get { return _listaCiudades; }
            set
            {
                if (_listaCiudades != value)
                {
                    _listaCiudades = value;
                    OnPropertyChanged("ListaCiudades");
                }
            }
        }
        private Ciudad _ciudadSeleccionada;

        public Ciudad CiudadSeleccionada
        {
            get { return _ciudadSeleccionada; }
            set {
                if (((Ciudad)_ciudadSeleccionada)?.id_ciudad != ((Ciudad)value).id_ciudad)
                {
                    _ciudadSeleccionada = value;
                    OnPropertyChanged("CiudadSeleccionada");
                }
            }
        }


        public async void ObtenerCiudades()
        {
            CiudadServices CiudadService = new CiudadServices();
            var listadoCiudad = await CiudadService.ObtenerCiudades();
            ListaCiudades = listadoCiudad;
        }

    }
}
