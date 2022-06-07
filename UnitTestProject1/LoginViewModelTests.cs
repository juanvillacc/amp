using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using AMP.ViewModels;
using Xamarin.Forms;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class LoginViewModelTests
    {
        [TestInitialize]
        public void Setup()
        {

        }
        [TestMethod]
        public async  Task LoginFallido()
        {
            Mock<INavigation> navigation = new Mock<INavigation>(); 
            // arrange: Organizar datos
            LoginViewModel viewModel = new LoginViewModel(navigation.Object); // mock
            viewModel.Contrasena = "Demo";
            viewModel.Usuario = "1161616";
            var mensajeEsperado = "No se pudo acceder a la plataforma";

            // act : Ejecutamos la prueba

            await Task.Run(() => viewModel.ValidarUsuario());
            // Compare : Evaluamos lo que nos dio
            Assert.AreEqual(mensajeEsperado, viewModel.Mensaje);
        }
        /*[TestMethod]
        public void LoginBueno()
        {
            Mock<INavigation> navigation = new Mock<INavigation>();
            // arrange: Organizar datos
            LoginViewModel viewModel = new LoginViewModel(navigation.Object); // mock
            viewModel.Contrasena = "Demo";
            viewModel.Usuario = "Pa$$word";
            var mensajeEsperado = "";

            // act : Ejecutamos la prueba
            ((Command)viewModel.IniciarSesion).Execute(null);
            // Compare : Evaluamos lo que nos dio
            Assert.AreEqual(mensajeEsperado, viewModel.Mensaje);
        }*/
    }
}
