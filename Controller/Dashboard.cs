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

    private void UpdateConnectionStatus(bool connected)
    {
      if (connected)
      {

      }
      else
      {

      }
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
        Connect.Enabled = true;
      }
      else
      {
        Logger.Log("No port selected", Logger.TYPE.WARNING);
        Connect.Enabled = false;
      }
    }

    private void Connect_Click(object sender, EventArgs e)
    {
      Device.Use((s) =>
      {
        Device.Command c = new()
        {
          command = Device.Commands.GET_VERSION,
          lba = 0
        };

        Device.SendCommand(s, c);

        var version = (int)Device.ReceiveUInt32(s);

        if (version > 0)
        {
          Logger.Log("Device version: " + version.ToString(), Logger.TYPE.INFO);
          MessageBox.Show("Device successfully connected", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
          Version.Text = "Version: " + version.ToString();

          UpdateConnectionStatus(true);
        }
        else
        {
          UpdateConnectionStatus(false);
        }
      });
    }

    private void Debug_ToggleBlink_Click(object sender, EventArgs e)
    {
      Device.Use((s) =>
      {
        Device.Command c = new()
        {
          command = Device.Commands.DEBUG_TOGGLE_BLINK,
          lba = 0
        };

        Device.SendCommand(s, c);

        var mode = (bool)Device.ReceiveBool(s);

        Logger.Log("Debug Toggle Blink: " + mode.ToString(), Logger.TYPE.INFO);
      });
    }
  }
}