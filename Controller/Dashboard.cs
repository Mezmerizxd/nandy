using System.IO.Ports;

namespace Controller
{
  public partial class Dashboard : Form
  {
    public string? SelectedSerialDevice = null;

    public Dashboard()
    {
      InitializeComponent();
    }

    private void FindNandy_Click(object sender, EventArgs e)
    {
      SerialPortDevices.Items.Clear();

      var ports = SerialPort.GetPortNames();
      foreach (var port in ports)
      {
        Logger.Log("Found port: " + port, Logger.TYPE.INFO);
        SerialPortDevices.Items.Add(port);
      }
    }

    private void SerialPortDevices_SelectedIndexChanged(object sender, EventArgs e)
    {
      SelectedSerialDevice = SerialPortDevices.SelectedItem.ToString();
      Logger.Log("Selected port: " + SelectedSerialDevice, Logger.TYPE.INFO);

      if (SelectedSerialDevice != null)
      {
        Device.Initialize(SelectedSerialDevice);
      }
      else
      {
        Logger.Log("No port selected", Logger.TYPE.WARNING);
      }

      Device.Use((d) =>
      {
        var version = Device.GetVersion(d);
        Logger.Log("Device version: " + version, Logger.TYPE.INFO);
      });
    }
  }
}