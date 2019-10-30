
using Plugin.BluetoothLE;
using Plugin.BluetoothLE.Server;
using System;
using System.Collections.Generic;
//using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Aplicativo_Ble
{
    public partial class MainPage : ContentPage
    {
        String usuario;

        public MainPage(String usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void searchDevice(object sender, EventArgs e)
        {           
            try
            {

                if (Device.RuntimePlatform == Device.iOS)
                {
                    DisplayAlert("Atenção", "Iniciado processo de presença!", "OK");
                    CrossBleAdapter.Current.Advertiser.Start(new AdvertisementData
                    {
                        LocalName = this.usuario,
                        ServiceUuids = new List<Guid>() 
                    });
                }
                else if (Device.RuntimePlatform == Device.Android)
                {
                    var servBLE = DependencyService.Get<InterfaceBLE>();
                    servBLE.getBle(this.usuario);
                }
                
            }
            catch (Exception)
            {
                DisplayAlert("Erro", "Necessário ativar o Bluethooth", "OK");
            }
        }

    }
}
