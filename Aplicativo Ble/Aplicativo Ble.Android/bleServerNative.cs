using System;
using Android.App;
using Android.Bluetooth;
using Android.Bluetooth.LE;
using Android.Content;

[assembly: Xamarin.Forms.Dependency(typeof(Aplicativo_Ble.Droid.bleServerNative))]
namespace Aplicativo_Ble.Droid
{
    public class bleServerNative : InterfaceBLE
    {
        public void getBle(String usuario)
        {
            Context actvity = Application.Context;
            BluetoothManager bluetooth = (BluetoothManager)actvity.GetSystemService(Context.BluetoothService);
            BluetoothAdapter bluetoothAdapter = bluetooth.Adapter;
            if (bluetoothAdapter.IsEnabled)
            {
                bluetoothAdapter.SetName(usuario);
                BluetoothLeAdvertiser bluetoothLeAdvertiser = bluetoothAdapter.BluetoothLeAdvertiser;
                AdvertiseSettings settings = new AdvertiseSettings.Builder()
                    .SetAdvertiseMode(AdvertiseMode.LowLatency).SetTxPowerLevel(AdvertiseTx.PowerHigh).SetConnectable(true).Build();

                var builder = new AdvertiseSettings.Builder();
                builder.SetAdvertiseMode(AdvertiseMode.LowLatency);
                builder.SetConnectable(true);
                builder.SetTimeout(0);
                builder.SetTxPowerLevel(AdvertiseTx.PowerUltraLow);

                AdvertiseData.Builder dataBuilder = new AdvertiseData.Builder();
                dataBuilder.SetIncludeDeviceName(true);
                dataBuilder.SetIncludeTxPowerLevel(true);

                bluetoothLeAdvertiser.StartAdvertising(builder.Build(), dataBuilder.Build(), new BleAdvertiseCallback());
                Android.Widget.Toast.MakeText(Application.Context, "Registro de presença automático iniciado.", Android.Widget.ToastLength.Long).Show();
            }
            else
            {
                Android.Widget.Toast.MakeText(Application.Context, "Por gentileza, o Bluetooth deve estar ligado!", Android.Widget.ToastLength.Long).Show();
            }
        }



        public class BleAdvertiseCallback : AdvertiseCallback
        {
            public override void OnStartFailure(AdvertiseFailure errorCode)
            {
                Console.WriteLine("Adevertise start failure {0}", errorCode);
                base.OnStartFailure(errorCode);
            }

            public override void OnStartSuccess(AdvertiseSettings settingsInEffect)
            {
                Console.WriteLine("Adevertise start success {0}", settingsInEffect.Mode);
                base.OnStartSuccess(settingsInEffect);
            }
        }
    }
}