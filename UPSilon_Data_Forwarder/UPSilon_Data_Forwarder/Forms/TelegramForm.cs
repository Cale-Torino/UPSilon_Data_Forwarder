using UPSilon_Data_Forwarder.Classes;
using UPSilon_Data_Forwarder.Classes.Logs;

namespace UPSilon_Data_Forwarder
{
    public partial class TelegramForm : Form
    {
        public TelegramForm()
        {
            InitializeComponent();
        }

        private void Test_button_Click(object sender, EventArgs e)
        {
            SendToTelegram();
            //https://api.telegram.org/bot6122285913:AAEvmC7rlX3vt0FvEGe-Cvh-EXOJv_pMH7o/sendMessage?chat_id=-1001948924591&parse_mode=HTML&text=%F0%9F%9A%A8+%3Cb%3EAlert%3C/b%3E%0A%3Ci%3E+UPSilon_Data_Forwarder%3C/i%3E%3Cu%3E+getMessage%3C/u%3E%0AMessage+details+go+here
            //https://api.telegram.org/bot6122285913:AAEvmC7rlX3vt0FvEGe-Cvh-EXOJv_pMH7o/sendMessage?chat_id=-1001948924591&text=Test
            //6122285913:AAEvmC7rlX3vt0FvEGe-Cvh-EXOJv_pMH7o
            //1001948924591
        }

        private async void SendToTelegram()
        {
            using (HttpClient client = new HttpClient())
            {
                //Add Default Request Headers
                //client.DefaultRequestHeaders.Add("Authorization", "Bearer token");
                try
                {
                    using (HttpResponseMessage response = await client.GetAsync(new Uri($"https://api.telegram.org/bot{Token_textBox.Text}/sendMessage?chat_id=-{Chatid_textBox.Text}&text={VarClass.JsonData}")))
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
                    MessageBox.Show(ex.Message, "Could not test Telegram API", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoggerClass.WriteLine(" *** Error:" + ex.Message + " [TelegramAPIForm] ***");
                    return;
                }
            }
        }

        private void TelegramForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Properties.Settings.Default.Chat_ID) || string.IsNullOrWhiteSpace(Properties.Settings.Default.Token))
            {

            }
            else
            {
                Chatid_textBox.Text = EncryptionClass.ToInsecureString(EncryptionClass.DecryptString(Properties.Settings.Default.Chat_ID));
                Token_textBox.Text = EncryptionClass.ToInsecureString(EncryptionClass.DecryptString(Properties.Settings.Default.Token));
            }
        }

        private void Save_button_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(Chatid_textBox.Text) || string.IsNullOrWhiteSpace(Token_textBox.Text))
                {
                    MessageBox.Show("Please Fill In The Textbox/Textboxes", "Null Or WhiteSpace Textbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoggerClass.WriteLine(" *** Please Fill In The Textbox/Textboxes [TelegramAPIForm] ***");
                }
                else
                {
                    Properties.Settings.Default.Chat_ID = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Chatid_textBox.Text));
                    Properties.Settings.Default.Token = EncryptionClass.EncryptString(EncryptionClass.ToSecureString(Token_textBox.Text));
                    Properties.Settings.Default.Save();
                    MessageBox.Show($"Settings Saved {Environment.NewLine}ChatID : {Chatid_textBox.Text}{Environment.NewLine}Token : {Token_textBox.Text}", "Settings Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoggerClass.WriteLine($" *** Settings Saved {Environment.NewLine}ChatID : {Chatid_textBox.Text}{Environment.NewLine}Token : {Token_textBox.Text} [TelegramAPIForm] ***");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save Settings Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{ex.Message} [TelegramAPIForm] ***");
                return;
            }
        }

        private void TelegramForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Enable_checkBox.Checked == true)
            {
                Properties.Settings.Default.Telegram_Checkbox = true;
            }
            if (string.IsNullOrWhiteSpace(Chatid_textBox.Text) || string.IsNullOrWhiteSpace(Token_textBox.Text))
            {
                MessageBox.Show("Please Fill In The Textbox/Textboxes Before Closing", "Null Or WhiteSpace Textbox", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoggerClass.WriteLine($" *** Please Fill In The Textbox/Textboxes Before Closing [TelegramAPIForm] ***");
                e.Cancel = true;
            }
        }
    }
}
