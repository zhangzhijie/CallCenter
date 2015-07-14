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
    public partial class FPositionEdit : Form
    {
        private Y_Position positionEntity = null;

        public FPositionEdit()
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
            this.positionEntity.PostName = this.txtPosition.Text.Trim();
            var result = BllPosition.Update(positionEntity);
            if (!result.IsOK)
            {
                this.lblError.Text = result.Msg;
                return;
            }
            ((FMain)this.Owner).BindPositionData();
            this.Dispose();
        }

        public Ad.Util.ResultU SelectPostion(string idStr)
        {
            if (string.IsNullOrWhiteSpace(idStr))
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "职位ID为空!" };
            }
            long id;
            if (!Int64.TryParse(idStr, out id))
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "职位ID格式错误!" };
            }
            positionEntity = BllPosition.SelectById(id);
            if (positionEntity != null)
            {
                this.txtPosition.Text = positionEntity.PostName;
                return new Ad.Util.ResultU { IsOK = true };
            }
            else
            {
                return new Ad.Util.ResultU { IsOK = false, Msg = "该记录已不存在" };
            }
        }
    }
}
