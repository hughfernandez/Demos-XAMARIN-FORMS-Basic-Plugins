# Demos-XAMARIN-FORMS-Basic-Plugins

Para ejecutar cada demo se debe de cambiar el inicio de la pagina en el archivo App.xaml.cs en el proyecto base de XAMARIN FORMS

Ejemplo:

using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace QRReaderDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new VibratePage(); //AQUI ES DONDE TIENES QUE COLOCAR LA PAGINA A MOSTRAR EN LOS DEMOS
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
