using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace FormUI.Tool
{
    public class EnumHelper
    {
        public enum FunctionEnum
        {

            [Description("呼入")]
            Answer=0,

            [Description("呼出")]
            Call=1,

            [Description("客户")]
            Customer=2,

            [Description("查询")]
            Search=3,

            [Description("知识库")]
            KnowledgeBase=4,

            [Description("导入")]
            Import=5,

            [Description("员工")]
            Employee=6,

            [Description("部门")]
            Department = 7,

            [Description("职位")]
            Position=8,

            [Description("功能")]
            Function =9,

            [Description("操作")]
            Operation=10,

            [Description("特殊(班长)")]
            Special =11
        }

        public enum OperationEnum
        {
            [Description("查看")]
            LookUp = 0,

            [Description("新增")]
            Add = 1,

            [Description("更新")]
            Update=2,

            [Description("删除")]
            Delete=3,

            [Description("导入")]
            Import=4


        }

        public enum LineStateEnum
        {
            [Description("维护忙")]
            TIS_OUTOFSERVICE = 0,

            [Description("空闲")]
            TIS_IDLE = 1,

            [Description("被叫振铃")]
            TIS_CALLEDRING = 2,

            [Description("回叫振铃")]
            TIS_BACKRING = 3,

            [Description("拨号")]
            TIS_DIAL = 4,

            [Description("回铃")]
            TIS_ONCALL = 5,

            [Description("催挂")]
            TIS_HURRY_HANGUP = 6,

            [Description("通话")]
            TIS_CONNECT = 7,

            [Description("等待")]
            TIS_WAIT = 8,

            [Description("同步,用于冗余控制")]
            TIS_SYNC = 9,

            [Description("准备好")]
            TIS_READY = 10,

            [Description("释放中状态")]
            TIS_FREEING = 11,

            [Description("线路故障")]
            TIS_LINE_ERROR = 12,

            [Description("入中继分配")]
            TIS_ALLOCATED_IN = 13,

            [Description("出中继分配")]
            TIS_ALLOCATED_OUT = 14,

            [Description("呼叫")]
            TIS_SEND_DIAL_OUT = 15,

            [Description("发号准备阶段")]
            TIS_TRUNK_DIALPRE = 16,

            [Description("DTMF来电显示阶")]
            TIS_TRUNK_RECV_DTMF = 17
        }


        public enum SelfContextMenuEnum
        {
            [Description("置忙")]
            Busy = 0,

            [Description("置闲")]
            Idle = 1,

            [Description("通话详细")]
            Details = 2,

            [Description("注销")]
            Logout = 3,
        }

        public enum OtherContextMenuEnum
        {
            [Description("代接")]
            InsteadAnswer = 0,

            [Description("呼叫转移")]
            Transfer = 1,

            [Description("监听")]
            Monitor = 2,

            [Description("强插")]
            ForceInsert = 3,

            [Description("强拆")]
            BreakLine = 4
        }

        public static string GetDescript(Enum penum)
        {

            System.Type enumType = penum.GetType();

            string name = penum.ToString();

            if (name != null)
            {
                System.Reflection.FieldInfo _fieldInfo = enumType.GetField(name);
                if (_fieldInfo != null)
                {
                    System.ComponentModel.DescriptionAttribute _attr = Attribute.GetCustomAttribute(_fieldInfo, typeof(System.ComponentModel.DescriptionAttribute),
                        false) as System.ComponentModel.DescriptionAttribute;
                    if (_attr != null)
                    {
                        return _attr.Description;
                    }
                }
            }
            return null;
        }

        public static string GetDescription<T>(int enumObj)
        {
            var enumType = typeof(T);

            Type typeDescription = typeof(DescriptionAttribute);

            System.Reflection.FieldInfo[] fields = enumType.GetFields();

            foreach (var field in fields)
            {

                if (field.FieldType.IsEnum == false)
                    continue;

                var value = (int)enumType.InvokeMember(field.Name, System.Reflection.BindingFlags.GetField, null, null, null);

                if (value == enumObj)
                {
                    object[] arr = field.GetCustomAttributes(typeDescription, true);
                    if (arr.Length > 0)
                    {
                        DescriptionAttribute aa = (DescriptionAttribute)arr[0];
                        return aa.Description;
                    }
                    else
                    {
                        return field.Name;
                    }
                }
            }
            return enumObj.ToString();
        }
    }
}
