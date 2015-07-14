using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormUI
{
    public partial class SplitPage : UserControl
    {
        /// <summary>
        /// 自定义事件数据基类
        /// </summary>
        public class EventPagingArg : EventArgs
        {
            private int _CurrentPageIndex;
            public EventPagingArg(int pageIndex)
            {
                _CurrentPageIndex = pageIndex;
            }
            public int CurrentPageIndex
            {
                get { return this._CurrentPageIndex; }
            }
        }

        /// <summary>
        /// 申明委托
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public delegate void EventPagingHandler(EventPagingArg e);

        public SplitPage()
        {
            InitializeComponent();
        }
        public event EventPagingHandler EventPaging;
        /// <summary>
        /// 每页显示记录数
        /// </summary>
        private int _pageSize = 20;
        /// <summary>
        /// 获取或设置每页显示记录数
        /// </summary>
        public int PageSize
        {
            get { return _pageSize; }
            set
            {
                _pageSize = value;
                GetPageCount();
            }
        }

        private int _RecordCount = 0;
        /// <summary>
        /// 获取或设置总记录数
        /// </summary>
        public int RecordCount
        {
            get { return _RecordCount; }
            set
            {
                _RecordCount = value;
                GetPageCount();
            }
        }

        private int _pageCount = 0;
        /// <summary>
        /// 获取页数
        /// </summary>
        public int PageCount
        {
            get { return _pageCount; }
        }

        private int _pageCurrent = 1;
        /// <summary>
        /// 当前页号
        /// </summary>
        public int PageCurrent
        {
            get
            {
                return this._pageCurrent == 0 ? 1 : this._pageCurrent;
            }
            set { _pageCurrent = value; }
        }

        private bool isTwoRow = false;
        public bool IsTwoRow
        {
            get
            {
                return this.isTwoRow;
            }
            set
            {
                this.isTwoRow = value;
                if (value)
                {
                    this.labPageInfo.Visible = false;
                    this.labPageInfo2.Visible = true;
                }
                else
                {
                    this.labPageInfo.Visible = true;
                    this.labPageInfo2.Visible = false;
                }
            }
        }

        private void GetPageCount()
        {
            if (this.RecordCount > 0)
            {
                this._pageCount = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(this.RecordCount) / Convert.ToDouble(this.PageSize)));
            }
            else
            {
                this._pageCount = 0;
            }
            this.SetCtrl();
        }

        /// <summary>
        /// 翻页控件数据绑定的方法
        /// </summary>
        private void Bind()
        {
            this.SetCtrl();

            if (this.EventPaging != null)
            {
                this.EventPaging(new EventPagingArg(this.PageCurrent));
            }
        }

        private void SetCtrl()
        {
            if (this.PageCurrent <= 0)
            {
                this.PageCurrent = 1;
            }
            else if (this.PageCurrent > this.PageCount)
            {
                this.PageCurrent = this.PageCount;
            }

            this.labPageInfo2.Text = this.labPageInfo.Text = String.Format(@"每页{0}条记录 共{1}页 {2}条记录", this.PageSize, this.PageCount, this.RecordCount);
            this.txtCurrentPage.Text = this.PageCurrent.ToString();

            if (this.PageCurrent == 1)
            {
                this.btnPrev.Enabled = false;
                this.btnFirst.Enabled = false;
            }
            else
            {
                btnPrev.Enabled = true;
                btnFirst.Enabled = true;
            }

            if (this.PageCurrent == this.PageCount)
            {
                this.btnLast.Enabled = false;
                this.btnNext.Enabled = false;
            }
            else
            {
                btnLast.Enabled = true;
                btnNext.Enabled = true;
            }

            if (this.RecordCount == 0)
            {
                btnNext.Enabled = false;
                btnLast.Enabled = false;
                btnFirst.Enabled = false;
                btnPrev.Enabled = false;
            }

            this.IsTwoRow = this.isTwoRow;

        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            PageCurrent = 1;
            this.Bind();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            PageCurrent -= 1;
            if (PageCurrent <= 0)
            {
                PageCurrent = 1;
            }
            this.Bind();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            this.PageCurrent += 1;
            if (PageCurrent > PageCount)
            {
                PageCurrent = PageCount;
            }
            this.Bind();
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            PageCurrent = PageCount;
            this.Bind();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (this.txtCurrentPage.Text != null && txtCurrentPage.Text != "")
            {
                if (Int32.TryParse(txtCurrentPage.Text, out _pageCurrent))
                {
                    this.Bind();
                }
                else
                {
                    showError("输入数字格式错误！");
                    this.txtCurrentPage.Focus();
                }
            }
        }

        private void showError(string msg)
        {
            MessageBox.Show(msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
