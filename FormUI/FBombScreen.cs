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
    public partial class FBombScreen : Form
    {
        private short id;

        private string phone;

        private bool isProviceInit = false;

        private long? areaId;

        private long? proviceId;

        private DateTime callDateTime;
        public FBombScreen(string phone,short id)
        {
            this.phone = phone;
            this.id = id;
            this.callDateTime = DateTime.Now;
            InitializeComponent();
            this.InitControl();
        }

        private void InitControl()
        {
            this.txtPhone.Text = this.phone;
            Y_Call_Cust custEntity = BllCustomer.BombScreenSelect(this.phone);
            if (custEntity != null)
            {
                this.txtCustName.Text = custEntity.CustName;
                if (!string.IsNullOrWhiteSpace(custEntity.Email))
                {
                    this.txtEmail.Text = custEntity.Email;
                }
                if (!string.IsNullOrWhiteSpace(custEntity.Job))
                {
                    this.txtJob.Text = custEntity.Job;
                }
                this.areaId = custEntity.AreaId.GetValueOrDefault();
                this.proviceId = custEntity.ProvinceId.GetValueOrDefault();
            }
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
                if (custEntity != null) 
                {
                    this.cmbArea.SelectedValue = custEntity.AreaId;
                }
            }

            // 初始化【客源】
            var custSourceList = SysLoadDataHelper.CustomerSourcList;
            if (custSourceList != null && custSourceList.Count > 0)
            {
                custSourceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbSource.DataSource = custSourceList;
                this.cmbSource.DisplayMember = "SHOWVALUE";
                this.cmbSource.ValueMember = "ID";
                if (custEntity != null)
                {
                    this.cmbSource.SelectedValue = custEntity.CustSourceId;
                }
            }

            // 初始化 【性别】
            var sexList = SexHelper.GetSexList();
            sexList.Insert(0, new Sex { Name = "请选择", Value = null });
            this.cmbSex.DataSource = sexList;
            this.cmbSex.DisplayMember = "Name";
            this.cmbSex.ValueMember = "Value";
            if (custEntity != null)
            {
                this.cmbSex.SelectedValue = custEntity.Sex.GetValueOrDefault() ? 1 : 0;
            }
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
                try
                {
                    if (this.proviceId != null)
                    {
                        if (this.cmbArea.SelectedValue != null)
                        {
                            if ((long)this.cmbArea.SelectedValue == this.areaId && !this.isProviceInit)
                            {
                                this.cmbProvice.SelectedValue = this.proviceId;
                                this.isProviceInit = true;
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        // 保存
        private void btnSave_Click(object sender, EventArgs e)
        {

            this.lblError.ForeColor = Color.Red;
            this.lblError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtPhone.Text))
            {
                this.lblError.Text = "电话不能为空";
                return;
            }
            string phoneStr = this.txtPhone.Text.Trim();
            bool isMobile = false;
            if (Regex.IsMatch(phoneStr, Ad.Util.RegexHelper.reg_Mobile_str2))
            {
                isMobile = true;
            }
            else if (Regex.IsMatch(phoneStr, Ad.Util.RegexHelper.reg_Tel_str2))
            {

            }
            else
            {
                this.lblError.Text = "电话号格式错误";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtCustName.Text))
            {
                this.lblError.Text = "客户名称不能为空";
                return;
            }
            if (this.cmbArea.SelectedValue == null)
            {
                this.lblError.Text = "所在区域不能为空";
                return;
            }
            if (this.cmbProvice.SelectedValue == null)
            {
                this.lblError.Text = "所在地区不能为空";
                return;
            }
            if (this.cmbSex.SelectedValue == null)
            {
                this.lblError.Text = "性别不能为空";
                return;
            }
            if (this.cmbSource.SelectedValue == null)
            {
                this.lblError.Text = "客户来源不能为空";
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtEmail.Text))
            {
                if (!Regex.IsMatch(this.txtEmail.Text.Trim(),Ad.Util.RegexHelper.reg_Email_str))
                {
                    this.lblError.Text = "邮箱地址格式错误";
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtProduce.Text))
            {
                this.lblError.Text = "咨询产品不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.rtbContent.Text))
            {
                this.lblError.Text = "咨询内容不能为空";
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
            entity.EntryDate = this.callDateTime;
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
                this.lblError.Text = result.Msg;
            }
            else
            {
                this.Dispose();
            }
        }

    }
}
