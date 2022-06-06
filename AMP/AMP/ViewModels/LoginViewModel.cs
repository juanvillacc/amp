using AMP.Services;
using AMP.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace AMP.ViewModels
{
    internal class LoginViewModel : BaseViewModel
    {
        INavigation Navigation;
        public LoginViewModel(INavigation navigation)
        {
            IniciarSesion = new Command(
                execute: async () =>
                {
                    UsuarioService usuario = new UsuarioService();

                    var validacion = await usuario.ValidarUsuarioAsync(Usuario, Contrasena);
                    if (validacion)
                    {
                        await Navigation.PushAsync(new ListadoSuscripcionPage());
                    }


                }, canExecute: () =>
                {
                    return !String.IsNullOrEmpty(Usuario) && !String.IsNullOrEmpty(Contrasena);
                });
            Navigation = navigation;
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



        public ICommand IniciarSesion { get; set; }
    }
}
