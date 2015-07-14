using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Resources;
using System.Reflection;
using System.Text.RegularExpressions;
using FormUI.Tool;
using FormUI.Plug;
using Ad.Fw;
using Ad.Model.DbModel;
using Ad.Model.VModel;

namespace FormUI
{
    public partial class FMain : Form
    {
        public FMain()
        {
            InitializeComponent();
        }

        private void FMain_Load(object sender, EventArgs e)
        {
            // 登录
            InitAndLogin();

            // 权限设置
            PermissionSet();
        }

        // 检查是否已经登录并在登陆前完成部分初始化
        private void InitAndLogin()
        {
            this.sptSearch.PageSize = AppSetting.PageSize;    // 查询
            this.sptKnowledge.PageSize = AppSetting.PageSize; // 知识库
            this.sptManager.PageSize = AppSetting.PageSize;   // 员工
            InitContextMenuStrip(); // 初始化ContextMenuStrip
            if (!StaticStateHelper.IsLogin.GetValueOrDefault())
            {
                FLogin flogin = new FLogin();
                flogin.Owner = this;
                flogin.ShowDialog();
            }
        }

        // 初始化呼叫模块中的ContextMenuStrip
        private void InitContextMenuStrip()
        {
            // 自己电话Item
            foreach (EnumHelper.SelfContextMenuEnum item in typeof(EnumHelper.SelfContextMenuEnum).GetEnumValues())
            {
                this.cmsSelf.Items.Add(new ToolStripMenuItem(EnumHelper.GetDescript(item), null, new EventHandler(SelfContextMenuItemSelected), 
                    Ad.Util.Const.SelfContextMenuPrefix + (int)item));
            }
            // 其他电话Item
            foreach (EnumHelper.OtherContextMenuEnum item in typeof(EnumHelper.OtherContextMenuEnum).GetEnumValues())
            {
                this.cmsOther.Items.Add(new ToolStripMenuItem(EnumHelper.GetDescript(item), null, new EventHandler(OtherContextMenuItemSelected),
                    Ad.Util.Const.OtherContextMenuPrefix + (int)item));
            }
        }

        // 单击自己电话Item引发的处理事件
        private void SelfContextMenuItemSelected(object sender,EventArgs e)
        {
            ToolStripMenuItem toolItem = (ToolStripMenuItem)sender;
            if (toolItem.Name == Ad.Util.Const.SelfContextMenuPrefix + (int)EnumHelper.SelfContextMenuEnum.Busy)
            {
                BusyFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.SelfContextMenuPrefix + (int)EnumHelper.SelfContextMenuEnum.Details)
            {
                AnswerSelfDetailFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.SelfContextMenuPrefix + (int)EnumHelper.SelfContextMenuEnum.Idle)
            {
                IdleFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.SelfContextMenuPrefix + (int)EnumHelper.SelfContextMenuEnum.Logout)
            {
                Logout();
            }
        }

