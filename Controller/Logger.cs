using System.Runtime.InteropServices;

namespace Controller
{
  internal class Logger
  {
    private const uint StdOutputHandle = 0xFFFFFFF5;
    [DllImport("kernel32.dll")]
    private static extern IntPtr GetStdHandle(UInt32 nStdHandle);
    [DllImport("kernel32.dll")]
    private static extern void SetStdHandle(UInt32 nStdHandle, IntPtr handle);
    [DllImport("kernel32")]
    private static extern bool AllocConsole();

    public enum TYPE : int
    {
      INFO = 0,
      WARNING = 1,
      ERROR = 2
    }

    public static void Initialize()
    {
      AllocConsole();
      var stdHandle = GetStdHandle(StdOutputHandle);
      var safeFileHandle = new Microsoft.Win32.SafeHandles.SafeFileHandle(stdHandle, true);
      var fileStream = new FileStream(safeFileHandle, FileAccess.Write);
      var standardOutput = new StreamWriter(fileStream, Console.Out.Encoding)
      {
        AutoFlush = true
      };
      Console.SetOut(standardOutput);
    }

    public static void Log(string message, TYPE type)
    {
      switch (type)
      {
        case TYPE.INFO:
          Console.ForegroundColor = ConsoleColor.Green;
          Console.WriteLine("[INFO] " + message);
          break;
        case TYPE.WARNING:
          Console.ForegroundColor = ConsoleColor.Yellow;
          Console.WriteLine("[WARNING] " + message);
          break;
        case TYPE.ERROR:
          Console.ForegroundColor = ConsoleColor.Red;
          Console.WriteLine("[ERROR] " + message);
          break;
      }
    }
  }
}
