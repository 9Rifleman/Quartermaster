using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quartermaster
{
    public partial class FormRename : Form
    {
        public FormRename()
        {
            InitializeComponent();
        }

        public DialogResult RenameDialog()
        {
            return(ShowDialog());
        }

        private void btnRename_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
