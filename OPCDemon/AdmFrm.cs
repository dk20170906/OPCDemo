using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OPCDemon
{
    public partial class AdmFrm : Form
    {
        public AdmFrm()
        {
            InitializeComponent();
            test();
        }
        public void test()
        {
            LocalConfigXml.SetKey("opcCofig.xml", "serverIP", "2456465");
        }

        private void AdmFrm_Load(object sender, EventArgs e)
        {

        }
    }
}
