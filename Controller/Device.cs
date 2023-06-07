using System;
using System.IO.Ports;
using System.Runtime.InteropServices;

namespace Controller
{
  internal class Device
  {
    private static string? com = null;
    public static bool IsInUse = false;

    public enum Commands : byte
    {
      GET_VERSION = 0x00,
      GET_STATUS = 0x01,
    }

    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Command
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

    public static SerialPort? Open()
    {
      if (com == null)
      {
        Logger.Log("Device not initialized", Logger.TYPE.ERROR);
        MessageBox.Show("No COM Device Selected!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return null;
      }

      if (IsInUse)
      {
        Logger.Log("Device already in use", Logger.TYPE.ERROR);
        return null;
      }

      SerialPort s = new SerialPort();

      try
      {
        s.PortName = com;
        s.ReadTimeout = 5000;
        s.WriteTimeout = 5000;

        s.Open();

        IsInUse = true;
      }
      catch (Exception ex)
      {
        Logger.Log("Failed to open device, " + ex.ToString(), Logger.TYPE.ERROR);
      }

      return s;
    }

    public static void Close(SerialPort serial)
    {
      try
      {
        serial.Close();
      }
      catch (Exception ex)
      {
        Logger.Log("Failed to close device, " + ex.ToString(), Logger.TYPE.ERROR);
      }

      IsInUse = false;
    }

    public static void Use(Action<SerialPort> func)
    {

      SerialPort? s = Device.Open();

      if (s == null)
      {
        Logger.Log("Failed to start device", Logger.TYPE.ERROR);
        return;
      }

      try
      {
        func(s);
      }
      catch (System.Exception e)
      {
        Logger.Log("Failed to use device, " + e.ToString(), Logger.TYPE.ERROR);
        Device.Close(s);
        throw;
      }
      finally
      {
        Device.Close(s);
      }
    }

    public static void SendCommand(SerialPort d, Command cmd)
    {
      if (d == null || !d.IsOpen)
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

    public static UInt32 ReceiveUInt32(SerialPort d)
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

    public static float ReceiveFloat(SerialPort d)
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
  }
}
