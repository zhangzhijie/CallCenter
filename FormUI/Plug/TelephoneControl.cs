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
    public partial class TelephoneControl : UserControl
    {
        public TelephoneControl()
        {
            InitializeComponent();
        }

        public delegate void UserControlMouseUpHandle(object sender, MouseEventArgs e);

        public event UserControlMouseUpHandle UserControlMouseUp;

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LblStateText
        {
            get { return this.lblState.Text; }
            set { this.lblState.Text = value; }
        }

        // 状态码
        public short? StateId { get; set; }
     

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LblStateColor
        {
            get { return this.lblState.ForeColor; }
            set { this.lblState.ForeColor = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LblSeatText
        {
            get { return this.lblSeat.Text; }
            set { this.lblSeat.Text = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LblSeatColor
        {
            get { return this.lblSeat.ForeColor; }
            set { this.lblSeat.ForeColor = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string LblUserNameText
        {
            get { return this.lblUserName.Text; }
            set { this.lblUserName.Text = value; }
        }

        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color LblUserNameColor
        {
            get { return this.lblUserName.ForeColor; }
            set { this.lblUserName.ForeColor = value; }
        }

        [Browsable(true)]
        public Image Image
        {
            get { return this.picTele.Image; }
            set { this.picTele.Image = value; }
        }

        // 座席号码
        public Int32? SeatId { get; set; }

        // 判断是否为自己座席
        public bool? IsSelfSeat { get; set; }

        private void mouseUp(object sender, MouseEventArgs e)
        {
            if (UserControlMouseUp != null)
            {
                UserControlMouseUp(this, e);
            }
        }
    }
}
