using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Aplicativo_Ble
{
    public partial class App : Application
    {
        public App()
        {
            this.
            InitializeComponent();
            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
(sender, cert, chain, sslPolicyErrors) =>
{
    if (cert != null) System.Diagnostics.Debug.WriteLine(cert);
    return true;
};

            MainPage = new Login();
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
