using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Ad.Model.DbModel;
using Ad.Fw;
using FormUI.Tool;

namespace FormUI
{
    public partial class FCallModule : Form
    {
        public FCallModule()
        {
            InitializeComponent();
            InitControl();
        }

        private void InitControl()
        {
            var areaList = SysLoadDataHelper.AreaList;
            if (areaList != null && areaList.Count > 0)
            {
                areaList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbArea.DataSource = areaList;
                this.cmbArea.DisplayMember = "SHOWVALUE";
                this.cmbArea.ValueMember = "ID";

                // 初始【地区】
                this.cmbProvice.DisplayMember = "SHOWVALUE";
                this.cmbProvice.ValueMember = "ID";
            }

            // 初始化【客源】
            var custSourceList = SysLoadDataHelper.CustomerSourcList;
            if (custSourceList != null && custSourceList.Count > 0)
            {
                custSourceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbSource.DataSource = custSourceList;
                this.cmbSource.DisplayMember = "SHOWVALUE";
                this.cmbSource.ValueMember = "ID";
            }

            // 初始化 【性别】
            var sexList = SexHelper.GetSexList();
            sexList.Insert(0, new Sex { Name = "请选择", Value = null });
            this.cmbSex.DataSource = sexList;
            this.cmbSex.DisplayMember = "Name";
            this.cmbSex.ValueMember = "Value";
        }

        private void cmbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbArea.SelectedValue == null)
            {
                this.cmbProvice.DataSource = new List<CTP_ENUM_ITEM>();
                return;
            }
            var proviceList = SysLoadDataHelper.GetProviceList(this.cmbArea.SelectedValue.ToString());
            if (proviceList != null && proviceList.Count > 0)
            {
                proviceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbProvice.DataSource = proviceList;
            }
        }

        private void btn11_Click(object sender, EventArgs e)
        {
            this.txtDailPhone.Text += ((Button)sender).Text;
        }

        private void btnDail_Click(object sender, EventArgs e)
        {
            this.lblCallError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtDailPhone.Text))
            {
                this.lblCallError.Text = "电话号码不能为空";
                return;
            }
            string phoneStr = this.txtDailPhone.Text.Trim();
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneStr, @"[\u4e00-\u9fbb]+"))
            {
                this.lblCallError.Text = "电话号码含有汉字";
                return;
            }

            FMain parentForm = (FMain)this.Owner;
            parentForm.DialForCallModule(phoneStr);
        }

        // 保存
        private void btnCallDetailSave_Click(object sender, EventArgs e)
        {
            this.lblCallDetailSaveError.ForeColor = Color.Red;
            this.lblCallDetailSaveError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
            {
                this.lblCallDetailSaveError.Text = "电话不能为空";
                return;
            }
            string phoneStr = this.txtPhone.Text.Trim();
            bool isMobile = false;
            if (Regex.IsMatch(phoneStr, Ad.Util.RegexHelper.reg_Mobile_str2))
            {
                isMobile = true;
            }
            else if (Regex.IsMatch(phoneStr,Ad.Util.RegexHelper.reg_Tel_str2))
            {

            }
            else
            {
                this.lblCallDetailSaveError.Text = "电话号格式错误";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtCustName.Text))
            {
                this.lblCallDetailSaveError.Text = "客户名称不能为空";
                return;
            }
            if (this.cmbArea.SelectedValue == null)
            {
                this.lblCallDetailSaveError.Text = "所在区域不能为空";
                return;
            }
            if (this.cmbProvice.SelectedValue == null)
            {
                this.lblCallDetailSaveError.Text = "所在地区不能为空";
                return;
            }
            if (this.cmbSex.SelectedValue == null)
            {
                this.lblCallDetailSaveError.Text = "性别不能为空";
                return;
            }
            if (this.cmbSource.SelectedValue == null)
            {
                this.lblCallDetailSaveError.Text = "客户来源不能为空";
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                if (!Regex.IsMatch(this.txtEmail.Text.Trim(),Ad.Util.RegexHelper.reg_Email_str))
                {
                    this.lblCallDetailSaveError.Text = "邮箱地址格式错误";
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtProduce.Text))
            {
                this.lblCallDetailSaveError.Text = "咨询产品不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.rtbContent.Text))
            {
                this.lblCallDetailSaveError.Text = "咨询内容不能为空";
                return;
            }
            Y_Call_Cust entity = new Y_Call_Cust();
            entity.AreaId = (long)this.cmbArea.SelectedValue;
            entity.Area = this.cmbArea.Text;
            entity.CustName = this.txtCustName.Text.Trim();
            entity.CustSourceId = (long)this.cmbSource.SelectedValue;
            entity.CustSource = this.cmbSource.Text;
            if (!LoginHelper.IsGodUser)
            {
                entity.DeptId = LoginHelper.GetOrgDeptId();
                entity.DeptName = LoginHelper.GetOrgDeptName();
                entity.StuffId = LoginHelper.GetManagerId();
                entity.StuffName = LoginHelper.GetManagerName();
            }
            else
            {
                entity.DeptId = 1131885118088629274L;
                entity.DeptName = "运营部";
                entity.StuffId = 5465197178881722204L;
                entity.StuffName = "李娜";
            }
            entity.Email = this.txtEmail.Text.Trim();
            entity.EntryDate = DateTime.Now;
            entity.Job = this.txtJob.Text;
            if (isMobile)
            {
                entity.Phone = phoneStr;
            }
            else
            {
                entity.Tel = phoneStr;
            }
            entity.Product = this.txtProduce.Text.Trim();
            entity.ProvinceId = (long)this.cmbProvice.SelectedValue;
            entity.Province = this.cmbProvice.Text;
            entity.Question = this.rtbContent.Text.Trim();
            entity.Sex = (int)this.cmbSex.SelectedValue == 0 ? false : true;

            var result = BllCallCust.Insert(entity);
            if (!result.IsOK)
            {
                this.lblCallDetailSaveError.Text = result.Msg;
            }
            else
            {
                this.rtbRemark.Text += "拨出时间： " + entity.EntryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + Environment.NewLine;
                this.rtbRemark.Text += "电话号:    " + phoneStr + Environment.NewLine;
                this.rtbRemark.Text += "客户名称： " + this.txtCustName.Text.Trim() + Environment.NewLine;
                this.rtbRemark.Text += "*****************************" + Environment.NewLine;
                this.lblCallDetailSaveError.ForeColor = Color.Green;
                this.lblCallDetailSaveError.Text = "保存成功";
            }
        }

        // 清除
        private void btnClearDetail_Click(object sender, EventArgs e)
        {
            this.txtPhone.Text = string.Empty;
            this.txtCustName.Text = string.Empty;
            this.cmbArea.SelectedIndex = 0;
            this.cmbSex.SelectedIndex = 0;
            this.cmbSource.SelectedIndex = 0;
            this.txtEmail.Text = string.Empty;
            this.txtJob.Text = string.Empty;
            this.txtProduce.Text = string.Empty;
            this.rtbContent.Text = string.Empty;
        }
    }
}
