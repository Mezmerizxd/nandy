using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  internal class Sockets
  {
    public static void Start()
    {
      Logger.Log("Starting sockets", Logger.TYPE.INFO);
    }

    public static void Stop()
    {
      Logger.Log("Stopping sockets", Logger.TYPE.INFO);
    }
  }
}
