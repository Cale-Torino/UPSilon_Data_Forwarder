using System.Diagnostics;
using UPSilon_Data_Forwarder.Classes.Logs;

namespace UPSilon_Data_Forwarder
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            linkLabel.ForeColor = Color.DodgerBlue;
            Versionlabel.Text = $"Version: {Application.ProductVersion}";
        }

        private void linkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo("https://tutorials.techrad.co.za/2023/05/17/upsilon-remote-monitor") { UseShellExecute = true });
            LoggerClass.WriteLine(" *** tutorials.techrad.co.za Link Clicked [AboutForm]  *** ");
        }
    }
}
