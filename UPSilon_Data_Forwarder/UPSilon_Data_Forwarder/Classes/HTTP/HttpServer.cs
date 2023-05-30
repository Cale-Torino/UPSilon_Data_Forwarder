﻿using System.Net;
using System.Text;
using System.Diagnostics;

namespace UPSilon_Data_Forwarder.Classes.HTTP
{
    internal class HttpServer
    {
        public static HttpListener listener = new();
        public static string url = "http://localhost:8000/";
        public static string JsonData = string.Empty;
        public static int requestCount = 0;
        public static string pageData = "{0}";
        /*        public static string pageData =
                    "<!DOCTYPE>" +
                    "<html>" +
                    "  <head>" +
                    "    <title>HttpListener Example</title>" +
                    "  </head>" +
                    "  <body>" +
                    "    <p>Page Views: {0}</p>" +
                    "    <form method=\"post\" action=\"shutdown\">" +
                    "      <input type=\"submit\" value=\"Shutdown\" {1}>" +
                    "    </form>" +
                    "  </body>" +
                    "</html>";*/

        public static async Task HandleIncomingConnections()
        {
            bool runServer = true;

            // While a user hasn't visited the `shutdown` url, keep on handling requests
            while (runServer)
            {
                // Will wait here until we hear from a connection
                HttpListenerContext ctx = await listener.GetContextAsync();
                //HttpListenerContext ctx = listener.GetContext();

                // Peel out the requests and response objects
                HttpListenerRequest req = ctx.Request;
                HttpListenerResponse resp = ctx.Response;

                // Print out some info about the request
                Debug.WriteLine("Request #: {0}", ++requestCount);
                Debug.WriteLine(req.Url.ToString());
                Debug.WriteLine(req.HttpMethod);
                Debug.WriteLine(req.UserHostName);
                Debug.WriteLine(req.UserAgent);

                // If `shutdown` url requested w/ POST, then shutdown the server after serving the page
                if (req.HttpMethod == "POST" && req.Url.AbsolutePath == "/shutdown")
                {
                    Debug.WriteLine("Shutdown requested");
                    runServer = false;
                }

                // Make sure we don't increment the page views counter if `favicon.ico` is requested
                if (req.Url.AbsolutePath != "/favicon.ico")
                {
                    if (string.IsNullOrWhiteSpace(VarClass.JsonData))
                    {
                        JsonData = "{\"message\": \"no data\"}";
                    }
                    else
                    {
                        JsonData = VarClass.JsonData;
                    }

                }
                else
                {
                    JsonData = "{\"message\": \"path error\"}";
                }

                // Write the response info
                //string disableSubmit = !runServer ? "disabled" : "";
                //byte[] data = Encoding.UTF8.GetBytes(String.Format(pageData, pageViews, disableSubmit));
                byte[] data = Encoding.UTF8.GetBytes(string.Format(pageData, JsonData));
                resp.ContentType = "text/html";
                resp.ContentEncoding = Encoding.UTF8;
                resp.ContentLength64 = data.LongLength;

                // Write out to the response stream (asynchronously), then close it
                await resp.OutputStream.WriteAsync(data);
                resp.Close();
            }
        }


        /*        public static void Main(string[] args)
                {
                    // Create a Http server and start listening for incoming connections
                    listener = new HttpListener();
                    listener.Prefixes.Add(url);
                    listener.Start();
                    Console.WriteLine("Listening for connections on {0}", url);

                    // Handle requests
                    Task listenTask = HandleIncomingConnections();
                    listenTask.GetAwaiter().GetResult();

                    // Close the listener
                    listener.Close();
                }*/
    }
}
