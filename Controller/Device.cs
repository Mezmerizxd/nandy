using System;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Controller
{
  internal class Device
  {
    private static string? com = null;
    private static SerialPort? device = null;

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

    public static void Initialize(string comm)
    {
      com = comm.ToUpper();

      Logger.Log("Device initialized", Logger.TYPE.INFO);
      return;
    }

    private static SerialPort? Start()
    {
      Logger.Log("Creating SerialPort instance", Logger.TYPE.INFO);

      device = null;

      if (com == null)
      {
        Logger.Log("No COM port specified", Logger.TYPE.ERROR);
        return null;
      }

      try
      {
        device = new SerialPort(com, 266000);
        device.ReadTimeout = 5000;
        device.WriteTimeout = 5000;

        device.Open();

        return device;
      }
      catch (System.Exception)
      {
        Logger.Log("Failed to create SerialPort instance", Logger.TYPE.ERROR);
        throw;
      }

    }

    private static void Stop()
    {
      if (device != null)
      {
        Logger.Log("Closing device", Logger.TYPE.INFO);
        device.Close();
      }
    }

    public static void Use(Action<SerialPort> func)
    {
      SerialPort? d = Start();
      if (d == null)
      {
        Logger.Log("Failed to start device", Logger.TYPE.ERROR);
        return;
      }

      try
      {
        func(d);
      }
      catch (System.Exception e)
      {
        Logger.Log("Failed to use device, " + e.ToString(), Logger.TYPE.ERROR);
        throw;
      }
      finally
      {
        Stop();
      }
    }

    private static void SendCommand(SerialPort d, Command cmd)
    {
      if (d == null)
      {
        Logger.Log("Failed to send command, device not initialized", Logger.TYPE.ERROR);
        return;
      }

      try
      {
        int size = Marshal.SizeOf(cmd);
        byte[] arr = new byte[size];
        IntPtr ptr = Marshal.AllocHGlobal(size);
        Marshal.StructureToPtr(cmd, ptr, true);
        Marshal.Copy(ptr, arr, 0, size);
        Marshal.FreeHGlobal(ptr);
        d.Write(arr, 0, arr.Length);
      }
      catch (System.Exception e)
      {
        Logger.Log("Failed to send command, " + e.ToString(), Logger.TYPE.ERROR);
        throw;
      }
    }

    private static UInt32 ReceiveUInt32(SerialPort d)
    {
      if (d == null)
      {
        Logger.Log("Failed to send command, device not initialized", Logger.TYPE.ERROR);
        return 0;
      }
      try
      {
        byte[] rxbuffer = new byte[4];
        int got = 0;
        while (got < rxbuffer.Length)
          got += d.Read(rxbuffer, got, rxbuffer.Length - got);

        if (got != rxbuffer.Length)
        {
          Logger.Log("Failed to receive data, got " + got + " bytes, expected " + rxbuffer.Length + " bytes", Logger.TYPE.ERROR);
          throw new System.Exception("Failed to receive data");
        }

        return BitConverter.ToUInt32(rxbuffer, 0);
      }
      catch (System.Exception e)
      {
        Logger.Log("Failed to receive data, " + e.ToString(), Logger.TYPE.ERROR);
        throw;
      }
    }

    private static float ReceiveFloat(SerialPort d)
    {
      if (d == null)
      {
        Logger.Log("Failed to send command, device not initialized", Logger.TYPE.ERROR);
        return 0;
      }
      try
      {
        byte[] rxbuffer = new byte[4];
        int got = 0;
        while (got < rxbuffer.Length)
          got += d.Read(rxbuffer, got, rxbuffer.Length - got);

        if (got != rxbuffer.Length)
        {
          Logger.Log("Failed to receive data, got " + got + " bytes, expected " + rxbuffer.Length + " bytes", Logger.TYPE.ERROR);
          throw new System.Exception("Failed to receive data");
        }

        return BitConverter.ToSingle(rxbuffer, 0);
      }
      catch (System.Exception e)
      {
        Logger.Log("Failed to receive data, " + e.ToString(), Logger.TYPE.ERROR);
        throw;
      }
    }

    public static string? GetVersion(SerialPort d)
    {
      Command cmd = new Command();
      cmd.command = Commands.GET_VERSION;
      cmd.lba = 0;

      SendCommand(d, cmd);

      var version = (int)ReceiveUInt32(d);
      if (version == 0)
      {
        return null;
      }

      return version.ToString();
    }
  }
}