        // 单击其他电话Item引发的处理事件
        private void OtherContextMenuItemSelected(object sender, EventArgs e)
        {
            ToolStripMenuItem toolItem = (ToolStripMenuItem)sender;
            if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.BreakLine)
            {
                TransferFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.Details)
            {
                AnswerOtherDetailFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.ForceInsert)
            {
                ForceInsertFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.InsteadAnswer)
            {
                InsteadAnswerFunc();
            }
            else if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.Monitor)
            {
                Logout();
            }
            else if (toolItem.Name == Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.Transfer)
            {
                TransferFunc();
            }
        }

        #region 自己Item
        // 置忙
        private void BusyFunc()
        {
            this.axCTISrv.cmdOffHook(AnswerHelper.CurrentChannelId);
        }

        // 置闲
        private void IdleFunc()
        {
            this.axCTISrv.cmdOnHook(AnswerHelper.CurrentChannelId);
        }

        // 通话详细
        private void AnswerSelfDetailFunc()
        {

        }

        // 注销
        private void Logout()
        {
            this.axCTISrv.logout();
            if (AnswerHelper.RefreshTelStateThread != null && AnswerHelper.RefreshTelStateThread.IsAlive)
            {
                AnswerHelper.RefreshTelStateThread.Abort();
            }
            AnswerHelper.AllChannelEntityList = new List<UserChannel>();
            LoginAndFlpToggle();
            StaticStateHelper.IsInitAllTDMT = false;
            this.flpAnswer.Controls.Clear();
        }
        #endregion

        #region 其他Item
        // 呼叫转移
        private void TransferFunc()
        {
            this.axCTISrv.cmdCallDivert(AnswerHelper.CurrentChannelId);
            Thread.Sleep(1000);
            this.axCTISrv.cmdDial(AnswerHelper.CurrentChannelId, AnswerHelper.SelectedTelControl.LblSeatText);
        }

        // 通话详细
        private void AnswerOtherDetailFunc()
        {
        }

        // 强制插入
        private void ForceInsertFunc()
        {

        }

        // 代接
        private void InsteadAnswerFunc()
        {

        }

        // 监听
        private void MonitorFunc()
        {

        }

        // 强断
        private void BreakLineFunc()
        {

        }
        #endregion


        // 登录和电话Flp切换
        private void LoginAndFlpToggle()
        {
            if (this.flpAnswer.Visible)
            {
                this.flpAnswer.Visible = false;
                this.pnlLoginTDMX.Visible = true;
                this.lblLoginTDMXError.Text = string.Empty;
            }
            else
            {
                this.flpAnswer.Visible = true;
                this.pnlLoginTDMX.Visible = false;
            }
        }

        // 设置权限及默认显示
        private void PermissionSet()
        {
            if (LoginHelper.IsGodUser)
            {
                // 默认选中模块
                this.tabControl1.SelectedIndex = 0;
                this.picWithTitle1.BackColor = Color.Blue;
                this.tabControl1_SelectedIndexChanged(this.tabControl1, new EventArgs());
                return;
            }
            if (!LoginHelper.IsHasFunction(EnumHelper.FunctionEnum.Special))
            {
                this.cmsOther.Items.RemoveByKey(Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.Monitor);
                this.cmsOther.Items.RemoveByKey(Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.Details);
                this.cmsOther.Items.RemoveByKey(Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.ForceInsert);
                this.cmsOther.Items.RemoveByKey(Ad.Util.Const.OtherContextMenuPrefix + (int)EnumHelper.OtherContextMenuEnum.BreakLine);

            }
            bool isChoicedDefault = false;
            foreach (EnumHelper.FunctionEnum item in typeof(EnumHelper.FunctionEnum).GetEnumValues())
            {
                try
                {
                    int index = (int)item;
                    Control[] controls = this.pnlPwtParent.Controls.Find("picWithTitle" + (index + 1), true);
                    if (controls == null && controls.Length == 0)
                        continue;

                    if (LoginHelper.IsHasFunction(item))
                    {
                        if (!isChoicedDefault)
                        {
                            // 默认选中模块
                            this.tabControl1.SelectedIndex = index;
                            controls[0].BackColor = Color.Blue;
                            this.tabControl1_SelectedIndexChanged(this.tabControl1, new EventArgs());
                            isChoicedDefault = true;
                        }
                    }
                    else
                    {
                        PicWithTitle picWithTitle = (PicWithTitle)(controls[0]);
                        picWithTitle.BackColor = Color.LightGray;
                        picWithTitle.BorderStyle = BorderStyle.Fixed3D;
                        picWithTitle.Enabled = false;
                    }
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        // 选择Model改变TabPage
        private void picWithTitle_userControlClicked(object sender, EventArgs e)
        {
            Plug.PicWithTitle picwithTitle = sender as Plug.PicWithTitle;
            if (sender == null)
            {
                return;
            }
            this.tabControl1.SelectedIndex = picwithTitle.Index;
        }

        // 切换TabPage
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.tabControl1.SelectedIndex)
            {
                case (int)EnumHelper.FunctionEnum.Answer:
                    if (!StaticStateHelper.IsInitAnswer.GetValueOrDefault())
                    {
                        LoginCTI();
                        StaticStateHelper.IsInitAnswer = true;
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.Call:
                    if (!StaticStateHelper.IsInitCall.GetValueOrDefault())
                    {
                        InitCallModel();
                        StaticStateHelper.IsInitCall = true;
                    }
                    CheckChannelLogin();
                    break;

                case (int)EnumHelper.FunctionEnum.Customer:
                    break;
                case (int)EnumHelper.FunctionEnum.Search:
                    if (!StaticStateHelper.IsInitSearch.GetValueOrDefault())
                    {
                        this.InitSearchModel();
                        StaticStateHelper.IsInitSearch = true;
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.KnowledgeBase:
                    knowledgeBase_Click(this.btnKnowledgeSearch, new EventArgs());
                    break;
                case (int)EnumHelper.FunctionEnum.Import:
                    break;
                case (int)EnumHelper.FunctionEnum.Position:
                    if (!StaticStateHelper.IsInitPosition.GetValueOrDefault())
                    {
                        this.InitPosition();
                        StaticStateHelper.IsInitPosition = true;
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.Function:
                    if (!StaticStateHelper.IsInitFuction.GetValueOrDefault())
                    {
                        this.BindFunctionData();
                        StaticStateHelper.IsInitFuction = true;
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.Operation:
                    if (!StaticStateHelper.IsInitOperation.GetValueOrDefault())
                    {
                        this.BindOperationData();
                        StaticStateHelper.IsInitOperation = true;
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.Department:
                    if (!StaticStateHelper.IsInitDepartment.GetValueOrDefault())
                    {
                        if (InitDepartmentModel())
                        {
                            StaticStateHelper.IsInitDepartment = true;
                        }
                    }
                    break;
                case (int)EnumHelper.FunctionEnum.Employee:
                    if (!StaticStateHelper.IsInitManager.GetValueOrDefault())
                    {
                        if (InitManagerModel())
                        {
                            StaticStateHelper.IsInitManager = true;
                        }
                        
                    }
                    break;
            }
        }

        #region 呼入模块

        private void LoginCTI()
        {
            if(LoginHelper.IsGodUser)
            {
                this.axCTISrv.login(this.axCTISrv.userName,this.axCTISrv.userName);
            }else
            {
                string[] channels = LoginHelper.GetChannels();
                this.axCTISrv.loginType = 6;
                if (channels.Length >0 )
                {
                    this.cmbTDMXChannel.Items.AddRange(channels);
                    this.cmbTDMXChannel.SelectedIndex = 0;
                    
                }
                if (channels.Length == 1)
                {
                    this.axCTISrv.login(channels[0], "");
                }
            }
        }

        // 登录TDMX
        private void btnLoginTDMX_Click(object sender, EventArgs e)
        {
            if (this.cmbTDMXChannel.SelectedItem != null)
            {
                string channel = this.cmbTDMXChannel.SelectedItem.ToString();
                this.axCTISrv.login(channel, "");
            }
        }

        private void InitAnswerModel()
        {
            var userChannelList = AnswerHelper.GetAllEnableChannels();
            if (userChannelList == null || userChannelList.Count == 0)
                return;

            foreach (var item in userChannelList)
            {
                TelephoneControl control = new TelephoneControl();
                
                control.Name = Ad.Util.Const.TelControlPrefix+item.dstID;
                switch ((int)item.dstStatu)
                {
                    case (int)EnumHelper.LineStateEnum.TIS_IDLE:
                        control.Image = Properties.Resources.standby88;
                        break;
                    case　(int)EnumHelper.LineStateEnum.TIS_DIAL:
                        control.Image = Properties.Resources.talking75;
                        break;
                    case (int)EnumHelper.LineStateEnum.TIS_ONCALL:
                        control.Image = Properties.Resources.belling74;
                        break;
                    case(int)EnumHelper.LineStateEnum.TIS_CONNECT:
                        control.Image = Properties.Resources.connect;
                        break;
                    case (int)EnumHelper.LineStateEnum.TIS_HURRY_HANGUP:
                        control.Image = Properties.Resources.hurryup;
                        break;
                    case (int)EnumHelper.LineStateEnum.TIS_CALLEDRING:
                        control.Image = Properties.Resources.belling74;
                        break;
                    default:
                        control.Image = Properties.Resources.other;
                        break;
                }
                control.LblStateText = EnumHelper.GetDescription<EnumHelper.LineStateEnum>((int)item.dstStatu);
                control.LblUserNameColor = Color.Black;
                control.LblUserNameText = item.pUserName;
                control.LblSeatColor = Color.Black;
                control.LblSeatText = item.dstPhone;
                control.SeatId = item.dstID;
                control.BorderStyle = BorderStyle.Fixed3D;
                control.ContextMenuStrip = cmsOther;
                control.StateId = item.dstStatu;
                if (!LoginHelper.IsGodUser)
                {
                    if (item.dstID == AnswerHelper.CurrentChannelId)
                    {
                        control.ContextMenuStrip = cmsSelf;
                        control.BackColor = Color.LightGreen;
                    }
                }

                control.UserControlMouseUp += telephoneControl_UserControlMouseUp;

                this.flpAnswer.Controls.Add(control);
            }
            if (!LoginHelper.IsGodUser)
            {
                AnswerHelper.RefreshTelStateThread = new Thread(RefreshTDMX);
                AnswerHelper.RefreshTelStateThread.Start();
            }
        }

        private void RefreshTDMX()
        {
            while (true)
            {
                this.axCTISrv.cmdGetOtherIDTisStatu(AnswerHelper.CurrentChannelId, 0, AnswerHelper.GetAllEnableChannels()[0].dstID);
                Thread.Sleep(3000);
            }
        }

        #endregion

        #region 呼出模块
        private void InitCallModel()
        {
            var areaList = SysLoadDataHelper.AreaList;
            if (areaList != null && areaList.Count > 0)
            {
                // 所在区域
                areaList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbCallArea.DataSource = areaList;
                this.cmbCallArea.DisplayMember = "SHOWVALUE";
                this.cmbCallArea.ValueMember = "ID";

                // 初始【地区】
                this.cmbCallProvice.DisplayMember = "SHOWVALUE";
                this.cmbCallProvice.ValueMember = "ID";
            }

            // 初始化【客源】
            var custSourceList = SysLoadDataHelper.CustomerSourcList;
            if (custSourceList != null && custSourceList.Count > 0)
            {
                custSourceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbCallSource.DataSource = custSourceList;
                this.cmbCallSource.DisplayMember = "SHOWVALUE";
                this.cmbCallSource.ValueMember = "ID";
            }

            // 初始化 【性别】
            var sexList = SexHelper.GetSexList();
            sexList.Insert(0, new Sex { Name = "请选择", Value = null });
            this.cmbCallSex.DataSource = sexList;
            this.cmbCallSex.DisplayMember = "Name";
            this.cmbCallSex.ValueMember = "Value";

            // 录入时间
            this.dtpCallEntryDate.Value = DateTime.Now;
        }

        // 检查是否登陆分机
        private void CheckChannelLogin()
        {
            if (!StaticStateHelper.IsInitAllTDMT.GetValueOrDefault())
            {
                this.btnCallDail.Enabled = false;
            }
            else
            {
                this.btnCallDail.Enabled = true;
            }
        }
        // 拨号
        private void btnDail_Click(object sender, EventArgs e)
        {
            this.lblCallDailError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtCallDailPhone.Text))
            {
                this.lblCallDailError.Text = "电话号码不能为空";
                return;
            }
            string phoneStr = this.txtCallDailPhone.Text.Trim();
            if (System.Text.RegularExpressions.Regex.IsMatch(phoneStr, @"[\u4e00-\u9fbb]+"))
            {
                this.lblCallDailError.Text = "电话号码含有汉字";
                return;
            }
            this.axCTISrv.cmdDial(AnswerHelper.CurrentChannelId,phoneStr);
        }

        private void cmbCallArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbCallArea.SelectedValue == null)
            {
                this.cmbCallProvice.DataSource = new List<CTP_ENUM_ITEM>();
                return;
            }
            var proviceList = SysLoadDataHelper.GetProviceList(this.cmbCallArea.SelectedValue.ToString());
            if (proviceList != null && proviceList.Count > 0)
            {
                proviceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbCallProvice.DataSource = proviceList;
            }
        }
        // 1,2...拨号
        private void btn11_Click(object sender, EventArgs e)
        {
            this.txtCallDailPhone.Text += ((Button)sender).Text;
        }

        // 保存
        private void btnCallDetailSave_Click(object sender, EventArgs e)
        {
            this.lblCallError.ForeColor = Color.Red;
            this.lblCallError.Text = string.Empty;
            if (string.IsNullOrWhiteSpace(this.txtCallPhone.Text))
            {
                this.lblCallError.Text = "电话不能为空";
                return;
            }
            string phoneStr = this.txtCallPhone.Text.Trim();
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
                this.lblCallError.Text = "电话号格式错误";
                return;
            }

            if (string.IsNullOrWhiteSpace(this.txtCallCustName.Text))
            {
                this.lblCallError.Text = "客户名称不能为空";
                return;
            }
            if (this.cmbCallArea.SelectedValue == null)
            {
                this.lblCallError.Text = "所在区域不能为空";
                return;
            }
            if (this.cmbCallProvice.SelectedValue == null)
            {
                this.lblCallError.Text = "所在地区不能为空";
                return;
            }
            if (this.cmbCallSex.SelectedValue == null)
            {
                this.lblCallError.Text = "性别不能为空";
                return;
            }
            if (this.cmbCallSource.SelectedValue == null)
            {
                this.lblCallError.Text = "客户来源不能为空";
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtCallEmail.Text))
            {
                if (!Regex.IsMatch(this.txtCallEmail.Text.Trim(), Ad.Util.RegexHelper.reg_Email_str))
                {
                    this.lblCallError.Text = "邮箱地址格式错误";
                    return;
                }
            }
            if (string.IsNullOrWhiteSpace(this.txtCallProduce.Text))
            {
                this.lblCallError.Text = "咨询产品不能为空";
                return;
            }
            if (string.IsNullOrWhiteSpace(this.rtbCallContent.Text))
            {
                this.lblCallError.Text = "咨询内容不能为空";
                return;
            }
            Y_Call_Cust entity = new Y_Call_Cust();
            entity.AreaId = (long)this.cmbCallArea.SelectedValue;
            entity.Area = this.cmbCallArea.Text;
            entity.CustName = this.txtCallCustName.Text.Trim();
            entity.CustSourceId = (long)this.cmbCallSource.SelectedValue;
            entity.CustSource = this.cmbCallSource.Text;
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
            entity.Email = this.txtCallEmail.Text.Trim();
            entity.EntryDate = DateTime.Now;
            entity.Job = this.txtCallJob.Text;
            entity.Phone = phoneStr;
            entity.Tel = this.txtCallPhone.Text;
            entity.Product = this.txtCallProduce.Text.Trim();
            entity.ProvinceId = (long)this.cmbCallProvice.SelectedValue;
            entity.Province = this.cmbCallProvice.Text;
            entity.Question = this.rtbCallContent.Text.Trim();
            entity.Sex = (int)this.cmbCallSex.SelectedValue == 0 ? false : true;

            var result = BllCallCust.Insert(entity);
            if (!result.IsOK)
            {
                this.lblCallError.Text = result.Msg;
            }
            else
            {
                this.rtbCallRemark.Text += "拨出时间： " + entity.EntryDate.Value.ToString("yyyy/MM/dd HH:mm:ss") + Environment.NewLine;
                this.rtbCallRemark.Text += "电话号:    " + phoneStr + Environment.NewLine;
                this.rtbCallRemark.Text += "客户名称： " + this.txtCallCustName.Text.Trim() + Environment.NewLine;
                this.rtbCallRemark.Text += "******************************" + Environment.NewLine;
                this.lblCallError.ForeColor = Color.Green;
                this.lblCallError.Text = "保存成功";
            }
        }

        // 清空
        private void btnCallClearDetail_Click(object sender, EventArgs e)
        {
            this.txtCallPhone.Text = string.Empty;
            this.txtCallCustName.Text = string.Empty;
            this.cmbCallArea.SelectedIndex = 0;
            this.cmbCallSex.SelectedIndex = 0;
            this.cmbCallSource.SelectedIndex = 0;
            this.txtCallEmail.Text = string.Empty;
            this.txtCallJob.Text = string.Empty;
            this.txtCallProduce.Text = string.Empty;
            this.rtbCallContent.Text = string.Empty;
        }
        #endregion

        #region 客户模块
        #endregion

        #region 查询 模块

        private void InitSearchModel()
        {
            // 初始化【区域】
            var areaList = SysLoadDataHelper.AreaList;
            if (areaList != null && areaList.Count > 0)
            {
                areaList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbSchArea.DataSource = areaList;
                this.cmbSchArea.DisplayMember = "SHOWVALUE";
                this.cmbSchArea.ValueMember = "ID";

                // 初始【地区】
                this.cmbSchProvince.DisplayMember = "SHOWVALUE";
                this.cmbSchProvince.ValueMember = "ID";
            }

            // 初始化【客源】
            var custSourceList = SysLoadDataHelper.CustomerSourcList;
            if (custSourceList != null && custSourceList.Count > 0)
            {
                custSourceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbSchSource.DataSource = custSourceList;
                this.cmbSchSource.DisplayMember = "SHOWVALUE";
                this.cmbSchSource.ValueMember = "ID";
            }


            IList<ORG_UNIT> deptList = new List<ORG_UNIT>();
            if (!LoginHelper.IsGodUser)
            {
                deptList.Add(new ORG_UNIT { ID = LoginHelper.GetOrgDeptId(), NAME = LoginHelper.GetOrgDeptName() });
                this.cmbSchDept.Enabled = false;
                if (!LoginHelper.IsHasFunction(EnumHelper.FunctionEnum.Special))
                {
                    this.txtSchStuff.Text = LoginHelper.GetManagerName();
                    this.txtSchStuff.ReadOnly = true;
                }
            }
            else
            {
                // 初始化【部门】
                deptList = SysLoadDataHelper.ImportCustDeptList;
                if (deptList != null & custSourceList.Count > 0)
                {
                    deptList.Insert(0, new ORG_UNIT { NAME = "请选择", ID = null });
                }
            }
            this.cmbSchDept.DataSource = deptList;
            this.cmbSchDept.DisplayMember = "NAME";
            this.cmbSchDept.ValueMember = "ID";

            // 初始化 【性别】
            var sexList = SexHelper.GetSexList();
            sexList.Insert(0, new Sex { Name = "请选择", Value = null });
            this.cmbSchSex.DataSource = sexList;
            this.cmbSchSex.DisplayMember = "Name";
            this.cmbSchSex.ValueMember = "Value";

            DateTime currentDateTime = DateTime.Now;
            int year = currentDateTime.Year;
            int month = currentDateTime.Month;
            int day = currentDateTime.Day;
            this.dtpSchDate1.Value = new DateTime(year, month, day,0,0,0);
            this.dtpSchDate2.Value = new DateTime(year, month, day, 23, 59, 59);

            this.BindSearchData();
        }

        // 区域change
        private void cmbSchArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbSchArea.SelectedValue == null)
            {
                this.cmbSchProvince.DataSource = new List<CTP_ENUM_ITEM>();
                return;
            }
            var proviceList = SysLoadDataHelper.GetProviceList(this.cmbSchArea.SelectedValue.ToString());
            if (proviceList != null && proviceList.Count > 0)
            {
                proviceList.Insert(0, new CTP_ENUM_ITEM { SHOWVALUE = "请选择", ID = null });
                this.cmbSchProvince.DataSource = proviceList;
            }
        }

        private void search_Click(object sender, EventArgs e)
        {
            this.BindSearchData();
        }
        public void BindSearchData()
        {
            string orderString = string.Format(@"#{0} desc", "CustCode");
            VCallCust model = new VCallCust();
            model.CustName = this.txtSchCustName.Text;
            model.Phone = this.txtSchCustPhone.Text;
            if(this.cmbSchArea.SelectedValue !=null)
            {
                model.AreaId = (long)this.cmbSchArea.SelectedValue;
            }
            if(this.cmbSchProvince.SelectedValue != null){
                model.ProvinceId = (long)this.cmbSchProvince.SelectedValue;
            }
            model.StuffName = this.txtSchStuff.Text;
            model.Product = this.txtSchProduce.Text;
            model.Email = this.txtSchMailAddr.Text;
            if(this.cmbSchSource.SelectedValue !=null)
            {
                model.CustSourceId = (long)this.cmbSchSource.SelectedValue;
            }
            model.Job = this.txtSchJob.Text;
            if (this.cmbSchDept.SelectedValue != null)
            {
                model.DeptId = (long)this.cmbSchDept.SelectedValue;
            }
            model.EntryDate1 = this.dtpSchDate1.Value;
            model.EntryDate2 = this.dtpSchDate2.Value;
            if (this.cmbSchSex.SelectedValue != null)
            {
                model.Sex = (int)this.cmbSchSex.SelectedValue;
            }
            model.Question = this.txtSchQuestion.Text;



            var pageList = BllCustomer.SplitCurrentDayStorage(model, null, this.sptSearch.PageSize, this.sptSearch.PageCurrent, orderString);
            this.bdsSearch.DataSource = pageList.Models;
            this.sptSearch.RecordCount = pageList.RecordCount;
        }
        // 【查询】 分页
        private void sptSearch_EventPaging(SplitPage.EventPagingArg e)
        {
            this.BindSearchData();
        }

        // 添加
        private void btnSearchAdd_Click(object sender, EventArgs e)
        {
            FCustAdd fCustAdd = new FCustAdd();
            fCustAdd.Owner = this;
            fCustAdd.ShowDialog();
        }
        #endregion

        #region 知识库

        // 【知识库】查找
        private void knowledgeBase_Click(object sender, EventArgs e)
        {
            this.BindKnowledgeBaseData();
        }

        // 添加新的知识条目
        private void btnKnowledgeAdd_Click(object sender, EventArgs e)
        {
            FKnowledgeAdd fKnowledgeAdd = new FKnowledgeAdd();
            fKnowledgeAdd.Owner = this;
            fKnowledgeAdd.ShowDialog();
        }

        // 【知识库】分页
        private void sptKnowledge_EventPaging(SplitPage.EventPagingArg e)
        {
            this.BindKnowledgeBaseData();
        }

        
        // 【知识库】绑定数据
        public void BindKnowledgeBaseData()
        {
            string orderString = string.Format(@"#{0} asc ", Y_KnowledgeBase_Description.KnowledgeCode);
            var knowledgeList = BllKnowledgeBase.SelectSplit(new VM_KnowledgeBase { Title = this.txtKnowledgeTitle.Text, KeyWords = this.txtKnowledgeKeyWords.Text },
                new string[]{Y_KnowledgeBase_Description.KnowledgeCode,Y_KnowledgeBase_Description.Title,Y_KnowledgeBase_Description.KeyWords,
                Y_KnowledgeBase_Description.Suffix,Y_KnowledgeBase_Description.UpdateDate,Y_KnowledgeBase_Description.CreateDate},
                this.sptKnowledge.PageSize, this.sptKnowledge.PageCurrent, orderString);
            this.bdsKnowledge.DataSource = knowledgeList.Models;
            this.sptKnowledge.RecordCount = knowledgeList.RecordCount;
        }

        // 【知识库】点击单元格
        private void dgvKnowledge_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;

            var cellObj = this.dgvKnowledge.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
            if (cellObj == null)
                return;

            // 点击cell的value
            string currentValue = cellObj.ToString();
            // 当前列名
            string currentColumnName = this.dgvKnowledge.Columns[e.ColumnIndex].Name;
            string title = this.dgvKnowledge.Rows[e.RowIndex].Cells["Know_Title"].Value.ToString();
            string knowledgeId = this.dgvKnowledge.Rows[e.RowIndex].Cells["Know_Code"].Value.ToString();
            string suffix = this.dgvKnowledge.Rows[e.RowIndex].Cells["Know_Suffix"].Value.ToString();
            if (currentColumnName == "Know_Detail")
            {
                var knowledgeList = BllKnowledgeBase.Select(null, string.Format(@"{0}=@{0}", Y_KnowledgeBase_Description.KnowledgeCode), new object[] { knowledgeId }, false);
                if (knowledgeList != null && knowledgeList.Count > 0)
                {
                    Y_KnowledgeBase entity = knowledgeList.First();
                    string dir = Path.Combine(Environment.CurrentDirectory, Ad.Util.Const.KnowledgeBaseDir);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string showFileNameWithoutExtension = Ad.Util.Const.KnowledgeBaseDir + knowledgeId + "_" + entity.UpdateDate.Value.ToString("yyMMddHHmmss");
                    string unzipFilePath = Path.Combine(dir, showFileNameWithoutExtension + "." + suffix);
                    if (!File.Exists(unzipFilePath))
                    {
                        string zipFilePath = Path.Combine(dir, showFileNameWithoutExtension + ".zip");
                        if (!File.Exists(zipFilePath))
                        {
                            FileStream fs = new FileStream(zipFilePath, FileMode.Create);
                            fs.Write(entity.Content, 0, entity.Content.GetUpperBound(0));
                            fs.Close();
                        }
                        string simpleFileName = showFileNameWithoutExtension + "." + entity.Suffix;
                        if (!FileUpLoad.UnZipFile(zipFilePath, dir, simpleFileName, null))
                        {
                            MessageBox.Show("解压错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        System.Diagnostics.Process.Start(Path.Combine(dir, simpleFileName));
                    }
                    else
                    {
                        System.Diagnostics.Process.Start(unzipFilePath);
                    }


                }
            }
            else if (currentColumnName == "Know_DownLoad")
            {
                var knowledgeList = BllKnowledgeBase.Select(null, string.Format(@"{0}=@{0}", Y_KnowledgeBase_Description.KnowledgeCode), new object[] { knowledgeId }, false);
                if (knowledgeList != null && knowledgeList.Count > 0)
                {
                    Y_KnowledgeBase entity = knowledgeList.First();
                    string dir = Path.Combine(Environment.CurrentDirectory, Ad.Util.Const.KnowledgeBaseDir);
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string showFileNameWithoutExtension = Ad.Util.Const.KnowledgeBaseDir + knowledgeId + "_" + entity.UpdateDate.Value.ToString("yyMMddHHmmss");
                    string unzipFilePath = Path.Combine(dir, showFileNameWithoutExtension + "." + suffix);
                    if (!File.Exists(unzipFilePath))
                    {
                        string zipFilePath = Path.Combine(dir, showFileNameWithoutExtension + ".zip");
                        if (!File.Exists(zipFilePath))
                        {
                            FileStream fs = new FileStream(zipFilePath, FileMode.Create);
                            fs.Write(entity.Content, 0, entity.Content.GetUpperBound(0));
                            fs.Close();
                        }
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.FileName = entity.Title;
                        sfd.DefaultExt = entity.Suffix;
                        sfd.Filter = "|*." + entity.Suffix;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            string simpleFileName = showFileNameWithoutExtension + "." + entity.Suffix;
                            if (!FileUpLoad.UnZipFile(zipFilePath, dir, simpleFileName, null))
                            {
                                MessageBox.Show("解压错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            try
                            {
                                File.Copy(Path.Combine(dir, simpleFileName), sfd.FileName);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("赋值文件错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                    }
                    else
                    {
                        SaveFileDialog sfd = new SaveFileDialog();
                        sfd.FileName = title;
                        sfd.DefaultExt = suffix;
                        sfd.Filter = "|*." + suffix;
                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                File.Copy(unzipFilePath, sfd.FileName);
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("赋值文件错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }


                }
            }
            else if (currentColumnName == "Know_Update")
            {
                FKnowledgeEdit fknowledgeEidt = new FKnowledgeEdit();
                if (fknowledgeEidt.BindData(knowledgeId))
                {
                    fknowledgeEidt.Owner = this;
                    fknowledgeEidt.ShowDialog();
                }
                else
                {
                    fknowledgeEidt.Dispose();
                    MessageBox.Show("打开失败，请刷新后再尝试打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (currentColumnName == "Know_Delete")
            {
                if (string.IsNullOrWhiteSpace(knowledgeId))
                {
                    MessageBox.Show("打开失败，请刷新后再尝试打开", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (DialogResult.OK == MessageBox.Show("确定删除 " + title + " ", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning))
                {
                    if (!BllKnowledgeBase.Delete(knowledgeId).IsOK)
                    {
                        MessageBox.Show("删除失败", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        this.BindKnowledgeBaseData();
                    }
                }
            }
        }
        #endregion

        #region  导入 模块
        // 改变模板
        private void cmbImportTempType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbImportTempType.SelectedIndex < 0)
            {
                this.dgvImportTemp.Columns.Clear();
            }
            else if (this.cmbImportTempType.SelectedIndex == 0)
            {
                DisplayCustTemplate();
            }
        }

        // 客户模板
        private void DisplayCustTemplate()
        {
            foreach (string name in ExcelTempBuild.custTitleArr)
            {
                DataGridViewColumn column = new DataGridViewColumn();
                column.HeaderText = name;
                column.Width = 80;
                this.dgvImportTemp.Columns.Add(column);
            }
        }

        // 生产模板
        private void btnImportTempCreate_Click(object sender, EventArgs e)
        {
            if (this.cmbImportTempType.SelectedIndex < 0)
            {
                return;
            }
            SaveFileDialog fileDialog = new SaveFileDialog();
            fileDialog.Filter = "excel | *.xls";
            fileDialog.DefaultExt = "excel | *.xls";
            fileDialog.FileName = "呼叫中心——客户资料";

            try
            {
                if (fileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var ms = ExcelTempBuild.CustTemplateCreat();
                    using (FileStream fs = new FileStream(fileDialog.FileName, FileMode.Create, FileAccess.Write))
                    {
                        byte[] data = ms.ToArray();
                        fs.Write(data, 0, data.Length);
                        fs.Flush();
                    }
                }
            }
            catch (Exception e1)
            {
                MessageBox.Show("模板生产失败" + Environment.NewLine + e1.Message);
            }
        }

        // 导入数据
        private void btnImportTempImport_Click(object sender, EventArgs e)
        {
            Ad.Model.StaticConst.ImportErrorMsg = "EOF";
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "Excel|*.xls;*.xlsx";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                Thread checkThread = new Thread(RunCheck);
                FProgessBar progessBar = new FProgessBar();
                checkThread.Start(new CommonClass { Item1 = fd.FileName, Item2 = progessBar, Item3 = checkThread });

                progessBar.Title = "正在检查数据，请耐心等待";
                progessBar.Owner = this;
                progessBar.ShowDialog();
            }
        }
        private void RunCheck(object obj)
        {
            CommonClass commonClass = (CommonClass)obj;
            string excelName = commonClass.Item1.ToString();
            FProgessBar progessBar = (FProgessBar)(commonClass.Item2);
            Thread thread = (Thread)(commonClass.Item3);
            CustomerExcelHelper customerExcelHelper = new CustomerExcelHelper(excelName);

            int totalRowNum;

            // 检查数据
            string errorString = customerExcelHelper.CheckImportCustomerExcel(out totalRowNum);
            if (!string.IsNullOrEmpty(errorString))
            {

                FCustomerImpInfo fce = new FCustomerImpInfo("错误", errorString, Color.Red);
                fce.Owner = this;
                this.Invoke(new MethodInvoker(delegate
                {
                    progessBar.Dispose();
                    fce.ShowDialog();
                }));

                if (thread != null && thread.IsAlive)
                {
                    thread.Abort();
                }
            }

            this.Invoke(new MethodInvoker(delegate
            {
                progessBar.Maximum = totalRowNum;
                progessBar.Minimum = 0;
                progessBar.Value = 0;
            }));


            Thread importThread = new Thread(RunImport);
            importThread.Start(new CommonClass
            {
                Item1 = customerExcelHelper,
                Item2 = progessBar,
                Item3 = thread,
                Item4 = importThread
            });
            // 导入数据
            Ad.Model.StaticConst.ImportErrorMsg = customerExcelHelper.InsertToDataBaseOneByOne();

        }

        private void RunImport(object obj)
        {
            CommonClass commonClass = (CommonClass)obj;
            CustomerExcelHelper customerExcelHelper = (CustomerExcelHelper)commonClass.Item1;
            FProgessBar progessBar = (FProgessBar)(commonClass.Item2);
            Thread checkThread = (Thread)(commonClass.Item3);
            Thread importThread = (Thread)(commonClass.Item4);
            while (true)
            {
                Thread.CurrentThread.Join(500);
                int num = customerExcelHelper.GetInsertedRowNum();
                double percent = Math.Round((num * 100.0) / progessBar.Maximum, 2);
                this.Invoke(new MethodInvoker(delegate
                {
                    progessBar.Value = num;
                    progessBar.Title = "已完成完成 " + percent + "%";
                }));

                if (Ad.Model.StaticConst.ImportErrorMsg != "EOF")
                {
                    FCustomerImpInfo fce2 = null;
                    if (Ad.Model.StaticConst.ImportErrorMsg == null)
                    {

                        fce2 = new FCustomerImpInfo("提示", "导入成功", Color.Black);
                        fce2.Owner = this;

                    }
                    else
                    {
                        fce2 = new FCustomerImpInfo("错误", Ad.Model.StaticConst.ImportErrorMsg, Color.Red);
                        fce2.Owner = this;
                        fce2.ShowDialog();
                    }

                    this.Invoke(new MethodInvoker(delegate
                    {
                        progessBar.Dispose();
                        fce2.ShowDialog();
                    }));
                    Thread.CurrentThread.Join(500);

                    if (importThread != null && importThread.IsAlive)
                    {
                        importThread.Abort();
                    }
                    if (checkThread != null && checkThread.IsAlive)
                    {
                        checkThread.Abort();
                    }
                    break;
                }
            }

        }
        #endregion

        #region 员工

        public bool InitManagerModel()
        {
            var deptList = DeptPosiHelper.GetDepartMent();
            if (deptList == null || deptList.Count == 0)
                return false;

            deptList.Insert(0, new Y_Department() { DepartName = "请选择", DepartId = null });
            this.cmbDept.DataSource = deptList;
            this.cmbDept.DisplayMember = "DepartName";
            this.cmbDept.ValueMember = "DepartId";
            this.cmbPosition.DisplayMember = "PostName";
            this.cmbPosition.ValueMember = "PostId";
            BindManagerData();
            return true;
        }

        private void cmbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDept.SelectedValue == null)
            {
                this.cmbPosition.DataSource = new List<Y_Position>();
                return;
            }

            var deptPosiList = DeptPosiHelper.GetDeptPosition();
            if (deptPosiList == null)
                return;

            var ls = deptPosiList.Where(m => m.DepartId.ToString().Equals(this.cmbDept.SelectedValue.ToString()));
            if (!ls.Any())
                return;

            var positionList = DeptPosiHelper.GetPosition();
            List<Y_Position> toPosiDisplayList = new List<Y_Position>();
            foreach (var item in ls)
            {
                var postIEnum = positionList.Where(m => m.PostId.ToString().Equals(item.PostId.ToString()));
                if (postIEnum.Any())
                {
                    toPosiDisplayList.Add(postIEnum.First());
                }
            }
            if (toPosiDisplayList.Count > 0)
            {
                toPosiDisplayList.Insert(0, new Y_Position() { PostName = "请选择", PostId = null });
            }
            this.cmbPosition.DataSource = toPosiDisplayList;
        }

        public void BindManagerData()
        {
            string orderString = string.Format(@" #{0} asc", Y_V_Manager_Description.ManagerId);
            Y_V_Manager model = new Y_V_Manager();
            model.NAME = this.txtManagerName.Text;
            long postId, deptId;
            if (this.cmbPosition.SelectedValue != null)
            {
               if(long.TryParse(this.cmbPosition.SelectedValue.ToString(),out postId))
               {
                   model.PostId = postId;
               }
            }
            if (this.cmbDept.SelectedValue != null)
            {
                if (long.TryParse(this.cmbDept.SelectedValue.ToString(), out deptId))
                {
                    model.DepartId = deptId;
                }
            }
            var pageList = BllManager.SplitManager(model, null, this.sptManager.PageSize, this.sptManager.PageCurrent, orderString);
            this.bdsManager.DataSource = pageList.Models;
            this.sptManager.RecordCount = pageList.RecordCount;
        }

        private void sptManager_EventPaging(SplitPage.EventPagingArg e)
        {
            this.BindManagerData();
        }


        private void btnManagerSearch_Click(object sender, EventArgs e)
        {
            this.BindManagerData();
        }

        private void btnMangerAdd_Click(object sender, EventArgs e)
        {
            FManagerAdd fManagerAdd = new FManagerAdd();
            fManagerAdd.Owner = this;
            fManagerAdd.ShowDialog();
        }

        private void dgvManager_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            string currentColumnName = this.dgvManager.Columns[e.ColumnIndex].Name;
            string managerIdStr = this.dgvManager.Rows[e.RowIndex].Cells["Manager_Id"].Value.ToString();
            string managerName = this.dgvManager.Rows[e.RowIndex].Cells["Manager_Name"].Value.ToString();
            if(string.IsNullOrWhiteSpace(managerIdStr))
                return;
            long managerId;
            if (!long.TryParse(managerIdStr, out managerId))
            {
                MessageBox.Show("员工ID格式错误!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (currentColumnName.Equals("Manager_Update"))
            {
                if (null != this.bdsManager.DataSource)
                {
                    try
                    {
                        var managerList = (IEnumerable<Y_V_Manager>)this.bdsManager.DataSource;
                        var selManagerIEnum = managerList.Where(m => m.ManagerId.ToString().Equals(managerIdStr));
                        if (selManagerIEnum.Any())
                        {
                            FManagerEdit fManagerEdit = new FManagerEdit(selManagerIEnum.First());
                            fManagerEdit.Owner = this;
                            fManagerEdit.ShowDialog();
                        }
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                
            }
            else if (currentColumnName.Equals("Manager_Delete"))
            {
                if (DialogResult.OK == MessageBox.Show(this, "是否删除（" + managerName + "）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    if (string.IsNullOrWhiteSpace(managerIdStr))
                    {
                        MessageBox.Show("员工ID为空!","错误",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }
                   
                    var resultU = BllManager.DeleteById(managerId);
                    if (!resultU.IsOK)
                    {
                        MessageBox.Show(resultU.Msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.BindManagerData();
                    }
                }
            }
            else if (currentColumnName.Equals("Manager_Pwd"))
            {
                if (DialogResult.OK == MessageBox.Show(this, "是否确认重置（" + managerName + "）的密码", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    if (string.IsNullOrWhiteSpace(managerIdStr))
                    {
                        MessageBox.Show("员工ID为空!", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    Y_Manager entity = new Y_Manager();
                    entity.ManagerId = managerId;
                    entity.Pwd = Ad.Security.MD5.Instance.BuildFingerprint(Ad.Util.Const.InitPwd);
                    var resultU = BllManager.Update(entity);
                    if (!resultU.IsOK)
                    {
                        MessageBox.Show(resultU.Msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        this.BindManagerData();
                    }
                }
            }
        }

        #endregion

        #region 部门
        private bool InitDepartmentModel()
        {
            var initResult = BllDepartment.InitDeptSelectThreeLevel();
            if (!initResult.IsOK)
            {
                MessageBox.Show(initResult.Msg, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (!DeptNodeHelper.InitBindNode(this.trvDept, initResult.Data))
            {
                MessageBox.Show(this,"绑定错误", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        // 选择部门
        private void trvDept_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node != null)
            {
                e.Node.BackColor = Color.Blue;
                //this.trvDept.SelectedNode.BackColor = Color.Blue;
                if (DeptNodeHelper.SelectedTreeNode != null)
                {
                    DeptNodeHelper.SelectedTreeNode.BackColor = SystemColors.Window;
                }
                DeptNodeHelper.SelectedTreeNode = e.Node;
                //DeptNodeHelper.SelectedTreeNode = this.trvDept.SelectedNode;
                Y_Department parentDeptEntity = (Y_Department)e.Node.Tag;
                var selectList = BllDepartment.SelectByParentCodeTwoLevel(parentDeptEntity.Code);
                if (DeptNodeHelper.BindNode(e.Node, selectList))
                {
                    List<Y_Department> deptList = new List<Y_Department>();
                    if (e.Node.Nodes.Count > 0)
                    {
                        for (int i = 0; i < e.Node.Nodes.Count; i++)
                        {
                            deptList.Add((Y_Department)e.Node.Nodes[i].Tag);
                        }
                    }
                    this.dgvDept.DataSource = deptList;
                    this.dgvDept.Refresh();
                }
                else
                {
                    MessageBox.Show("选择部门错误");
                }
            }
        }

        // 添加部门
        private void btnAddDept_Click(object sender, EventArgs e)
        {
            if (this.trvDept.SelectedNode != null)
            {
                Y_Department deptEntity = (Y_Department)this.trvDept.SelectedNode.Tag;
                if (deptEntity == null)
                    return;
                FDepartmentAdd fDepartmentAdd = new FDepartmentAdd(deptEntity.Code);
                fDepartmentAdd.Owner = this;
                fDepartmentAdd.ShowDialog();
            }
        }

        public void RefreshTreeViewAndDataGridView()
        {
            this.trvDept_AfterSelect(this.trvDept, new TreeViewEventArgs(this.trvDept.SelectedNode));
        }

        // 部门更新，修改，职位分配
        private void dgvDept_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            // 当前列名
            string currentColumnName = this.dgvDept.Columns[e.ColumnIndex].Name;
            string deptId = this.dgvDept.Rows[e.RowIndex].Cells["Dept_Id"].Value.ToString();
            if (currentColumnName == "Dept_Position")
            {
                string hasChildStr = this.dgvDept.Rows[e.RowIndex].Cells["Dept_HasChild"].Value.ToString();
                if (hasChildStr.ToUpper().Equals("TRUE"))
                {
                    return;
                }
                long deptIdNum;
                if (!long.TryParse(deptId, out deptIdNum))
                {
                    MessageBox.Show("部门编码错误");
                    return;
                }
                FDeptPosition fDeptPosition = new FDeptPosition(deptIdNum);
                fDeptPosition.Owner = this;
                fDeptPosition.ShowDialog();
            }
            else if (currentColumnName == "Dept_Update")
            {
                FDepartmentEdit fDepartmentEdit = new FDepartmentEdit();
                fDepartmentEdit.Owner = this;
                if (fDepartmentEdit.SelectDepartmen(deptId))
                {
                    fDepartmentEdit.ShowDialog();
                }
                else
                {
                    fDepartmentEdit.Dispose();
                    MessageBox.Show("查找时发生错误");
                }
            }
            else if (currentColumnName == "Dept_Delete")
            {
                string deptName = this.dgvDept.Rows[e.RowIndex].Cells["Dept_Name"].Value.ToString();

                if (DialogResult.OK == MessageBox.Show(this, "是否删除（" + deptName + "）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    if (string.IsNullOrWhiteSpace(deptId))
                    {
                        MessageBox.Show("部门ID为空!");
                        return;
                    }
                    var resultU = BllDepartment.Delete(deptId);
                    if (!resultU.IsOK)
                    {
                        MessageBox.Show(resultU.Msg);
                        return;
                    }
                    else
                    {
                        this.RefreshTreeViewAndDataGridView();
                    }
                }
            }
        }

        // 只有子节点可分配权限
        private void dgvDept_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                string hasChildStr = this.dgvDept.Rows[e.RowIndex].Cells["Dept_HasChild"].Value.ToString();
                var cell = (DataGridViewLinkCell)this.dgvDept.Rows[e.RowIndex].Cells["Dept_Position"];
                if (hasChildStr.ToUpper().Equals("TRUE"))
                {
                    cell.ReadOnly = true;
                    cell.TrackVisitedState = false;
                    cell.LinkColor = Color.Gray;
                    cell.LinkBehavior = LinkBehavior.NeverUnderline;
                    cell.Value = "不可分配";
                }
                else
                {
                    cell.Value = "分配职位";
                }
            }

            
        }
        #endregion

        #region 职位 模块
        private void btnPostSearch_Click(object sender, EventArgs e)
        {
            this.BindPositionData(); 
        }
        private void btnPostAdd_Click(object sender, EventArgs e)
        {
            FPositionAdd fPositionAdd = new FPositionAdd();
            fPositionAdd.Owner = this;
            fPositionAdd.ShowDialog();
        }

        private void InitPosition()
        {
            this.cmbPostPermission.DataSource = new List<CommonClass> 
            { 
                new CommonClass { Item1 = null, Item2 = null }, 
                new CommonClass { Item1 = false, Item2 = "未分配" }, 
                new CommonClass { Item1 = true, Item2 = "已分配" } 
            };
            this.cmbPostPermission.ValueMember = "Item1";
            this.cmbPostPermission.DisplayMember = "Item2";
            this.BindPositionData();
        }
        public void BindPositionData()
        {
            Y_Position entity = new Y_Position();
            entity.PostName = this.txtPost.Text;
            if (this.cmbPostPermission.SelectedIndex > -1)
            {
                if (this.cmbPostPermission.SelectedValue != null)
                {
                    entity.IsDistribution = (bool)this.cmbPostPermission.SelectedValue;
                }
            }
            this.bdsPosition.DataSource = BllPosition.Select(entity);
        }

        private void dgvPosition_CellClick(object sender, DataGridViewCellEventArgs e)
        {
             if (e.ColumnIndex == -1 || e.RowIndex == -1)
                return;
            // 当前列名
            string currentColumnName = this.dgvPosition.Columns[e.ColumnIndex].Name;
            string postId = this.dgvPosition.Rows[e.RowIndex].Cells["Post_PostId"].Value.ToString();
            if (currentColumnName == "Post_DistPermission")
            {
                FPosiFuncOper fPosiFuncOper = new FPosiFuncOper();
                fPosiFuncOper.Owner = this;
                var posiFunOperResult = fPosiFuncOper.InitCrol(postId);
                if (posiFunOperResult.IsOK)
                {
                    fPosiFuncOper.ShowDialog();
                }
                else
                {
                    fPosiFuncOper.Dispose();
                    MessageBox.Show(posiFunOperResult.Msg);
                }
            }
            else if (currentColumnName == "Post_Update")
            {
                FPositionEdit fPositionEdit = new FPositionEdit();
                fPositionEdit.Owner = this;
                var posiResult = fPositionEdit.SelectPostion(postId);
                if (posiResult.IsOK)
                {
                    fPositionEdit.ShowDialog();
                }
                else
                {
                    fPositionEdit.Dispose();
                    MessageBox.Show(posiResult.Msg);
                }
            }
            else if (currentColumnName == "Post_Delete")
            {
                string posiName = this.dgvPosition.Rows[e.RowIndex].Cells["Post_PostName"].Value.ToString();

                if (DialogResult.OK == MessageBox.Show(this, "是否删除（" + posiName + "）", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information))
                {
                    if (string.IsNullOrWhiteSpace(postId))
                    {
                        MessageBox.Show("职位ID为空!");
                        return;
                    }
                    var resultU = BllPosition.DeleteById(postId);
                    if (!resultU.IsOK)
                    {
                        MessageBox.Show(resultU.Msg);
                        return;
                    }
                    else
                    {
                        this.BindPositionData();
                    }
                }
            }
        }

        #endregion

        #region 功能  模块
        private void btnFuncCreate_Click(object sender, EventArgs e)
        {
            try
            {
                int i = 0;
                List<Y_Function> funList = new List<Y_Function>();
                foreach (EnumHelper.FunctionEnum pEnum in Enum.GetValues(typeof(EnumHelper.FunctionEnum)))
                {
                    Y_Function entity = new Y_Function();
                    entity.FunctionId = i++;
                    entity.FunctionName = EnumHelper.GetDescript(pEnum);
                    entity.FunctionType = (int)pEnum;
                    funList.Add(entity);
                }
                var result =  BllFunction.Insert(funList,true);
                if (result.IsOK)
                {
                    this.BindFunctionData();
                }
                else
                {
                    MessageBox.Show(result.Msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        public void BindFunctionData()
        {
            this.bdsFunction.DataSource = BllFunction.Select();
        }
        #endregion

        #region 操作 模块
        private void btnOperCreate_Click(object sender, EventArgs e)
        {
            int i = 0;
            try
            {
                List<Y_Operation> operList = new List<Y_Operation>();
                foreach (EnumHelper.OperationEnum pEnum in Enum.GetValues(typeof(EnumHelper.OperationEnum)))
                {
                    Y_Operation entity = new Y_Operation();
                    entity.OperationId = i++;
                    entity.OperationType = (int)pEnum;
                    entity.OperationName = EnumHelper.GetDescript(pEnum);
                    operList.Add(entity);
                }
                var result = BllOperation.Insert(operList, true);
                if (result.IsOK)
                {
                    this.BindOperationData();
                }
                else
                {
                    MessageBox.Show(result.Msg);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void BindOperationData()
        {
            this.bdsOperation.DataSource = BllOperation.Select();
        }
        #endregion


        //  右键(细节控制)
        private void telephoneControl_UserControlMouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                AnswerHelper.SelectedTelControl = null;
                AnswerHelper.SelectedTelControl = (TelephoneControl)sender;
                if (AnswerHelper.SelectedTelControl.SeatId == AnswerHelper.CurrentChannelId)
                {
                    // 自己的电话
                }
                else
                {
                    // 其他电话
                    short statusId = AnswerHelper.SelectedTelControl.StateId.GetValueOrDefault();
                }
            }

            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 修改密码
        private void pwtPassword_userControlClicked(object sender, EventArgs e)
        {
            FPwdChange fPwdChange = new FPwdChange();
            fPwdChange.Owner = this;
            fPwdChange.ShowDialog();
        }

        #region CTI 事件
        // cti插件登录错误 【事件】
        private void axCTISrv_loginErr(object sender, AxwpCTIOcx.__CTISrv_loginErrEvent e)
        {
            if (this.pnlLoginTDMX.Visible)
            {
                this.lblLoginTDMXError.Text = e.errCode + " : " + e.errDesc;
            }
            else
            {
                MessageBox.Show("登录TDMx交换机发生错误 ---" + e.errCode + ":" + e.errDesc,
                    "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // cti插件登录成功【事件】
        private void axCTISrv_loginOK(object sender, AxwpCTIOcx.__CTISrv_loginOKEvent e)
        {

            LoginAndFlpToggle();
            if (e.iD < 1024)
            {
                AnswerHelper.CurrentChannelId = e.iD;
            }
            if (AnswerHelper.AllChannelEntityList.Count == 0)
            {
                this.axCTISrv.cmdGetOtherIDTisStatu(AnswerHelper.CurrentChannelId, 0, 0);
            }
            
        }

        // 得到所有可用channel 【事件】
        private void axCTISrv_otherIDTisInfoArrival4(object sender, AxwpCTIOcx.__CTISrv_otherIDTisInfoArrival4Event e)
        {
            if (!StaticStateHelper.IsInitAllTDMT.GetValueOrDefault())
            {
                if (e.dstID == -1)
                {
                    StaticStateHelper.IsInitAllTDMT = true;
                    InitAnswerModel();
                    return;
                }
                short d = (short)(e.dstID + 1);
                // 当前分机号码
                if (e.dstID == AnswerHelper.CurrentChannelId)
                {
                    AnswerHelper.CurrentSeatPhone = e.dstPhone;
                }
                AnswerHelper.AllChannelEntityList.Add(new UserChannel
                {
                    iD = e.iD,
                    cardType = e.cardType,
                    dstID = e.dstID,
                    dstPhone = e.dstPhone,
                    dstStatu = e.dstStatu,
                    dstUserName = e.dstUserName,
                    dstUserType = e.dstUserType,
                    mixdata = e.mixdata,
                    moduleStatus = e.moduleStatus,
                    morningCallTime = e.morningCallTime,
                    signal = e.signal,
                    simStatus = e.simStatus,
                    srvCls = e.srvCls,
                    userType = e.userType
                });
                this.axCTISrv.cmdGetOtherIDTisStatu(AnswerHelper.CurrentChannelId, 0, d);
            }
            else
            {
                if (e.dstID == -1)
                {
                    return;
                }
                if (e.dstID != AnswerHelper.CurrentChannelId)
                {
                    string controlName = Ad.Util.Const.TelControlPrefix + e.dstID;
                    Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
                    try
                    {
                        if (controls != null && controls.Length > 0)
                        {
                            TelephoneControl telcontrol = (TelephoneControl)controls[0];
                            switch ((int)e.dstStatu)
                            {
                                case (int)EnumHelper.LineStateEnum.TIS_IDLE:
                                    telcontrol.Image = Properties.Resources.standby88;
                                    break;
                                case (int)EnumHelper.LineStateEnum.TIS_DIAL:
                                    telcontrol.Image = Properties.Resources.talking75;
                                    break;
                                case (int)EnumHelper.LineStateEnum.TIS_ONCALL:
                                    telcontrol.Image = Properties.Resources.belling74;
                                    break;
                                case (int)EnumHelper.LineStateEnum.TIS_CONNECT:
                                    telcontrol.Image = Properties.Resources.connect;
                                    break;
                                case (int)EnumHelper.LineStateEnum.TIS_HURRY_HANGUP:
                                    telcontrol.Image = Properties.Resources.hurryup;
                                    break;
                                case (int)EnumHelper.LineStateEnum.TIS_CALLEDRING:
                                    telcontrol.Image = Properties.Resources.belling74;
                                    break;
                                default:
                                    telcontrol.Image = Properties.Resources.other;
                                    break;
                            }
                            telcontrol.LblStateText = EnumHelper.GetDescription<EnumHelper.LineStateEnum>((int)e.dstStatu);
                        }
                    }
                    catch (Exception ex) { }
                }
                short d = (short)(e.dstID + 1);
                while (!AnswerHelper.GetAllEnableChannels().Where(m => m.dstID == d).Any())
                {
                    d++;
                    if (d > 1023)
                        break;
                }
                if (d < 1024)
                {
                    this.axCTISrv.cmdGetOtherIDTisStatu(AnswerHelper.CurrentChannelId, 0, d);
                }
            }
        }

        // 回铃 【事件】
        private void axCTISrv_onCall(object sender, AxwpCTIOcx.__CTISrv_onCallEvent e)
        {
            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.belling74;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_ONCALL);

                    var channelEnumList = AnswerHelper.GetAllEnableChannels().Where(m => m.iD == e.iD);
                    if (channelEnumList.Any())
                    {
                        UserChannel userChannel = channelEnumList.First();
                        FBombScreen fBombScreen = new FBombScreen(userChannel.dstPhone,userChannel.iD);
                        fBombScreen.Owner = this;
                        fBombScreen.ShowDialog();
                    }
                }
            }
            catch (Exception ex) { }
        }

        //维护忙 【事件】
        private void axCTISrv_outOfService(object sender, AxwpCTIOcx.__CTISrv_outOfServiceEvent e)
        {
            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.other;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_OUTOFSERVICE);
                }
            }
            catch (Exception ex) { }
        }

        //空闲 【事件】
        private void axCTISrv_idle(object sender, AxwpCTIOcx.__CTISrv_idleEvent e)
        {
            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.standby88;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_IDLE);
                }
            }
            catch (Exception ex) { }

            if (AnswerHelper.CallTimer.IsRunning)
            {
                TimeSpan timeSpan = AnswerHelper.CallTimer.Elapsed;
                AnswerHelper.CallTimer.Reset();
                int hour = timeSpan.Hours;
                int min = timeSpan.Minutes;
                int sec = timeSpan.Seconds;
                Y_Call_Log callLogEntity = new Y_Call_Log();
                callLogEntity.ChannelNo = e.iD;
                callLogEntity.Phone = AnswerHelper.PhoneNum;
                callLogEntity.SeatPhone = AnswerHelper.CurrentSeatPhone;
                callLogEntity.StartTime = AnswerHelper.StartTime;
                callLogEntity.TalkTime = hour.ToString("00") + ":" + min.ToString("00") +":"+ sec.ToString("00");
                BllCallLog.Insert(callLogEntity);
            }
        }

        //通话 【事件】
        private void axCTISrv_connected(object sender, AxwpCTIOcx.__CTISrv_connectedEvent e)
        {
            if (AnswerHelper.CallTimer.IsRunning)
            {
                AnswerHelper.CallTimer.Reset();
            }
            AnswerHelper.CallTimer.Start();
            AnswerHelper.PhoneNum = e.assPhone;
            AnswerHelper.StartTime = DateTime.Now;

            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.connect;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_CONNECT);
                }
            }
            catch (Exception ex) { }
        }

        //催挂 【事件】
        private void axCTISrv_hurryHangUp(object sender, AxwpCTIOcx.__CTISrv_hurryHangUpEvent e)
        {
            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.hurryup;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_HURRY_HANGUP);
                }
            }
            catch (Exception ex) { }

            if (AnswerHelper.CallTimer.IsRunning)
            {
                TimeSpan timeSpan = AnswerHelper.CallTimer.Elapsed;
                AnswerHelper.CallTimer.Reset();
                int hour = timeSpan.Hours;
                int min = timeSpan.Minutes;
                int sec = timeSpan.Seconds;
                Y_Call_Log callLogEntity = new Y_Call_Log();
                callLogEntity.ChannelNo = e.iD;
                callLogEntity.Phone = AnswerHelper.PhoneNum;
                callLogEntity.SeatPhone = AnswerHelper.CurrentSeatPhone;
                callLogEntity.StartTime = AnswerHelper.StartTime;
                callLogEntity.TalkTime = hour.ToString("00") + ":" + min.ToString("00") + ":" + sec.ToString("00");
                BllCallLog.Insert(callLogEntity);
            }
        }

        //拨号 【事件】
        private void axCTISrv_dial(object sender, AxwpCTIOcx.__CTISrv_dialEvent e)
        {
            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.talking75;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_DIAL);
                }
            }
            catch (Exception ex) { }
        }

        //被叫振铃 【事件】
        private void axCTISrv_calledRing(object sender, AxwpCTIOcx.__CTISrv_calledRingEvent e)
        {
            FBombScreen fBombScreen = new FBombScreen(e.assPhone, e.iD);
            fBombScreen.Owner = this;
            fBombScreen.ShowDialog();

            string controlName = Ad.Util.Const.TelControlPrefix + e.iD;
            Control[] controls = this.flpAnswer.Controls.Find(controlName, true);
            try
            {
                if (controls != null && controls.Length > 0)
                {
                    TelephoneControl telcontrol = (TelephoneControl)controls[0];
                    telcontrol.Image = Properties.Resources.belling74;
                    telcontrol.LblStateText = EnumHelper.GetDescript(EnumHelper.LineStateEnum.TIS_ONCALL);
                }
            }
            catch (Exception ex) { }
        }


        // 入中继分配
        private void axCTISrv_inTrunkAllocated(object sender, AxwpCTIOcx.__CTISrv_inTrunkAllocatedEvent e)
        {
            MessageBox.Show("入中继分配" + Environment.NewLine + 
                            "iD:           :"+ e.iD+Environment.NewLine +
                            "userTYpe      :"+e.userType+Environment.NewLine+
                            "IOFlag        :"+e.iOFlag+Environment.NewLine+
                            "assID         :"+e.assID+Environment.NewLine+
                            "assUserType   :"+e.assUserType+Environment.NewLine+
                            "assPhone      :"+e.assPhone+Environment.NewLine+
                            "assUserName   :"+e.assUserName);
//            ID：被分配的中继线路号
//userType：中继用户类型，见附录。
//IOFlag：呼入呼出标志 0-外线呼入 1-内线呼出
//assID:相关用户
//assUserType:相关用户的用户类型
//assPhone:相关用户的号码
//assUserName:相关用户名称

        }

        // 出中继分配
        private void axCTISrv_outTrunkAllocated(object sender, AxwpCTIOcx.__CTISrv_outTrunkAllocatedEvent e)
        {
            MessageBox.Show("出中继分配"+Environment.NewLine+
                "iD:           :" + e.iD + Environment.NewLine +
                "userTYpe      :" + e.userType + Environment.NewLine +
                "IOFlag        :" + e.iOFlag + Environment.NewLine +
                "assID         :" + e.assID + Environment.NewLine +
                "assUserType   :" + e.assUserType + Environment.NewLine +
                "assPhone      :" + e.assPhone + Environment.NewLine +
                "assUserName   :" + e.assUserName);
        }
        #endregion

        // 关闭主窗口
        private void FMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (AnswerHelper.RefreshTelStateThread != null && AnswerHelper.RefreshTelStateThread.IsAlive)
            {
                AnswerHelper.RefreshTelStateThread.Abort();
            }
        }

        // 出中继呼叫
        private void axCTISrv_outTrunkCall(object sender, AxwpCTIOcx.__CTISrv_outTrunkCallEvent e)
        {
            MessageBox.Show("出中继呼叫" + Environment.NewLine +
               "iD:           :" + e.iD + Environment.NewLine +
               "userTYpe      :" + e.userType + Environment.NewLine +
               "IOFlag        :" + e.iOFlag + Environment.NewLine +
               "assID         :" + e.assID + Environment.NewLine +
               "assUserType   :" + e.assUserType + Environment.NewLine +
               "assPhone      :" + e.assPhone + Environment.NewLine +
               "assUserName   :" + e.assUserName);
        }


    }
}
