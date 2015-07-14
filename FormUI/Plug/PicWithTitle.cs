using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI.Plug
{
    public partial class PicWithTitle : UserControl
    {
        public PicWithTitle()
        {
            InitializeComponent();
        }

        public delegate void userControlHandle(object sender, EventArgs e);

        public event userControlHandle userControlClicked;

        // 默认索引
        private int index = 0;

        // 点击后的颜色
        private Color activeColor = Color.Blue;

        private void userControl_Click(object sender, EventArgs e)
        {
            if (this.activeColor != this.BackColor)
            {
                Control parentControl = this.Parent;
                if (parentControl != null)
                {
                    ControlCollection controls = parentControl.Controls;

                    foreach (Control control in controls)
                    {
                        if (control is PicWithTitle)
                        {
                            if (control.BackColor == this.activeColor)
                            {
                                control.BackColor = this.BackColor;
                            }
                        }

                    }
                }
                this.BackColor = this.activeColor;
            }
            if (userControlClicked != null)
            {
                userControlClicked(this, e);
            }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get { return this.label1.Text; }
            set { this.label1.Text = value; }
        }

        [Browsable(true)]
        public Color ActiveColor
        {
            get { return this.activeColor; }
            set { this.activeColor = value; }
        }

        [Browsable(true)]
        public Image Image
        {
            get { return this.picBox.Image; }
            set { this.picBox.Image = value; }
        }

        [Browsable(true)]
        public int Index
        {
            get { return this.index; }
            set { this.index = value; }
        }
    }
}
