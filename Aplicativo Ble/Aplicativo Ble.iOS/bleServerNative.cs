using CoreBluetooth;
using CoreFoundation;
using Foundation;
using System;


[assembly: Xamarin.Forms.Dependency(typeof(Aplicativo_Ble.iOS.AppDelegate))]
namespace Aplicativo_Ble.iOS
{
    public class bleServerNative : InterfaceBLE
    {
        CBPeripheralManager peripheralManager;
        private readonly CBCentralManager manager = new CBCentralManager();
        public void getBle(String usuario)
        {
            string dataServiceUUIDsKey = "71DA3FD1-7E10-41C1-B16F-4430B5060000";
            string customBeaconServiceUUIDsKey = "71DA3FD1-7E10-41C1-B16F-4430B5060001";
            string customBeaconCharacteristicUUIDKey = "71DA3FD1-7E10-41C1-B16F-4430B5060002";
            string identifier = "71DA3FD1-7E10-41C1-B16F-4430B5060003";

            
            peripheralManager = new CBPeripheralManager();

            var customBeaconServiceUUID = CBUUID.FromString(customBeaconServiceUUIDsKey);
            var customBeaconCharacteristicUUID = CBUUID.FromString(customBeaconCharacteristicUUIDKey);

            var service = new CBMutableService(customBeaconServiceUUID, true);
            var dataUUID = NSData.FromString(identifier, NSStringEncoding.UTF8);

            var characteristic = new CBMutableCharacteristic(
                customBeaconCharacteristicUUID,
                CBCharacteristicProperties.Read,
                dataUUID,
                CBAttributePermissions.Readable);
            service.Characteristics = new CBCharacteristic[] { characteristic };
            peripheralManager.AddService(service);

            var localName = new NSString(usuario);

            var advertisingData = new NSDictionary(
                CBAdvertisement.DataLocalNameKey,
                localName,
                CBAdvertisement.IsConnectable,
                CBAdvertisement.DataManufacturerDataKey,
                CBUUID.FromString(dataServiceUUIDsKey),
                CBAdvertisement.DataServiceUUIDsKey,
                CBUUID.FromString(dataServiceUUIDsKey));

            peripheralManager.StartAdvertising(advertisingData);

        }

    }
}