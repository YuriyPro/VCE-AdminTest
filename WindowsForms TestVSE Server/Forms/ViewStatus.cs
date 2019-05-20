using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsForms_TestVSE_Server.Forms
{
    public partial class ViewStatus : Form
    {
        public ViewStatus()
        {
            InitializeComponent();
        }

        private void ViewStatus_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'testVCE_Server3DataSet3.Status' table. You can move, or remove it, as needed.
            this.statusTableAdapter.Fill(this.testVCE_Server3DataSet3.Status);

        }
    }
}
