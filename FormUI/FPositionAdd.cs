using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Model.DbModel;
using Ad.Fw;

namespace FormUI
{
    public partial class FPositionAdd : Form
    {
        public FPositionAdd()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtPosition.Text))
            {
                this.lblError.Text = "职位不能为空";
                return;
            }
            Y_Position entity = new Y_Position { PostName = this.txtPosition.Text.Trim() };
            var result = BllPosition.Insert(entity);
            if (!result.IsOK)
            {
                this.lblError.Text = result.Msg;
                return;
            }
            ((FMain)this.Owner).BindPositionData();
            this.Dispose();
        }
    }
}
