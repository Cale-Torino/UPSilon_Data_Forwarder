using System.Net;
using System.Net.Sockets;

namespace UPSilon_Data_Forwarder.Classes
{
    internal class VarClass
    {
        public static bool Listen { get; set; } = false;
        public static string SMSdata { get; set; } = string.Empty;
        public static string UPSdata { get; set; } = string.Empty;
        public static string JsonData { get; set; } = string.Empty;
        public static string Salt_Secret { get; set; } = "FJ2zjPjDpNZTYIITb2uCXe_MpF8bPpLaSIIztbTG";
        //public static TcpListener ListenerSMS { get; set; } = new(IPAddress.Parse("127.0.0.1"), 8652);
        //public static TcpListener ListenerSMS { get; set; }
        //public static TcpClient ClientUPS { get; set; } = new("127.0.0.1", 2570);
        //public static TcpClient ClientUPS { get; set; } = new TcpClient();
        public static TcpListener ListenerSMS { get; set; } = new TcpListener(IPAddress.Parse("127.0.0.1"), 8652);
    }
}
