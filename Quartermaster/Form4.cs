using System.Media;

namespace Quartermaster
{
    public partial class SecretDialog : Form
    {
        public SecretDialog()
        {
            InitializeComponent();
        }

        SoundPlayer sp = new SoundPlayer(Directory.GetCurrentDirectory() + @"\dorkmode.wav");      
        private void SecretDialog_Load(object sender, EventArgs e)
        {
            Task.Delay(500);
            if (File.Exists(Directory.GetCurrentDirectory() + @"\dorkmode.wav"))
            {
                sp.Play();
            }
            return;
        }

        private void SecretDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            sp.Stop();
        }
    }
}
