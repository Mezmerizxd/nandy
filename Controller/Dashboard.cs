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
    }

    private void GetVersion_Click(object sender, EventArgs e)
    {
      Device.Use((s) =>
      {
        Device.Command c = new Device.Command();
        c.command = Device.Commands.GET_VERSION;
        c.lba = 0;

        Device.SendCommand(s, c);

        var version = (int)Device.ReceiveUInt32(s);
        Logger.Log("Device version: " + version.ToString(), Logger.TYPE.INFO);
        MessageBox.Show("Device version: " + version.ToString(), "Version", MessageBoxButtons.OK, MessageBoxIcon.Information);
      });
    }
  }
}