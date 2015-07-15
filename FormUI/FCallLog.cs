using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ad.Model.VModel;
using Ad.Model.DbModel;
using Ad.Fw;
using FormUI.Tool;

namespace FormUI
{
    public partial class FCallLog : Form
    {
        public FCallLog()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            DateTime currentDateTime = DateTime.Now;
            int year = currentDateTime.Year;
            int month = currentDateTime.Month;
            int day = currentDateTime.Day;
            this.dtpDate1.Value = new DateTime(year, month, day, 0, 0, 0);
            this.dtpDate2.Value = new DateTime(year, month, day, 23, 59, 59);

            this.stpCallLog.PageSize = 50;

            this.txtExtensionNo.Text = AnswerHelper.CurrentSeatPhone;
            if (!LoginHelper.IsGodUser && !LoginHelper.IsHasFunction(EnumHelper.FunctionEnum.Special))
            {
                this.txtExtensionNo.Enabled = false;
            }

            BindingCallLog();
        }

        // 分页
        private void splitPage1_EventPaging(SplitPage.EventPagingArg e)
        {
            BindingCallLog();
        }

        private void BindingCallLog()
        {
            VCallLog model = new VCallLog();
            model.ExtensionNum = this.txtExtensionNo.Text.Trim();
            model.StartTime1 = this.dtpDate1.Value;
            model.StartTime2 = this.dtpDate2.Value;
            string orderString = string.Format("{0} asc,{1} asc", Y_Call_Log_Description.SeatPhone, Y_Call_Log_Description.StartTime);
            var pageList = BllCallLog.SelectSplit(model, this.stpCallLog.PageSize, this.stpCallLog.PageCurrent, orderString);
            this.bdsCallLog.DataSource = pageList.Models;
            this.stpCallLog.RecordCount = pageList.RecordCount;
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            int rownum = (e.RowIndex + 1);
            Rectangle rct = new Rectangle(e.RowBounds.Location.X, e.RowBounds.Location.Y + 4, ((DataGridView)sender).RowHeadersWidth - 4, e.RowBounds.Height);
            TextRenderer.DrawText(e.Graphics, rownum.ToString(), ((DataGridView)sender).RowHeadersDefaultCellStyle.Font, rct, 
                ((DataGridView)sender).RowHeadersDefaultCellStyle.ForeColor, System.Drawing.Color.Transparent, TextFormatFlags.HorizontalCenter);
        }
        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            BindingCallLog();
        }

        private void txtExtensionNo_TextChanged(object sender, EventArgs e)
        {
            BindingCallLog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BindingCallLog();
        }
    }
}
