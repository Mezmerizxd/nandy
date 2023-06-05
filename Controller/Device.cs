using System;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Controller
{
  internal class Device
  {
    public static SerialPort? device = null;

    public enum Commands : byte
    {
      GET_VERSION = 0x00,
      GET_STATUS = 0x01,
    }

    struct Command
    {
      public Commands command;
      public UInt32 lba;
    }

    public static void Initialize(string com)
    {
      if (device != null)
      {
        Logger.Log("Closing device", Logger.TYPE.INFO);
        device.Close();
      }

      try
      {
        device = new SerialPort(com, 266000);
        device.ReadTimeout = 500;
        device.WriteTimeout = 500;
        device.Handshake = Handshake.None;
        device.Parity = Parity.None;
        device.StopBits = StopBits.One;
        device.DataBits = 8;
        device.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

        Command cmd = new Command();
        cmd.command = Commands.GET_VERSION;
        cmd.lba = 0;

        SendCommand(cmd);

        var version = (int)ReceiveUInt32();
        Logger.Log("Device version: " + version, Logger.TYPE.INFO);
      }
      catch (Exception e)
      {
        Logger.Log("Failed to initialize device, " + e.ToString(), Logger.TYPE.ERROR);
        throw;
      }


      Logger.Log("Device initialized", Logger.TYPE.INFO);
    }

    public static void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
    {
      var sp = (SerialPort)sender;
      var indata = sp.ReadExisting();
      Logger.Log("Data received: " + indata, Logger.TYPE.INFO);
    }

    private static void SendCommand(Command cmd)
    {
      if (device != null)
      {
        device.Open();
        int size = Marshal.SizeOf(cmd);
        byte[] arr = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(cmd, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);
        device.Write(arr, 0, arr.Length);
        device.Close();
      }
      else
      {
        Logger.Log("No device initialized", Logger.TYPE.WARNING);
      }
    }

    private static UInt32 ReceiveUInt32()
    {
      if (device != null)
      {
        device.Open();
        byte[] rxbuffer = new byte[4];
        int got = 0;
        while (got < rxbuffer.Length)
          got += device.Read(rxbuffer, got, rxbuffer.Length - got);
        device.Close();
        return BitConverter.ToUInt32(rxbuffer, 0);
      }
      else
      {
        Logger.Log("No device initialized", Logger.TYPE.WARNING);
        return 0;
      }
    }
  }
}
