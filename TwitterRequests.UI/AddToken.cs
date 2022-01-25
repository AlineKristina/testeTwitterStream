using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitterRequests.Domain;

namespace TwitterRequests.UI
{
    public partial class AddToken : Form
    {
        

        public AddToken()
        {
            InitializeComponent();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            var start = new RequestedStream(txt_Token.Text);
            start.Show();
            this.Hide();
        }
    }
}
