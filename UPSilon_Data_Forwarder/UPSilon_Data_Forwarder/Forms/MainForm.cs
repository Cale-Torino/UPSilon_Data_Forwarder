using System.ComponentModel;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Text.Json;
using UPSilon_Data_Forwarder.Classes.Json;
using UPSilon_Data_Forwarder.Classes;
using UPSilon_Data_Forwarder.Classes.Logs;
using UPSilon_Data_Forwarder.Classes.HTTP;

namespace UPSilon_Data_Forwarder
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form f = new AboutForm())
            {
                f.ShowDialog();
                f.Activate();
            }
        }

        private void telegramToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form f = new TelegramForm())
            {
                f.ShowDialog();
                f.Activate();
            }
        }

        private void hTTPAPIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form f = new HTTPAPIForm())
            {
                f.ShowDialog();
                f.Activate();
            }
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SMSListner();
            UPSClient();
            Checkhttp();
        }

        private void Checkhttp()
        {
            if (Properties.Settings.Default.HTTP_Checkbox)
            {
                Start_Server();
            }
        }
        private async void Start_Server()
        {
            if (HttpServer.listener.IsListening)
            {
                MessageBox.Show("HttpListener Already Listining", "HttpListener", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine($" *** HttpListener Already Listining [MainForm] ***");
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Url))
                {
                    MessageBox.Show("Please Fill In Your Url Endpoint", "No Url Endpoint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoggerClass.WriteLine($" *** Please Fill In Your Url Endpoint [MainForm] ***");
                }
                else
                {
                    //SimpleHTTPServer server = new SimpleHTTPServer(@"C:\Users\User501\source\repos\UPSilon_Data_Forwarder\UPSilon_Data_Forwarder\bin\Debug\net6.0-windows\index.html",8000);
                    string url = EncryptionClass.ToInsecureString(EncryptionClass.DecryptString(Properties.Settings.Default.Url));
                    HttpServer.listener = new HttpListener();
                    HttpServer.listener.Prefixes.Add(url);
                    HttpServer.listener.Start();
                    LogsTextBox.AppendText($"Listening for connections on {url}{Environment.NewLine}");
                    LoggerClass.WriteLine($" *** Listening for connections on {url} [MainForm] ***");

                    // Handle requests
                    await HttpServer.HandleIncomingConnections();
                    //listenTask.GetAwaiter().GetResult();

                    // Close the listener
                    //HttpServer.listener.Close();
                }
            }

        }
        private void UPSClient()
        {
            if (ClientWorker.IsBusy)
            {
                //MessageBox.Show("Client Is Busy");
                LogsTextBox.AppendText($"[{DateTime.Now}] : Client Is Busy\n");
                LoggerClass.WriteLine($" *** Client Is Busy [MainForm] ***");
            }
            else
            {
                LogsTextBox.AppendText($"[{DateTime.Now}] : Client Connecting...\n");
                LoggerClass.WriteLine($" *** Client Connecting... [MainForm] ***");
                ClientWorker.RunWorkerAsync();
            }
        }

        private void SMSListner()
        {
            try
            {
                if (VarClass.ListenerSMS.Server.IsBound)
                {
                    MessageBox.Show("Server Already Listning");
                    LoggerClass.WriteLine($" *** Server Already Listning [MainForm] ***");
                    LogsTextBox.AppendText($"[{DateTime.Now}] : Server Already Listning\n");
                }
                else
                {
                    LogsTextBox.AppendText($"[{DateTime.Now}] : 8652 Start Listning...\n");
                    LoggerClass.WriteLine($" *** 8652 Start Listning... [MainForm] ***");
                    VarClass.Listen = true;
                    //VarClass.ListenerSMS = new(new IPEndPoint(IPAddress.Any, 8652));
                    VarClass.ListenerSMS = new(IPAddress.Parse("127.0.0.1"), 8652);
                    VarClass.ListenerSMS.Start();
                    MainSMSListner();
                }
            }
            catch (Exception ex)
            {
                LogsTextBox.AppendText($"Error: ({ex.Message}\n");
                LoggerClass.WriteLine($" *** Error: {ex.Message} [MainForm] ***");
                VarClass.ListenerSMS.Stop();
                return;
            }
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (VarClass.ListenerSMS.Server.IsBound)
                {
                    LogsTextBox.AppendText($"[{DateTime.Now}] : Stop Listning!\n");
                    LoggerClass.WriteLine($" *** Stop Listning! [MainForm] ***");
                    VarClass.Listen = false;
                    VarClass.ListenerSMS.Stop();
                    //VarClass.ClientUPS.Close();
                    //VarClass.ListenerSMS = new(new IPEndPoint(IPAddress.Any, 2570));
                    //VarClass.ListenerSMS.Start();
                    //MainS();
                }
                else
                {
                    MessageBox.Show("Server Already Stopped");
                    LoggerClass.WriteLine($" *** Server Already Stopped [MainForm] ***");
                    LogsTextBox.AppendText($"[{DateTime.Now}] : Server Already Stopped\n");
                }
            }
            catch (Exception ex)
            {
                LoggerClass.WriteLine($" *** Error: {ex.Message} [MainForm] ***");
                LogsTextBox.AppendText($"Error: ({ex.Message}\n");
                return;
            }

        }


        private async Task HandleClient(TcpClient clt)
        {
            using NetworkStream ns = clt.GetStream();
            ns.ReadTimeout = 10000;
            using StreamReader sr = new(ns);
            string msg = await sr.ReadToEndAsync();
            ns.WriteByte(0);
            ns.Flush();
            //VarClass.UPSdata = msg;
            LogsTextBox.AppendText($"[{DateTime.Now}] : Data ({msg.Length} bytes):\n{msg}\n");
        }

        public async void MainSMSListner()
        {
            while (VarClass.Listen)
            {
                if (VarClass.ListenerSMS.Pending())
                {
                    await HandleClient(await VarClass.ListenerSMS.AcceptTcpClientAsync());
                    //LogsTextBox.AppendText($"Received new message ({VarClass.UPSdata}");
                }
                else
                {
                    await Task.Delay(100); //<--- timeout
                }
            }
        }

        private async void SendToTelegram()
        {
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri($"https://api.telegram.org/bot{Properties.Settings.Default.Token}/sendMessage?chat_id=-{Properties.Settings.Default.Chat_ID}&text={VarClass.JsonData}")))
                    {
                        using (HttpContent content = response.Content)
                        {
                            //Read the result and display in Textbox
                            string result = await content.ReadAsStringAsync();//Result string JSON
                            string reasonPhrase = response.ReasonPhrase;//Reason OK, FAIL etc.
                            LogsTextBox.AppendText(result + Environment.NewLine);
                            LogsTextBox.AppendText(reasonPhrase + Environment.NewLine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not send via Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [MainForm] ***");
                    return;
                }
            }
        }

        public static string CleanString(string dirtyString)
        {
            HashSet<char> removeChars = new HashSet<char>("?&^$#@!()+-,:;<>’\'-_*");
            StringBuilder result = new StringBuilder(dirtyString.Length);
            foreach (char c in dirtyString)
            {
                if (!removeChars.Contains(c)) // prevent dirty chars
                {
                    result.Append(c);
                }
            }
            return result.ToString().Replace("\0", string.Empty);
        }

        private void JsonForm(float InVoltage, float FaultVoltage, float OutputVoltage, int Current, float Frequency, float BatteryVoltage, string Temperature, string UPSBinary)
        {
            SerializeClass tj = new();
            string result = JsonSerializer.Serialize(tj.Serialized(InVoltage, FaultVoltage, OutputVoltage, Current, Frequency, BatteryVoltage, Temperature, UPSBinary));
            //BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : {result}{Environment.NewLine}")));
            VarClass.JsonData = result;
            if (Properties.Settings.Default.Telegram_Checkbox)
            {
                //send to telegram
                SendToTelegram();
            }
            LoggerClass.WriteLine($"{result}{Environment.NewLine}");
            //BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : ({text.Length} bytes) : {text}{Environment.NewLine}")));

        }

        private void ClientWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                using TcpClient client = new("127.0.0.1", 2570);
                using NetworkStream stream = client.GetStream();
                while (VarClass.Listen)
                {
                    if (stream.Socket.IsBound)
                    {
                        // Read the first batch of the TcpServer response bytes.
                        try
                        {
                            byte[] data = new byte[1024];

                            int bytes = stream.Read(data, 0, data.Length);
                            string str = Encoding.UTF8.GetString(data, 0, bytes);
                            //string str = (new UTF8Encoding(false)).GetString(data, 0, bytes);
                            string rr = str.Replace("\0", string.Empty);
                            //string[] rr = sr.Split('(');
                            if (rr.Length > 47)
                            {
                                string r = rr[^47..];
                                //LoggerClass.WriteLine($"{r}{Environment.NewLine}");
                                BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : {r}{Environment.NewLine}")));
                                string[] s = r.Split(' ');
                                JsonForm(float.Parse(s[0]), float.Parse(s[1]), float.Parse(s[2]), int.Parse(s[3]), float.Parse(s[4]), float.Parse(s[5]), s[6], s[7].TrimEnd('\r', '\n'));
                                stream.Flush();
                            }
                        }
                        catch (Exception ex)
                        {
                            LoggerClass.WriteLine($" *** Error: StreamReadException: {ex.Message} [MainForm] ***");
                            BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : StreamReadException: {ex.Message}\n")));
                            return;
                        }
                        // Explicit close is not necessary since TcpClient.Dispose() will be
                        // called automatically.
                        // stream.Close();
                        // client.Close();
                    }
                    else
                    {
                        LoggerClass.WriteLine(" *** Error: StreamReadException: Socket Not Bound [MainForm] ***");
                        BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : StreamReadException: Socket Not Bound\n")));
                    }
                }
                client.Dispose();
                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException ex)
            {
                LoggerClass.WriteLine($" *** Error: ArgumentNullException: {ex.Message} [MainForm] ***");
                BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : ArgumentNullException: {ex.Message}\n")));
            }
            catch (SocketException ex)
            {
                LoggerClass.WriteLine($" *** Error: SocketException: {ex.Message} [MainForm] ***");
                BeginInvoke(new MethodInvoker(() => LogsTextBox.AppendText($"[{DateTime.Now}] : SocketException: {ex.Message}\n")));
            }
        }
    }
}