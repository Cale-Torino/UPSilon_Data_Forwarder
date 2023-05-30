using System.Timers;
using UPSilon_Data_Forwarder.Classes.Logs;
using Timer = System.Timers.Timer;

namespace UPSilon_Data_Forwarder
{
    public partial class SplashForm : Form
    {
        public SplashForm()
        {
            InitializeComponent();
        }
        Timer myTimer = new();
        private void SplashForm_Load(object sender, EventArgs e)
        {
            Activate();
            BringToFront();
            Console.Beep();
            CreateFolder();
            LoggerClass.WriteLine(GetSpecsClass.GetSpecs());
            Versionlabel.Text = $"Version: {Application.ProductVersion}";
            myTimer.Elapsed += new ElapsedEventHandler(TimeUp);
            myTimer.Interval = 3000;
            myTimer.Start();//start timer
        }
        private void CreateFolder()
        {
            try
            {
                //Create the folders used by the app
                Directory.CreateDirectory(Application.StartupPath + @"\Logs");
                Directory.CreateDirectory(Application.StartupPath + @"\Updates");
                LoggerClass.WriteLine(" *** Application Start [SplashForm] ***");
                LoggerClass.WriteLine(" *** CreateDirectory Success [SplashForm] ***");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Create Folder Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoggerClass.WriteLine($" *** Error:{ex.Message} [SplashForm] ***");
                return;
            }
        }
        public void TimeUp(object sender, ElapsedEventArgs e)
        {
            LoggerClass.WriteLine(" *** TimeUp [SplashForm] ***");
            myTimer.Stop();
            Invoke((MethodInvoker)delegate
            {
                Hide();
                using (Form f = new MainForm())
                {
                    f.ShowDialog();
                    f.Activate();
                }
                Close();
            });
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
