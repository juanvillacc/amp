using AMP.Services;
using AMP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        INavigation Navigation;
        public LoginViewModel(INavigation navigation)
        {
            IniciarSesion = new Command(
                execute: async () =>
                {
                    await ValidarUsuario();

                }, canExecute: () =>
                {
                    return !string.IsNullOrEmpty(Usuario) && !string.IsNullOrEmpty(Contrasena);
                });
            Navigation = navigation;
        }

        public async Task ValidarUsuario()
        {
            UsuarioService usuario = new UsuarioService();

            var validacion = await usuario.ValidarUsuarioAsync(Usuario, Contrasena);
            if (validacion)
            {
                await Navigation.PushAsync(new ListadoSuscripcionPage());
            }
            else
            {
                Mensaje = "No se pudo acceder a la plataforma";
            }
        }

        private String _usuario;

        public String Usuario
        {
            get { return _usuario; }
            set
            {
                if (_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged("Usuario");
                    ((Command)IniciarSesion).ChangeCanExecute();
                }

            }
        }

        private String _contrasena;

        public String Contrasena
        {
            get { return _contrasena; }
            set
            {
                if (_contrasena != value)
                {
                    _contrasena = value;
                    OnPropertyChanged("Contrasena");
                    ((Command)IniciarSesion).ChangeCanExecute();
                }

            }
        }

        private string _mensaje;

        public string Mensaje
        {
            get { return _mensaje; }
            set
            {
                if (_mensaje != value)
                {
                    _mensaje = value;
                    OnPropertyChanged("Mensaje");
                }
            }
        }


        public ICommand IniciarSesion { get; set; }
    }
}
