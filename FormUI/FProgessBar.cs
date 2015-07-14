using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Ad.Fw;

namespace FormUI
{
    public partial class FProgessBar : Form
    {
        public FProgessBar()
        {
            InitializeComponent();

        }

        public string Title
        {
            get { return this.label1.Text; }
            set
            {
                this.label1.Text = value;
            }
        }

        public int Maximum
        {
            get { return this.progressBar1.Maximum; }
            set
            {
                this.progressBar1.Maximum = value;
            }
        }

        public int Minimum
        {
            get { return this.progressBar1.Minimum; }
            set
            {
                this.progressBar1.Minimum = value;
            }
        }

        public int Value
        {
            get { return this.progressBar1.Value; }
            set{
                this.progressBar1.Value = value;
            }
        }
    }
}
