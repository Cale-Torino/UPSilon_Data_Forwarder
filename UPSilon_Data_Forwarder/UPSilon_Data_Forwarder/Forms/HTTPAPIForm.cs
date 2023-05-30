using System.Net;
using UPSilon_Data_Forwarder.Classes;
using UPSilon_Data_Forwarder.Classes.HTTP;
using UPSilon_Data_Forwarder.Classes.Logs;

namespace UPSilon_Data_Forwarder
{
    public partial class HTTPAPIForm : Form
    {
        public HTTPAPIForm()
        {
            InitializeComponent();
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            Start_Server();
            Get_Test();
        }

        private async void Start_Server()
        {
            if (HttpServer.listener.IsListening)
            {
                MessageBox.Show("HttpListener Already Listining", "HttpListener", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Url))
                {
                    MessageBox.Show("Please Fill In Your Url Endpoint", "No Url Endpoint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    //SimpleHTTPServer server = new SimpleHTTPServer(@"C:\Users\User501\source\repos\UPSilon_Data_Forwarder\UPSilon_Data_Forwarder\bin\Debug\net6.0-windows\index.html",8000);
                    HttpServer.listener = new HttpListener();
                    HttpServer.listener.Prefixes.Add(Url_textBox.Text);
                    HttpServer.listener.Start();
                    LogsTextBox.AppendText($"Listening for connections on {Url_textBox.Text}{Environment.NewLine}");

                    // Handle requests
                    await HttpServer.HandleIncomingConnections();
                    //listenTask.GetAwaiter().GetResult();

                    // Close the listener
                    //HttpServer.listener.Close();
                }
            }

        }

        private async void Get_Test()
        {
            Thread.Sleep(3000);
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Url))
                    {
                        MessageBox.Show("Please Fill In Your Url Endpoint", "No Url Endpoint", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        if (Uri.IsWellFormedUriString(Url_textBox.Text, UriKind.Absolute))
                        {
                            /*                            UriBuilder builder = new(Properties.Settings.Default.Url)
                                                        {
                                                            Port = 8000
                                                        };*/
                            using (HttpResponseMessage response = await client.GetAsync(new Uri(Url_textBox.Text)))
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
                        else
                        {
                            MessageBox.Show("Not Well Formed Uri String", "Could not test HTTP API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Could not test HTTP API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [HTTPAPIForm] ***");
                    return;
                }
            }
        }

        private void HTTPAPIForm_Load(object sender, EventArgs e)
        {
            //Url_textBox.Text = "http://localhost:8000/";
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Url))
            {

            }
            else
            {
                //SecureString Appid = EncryptionClass.DecryptString(Properties.Settings.Default.Url);
                Url_textBox.Text = EncryptionClass.ToInsecureString(EncryptionClass.DecryptString(Properties.Settings.Default.Url));
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Url_textBox.Text))
                {
                    MessageBox.Show("Please Fill In The Textbox/Textboxes", "Null Or WhiteSpace Textbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (Uri.IsWellFormedUriString(Url_textBox.Text, UriKind.Absolute))
                    {
                        Properties.Settings.Default.Url = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Url_textBox.Text));
                        Properties.Settings.Default.Save();
                        MessageBox.Show($"Settings Saved {Environment.NewLine}Url : {Url_textBox.Text}", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Not Well Formed Uri String", "Could not test HTTP API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Settings Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{ex.Message} [TelegramAPIForm] ***");
                return;
            }
        }

        private void HTTPAPIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Enable_checkBox.Checked == true)
            {
                Properties.Settings.Default.HTTP_Checkbox = true;
            }
            if (string.IsNullOrWhiteSpace(Url_textBox.Text))
            {
                MessageBox.Show("Please Fill In The Textbox/Textboxes Before Closing", "Null Or WhiteSpace Textbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("http://127.0.0.1:8000/");
            //Process.Start(new ProcessStartInfo("http://127.0.0.1:8000/") { UseShellExecute = true });
            //LoggerClass.WriteLine(" *** Well Formatted String Clicked : http://127.0.0.1:8000/ [AboutForm]  *** ");
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Red;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }
    }
}
