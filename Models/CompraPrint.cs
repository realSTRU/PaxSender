using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing.Printing;
using System.Drawing;
using System.Text;
using System.IO;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;
using System.Threading.Tasks;
using PaxSender.BLL;

public class CompraPrint
{
    public static async Task ImprimirFacturaAsync(Venta compra, string Cliente)
    {
        string factura = GenerarContenidoFactura(compra, Cliente); // Implementa la lógica para generar el contenido de la factura

        // Conectarse a la impresora a través de Bluetooth
        BluetoothDeviceInfo printerDevice = await FindBluetoothPrinterAsync("MTP-2"); // Reemplaza "NombreDeTuImpresora" con el nombre real de tu impresora
        if (printerDevice != null)
        {
            using BluetoothClient bluetoothClient = new BluetoothClient();
            await Task.Run(() => bluetoothClient.Connect(printerDevice.DeviceAddress, BluetoothService.SerialPort));
            if (bluetoothClient.Connected)
            {
                await SendDataToBluetoothPrinterAsync(bluetoothClient.GetStream(), factura);
            }
        }
    }

    private static async Task<BluetoothDeviceInfo> FindBluetoothPrinterAsync(string printerName)
    {
        BluetoothClient bluetoothClient = new BluetoothClient();
        BluetoothDeviceInfo[] devices = await Task.Run(() => bluetoothClient.DiscoverDevices());

        foreach (BluetoothDeviceInfo device in devices)
        {
            if (device.DeviceName == printerName)
            {
                return device;
            }
        }

        return null;
    }

    private static async Task SendDataToBluetoothPrinterAsync(Stream stream, string content)
    {
        // Convertir el contenido de la factura en bytes para enviar a la impresora
        byte[] data = Encoding.ASCII.GetBytes(content);

        // Enviar los datos a través de Bluetooth
        await stream.WriteAsync(data, 0, data.Length);
    }

    private static string GenerarContenidoFactura(Venta compra,string Cliente)
    {
        // Implementa la lógica para generar el contenido de la factura como una cadena de texto
        // Puedes utilizar un StringBuilder para facilitar la construcción del contenido
        // Por ejemplo:
        double libra = 0;
        StringBuilder contenido = new StringBuilder();
        contenido.AppendLine("=============================");
        contenido.AppendLine("        Factura");
        contenido.AppendLine("=============================");
        contenido.AppendLine($"Cliente:{Cliente}");
        contenido.AppendLine($"Fecha: {compra.Fecha.ToString()}");
        contenido.AppendLine($"Numero de factura:{compra.VentaId.ToString()}");
        contenido.AppendLine("=============================");
        contenido.AppendLine("Descripcion   Cantidad   Precio");
        
        foreach (var item in compra.DetalleVenta)
        {
            contenido.AppendLine($"{item.ArticuloId}               {item.Cantidad}        {item.Precio}");
        }
        contenido.AppendLine("=============================");
        contenido.AppendLine($"Total:                   ${compra.Total}");
        contenido.AppendLine("=============================");
        contenido.AppendLine("Gracias por su compra!");
        contenido.AppendLine("Vuelva pronto");
        return contenido.ToString();
    }
}
