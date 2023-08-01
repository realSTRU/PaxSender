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

public class EnvioPrint
{
    public static async Task ImprimirFacturaAsync(Envio envio)
    {
        string factura = GenerarContenidoFactura(envio); // Implementa la lógica para generar el contenido de la factura

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

    private static string GenerarContenidoFactura(Envio envio)
    {
        // Implementa la lógica para generar el contenido de la factura como una cadena de texto
        // Puedes utilizar un StringBuilder para facilitar la construcción del contenido
        // Por ejemplo:
        double libra = 0;
        StringBuilder contenido = new StringBuilder();
        contenido.AppendLine("=============================");
        contenido.AppendLine("        Factura");
        contenido.AppendLine("=============================");
        contenido.AppendLine($"Cliente:{envio.Destinatario_Referencia}");
        contenido.AppendLine($"Sucursal: {envio.SucursalId}");
        contenido.AppendLine($"Direccion: {envio.Destino}");
        contenido.AppendLine($"Fecha: {envio.Fecha.ToString()}");
        contenido.AppendLine($"Numero de factura:{envio.EnvioId.ToString()}");
        contenido.AppendLine($"Precio Libra: $295.00");
        contenido.AppendLine("=============================");
        contenido.AppendLine("Descripcion   Cantidad   Peso");
        foreach (var item in envio.DetalleEnvio)
        {
            contenido.AppendLine($"{item.ArticuloId}                {item.Cantidad}        {item.Peso}");
            libra = item.Cantidad * item.Peso;
        }
        contenido.AppendLine("=============================");
        contenido.AppendLine($"Peso total:            LB:{libra}");
        contenido.AppendLine($"Total:                   ${envio.Total_Envio}");
        contenido.AppendLine("=============================");
        contenido.AppendLine("Constancia de servicio de envio");
        return contenido.ToString();
    }
}
