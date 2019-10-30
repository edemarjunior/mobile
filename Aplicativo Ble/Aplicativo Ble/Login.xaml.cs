using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Aplicativo_Ble
{ 
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
          
            // Define o binding context
            this.BindingContext = this;
            // Define a propriedade
            this.IsBusy = false;
            //Define o evento Click do botão de login
            BtnLogin.Clicked += BtnLogin_Clicked;
        }
        //define a propriedade IsBusy como true
        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            //ativa o ActivityIndicator
            this.IsBusy = true;
            Connection connection = new Connection();

            var retorno = await connection.getToken(usuario.Text, senha.Text);
            //retorno.Contains("");
           // if(retorno == "")
           // {
               // await DisplayAlert("Erro", "Usuário ou senha inválidos, tente novamente", "OK");
               // this.IsBusy = false;
           // }
           // else  
           // {
               // if (retorno == "405")
                //{
                    
                //    await DisplayAlert("Erro", "Sem conexão com servidor", "OK");
                //    this.IsBusy = false;
                //}
                //else
                //{
                    Application.Current.MainPage = new NavigationPage(new MainPage(usuario.Text)); 
                //}
            //}

        }

    }
}