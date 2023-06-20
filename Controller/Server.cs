using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Controller
{
  internal class Server
  {
    public static HttpListener? listener;
    public static string url = "http://localhost:8000/";
    public static string basicHtml =
    "<!DOCTYPE>" +
    "<html>" +
    "  <head>" +
    "    <title>Nandy</title>" +
    "  </head>" +
    "  <body>" +
    "    <p>Local http server for Nandy</p>" +
    "  </body>" +
    "</html>";

    public static void Start()
    {
      Logger.Log("Starting server", Logger.TYPE.INFO);

      listener = new HttpListener();
      listener.Prefixes.Add(url);
      listener.Start();

      Task TListen = Listen();
      TListen.GetAwaiter().GetResult();

      listener.Close();
    }

    public static void Stop()
    {
      Logger.Log("Stopping server", Logger.TYPE.INFO);
    }

    public static async Task Listen()
    {
      if (listener == null)
      {
        Logger.Log("Server is not running", Logger.TYPE.ERROR);
        return;
      }

      while (listener.IsListening)
      {
        HttpListenerContext context = await listener.GetContextAsync();
        HttpListenerRequest request = context.Request;
        HttpListenerResponse response = context.Response;

        string responseString = string.Format(basicHtml, 0, "");
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        response.ContentType = "text/html";
        response.ContentEncoding = Encoding.UTF8;
        System.IO.Stream output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
        output.Close();
      }
    }
  }
}
