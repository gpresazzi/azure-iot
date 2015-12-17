using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Common.Exceptions;


namespace IotubExample
{
    class Program
    {
        static RegistryManager registryManager;
        static string connectionString = "HostName=IotHubKalpa.azure-devices.net;SharedAccessKeyName=iothubowner;SharedAccessKey=1nwBlU4OFIy1tXYPUG2oS22OLLRoYIIwlF2LPfx2TrM=";

        static void Main(string[] args)
        {
            registryManager = RegistryManager.CreateFromConnectionString(connectionString);
            AddDeviceAsync().Wait();
            Console.ReadLine();
        }

        private async static Task AddDeviceAsync()
        {
            string deviceId = "LaptopDevice";
            Device device;
            try
            {
                device = await registryManager.AddDeviceAsync(new Device(deviceId));
            }
            catch (DeviceAlreadyExistsException)
            {
                device = new Device(deviceId);
            }
            Console.WriteLine("Generated device key: {0}", device.Authentication.SymmetricKey.PrimaryKey);
        }
    }
}
